using System.Data;
using System.Data.SqlClient;

namespace MovieLibrary.Sql;

public class SqlMovieDatabase : MovieDatabase
{
    public SqlMovieDatabase (string connectionString)
    {
        _connectionString = connectionString;
    }
    protected override Movie AddCore ( Movie movie )
    {
        using var conn = OpenConnection ();

        //Approach 1- Preferred
        var cmd = new SqlCommand ("AddMovie", conn) { CommandType = CommandType.StoredProcedure };
        //cmd = conn.CreateCommand(); //Aproach 2
        //cmd.CommandText = "AddMovie";

        //Avoid SQL Injections, Use Paramaters
        //var parmName = cmd.Parameters.Add("@name", SqlDbType.NVarChar); //Approach 1
        //parmName.Value = movie.Title;

        cmd.Parameters.AddWithValue("@name", movie.Title); //Approach 2 (SQL Only)
        cmd.Parameters.AddWithValue("@rating", movie.Rating?.Name);
        cmd.Parameters.AddWithValue("@description", movie.Description);
        cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
        cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
        cmd.Parameters.AddWithValue("@isClassic", movie.IsBlackAndWhite);

       /* cmd.Parameters.Add(new SqlParameter("@name", movie.Title));*/ //Approach 3 as a desperate option
        movie.Id = Convert.ToInt32(cmd.ExecuteScalar());
        return movie;
    }
    protected override void DeleteCore ( int id )
    {
        using var conn = OpenConnection();

        var cmd = new SqlCommand("DeleteMovie", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }
    protected override Movie FindById ( int id ) => GetCore ( id );
    protected override Movie FindByTitle ( string title )
    {
        using var conn = OpenConnection();

        var cmd = new SqlCommand("FindByName", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@name", title) ;
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            return new Movie() {
                //Id = reader.GetInt32(0), //Approach 1
                Id = reader.GetInt32("Id"), //Apporach 2 (Preffered)
                Title = reader.GetString(1),
                Description = reader.IsDBNull("Description")? "" : reader.GetFieldValue<string>("Description"),
                Rating = new Rating(reader.GetString("Rating")),
                RunLength = reader.GetInt32("RunLength"),
                ReleaseYear = reader.GetInt32("ReleaseYear"),
                IsBlackAndWhite = reader.GetBoolean("IsClassic"),
            };

        };
        return null;
    }
    protected override IEnumerable<Movie> GetAllCore ()
    {
        //Open Connection, Do Work, Then Close Connection
        var conn = OpenConnection();

        //Buffered IO
        var ds = new DataSet();
        var da = new SqlDataAdapter() {
            SelectCommand = new SqlCommand("GetMovies", conn) { CommandType = CommandType.StoredProcedure }
        };

        da.Fill(ds);

        //Enumerate dataset
        var movies = new List<Movie>();

        var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
        if ( table != null )
        {
            foreach (var row in table.Rows.OfType<DataRow>())
            {
                movies.Add(new Movie() {
                    //Id = Convert.ToInt32(row[0]), approach 1
                    Id = Convert.ToInt32(row["Id"]), //Approach 2
                    Title = row.Field<string>(1),    //Approach 3
                    Description = row.IsNull("Description") ? "" : row.Field<string>("Description"), //Approach 4(Preferred)
                    Rating = new Rating(row.Field<string>("Rating")),
                    RunLength = row.Field<int>("RunLength"),
                    ReleaseYear = row.Field<int>("ReleaseYear"),
                    IsBlackAndWhite = row.Field<bool>("IsClassic")
                    //IsBlackAndWhite = row.Field<int>("IsClassic") != 0,
                    //Genre =
                }) ;
            }
        }

        return movies;
    }
    protected override Movie GetCore ( int id )
    {
       using var conn = OpenConnection();

       var cmd = new SqlCommand("GetMovie", conn) { CommandType = CommandType.StoredProcedure };
       cmd.Parameters.AddWithValue("@id", id);
       var reader =  cmd.ExecuteReader();
        while (reader.Read())
        {
            return new Movie() {
                //Id = reader.GetInt32(0), //Approach 1
                Id = reader.GetInt32("Id"), //Apporach 2 (Preffered)
                Title = reader.GetString(1),
                Description = reader.IsDBNull("Description")? "" :reader.GetFieldValue<string>("Description"),
                Rating = new Rating(reader.GetString("Rating")),
                RunLength = reader.GetInt32("RunLength"),
                ReleaseYear = reader.GetInt32("ReleaseYear"),
                IsBlackAndWhite = reader.GetBoolean("IsClassic"),
            };

        };
        return null;
    }
    protected override void UpdateCore ( int id, Movie movie )
    {
        using var conn = OpenConnection();

        var cmd = new SqlCommand("UpdateMovie", conn) { CommandType = CommandType.StoredProcedure };

        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", movie.Title); 
        cmd.Parameters.AddWithValue("@rating", movie.Rating?.Name);
        cmd.Parameters.AddWithValue("@description", movie.Description);
        cmd.Parameters.AddWithValue("@releaseYear", movie.ReleaseYear);
        cmd.Parameters.AddWithValue("@runLength", movie.RunLength);
        cmd.Parameters.AddWithValue("@isClassic", movie.IsBlackAndWhite);
        //Execute No Results
        cmd.ExecuteNonQuery();
    }

    private SqlConnection OpenConnection()
    {
        var conn = new SqlConnection(_connectionString);
        conn.Open();

        return conn;
    }
    private readonly string _connectionString;
}
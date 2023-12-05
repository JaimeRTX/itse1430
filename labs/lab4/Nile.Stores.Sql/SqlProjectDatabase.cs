using System.Data;
using System.Data.SqlClient;

namespace Nile.Stores.Sql;

public class SqlProjectDatabase : ProductDatabase
{
    public SqlProjectDatabase (string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override Product GetCore ( int id )
    {
        using var conn = OpenConnection();

        var cmd = new SqlCommand("GetProduct", conn) { CommandType = CommandType.StoredProcedure};
        cmd.Parameters.AddWithValue("@id", id);
        var reader = cmd.ExecuteReader();
        while ( reader.Read())
        {
            return new Product() 
            {
                Id = reader.GetInt32("Id"),
                Name = reader.GetString("Name"),
                Price = reader.GetDecimal("Price"),
                Description = reader.GetString("Description"),
                IsDiscontinued = reader.GetBoolean("IsDiscontinued")
            };
        };
        return null;
    }
    protected override IEnumerable<Product> GetAllCore ()
    {
        var conn = OpenConnection();

        var ds = new DataSet();
        var da = new SqlDataAdapter() {
            SelectCommand = new SqlCommand("GetAllProduct", conn) { CommandType = CommandType.StoredProcedure }
        };
        
        da.Fill(ds);

        var product = new List<Product>();
        var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
        if (table != null) 
        {
            foreach (var row in table.Rows.OfType<DataRow>())
            {
                product.Add(new Product() {
                    Id = row.Field<int>("Id"),
                    Name = row.Field<string>("Name"),
                    Price = row.Field<decimal>("Price"),
                    Description = row.IsNull("Description") ? "" : row.Field<string>("Description"),
                    IsDiscontinued = row.Field<bool>("IsDiscontinued")
                }) ;
            }
        }
        return product;
    }
    protected override void RemoveCore ( int id )
    {
        using var conn = OpenConnection();

        var cmd = new SqlCommand("DeleteProduct", conn) { CommandType = CommandType.StoredProcedure };
        cmd.Parameters.AddWithValue("@id", id);

        cmd.ExecuteNonQuery();
    }
    protected override void UpdateCore ( Product existing, Product newItem )
    {
        using var conn = OpenConnection();

        var cmd = new SqlCommand("Update Product");

        //cmd.Parameters.AddWithValue("@Id", id);
    }
    protected override Product AddCore ( Product product ) => throw new NotImplementedException();
    protected override Product FindByName ( string name ) => throw new NotImplementedException();
    protected override Product FindById ( int id ) => throw new NotImplementedException();

    private SqlConnection OpenConnection ()
    {
        var conn = new SqlConnection(_connectionString);
        conn.Open();

        return conn;
    }

    private readonly string _connectionString;
}
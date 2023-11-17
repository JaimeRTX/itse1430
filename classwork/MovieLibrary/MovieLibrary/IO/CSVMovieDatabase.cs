
namespace MovieLibrary.IO;

public class CSVMovieDatabase : MovieDatabase
{
    public CSVMovieDatabase (string filename)
    {
        _filename = filename;
    }
    protected override Movie AddCore ( Movie movie )
    {
        IEnumerable<Movie> movies = LoadMovies ();

        //Get Highest Id
        var id = movies.Any() ? movies.Max(x => x.Id) : 0;
        movie.Id = ++id;

        //Save New Movie
        File.AppendAllLines(_filename, new[] { WriteMovie(movie) });
        return movie;
    }
    protected override void DeleteCore ( int id )
    {
        var movies = LoadMovies().ToList();

        movies.RemoveAll(x => x.Id == id);

        SaveMovies(movies);
    }
    protected override Movie FindById ( int id )
    {
        return LoadMovies().FirstOrDefault(x => x.Id == id);
    }
    protected override Movie FindByTitle ( string title )
    {
        var movies = LoadMovies();

        return movies.FirstOrDefault(x => String.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));
    }
    protected override IEnumerable<Movie> GetAllCore ()
    {
        return LoadMovies();
    }
    protected override Movie GetCore ( int id ) => FindById (id);
    protected override void UpdateCore ( int id, Movie movie )
    {
        var movies = LoadMovies().ToList();

        var existing = movies.FirstOrDefault(x => x.Id == id);
        if (existing == null)
        {
            throw new InvalidOperationException("Movie Not Found");
        }
        //Update
        existing.Title = movie.Title;
        existing.Description = movie.Description;
        existing.Genre = movie.Genre;
        existing.Rating = movie.Rating;
        existing.RunLength = movie.RunLength;
        existing.ReleaseYear = movie.ReleaseYear;
        existing.IsBlackAndWhite = movie.IsBlackAndWhite;

        //Save
        SaveMovies(movies);
    }

    //Preferred
    //private IEnumerable<Movie> LoadMovies ()
    //{
    //    if (File.Exists(_filename))
    //    {


    //        //string[] lines = File.ReadAllLines(_filename);
    //        //string text = File.ReadAllText(_filename);
    //        //Prefered Approach
    //        foreach (var line in File.ReadLines(_filename))
    //        {
    //            //TODO: Parse Line
    //            var movie = ReadMovie(line);
    //            if((movie?.Id ?? 0) > 0)
    //            {
    //                yield return movie;
    //            }
    //        };
    //    };

    //}

    //Lower Level
    private IEnumerable<Movie> LoadMovies ()
    {
        if (File.Exists(_filename))
        {

            //Preffered Approach -using statement 
            //using (var id = someresource {s*}
            using Stream stream = File.OpenRead(_filename);
            using StreamReader reader = null;
            //var reader = new StreamReader(stream);

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var movie = ReadMovie(line);
                if ((movie?.Id ?? 0) > 0)
                {
                    yield return movie;
                }
            }
        }
    }

    private Movie ReadMovie (string line)
    {
        if(String.IsNullOrEmpty(line))
        {
            return null;
        }
        string [] tokens = line.Split(',');
        if(tokens.Length != 8)
        {
            return null;
        }

        return new Movie() {
            Id = ToInt32(tokens[0]),
            Title = Deqoute(tokens[1]),
            RunLength = ToInt32(tokens[2]),
            ReleaseYear = ToInt32(tokens[3]),
            Genre = Deqoute(tokens[4]),
            Rating = new Rating(Deqoute(tokens[5])),
            IsBlackAndWhite = ToInt32(tokens[6]) > 0,
            Description =Deqoute(tokens[7])
        };

    }

    private string WriteMovie (Movie movie )
    {
        var fields = new[]
        {
            movie.Id.ToString(),
            Enqoute(movie.Title),
            movie.RunLength.ToString(),
            movie.ReleaseYear.ToString(),
            Enqoute(movie.Genre),
            Enqoute(movie.Rating.Name),
            movie.IsBlackAndWhite ? "1" : "0",
            Enqoute(movie.Description)
        };
        return String.Join(",", fields);
    }
    private static int ToInt32 (string value) => Int32.TryParse(value, out var result) ? result : 0;

    private static string Enqoute ( string value ) => "\"" + value + "\"";
    private static string Deqoute ( string value ) => value.Trim('"');
    private void SaveMovies (IEnumerable<Movie> movies)
    {
        var contents = movies.Select(x => WriteMovie(x));
        File.WriteAllLines(_filename, contents);
    }
    private readonly string _filename;
}

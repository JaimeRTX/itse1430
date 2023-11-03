namespace MovieLibrary.Memory;

/// <summary>
/// Represents a Database of Movies
/// </summary>

public class MemoryMovieDatabase : MovieDatabase
{

    protected override Movie AddCore ( Movie movie )
    {
       
        movie.Id = _id++;
        _movies.Add(Clone(movie));
        return movie;
    }

    protected override void UpdateCore ( int id, Movie movie )
    {
       var  existing = FindById(id);
        Copy(existing, movie);
    }

    protected override void DeleteCore ( int id )
    {
        var movie = FindById(id);
        if (movie != null)
            _movies.Remove(movie);
    }

    public void Delete ( int id )
    {
        //TODO: Id > 0
        //var index = FindById(id);
        //if (index >= 0)
        //{
        //    _movies[index] = null;
        //}
        var movie = FindById(id);
        if (movie != null)
        {
            _movies.Remove(movie); //Reference Equality
        }

    }



    protected override Movie GetCore ( int id )
    {
        var movie = FindById(id);
        if(movie == null)
        {
            return null;
        }
        return Clone(movie);
    }

    protected override IEnumerable<Movie> GetAllCore ()
    {
        //var count = _movies.Count;
        ////How Many Are Not Null
        ////var count = 0;
        ////for (var index = 0; index < _movies.Length; ++index)
        ////{
        ////    if (_movies[index] != null)
        ////    {
        ////        ++count;
        ////    }

        ////}
        ////Clone Array
        //var items = new Movie[_movies.Count];
        //var itemIndex = 0;
        //foreach (var movie in _movies)
        //    items[itemIndex++] = movie;
        ////for (var index = 0; index < _movies.Length; ++index)
        ////{
        ////    if (_movies[index] != null)
        ////    {
        ////        items[itemIndex++] = Clone(_movies[index]);
        ////    }
        ////}

        //If Return Type is IEnumerable<T> then you say Iterator to implement
        //var items = new List<Movie>();
        //foreach (var movie in _movies)
        //{
        //    items.Add(Clone(movie));
        //}
        //return _movies;

        foreach (var movie in _movies)
        {
            //Yield Only Allowed in an Iterator
            yield return Clone(movie);
        }

    }

    //private readonly Movie[] _movies = new Movie[100];
    //List<T> generic type, resizeablea array of T
    private readonly List<Movie> _movies = new List<Movie>();
    private int _id = 1;


    private Movie Clone ( Movie movie )
    {
        var item = new Movie();
        item.Id = movie.Id;
        Copy(item, movie);

        return item;
    }

    private void Copy ( Movie target, Movie source )
    {
        //Don't Copy ID
        target.Title = source.Title;
        target.Description = source.Description;
        target.Rating = source.Rating;
        target.ReleaseYear = source.ReleaseYear;
        target.RunLength = source.RunLength;
        target.IsBlackAndWhite = source.IsBlackAndWhite;
        target.Genre = source.Genre;
    }

    protected override Movie FindByTitle ( string title )
    {
        //for (var index = 0; index < _movies.Length; ++index)
        //{
        //    if (String.Equals(title, _movies[index]?.Title, StringComparison.OrdinalIgnoreCase))
        //    {
        //        return _movies[index];
        //    }
        //}
        foreach (var movie in _movies)
            if (String.Equals(title, movie.Title, StringComparison.OrdinalIgnoreCase))
            {
                return movie;
            }
        return null;
    }

    protected override Movie FindById ( int id )
    {
        //for (var index = 0; index < _movies.Length; ++index)
        //{
        //    if (_movies[index]?.Id == id)
        //    {
        //        return index;
        //    }
        //}
        foreach (var movie in _movies)
            if (movie.Id == id)
            {
                return movie;
            }
        return null;
    }
}

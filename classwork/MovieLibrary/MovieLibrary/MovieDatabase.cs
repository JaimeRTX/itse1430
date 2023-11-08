namespace MovieLibrary;

/// <summary>
/// Represents a Database of Movies
/// </summary>

public abstract class MovieDatabase : IMovieDatabase
{


    public virtual string Add ( Movie movie )
    {
        //Validate: null, invalid movie
        if (movie == null)
        {
            return "Movie is null";
        }
        if (!ObjectValidator.TryValidate(movie, out var error))
        {
            return error.First().ErrorMessage;
        }

        //Title Must be Unique 
        var existing = FindByTitle(movie.Title);
        if (existing != null)
        {
            return "Movie title must be Unique";
        }

        //Find an Empty Slot
        //for (var index = 0; index < _movies.Length; ++index)
        //{
        //    if (_movies[index] == null)
        //    {
        //        movie.Id = _id++;
        //        _movies[index] = Clone(movie);
        //        return "";
        //    }
        //}

        //Hack This is a Hack For Now
        var newMovie = AddCore(movie);
        movie.Id = newMovie.Id;
        return "";
    }

    protected abstract Movie AddCore ( Movie movie );

    public virtual string Update ( int id, Movie movie )
    {

        if (id <= 0)
        {
            return "ID is Invalid";
        }

        if (movie == null)
        {
            return "Movie is null";
        }

        if (!ObjectValidator.TryValidate(movie, out var error))
        {
            return error.First().ErrorMessage;
        }

        //Title must be unique and not self
        var existing = FindByTitle(movie.Title);
        if (existing != null && existing.Id != id)
        {
            return "Movie title must be Unique";
        }

        //Movie must exist
        existing = FindById(id);
        if (existing == null)
        {
            return "Movie Not Found";
        }

        UpdateCore(id, movie);
        //Update
        return "";
    }

    protected abstract void UpdateCore(int id, Movie movie);

    public virtual void Delete ( int id )
    {
        //TODO: Id > 0
        //var index = FindById(id);
        //if (index >= 0)
        //{
        //    _movies[index] = null;
        //}
        DeleteCore(id);

    }

    protected abstract void DeleteCore ( int id );

    //public virtual IEnumerable<Movie> GetAll ()
    //{
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

    //foreach (var movie in _movies)
    //{
    //    //Yield Only Allowed in an Iterator
    //    yield return Clone(movie);
    //}

    //    return GetAllCore() ?? Enumerable.Empty<Movie>();

    //}

    //Expression Body ::= member who uses lambda syntax
    public virtual IEnumerable<Movie> GetAll () => GetAllCore() ?? Enumerable.Empty<Movie>();

    protected abstract IEnumerable<Movie> GetAllCore ();

    //private readonly Movie[] _movies = new Movie[100];
    //List<T> generic type, resizeablea array of T



    protected abstract Movie FindByTitle ( string title );

    protected abstract Movie FindById ( int id );

    public virtual Movie Get ( int id )
    {
        if (id <= 0)
        {
            return null;
        }
        return GetCore(id);
    }
    protected abstract Movie GetCore(int id);
}

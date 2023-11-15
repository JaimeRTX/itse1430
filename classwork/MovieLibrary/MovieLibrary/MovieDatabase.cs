namespace MovieLibrary;

/// <summary>
/// Represents a Database of Movies
/// </summary>

public abstract class MovieDatabase : IMovieDatabase
{


    public virtual Movie Add ( Movie movie )
    {
        

        //Validate: null, invalid movie
        if (movie == null)
        {
            throw new ArgumentNullException(nameof(movie));
        }
        ObjectValidator.Validate(movie);

        //Title Must be Unique 
        var existing = FindByTitle(movie.Title);
        if (existing != null)
        {
            throw new InvalidOperationException("Movie title must be Unique");
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
        try
        {
            return AddCore(movie);
        }
        catch(Exception ex)
        {
            throw new InvalidCastException("Add Failed", ex);
        }
        //return AddCore(movie);
    }

    protected abstract Movie AddCore ( Movie movie );

    public virtual void Update ( int id, Movie movie )
    {

        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID Must Be Greater Than 0");
        }

        if (movie == null)
        {
            throw new ArgumentNullException(nameof(movie));
        }

        ObjectValidator.Validate(movie);

        //Title must be unique and not self
        var existing = FindByTitle(movie.Title);
        if (existing != null && existing.Id != id)
        {
            throw new InvalidOperationException("Movie title must be Unique");
        }
        //Movie must exist
        existing = FindById(id);
        if (existing == null)
        {
            throw new ArgumentException("Movie Not Found", nameof(id));
        }
        try
        {
            UpdateCore(id, movie);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Add Failed", ex);
        }
        //UpdateCore(id, movie);
        //Update;
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

        if( id <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(id), "ID Must Be Greater Than 0");
        }
         try
        {
            DeleteCore(id);
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Add Failed", ex);
        }
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
            throw new ArgumentOutOfRangeException(nameof(id), "ID Must Be Greater Than 0");
        }
        return GetCore(id);
    }
    protected abstract Movie GetCore(int id);
}

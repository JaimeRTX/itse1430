﻿namespace MovieLibrary.Memory;

/// <summary>
/// Represents a Database of Movies
/// </summary>

public class MemoryMovieDatabase
{

    public MemoryMovieDatabase ()
    {
        //Object Initializer - replace need for creating an object (expression) and then assigning values to properties (statements)
        //object-initializer ::= new T() {property-assignment+}
        //Property-assignment ::=id =Et;
        //var movie = new Movie();
        //movie.Id = _id++;
        //movie.Title = "Jaws";
        //movie.ReleaseYear = 1990;
        //movie.Rating = Rating.R;
        //movie.RunLength = 120;
        //_movies[0] = movie;


        //_movies[0]= new Movie() {
        //    Id = _id++,
        //    Title = "Jaws",
        //    ReleaseYear = 1990,
        //    Rating = Rating.R,
        //    RunLength = 120,
        //};

        //Collection Initilizaer syntax
        //Set Up Movies
        var movies = new[] {
            new Movie() {
                Title = "Jaws",
                ReleaseYear = 1990,
                Rating = Rating.R,
                RunLength = 120,
            },

            new Movie() {
                Title = "Jaws 2",
                ReleaseYear = 1992,
                Rating = Rating.R,
                RunLength = 135,
            },


            new Movie() {
                Title = "Jaws 3",
                ReleaseYear = 1997,
                Rating = Rating.R,
                RunLength = 120,
            },

        };


        //Enumeration-use foreach
        //foreach- statement ::=foreach (T id in array) S;
        //1. Loop Varient is Readonly
        //2. array must be immutable while enumarating
        //for(int index = 0; index < movies.Length; index++)
        foreach (var movie in movies)
        {
            Add(movie);
        }

    }

    public string Add ( Movie movie )
    {
        //Validate: null, invalid movie
        if (movie == null)
        {
            return "Movie is null";
        }
        if (!movie.TryValidate(out var error))
        {
            return error;
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
        movie.Id = _id++;
        _movies.Add(Clone(movie));
        return "";
    }

    public string Update (int id, Movie movie )
    {

        if(id <= 0)
        {
            return "ID is Invalid";
        }

        if (movie == null)
        {
            return "Movie is null";
        }

        if (!movie.TryValidate(out var error))
        {
            return error;
        }
        
        //Title must be unique and not self
        var existing = FindByTitle(movie.Title);
        if (existing != null && existing.Id != id)
        {
            return "Movie title must be Unique";
        }

        //Movie must exist
        existing = FindById(id);
        if(existing == null)
        {
            return "Movie Not Found";
        }

        //Update
        Copy(existing, movie);
        return "";
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
        if(movie != null)
        {
            _movies.Remove(movie); //Reference Equality
        }

    }

    public Movie[] GetAll ()
    {
        var count = _movies.Count;
        //How Many Are Not Null
        //var count = 0;
        //for (var index = 0; index < _movies.Length; ++index)
        //{
        //    if (_movies[index] != null)
        //    {
        //        ++count;
        //    }

        //}



        //Clone Array
        var items = new Movie[_movies.Count];
        var itemIndex = 0;
        foreach (var movie in _movies)
            items[itemIndex++] = movie;
        //for (var index = 0; index < _movies.Length; ++index)
        //{
        //    if (_movies[index] != null)
        //    {
        //        items[itemIndex++] = Clone(_movies[index]);
        //    }
        //}

        return items;
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

    private void Copy(Movie target, Movie source)
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

    private Movie FindByTitle ( string title )
    {
        //for (var index = 0; index < _movies.Length; ++index)
        //{
        //    if (String.Equals(title, _movies[index]?.Title, StringComparison.OrdinalIgnoreCase))
        //    {
        //        return _movies[index];
        //    }
        //}
        foreach(var movie in _movies)
            if(String.Equals(title, movie.Title, StringComparison.OrdinalIgnoreCase))
            {
                return movie;
            }
        return null;
    }

    private Movie FindById ( int id )
    {
        //for (var index = 0; index < _movies.Length; ++index)
        //{
        //    if (_movies[index]?.Id == id)
        //    {
        //        return index;
        //    }
        //}
        foreach(var movie in _movies)
            if(movie.Id == id)
            {
                return movie;
            }
        return null;
    }
}
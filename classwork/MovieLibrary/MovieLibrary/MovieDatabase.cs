﻿
namespace MovieLibrary;

/// <summary>
/// Represents a Database of Movies
/// </summary>

public class MovieDatabase
{

    public MovieDatabase ()
    {
        //Object Initializer
        //var movie = new Movie();
        //movie.Id = _id++;
        //movie.Title = "Jaws";
        //movie.ReleaseYear = 1990;
        //movie.Rating = Rating.R;
        //movie.RunLength = 120;
        //_movies[0] = movie;


        _movies[0]= new Movie() {
            Id = _id++,
            Title = "Jaws",
            ReleaseYear = 1990,
            Rating = Rating.R,
            RunLength = 120,
        };

        movie = new Movie();
        movie.Id = _id++;
        movie.Title = "Jaws 2";
        movie.ReleaseYear = 1993;
        movie.Rating = Rating.R;
        movie.RunLength = 135;
        _movies[1] = movie;

        movie = new Movie();
        movie.Id = _id++;
        movie.Title = "Jaws 3";
        movie.ReleaseYear = 1997;
        movie.Rating = Rating.R;
        movie.RunLength = 120;
        _movies[2] = movie;

        movie = new Movie();
        movie.Id = _id++;
        movie.Title = "Jaws 4: New Bites";
        movie.ReleaseYear = 1999;
        movie.Rating = Rating.R;
        movie.RunLength = 200;
        _movies[3] = movie;
    }

    public string Add ( Movie movie )
    {
        //Validate: null, invalid movie
        if ( movie == null )
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
        for (var index = 0; index < _movies.Length; ++index)
        {
            if (_movies[index] == null)
            {
                movie.Id = _id++;
                _movies[index] = Clone(movie);
                return "";
            }
        }
        return "Array is Full";
    }

    public void Update ( Movie movie )
    {

    }

    public void Delete ( int id )
    {
        //TODO: Id > 0
        var index = FindById(id);
        if (index >= 0)
        {
            _movies[index] = null;
        }

    }

    public Movie[] GetAll ()
    {
        //How Many Are Not Null
        var count = 0;
        for (var index = 0; index < _movies.Length; ++index)
        {
            if (_movies[index] != null)
            {
                ++count;
            }

        }

        //Clone Array
        var items = new Movie[count];
        var itemIndex = 0;
        for (var index = 0; index < _movies.Length; ++index)
        {
            if (_movies[index] != null)
            {
                items[itemIndex++] = Clone(_movies[index]);
            }
        }

            return items;
    }

    private readonly Movie[] _movies = new Movie[100];
    private int _id = 1;


    private Movie Clone (Movie movie)
    {
        var item = new Movie();
        item.Id = movie.Id;
        item.Title = movie.Title;
        item.Description = movie.Description;
        item.Rating = movie.Rating;
        item.ReleaseYear = movie.ReleaseYear;
        item.RunLength = movie.RunLength;
        item.IsBlackAndWhite = movie.IsBlackAndWhite;
        item.Genre = movie.Genre;

        return item;
    }

    private Movie FindByTitle (string title)
    {
        for (var index = 0; index < _movies.Length; ++index)
        {
            if (String.Equals(title, _movies[index]?.Title, StringComparison.OrdinalIgnoreCase))
            {
                return _movies[index];
            }
        }
        return null;
    }

    private int FindById(int id)
    {
        for (var index = 0; index < _movies.Length; ++index)
        {
            if (_movies[index]?.Id == id)
            {
                return index;
            }
        }
        return -1;
    }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary;

public static class DatabaseSeeder
{
    public static void Seed (this IMovieDatabase database)
    {
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
            database.Add(movie);
        }

    }

}

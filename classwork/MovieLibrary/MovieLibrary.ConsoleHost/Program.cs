
//TODO: Remove This
using MovieLibrary;

namespace MovieLibrary.ConsoleHost;

partial class Program
{

    static void Main ()
    {

        var app = new Program();
        app.Run ();

    }

    void Run ()
    {

    

        Movie movie = new Movie();

        //Entry Point
        var done = false;
        do
        {
            //int command = ViewMovie();
            //if (command == 1)
            //    AddMovie();
            //else if (command == 2)
            //    EditMovie();
            //else if (command == 3)
            //    DeleteMovie();
            //else if (command == 4)
            //    DisplayMovie();
            //else if (command == 0)
            //    done = true;
            switch (DisplayMenu())
            {
                case MenuCommand.Add: movie = AddMovie(); break;
                case MenuCommand.Edit: EditMovie(); break;
                case MenuCommand.Delete:
                {
                    //TODO: Clean This Up
                    if (DeleteMovie(movie))
                        movie = new Movie();
                    break;
                }

                case MenuCommand.View: ViewMovie(movie); break;
                case MenuCommand.Quit:
                {
                    done = true;
                    //Do More Stuff Here
                    break;
                }

                default: Console.WriteLine("Unknown Option"); break;
            }


        } while (!done);

    }


    //Get Movie Details and Display
    //Functions


    MenuCommand DisplayMenu ()
    {

        Console.WriteLine("----------------");
        Console.WriteLine("(A)dd Movie");
        Console.WriteLine("(E)dit Movie");
        Console.WriteLine("(D)elete Movie");
        Console.WriteLine("(V)iew Movie");
        Console.WriteLine("(Q)uit");

        do
        {

            switch (Console.ReadKey(true).Key)
            {
                //case "A": //return 1;
                // case "a": return 1;
                case ConsoleKey.A: return MenuCommand.Add;

                //case "E": //return 2;
                //case "e": return 2;
                case ConsoleKey.E: return MenuCommand.Edit;

                // case "D": //return 3;
                // case "d": return 3;
                case ConsoleKey.D: return MenuCommand.Delete;

                // case "V": //return 4;
                // case "v": return 4;
                case ConsoleKey.V: return MenuCommand.View;

                // case "Q": //return 0;
                // case "q": return 0;
                case ConsoleKey.Q: return MenuCommand.Quit;
            };
        } while (true);
    }

    Movie AddMovie ()
    {
        var movie = new Movie();
        do
        {

            movie.Title = ReadString("Enter A Title:", true);

            movie.Description = ReadString("Enter A Description:", false);

            movie.RunLength = ReadInt("Enter The Run Lenth in Minutes", 0);
            if (movie.NeedsIntermission)
                Console.WriteLine("Needs Intermission");

            movie.ReleaseYear = ReadInt("Enter The Date of the Release Year", Movie.MininumReleaseYear);

            movie.Genre = ReadString("Enter a Genre: ", false);
            movie.Rating = ReadRating("Enter a Rating: ");
            //if (movie.Rating != null)
            //    movie.Rating.Name = "Whatever";

            movie.IsBlackAndWhite = ReadBoolean("Is the Movie in Black and White? (Y/N)");

            //Validate
            var error = movie.Validate();
            if (String.IsNullOrEmpty(error))
                return movie;

            Console.WriteLine($"ERROR: {error}");
        } while (true);
    }

    bool DeleteMovie ( Movie movie )
    {

        if (String.IsNullOrEmpty(movie.Title))

            return false;

        if (!Confirm($"Are you Sure you Would Like to Delete this Movie '{movie.Title}' (Y/N)"))
            return false;

        //TODO: Delete Movie
        //title= "";
        return true;
    }
    void EditMovie ()
    {
        Console.WriteLine("Not Implimented Yet");
    }

    void ViewMovie ( Movie movie )
    {
        //Lenght of a String


        if (String.IsNullOrEmpty(movie.Title))
        {
            Console.WriteLine("No Movies Availible");
            return;
        };

        /*movie.DownloadMetadata()*/
        ;

        Console.WriteLine();
        // Console.WriteLine("-------------");
        Console.WriteLine("".PadLeft(15, '-'));
        // Console.WriteLine("\n-------------");
        Console.WriteLine(movie.Title);

        //String Formating
        //Run Length: # Minutes
        //Console.WriteLine("Run Length: " + length + " Minutes");
        //1. Concat
        // Console.WriteLine("Run Length: " + length.ToString() + " Minutes");
        //var message = String.Concat("Run Lenght: ", length.ToString(), " mins");
        //Console.WriteLine(message);
        //var message2 = String.Join(" ", "Run Length:", length, "mins");
        //2. String.Format
        //string message = String.Format("Run Lenght: {0:000} mins", length);
        //Console.WriteLine(message);
        //Console.WriteLine("Run Lenght: {0} mins", length);
        //3. String Interpolation
        string message = $"Run Lenght: {movie.RunLength} mins";
        Console.WriteLine(message);




        //Released yyy
        // Console.WriteLine("Relased " + releaseYear);
        Console.WriteLine($"Released {movie.ReleaseYear}");

        Console.WriteLine(movie.Genre);

        //MPAA Rating
        Console.WriteLine($"MPAA Rating: {movie.Rating}");

        //Black and White?
        // string format = "Color";
        //if (isBlackAndWhite)
        //    format = "Black and White";

        //v2
        string format = movie.IsBlackAndWhite ? "Black and White" : "Color";
        Console.WriteLine("Format:" + format);

        //v3
        //Console.WriteLine("Format " + (isBlackAndWhite ? "Black and White" : "Color"));

        Console.WriteLine(movie.Description);

        //More String Functions
    }

    bool Confirm ( string message )
    {
        return ReadBoolean(message);
    }

    /// <summary>
    /// Reads a Boolean Value
    /// </summary>
    /// <param name="message">Message to Show</param>
    /// <returns>
    /// Returns True if Value was True, or False OtherWise
    /// </returns>
    bool ReadBoolean ( string message )
    {
        Console.WriteLine(message);

        //TODO: Handle Failure
        while (true)
        {
            // string value = Console.ReadLine();
            // var value = Console.ReadLine();
            ////if (value == "Y" || value == "y")
            ////    return true;
            ////else if (value == "N" || value == "n")
            ////    return false;
            ///
            switch (Console.ReadKey(true).Key)
            {
                //case "Y":
                //case "y": return true;
                case ConsoleKey.Y: return true;

                //case "N":
                //case "n": return false;
                case ConsoleKey.N: return false;

            };


            // Console.WriteLine("Please Enter Y/N");
        };
    }

    int ReadInt ( string message, int minimumValue )
    {
        Console.WriteLine(message);

        do
        {


            string value = Console.ReadLine();

            //int result = Int32.Parse(value);
            //int result;
            //if (Int32.TryParse(value, out result)) ;
            //Incase
            if (Int32.TryParse(value, out int result))
                if (result >= minimumValue)
                    return result;

            Console.WriteLine("Value must be at least " + minimumValue);
        } while (true);
    }

    string ReadString ( string message, bool isRequired )
    {
        Console.WriteLine(message);

        do
        {
            string value = Console.ReadLine().Trim();

            if (!isRequired || !String.IsNullOrEmpty(value))
                return value;
            //if (!isRequired)g
            //    return value;

            //if (value != "")
            //        return value;

            Console.WriteLine("Please Enter a Value");

        } while (true);

    }

    Rating ReadRating ( string message )
    {
        Console.WriteLine(message);

        do
        {
            string value = Console.ReadLine();

            // if (value == "PG")
            //1. String Compare 1 --> Don't Use
            // if (value.ToUpper() == "PG")
            // value = value.ToLower();
            //if (value == "pg")
            //2. String Comapre 2
            // if (String.Compare(value, "PG", true) == 0) 
            //if (value.CompareTo("PG") == 0)
            //3 . String Equals --> Preferred
            if (String.Equals(value, "PG", StringComparison.CurrentCultureIgnoreCase))
                return Rating.PG;
            else if (String.Equals(value, "G", StringComparison.CurrentCultureIgnoreCase))
                return Rating.G;
            else if (String.Equals(value, "PG-13", StringComparison.CurrentCultureIgnoreCase))
                return Rating.PG13;
            else if (String.Equals(value, "R", StringComparison.CurrentCultureIgnoreCase))
                return Rating.R;
            //else if (value == "")
            //   return "";
            else if (String.IsNullOrEmpty(value))
                return null;

            Console.WriteLine("Invalid Rating");

        } while (true);

    }

}
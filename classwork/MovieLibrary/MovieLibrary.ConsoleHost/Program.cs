// Get Movies
// Tittle genre, description, MPAA Rating
// Length, relase year, budget
// IsBlackAndWhite
// Operation, Add, Edit, View, delete

string title = "", genre = "";
string description = "", rating = "";

int length = 0, releaseYear = 1900;
decimal budget = 125.45M;

bool isBlackAndWhite = false;

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
        case 1: AddMovie(); break;
        case 2: EditMovie(); break;
        case 3: DeleteMovie(); break;
        case 4: ViewMovie(); break;
        case 0:
        {
            done = true; 
            //Do More Stuff Here
            break;
        }

        default: Console.WriteLine("Unknown Option"); break;
    }


} while (!done);


//Get Movie Details and Display
//Functions

int DisplayMenu () 
{

    Console.WriteLine("----------------");
    Console.WriteLine("(A)dd Movie");
    Console.WriteLine("(E)dit Movie");
    Console.WriteLine("(D)elete Movie");
    Console.WriteLine("(V)iew Movie");      
    Console.WriteLine("(Q)uit");

    do
    {


        //var input = Console.ReadLine();
        //if (input == "A" || input == "a")
        //    return 1;
        //else if (input == "E" || input == "e")
        //    return 2;
        //else if (input == "D" || input == "d")
        //    return 3;
        //else if (input == "V" || input == "v")
        //    return 4;
        //else if (input == "Q" || input == "q")
        //    return 0;

        switch(Console.ReadKey(true).Key)
            {
            //case "A": //return 1;
            // case "a": return 1;
            case ConsoleKey.A: return 1;

            //case "E": //return 2;
            //case "e": return 2;
            case ConsoleKey.E: return 2;

            // case "D": //return 3;
            // case "d": return 3;
            case ConsoleKey.D: return 3;

            // case "V": //return 4;
            // case "v": return 4;
            case ConsoleKey.V: return 4;

            // case "Q": //return 0;
            // case "q": return 0;
            case ConsoleKey.Q: return 0;
        };
    } while (true);
}

void AddMovie ()
{
    title = ReadString("Enter A Title:", true);
    description = ReadString("Enter A Description:", false);

    length = ReadInt("Enter The Run Lenth in Minutes", 0);
    releaseYear = ReadInt("Enter The Date of the Release Year", 1900);

    genre = ReadString("Enter a Genre: ", false);
    rating = ReadRating("Enter a Rating: ");

    isBlackAndWhite = ReadBoolean("Is the Movie in Black and White? (Y/N)");
}

void DeleteMovie ()
{
    if (String.IsNullOrEmpty(title))

        return;

    if (!Confirm($"Are you Sure you Would Like to Delete this Movie '{title}' (Y/N)"))
        return;

    title= "";
}
void EditMovie ()
{
    Console.WriteLine("Not Implimented Yet");
}

void ViewMovie ()
{
    //Lenght of a String

    int len = title.Length;

    if(String.IsNullOrEmpty(title))
    {
        Console.WriteLine("No Movies Availible");
        return;
    };

    Console.WriteLine();
    // Console.WriteLine("-------------");
    Console.WriteLine("".PadLeft(15, '-'));
   // Console.WriteLine("\n-------------");
    Console.WriteLine(title);

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
    string message = $"Run Lenght: {length} mins";
    Console.WriteLine(message);




    //Released yyy
   // Console.WriteLine("Relased " + releaseYear);
   Console.WriteLine($"Released {releaseYear}");

    Console.WriteLine(genre);

    //MPAA Rating
    Console.WriteLine($"MPAA Rating: {rating}");

    //Black and White?
    // string format = "Color";
    //if (isBlackAndWhite)
    //    format = "Black and White";

    //v2
    string format = isBlackAndWhite ? "Black and White" : "Color";
     Console.WriteLine("Format:" + format);

    //v3
    //Console.WriteLine("Format " + (isBlackAndWhite ? "Black and White" : "Color"));

    Console.WriteLine(description);

    //More String Functions
}

bool Confirm (string message)
{
    return ReadBoolean(message);
}

bool ReadBoolean(string message )
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

int ReadInt ( string message, int minimumValue)
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
    }while (true);
}

string ReadString (string message, bool isRequired)
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

    }  while (true);

}

string ReadRating ( string message)
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
      if(String.Equals(value, "PG", StringComparison.CurrentCultureIgnoreCase))
            return "PG";
        else if (String.Equals(value, "G", StringComparison.CurrentCultureIgnoreCase))
            return "G";
        else if (String.Equals(value, "PG-13", StringComparison.CurrentCultureIgnoreCase))
            return "PG-13";
        else if (String.Equals(value, "R", StringComparison.CurrentCultureIgnoreCase))
            return "R";
        //else if (value == "")
        //   return "";
        else if (String.IsNullOrEmpty(value))
            return "";

        Console.WriteLine("Invalid Rating");

    } while (true);

}


//double someFloatingValue = 3.14159;
//char letterGrade = 'A';

//{
// int hours = 5;
//int title = 54;
//title = "Jaws";

// Console.WriteLine(title);
// Console.WriteLine(length);
//}
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

//Get Movie Details and Display
GetMovie();
DisplayMovie();

//Functions

void GetMovie ()
{
    title = ReadString("Enter A Title:", true);
    description = ReadString("Enter A Description:", false);

    length = ReadInt("Enter The Run Lenth in Minutes", 0);
    releaseYear = ReadInt("Enter The Date of the Release Year", 1900);

    genre = ReadString("Enter a Genre: ", false);
    rating = ReadString("Enter a Rating: ", false);

    isBlackAndWhite = ReadBoolean("Is the Movie in Black and White? (Y/N)");
}

void DisplayMovie ()
{
    Console.WriteLine();
    Console.WriteLine("-------------");
    Console.WriteLine(title);

    //Run Length: # Minutes
    Console.WriteLine("Run Length: " + length + " Minutes");

    //Released yyy
    Console.WriteLine("Relased " + releaseYear);

    Console.WriteLine(genre);

    //MPAA Rating
    Console.WriteLine("MPAA Rating: " + rating);

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
}

bool ReadBoolean(string message )
{
    Console.WriteLine(message);

    //TODO: Handle Failure
    while (true)
    {
        // string value = Console.ReadLine();
        var value = Console.ReadLine();
        if (value == "Y" || value == "y")
            return true;
        else if (value == "N" || value == "n")
            return false;

        Console.WriteLine("Please Enter Y/N");
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
    string value = Console.ReadLine();

    if (!isRequired || value != "")
        return value;
    //if (!isRequired)
    //    return value;

    //if (value != "")
    //        return value;

        Console.WriteLine("Please Enter a Value");

    }  while (true);

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
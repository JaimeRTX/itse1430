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
}

void DisplayMovie ()
{
    Console.WriteLine(title);
    Console.WriteLine(description);
    Console.WriteLine(length);
}

int ReadInt ( string message, int minimumValue)
{
    Console.WriteLine(message);

    string value = Console.ReadLine();

    //int result = Int32.Parse(value);
    int result;
    if (Int32.TryParse(value,out result))
        if (result >= minimumValue)
     return result;

    //TODO: Input Validation
    return 0;
}

string ReadString (string message, bool isRequired)
{
    Console.WriteLine(message);

    string value = Console.ReadLine();
    if (!isRequired)
        return value;
    //else
    //    return "";

    //TODO: INPUT VALIDATION FOR REQUIRED
    return value;
   // if (false)
    //{
   //     if (true)
   //         Console.WriteLine();
   // } else
   //     Console.WriteLine();
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
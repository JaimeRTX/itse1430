

using System.ComponentModel.Design;

var awake = false;
Introduction();



    do
    {
        int dreamX = 0;
        int dreamY = 0;

   DreamTracker(dreamX, dreamY);
    switch (DreamMenu())
    {
        
        case 1: HeadWest(dreamX); break;
        case 2: HeadNorth(dreamY); break;
        case 3: HeadEast(dreamX); break; 
        case 4: HeadSouth(dreamY); break;
        case 0:
        {
            if (EndingTheDream("Do You Want to End the Dream(Y/N)"))
                return;
            break;
        }
            default: Console.WriteLine("You Freeze up in Confusion on What you Wanted to do (Unknown Key)"); break;

    }



} while (!awake);


int HeadWest ( int MinusX )
{
    return MinusX--;
}

int HeadNorth ( int PlusY )
{
    return PlusY++;
}

int HeadEast ( int PlusX )
{
    return PlusX + 1;
}

int HeadSouth ( int MinusY )
{
    return MinusY--;
}



bool EndingTheDream (string message)
{
    return ReadBoolean(message);
}

bool ReadBoolean(string message)
{
    Console.WriteLine(message);

    while (true)
    {
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.Y: return true;
            case ConsoleKey.N: return false;
        };

    };
}

int DreamMenu()
{
    Console.WriteLine("|".PadLeft(18, '-'));
    Console.WriteLine("Head (W)est");
    Console.WriteLine("Head (N)orth");
    Console.WriteLine("Head (E)ast");
    Console.WriteLine("Head (S)outh");
    Console.WriteLine("End the (D)ream");
    Console.WriteLine("|----------------|");

    do
    {
    switch(Console.ReadKey(true).Key)
        {
            case ConsoleKey.W: return 1;
            case ConsoleKey.N: return 2;
            case ConsoleKey.E: return 3;
            case ConsoleKey.S: return 4;
            case ConsoleKey.D: return 0;
        }

    }while (true);

}

void Introduction ()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine("  You Remember Lying in your Bed Trying to go to Sleep, After Some Time You Feel the Surface of your Bed Change. When ");
    Console.WriteLine("  You Open Your Eyes you Find Yourself On what Seems like a Beach of a Seemingly Magical, yet Broken World");
    Console.WriteLine();
    Console.WriteLine("  Everything seems to be of Cool Colors, and things like the Sand, Water, and Surrounding Rocks have a tints of ");
    Console.WriteLine("  Purples and Blues. Most Importantly you see That the Overall Land is Made up of Broken Islands. Thankfully");
    Console.WriteLine("  you Feel Way Lighter on Your Feet.");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea1()
{

    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine(" The Sourounding Area You See a Calm Beach that Seems to have been Untouched by Time To the East If You Can Safely ");
    Console.WriteLine(" Make the Down Trip, While in the South you a Countinue to the Mountain Where What you Think is a Bridge Further in");
    Console.WriteLine(" The Distance");
    Console.WriteLine();
    Console.WriteLine(" ");

}

void DreamArea2()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine("  The Sourounding Area you see a Clearing to the South a Narrow Path full of plant Life Ranging from Bright Blues to ");
    Console.WriteLine("  Deep Purples, WHile the West has the Sand Falling off the Broken Land, while on the other side of the gap is a Rocky");
    Console.WriteLine("  Path Leading to Mountain With What You Believe to be a Tree on Top, While the East Looks like a Collection of Small ");
    Console.WriteLine("  Islands Sourrounding a Slighty Bigger one with a Broken Statue");
    Console.WriteLine();
    Console.WriteLine("  The Direct Area Around You Is a Calm Beach With Sand that has a Purple Tint, With the Water Still With a Pink Lining.");
    Console.WriteLine("  There is a Few Palm Trees Near the Edge Outside, Yet the Land itself seems Barren. You Feel Calm Yet in The Back of ");
    Console.WriteLine("  Your Mind You Feel a sense of Unease at the Emptiness of the Land and What Could've Caused it");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea3()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine(" The Sourounding Area You See a Calm Beach that Seems to have been Untouched by Time To the West If You Make Swift");
    Console.WriteLine(" Jumps. While the South has a Single Path inside a Deep Part of the Forest, Unknown to you of What Could be Inside");
    Console.WriteLine();
    Console.WriteLine(" The Direct Area Around you See is Multiple Pieces of an Island, The Center Island is the Most Prominent From");
    Console.WriteLine(" Being the Biggest Piece as Well Having What Seems to be Broken Statue. Upon Closer Inspection It Looks to be");
    Console.WriteLine(" Religious in Orgin, but From what Religion it Eludes you. From that Relevation you see that Other Pieces");
    Console.WriteLine(" of Land Have some Rubble of What Could've Been a Church");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea4()
{
    Console.WriteLine("PlaceHolder For Room 4");
}

void DreamArea5()
{
    Console.WriteLine("PlaceHolder For Room 5");
}

void DreamArea6()
{
    Console.WriteLine("PlaceHolder for Room 6");
}

void DreamArea7()
{
    Console.WriteLine("PlaceHolder For Room 7");
}

void DreamArea8()
{
    Console.WriteLine("PlaceHolder for Room 8");
}

void DreamArea9()
{
    Console.WriteLine("PlaceHolder For Room 9");
}

int DreamTracker ( int dreamX, int dreamY )
{
    int MaximumX = 3;
    int MaximumY = 3;
    int roomNumber = dreamX + (MaximumX * (dreamY - 1));

    if (dreamX >= 0 && dreamX < MaximumX && dreamY >= 0 && dreamY < MaximumY)
        switch (roomNumber)
        {
            case -3: DreamArea1(); break;
            case -2: DreamArea2(); break;
            case -1: DreamArea3(); break;
            case 0: DreamArea4(); break;
            case 2: DreamArea5(); break;
            case 1: DreamArea6(); break;
            case 3: DreamArea7(); break;
            case 4: DreamArea8(); break;
            case 5: DreamArea9(); break;
        } return roomNumber;
}

void WrongMove()
{
    Console.WriteLine("You Can't Find a Way to Keep Going");
}
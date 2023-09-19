

/*
 * Jaime Rodriguez
 * ITSE 1430 
 * Lab 1
 */

using System.ComponentModel;

var awake = false;
Introduction();

int dreamX = 0;
int dreamY = 0;
//dreamX = HeadWest(dreamX);
//dreamX = HeadEast(dreamX);
//dreamY = HeadSouth(dreamY);
//dreamY = HeadNorth(dreamY);

do
    {

    //dreamX = HeadWest(dreamX);
    //dreamX = HeadEast(dreamX);
    //dreamY = HeadSouth(dreamY);
    //dreamY = HeadNorth(dreamY);
    DreamTracker(dreamX, dreamY);
    dreamX = HeadWest(dreamX);
    dreamX = HeadEast(dreamX);
    dreamY = HeadSouth(dreamY);
    dreamY = HeadNorth(dreamY);
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
    MinusX = MinusX - 1;
    return MinusX;
}

int HeadNorth ( int PlusY )
{
    PlusY = PlusY + 1;
    return PlusY;
}

int HeadEast ( int PlusX )
{   
    PlusX = PlusX + 1;
    return PlusX;
}

int HeadSouth ( int MinusY )
{
    MinusY = MinusY - 1;
    return MinusY;
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
    Console.WriteLine("|----------------|");
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
    Console.WriteLine("  You Open Your Eyes you Find Yourself On A Mountain With the Only Thing With you is a Solitary Tree");
    Console.WriteLine();
    Console.WriteLine("  You Look Down Around You for a Glance at the Land and Everything seems to have have a tints of ");
    Console.WriteLine("  Purples and Blues. Most Importantly you see That the Overall Land is Made up of Broken Islands. Thankfully");
    Console.WriteLine("  you Feel Way Lighter on Your Feet.");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea1()
{

    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine(" The Sourounding Area You See a Calm Beach that Seems to have been Untouched by Time To the East If You Can Safely ");
    Console.WriteLine(" Make the Down Trip, While in the South you is a Countinue to the Mountain Where What you Think is a Bridge Further in");
    Console.WriteLine(" The Distance");
    Console.WriteLine();
    Console.WriteLine(" The Direct Area Around You is A Mountanous Area Where the Top is Flat, but What Catches your Eye is Rhat in The Center");
    Console.WriteLine(" From a Small Area of Soil a Lone Singular Tree is Standing Tall, with Darkish Purple Bark and Pink Leaves");
    Console.WriteLine("  [You Are in Position (0,0)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");

}

void DreamArea2()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine("  The Sourounding Area you see a Clearing to the South a Narrow Path full of plant Life Ranging from Bright Blues to ");
    Console.WriteLine("  Deep Purples, WHile the West has the Sand Falling off the Broken Land, while on the other side of the gap is a Rocky");
    Console.WriteLine("  Path Leading to Mountain You Woke on With the Tree Still on Top, While the East Looks like a Collection of Small ");
    Console.WriteLine("  Islands Sourrounding a Slighty Bigger one with a Broken Statue");
    Console.WriteLine();
    Console.WriteLine("  The Direct Area Around You Is a Calm Beach With Sand that has a Purple Tint, With the Water Still With a Pink Lining.");
    Console.WriteLine("  There is a Few Palm Trees Near the Edge Outside, Yet the Land itself seems Barren. You Feel Calm Yet in The Back of ");
    Console.WriteLine("  Your Mind You Feel a sense of Unease at the Emptiness of the Land and What Could've Caused it");
    Console.WriteLine("  [You Are in Position (1,0)]");
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
    Console.WriteLine("  [You Are in Position (2,0)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea4()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine(" The Sourounding Area You See in the North The Mountain You Woke up on With the Still Tree on Top of it, While on the ");
    Console.WriteLine(" East There Seems to be Rementants of Starcase Leading Down to What You Make Out To Be A Fountain In the Middle of");
    Console.WriteLine(" Heavy Vegitation, While the South The Bridge Seems to Start to Incline Down into A Broken Building");
    Console.WriteLine();
    Console.WriteLine(" The Direct Area Around You, Seems to be a Border Between the full Nature of this land Being Untouched and Man-Made");
    Console.WriteLine(" Structures. You Do Wonder What Happened to the People That Made These, But from how the Quality of Material Does ");
    Console.WriteLine(" Feel Fresh in a Way, so You Can only Assume all The Broken Areas and Parts Were Destroyed and You Don't Want To");
    Console.WriteLine(" Think What Could've Caused It");
    Console.WriteLine("  [You Are in Position (0,1)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea5()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine(" The Sourounding Area You See a Calm Beach that Seems to have been Untouched by Time To The North If You Can Get");
    Console.WriteLine(" Through the Narrow Path. While the West has a Single Path inside a Deep Part of the Forest, Unknown to you of What");
    Console.WriteLine(" Could be Inside. The South Has a Suprisngly Clear Path to A Broken Off Island with A Structure Way Further Off the ");
    Console.WriteLine(" Distance. Finally in the East You See A Broken Staircase Leading to a Point in the Mountain, You Feel Confortable That");
    Console.WriteLine(" You Can Jump Up To Each Piece Walking Up to the Mountain Area");
    Console.WriteLine();
    Console.WriteLine(" The Direct Area Around You is Heavy Vegitation, but What Catched Your Eye is the Middle. A Fountain Which Feels Alien");
    Console.WriteLine(" Since for Some Reason the Fountain and the Grass Touching it Seems to be of a More Natural Color with no Purples,  ");
    Console.WriteLine(" Pinks, or Blues. That Makes You Feel Better in a way You Can't Really Describe");
    Console.WriteLine("  [You Are in Position (1,1)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea6()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine(" The Sourounding Area has the North Way Obscured, but You Think you See Multiple Floating Objects, While the West");
    Console.WriteLine(" Has a Narrow Path You Think You can Barely Fit Towards to a Less Heavy Part of the Forest, Finally to your Surprise");
    Console.WriteLine(" In The South There is a Cut Path Towards a Clearing to an Area");
    Console.WriteLine();
    Console.WriteLine(" The Direct Area Around You is Just full of Trees, Bushes, and Any Other Plantlife From What You Can See. It Feels");
    Console.WriteLine(" Catastrophic Due to How Hard is it to Move Through it All. Yet It Makes You Think What had Happened to all of the");
    Console.WriteLine(" Animals in This Place. Either they are Hiding or Something had Wiped them Out. You Try to Push that Thought Away");
    Console.WriteLine("  [You Are in Position (2,1)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea7()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine(" The Sourounding Area has the North Having a Bride Upwards to a Mountainous Area, While in the East ");
    Console.WriteLine("  [You Are in Position (0,2)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea8()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine("  [You Are in Position (1,2)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

void DreamArea9()
{
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
    Console.WriteLine("  [You Are in Position (2,2)]");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}

int DreamTracker ( int dreamX, int dreamY )
{
    int MaximumX = 3;
    int MaximumY = 3;
    int roomNumber = dreamX + (MaximumX * (dreamY - 1));

    
    if (dreamX >= 0 && dreamX < MaximumX && dreamY >= 0 && dreamY < MaximumY)
    {
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
        }
        return roomNumber;
    } else
    {
        WrongMove();
        return 0;
    }
}

void WrongMove()
{
    Console.WriteLine("You Can't Find a Way to Keep Going");
}
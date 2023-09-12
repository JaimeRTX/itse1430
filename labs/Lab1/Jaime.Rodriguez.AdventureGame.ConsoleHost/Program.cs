


Introduction();

//do
//{
//    switch(DreamMenu())
//    {
//        case 1:
//        case 2:
//        case 3:
//        case 4: 
//        case 0:
//           {
//
//           }
//    }
//     
//   default: Console.WriteLine("You Freeze up in Confusion on What you Wanted to do (Unknown Key)")
//}



void EndingTheDream()
{
    if (!Confirm("Do You Want to Wake Up (Y/N)"))
        return;

}

bool Confirm (string message)
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
    Console.WriteLine("  You Open Your Eyes you Find Yourself On what Seems like a Beach of a Seemingly Magical, yet Broken World");
    Console.WriteLine("  ");
    Console.WriteLine("  Everything seems to be of Cool Colors, and things like the Sand, Water, and Surrounding Rocks have a tints of ");
    Console.WriteLine("  Purples and Blues. Most Importantly you see That the Overall Land is Made up of Broken Islands. Thankfully");
    Console.WriteLine("  you Feel Way Lighter on Your Feet.");
    Console.WriteLine(" |-------------------------------------------------------------------------------------------------------------------|");
}
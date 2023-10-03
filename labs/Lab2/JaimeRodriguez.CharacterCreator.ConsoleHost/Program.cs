/*
 * Jaime Rodriguez
 * ITSE 1430 
 * Lab 2
 */
using System.ComponentModel.Design;

namespace JaimeRodriguez.CharacterCreator.ConsoleHost;

partial class Program
{
    static void Main()
    {
        var app = new Program();
        app.Run ();
    }
    void Run()
    {
        var menu = false;
        do
        {
            switch (DisplayMenu())
            {
                case CharacterMenuOptions.Add: AddCharacter(); break;
                case CharacterMenuOptions.View: ViewCharacter(); break;
                case CharacterMenuOptions.Edit: EditCharacter(); break;
                case CharacterMenuOptions.Delete: DeleteCharacter(); break;
                case CharacterMenuOptions.Quit:
                {
                    if (QuitCreator("Do You Wish To Exit the Creator? (Y/N)"))
                        return;
                    break;
                }
            }
        }while (!menu);
    }


    CharacterMenuOptions DisplayMenu()
    {
        Console.WriteLine("-----------------------------");
        Console.WriteLine("(A) Add A New Character");
        Console.WriteLine("(V) View A Character");
        Console.WriteLine("(E) Edit A Character");
        Console.WriteLine("(D) Delete A Character");
        Console.WriteLine("(Q) Quit The Creator");

        do
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.A: return CharacterMenuOptions.Add;
                case ConsoleKey.E: return CharacterMenuOptions.Edit;
                case ConsoleKey.D: return CharacterMenuOptions.Delete;
                case ConsoleKey.V: return CharacterMenuOptions.View;
                case ConsoleKey.Q: return CharacterMenuOptions.Quit;
            }

        }while (true);
    }

    void AddCharacter()
    {
        Console.WriteLine("PlaceHolder");
    }

    void ViewCharacter ()
    {
        Console.WriteLine("PlaceHolder");
    }

    void DeleteCharacter()
    {
        Console.WriteLine("PlaceHolder");
    }

    void EditCharacter()
    {
        Console.WriteLine("PlaceHolder");
    }
    bool ReadBoolean ( string message )
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

    bool QuitCreator ( string message )
    {
        return ReadBoolean ( message );
    }
}




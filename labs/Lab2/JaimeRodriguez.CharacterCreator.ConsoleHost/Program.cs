/*
 * Jaime Rodriguez
 * ITSE 1430 
 * Lab 2
 */
using System.ComponentModel.Design;

using JaimeRodriguez.CharacterCreator_;

namespace JaimeRodriguez.CharacterCreator.ConsoleHost;

partial class Program
{
    static void Main ()
    {
        var app = new Program();
        app.Run();
    }
    void Run ()
    {
        Character character = new Character();
        var menu = false;
        do
        {
            switch (DisplayMenu())
            {
                case CharacterMenuOptions.Add: character = AddCharacter(); break;
                case CharacterMenuOptions.View: ViewCharacter(character); break;
                case CharacterMenuOptions.Edit: EditCharacter(); break;
                case CharacterMenuOptions.Delete:
                {
                   if(DeleteCharacter(character))
                    character = new Character();
                    break;
                }
                case CharacterMenuOptions.Quit:
                {
                    if (Confirm("Do You Wish To Exit the Creator? (Y/N)"))
                        return;
                    break;
                }
            }
        } while (!menu);
    }


    CharacterMenuOptions DisplayMenu ()
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

        } while (true);
    }

    Character AddCharacter ()
    {
        var character = new Character();
        do
        {
            character.Name = ReadString("Enter Your Name: ", true);

            character.Profession = ReadProfession("Select a Profession [Athlete, Priest, Builder, Botanist, Hermit]");

            character.Race = ReadRace("What is Your Lineage [Human, Elf, Astral-Born, Dwarf, Dragonborn]");

            return character;
        }while (true);

    }

    void ViewCharacter (Character character)
    {
      if(String.IsNullOrEmpty(character.Name))
        {
            Console.WriteLine("No Chracter's Made");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("".PadLeft(25, '-'));
        Console.WriteLine($"Character Name: {character.Name}");
        Console.WriteLine($"Character Profession: {character.Profession}");
        Console.WriteLine($"Race of the Character: {character.Race}");

    }

    bool DeleteCharacter (Character character)
    {
        if (String.IsNullOrEmpty(character.Name))

            return false;

        if (!Confirm($"Are you Sure You Would To Delete '{character.Name}' (Y/N)"))
            return false;

        return true;
    }

    void EditCharacter ()
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
        
    bool Confirm ( string message )
    {
        return ReadBoolean(message);
    }

    string ReadString ( string message, bool isRequired )
    {
        Console.WriteLine(message);

        do
        {
            string value = Console.ReadLine().Trim();

            if (!isRequired || !String.IsNullOrEmpty(value))
                return value;

            Console.WriteLine("Please Enter a Value");

        } while (true);

    }

    string ReadProfession (string message)
    {
        Console.WriteLine(message);
        do
        {
            string value = Console.ReadLine();

            if (String.Equals(value, "Athlete", StringComparison.CurrentCultureIgnoreCase))
                return "Athlete";
            else if (String.Equals(value, "Priest", StringComparison.CurrentCultureIgnoreCase))
                return "Priest";
            else if (String.Equals(value, "Builder", StringComparison.CurrentCultureIgnoreCase))
                return "Builder";
            else if (String.Equals(value, "Botanist", StringComparison.CurrentCultureIgnoreCase))
                return "Botanist";
            else if (String.Equals(value, "Hermit", StringComparison.CurrentCultureIgnoreCase))
                return "Hermit";
            else if (String.IsNullOrEmpty(value))
                return "";

        } while (true);
    }

    string ReadRace (string message)
    {
        Console.WriteLine(message);
        do
        {
            string value = Console.ReadLine();
            if (String.Equals(value, "Human", StringComparison.CurrentCultureIgnoreCase))
                return "Human";
            else if (String.Equals(value, "Elf", StringComparison.CurrentCultureIgnoreCase))
                return "Elf";
            else if (String.Equals(value, "Astral-Born", StringComparison.CurrentCultureIgnoreCase))
                return "Astral-Born";
            else if (String.Equals(value, "Dwarf", StringComparison.CurrentCultureIgnoreCase))
                return "Dwarf";
            else if (String.Equals(value, "Dragonborn", StringComparison.CurrentCultureIgnoreCase))
                return "Dragonborn";
            else if (String.IsNullOrEmpty(value))
                return "";


        } while (true);
    }
}




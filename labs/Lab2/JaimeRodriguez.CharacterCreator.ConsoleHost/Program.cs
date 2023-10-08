/*
 * Jaime Rodriguez
 * ITSE 1430 
 * Lab 2
 */

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
                case CharacterMenuOptions.Edit: EditCharacter(character); break;
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

            character.Strength = ReadInt("Enter Your Strength Stat [0-100]", Character.MinimumStat, Character.MaximumStat);

            character.Inteligence = ReadInt("Enter Your Inteligence Stat [0-100]", Character.MinimumStat, Character.MaximumStat);

            character.Agility = ReadInt("Enter Your Agility Stat [0-100]", Character.MinimumStat, Character.MaximumStat);

            character.Constitution = ReadInt("Enter Your Constitution Stat [0-100]", Character.MinimumStat, Character.MaximumStat);

            character.Charisma = ReadInt("Enter Your Charisma Stat [0-100]", Character.MinimumStat, Character.MaximumStat);

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
        Console.WriteLine($"Strength Stat: {character.Strength}");
        Console.WriteLine($"Inteligence Stat: {character.Inteligence}");
        Console.WriteLine($"Agility Stat: {character.Agility}");
        Console.WriteLine($"Constitution Stat: {character.Constitution}");
        Console.WriteLine($"Charisma Stat: {character.Charisma}");

    }

    bool DeleteCharacter (Character character)
    {
        if (String.IsNullOrEmpty(character.Name))

            return false;

        if (!Confirm($"Are you Sure You Would To Delete '{character.Name}' (Y/N)"))
            return false;

        return true;
    }

    Character EditCharacter (Character character)
    {
       
        if (String.IsNullOrEmpty(character.Name))
        {
            Console.WriteLine("No Chracter To Edit");
            return character;
        }

        if (Confirm("Would You Like to Change Your Name(Y/N)"))
        {
            character.Name = ReadString("Enter Your New Name", true);
        }

        if (Confirm("Would You Like to Change Your Profession(Y/N)"))
        {
            character.Profession = ReadString("Enter Your New Profession", true);
        }

        if (Confirm("Would You Like to Change Your Race(Y/N)"))
        {
            character.Race = ReadString("Enter Your New Race", true);
        }

        if (Confirm("Would You Like to Change Your Strength Stat(Y/N)"))
        {
            character.Strength = ReadInt("Enter Your New Strength[0-100]", Character.MinimumStat, Character.MaximumStat);
        }

        if (Confirm("Would You Like to Change Your Inteligence Stat(Y/N)"))
        {
            character.Inteligence = ReadInt("Enter Your New Inteligence[0-100]", Character.MinimumStat, Character.MaximumStat);
        }

        if (Confirm("Would You Like to Change Your Agility Stat(Y/N)"))
        {
            character.Agility = ReadInt("Enter Your New Agility[0-100]", Character.MinimumStat, Character.MaximumStat);
        }

        if (Confirm("Would You Like to Change Your Constitution Stat(Y/N)"))
        {
            character.Constitution = ReadInt("Enter Your New Constitution[0-100]", Character.MinimumStat, Character.MaximumStat);
        }

        if (Confirm("Would You Like to Change Your Charisma Stat(Y/N)"))
        {
            character.Charisma = ReadInt("Enter Your New Charisma[0-100]", Character.MinimumStat, Character.MaximumStat);
        }

        return character;
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

    int ReadInt (string message, int minimumValue, int maximumValue)
    {
        Console.WriteLine(message);

        do
        {
            string value = Console.ReadLine();
            if (Int32.TryParse(value, out int result))
                if(result >= minimumValue && result <= maximumValue)
                    return result;
            
           Console.WriteLine($"The Stat Needs to be Between {minimumValue} and {maximumValue}");
        } while (true);
    }
}




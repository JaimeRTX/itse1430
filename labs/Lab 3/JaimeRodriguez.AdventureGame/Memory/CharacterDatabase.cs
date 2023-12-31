﻿namespace JaimeRodriguez.AdventureGame.Memory;
public class CharacterDatabase
{

    private readonly List<AdventureCharacters> _characters = new List<AdventureCharacters>();
    private int _characterId = 1;

    /// <summary>
    /// Checks the Name of the Character
    /// </summary>
    private AdventureCharacters FindByName ( string name )
    {
        foreach (var character in _characters)
        {
            if (String.Equals(name, character.Name, StringComparison.OrdinalIgnoreCase))
            {
                return character;
            }
        }
        return null;
    }

    /// <summary>
    /// Checks the ID Of the Character
    /// </summary>
    private AdventureCharacters FindByCharacterId ( int characterId )
    {
        foreach (var character in _characters)
            if (character.CharacterId == characterId)
            {
                return character;
            }
        return null;
    }

    private AdventureCharacters Clone ( AdventureCharacters characters )
    {
        var item = new AdventureCharacters();
        item.CharacterId = characters.CharacterId;
        Copy(item, characters);

        return item;
    }

    private void Copy ( AdventureCharacters target, AdventureCharacters source )
    {
        target.Name = source.Name;
        target.Profession = source.Profession;
        target.Race = source.Race;
        target.Strength = source.Strength;
        target.Inteligence = source.Inteligence;
        target.Agility = source.Agility;
        target.Constitution = source.Constitution;
        target.Charisma = source.Charisma;
    }


    /// <summary>
    /// Helps to Validate and to add a character to the list
    /// </summary>
    public string Add ( AdventureCharacters character )
    {
        if (character == null)
        {
            return "Character is Null";
        }
        if (!ObjectValidator.TryValidate(character, out var error))
        {
            return error.First().ErrorMessage;
        }
        var existing = FindByName(character.Name);
        if (existing != null)
        {
            return "Character Name Must be Unique";
        }
        character.CharacterId = _characterId++;
        _characters.Add(Clone(character));
        return "";
    }

    /// <summary>
    /// Helps to Edit and to Validate the Edit
    /// </summary>
    public string Update ( int id, AdventureCharacters character )
    {
        if (id <= 0)
        {
            return "Id is Invalid";
        }

        if (character == null)
        {
            return "Character is Null";
        }
        if (!ObjectValidator.TryValidate(character, out var error))
        {
            return error.First().ErrorMessage;
        }
        var existing = FindByName(character.Name);
        if (existing != null && existing.CharacterId != id)
        {
            return "Character Name Must Be Unique";
        }
        existing = FindByCharacterId(id);
        if (existing == null)
        {
            return "Character Not Found";
        }

        Copy(existing, character);
        return "";
    }

    /// <summary>
    /// Helps to Delete the Movie from the list
    /// </summary>
    public void Delete ( int id )
    {
        var character = FindByCharacterId(id);
        if (character != null)
        {
            _characters.Remove(character);
        }
    }

    public IEnumerable<AdventureCharacters> GetAll ()
    {
        foreach (var character in _characters)
        {
            yield return Clone(character);
        }
    }

}


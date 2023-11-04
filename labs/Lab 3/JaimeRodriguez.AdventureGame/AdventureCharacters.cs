using System.ComponentModel.DataAnnotations;
namespace JaimeRodriguez.AdventureGame;

    ///<remarks>
    ///This Class Holds The Values and Initizilatzation of different aspect used for the Charactrer Creator. 
    ///</remarks>
    /// <summary>
    /// It Represents the Character and each aspect of it 
    /// </summary>
    public class AdventureCharacters : IValidatableObject
    {

        public AdventureCharacters()
    {
        _initilized = true;
    }
        private readonly bool _initilized = false;
        private string _name;
        private string _profession;
        private string _race;

        /// <summary>
        /// This Stores The Name of the Character User Makes
        /// </summary>
        public string Name
        {
            get {
                if (String.IsNullOrEmpty(_name))
                    return "";
                return _name;
            }
            set {
                if (value != null)
                    value = value.Trim();
                _name = value;
            }
        }

        /// <summary>
        /// This Stores the Profession of the Character User Makes
        /// </summary>
        public string Profession
        {
            get {
                if (String.IsNullOrEmpty(_profession))
                    return "";

                return _profession;
            }
            set {
                _profession = value;
            }
        }

        /// <summary>
        /// This Stores The Race of the Character User Makes
        /// </summary>
        public string Race
        {
            get {
                if (String.IsNullOrEmpty(_race))
                    return "";
                return _race;
            }
            set {
                _race = value;
            }
        }

        /// <summary>
        /// The Value of the Minimum Value for Stats
        /// </summary>
        public const int MinimumStat = 1;

        /// <summary>
        /// The Value of the Maximum Value for Stats
        /// </summary>
        public const int MaximumStat = 100;

        /// <summary>
        /// Holds The Value for the Character's Strength 
        /// </summary>
        public int Strength { get; set; } = MinimumStat;

        /// <summary>
        /// Holds The Value for the Character's Inteligence
        /// </summary>
        public int Inteligence { get; set; } = MinimumStat;

        /// <summary>
        /// Holds The Value for the Character's Agility
        /// </summary>
        public int Agility { get; set; } = MinimumStat;

        /// <summary>
        /// Holds The Value for the Character's Constitution
        /// </summary>
        public int Constitution { get; set; } = MinimumStat;

        /// <summary>
        /// Holds The Value for the Character's Charisma 
        /// </summary>
        public int Charisma { get; set; } = MinimumStat;

        /// <summary>
        /// Holds Unique ID for each charcter
        /// </summary>
        public int CharacterId { get; set; }

    public override string ToString()
    {
        return $"{Name} [{Profession}, {Race}]";
    }

    public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
    {
        if (String.IsNullOrEmpty(_name))
        {
            yield return new ValidationResult("Character Name is Required");
        }

        if(String.IsNullOrEmpty(_profession))
        {
            yield return new ValidationResult("Profession is Required");
        }

        if (Strength > MaximumStat || Strength < MinimumStat)
        {
            yield return new ValidationResult("Strength Stat Must be between 1-100");
        }

        if (Inteligence > MaximumStat && Inteligence < MinimumStat)
        {
            yield return new ValidationResult("Inteligence Stat Must be between 1-100");
        }

        if (Agility > MaximumStat && Agility < MinimumStat)
        {
            yield return new ValidationResult("Agility Stat Must be between 1-100");
        }

        if (Constitution > MaximumStat && Constitution < MinimumStat)
        {
            yield return new ValidationResult("Constitution Stat Must be between 1-100");
        }

        if (Charisma > MaximumStat && Charisma < MinimumStat)
        {
            yield return new ValidationResult("Charisma Stat Must be between 1-100");
        }

    }

}


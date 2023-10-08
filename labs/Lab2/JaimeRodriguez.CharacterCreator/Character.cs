using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaimeRodriguez.CharacterCreator_
{
    public class Character
    {
        private string _name;
        private string _profession;
        private string _race;
        private int _strength;
        private int _inteligence;
        private int _agility;
        private int _constitution;
        private int _charisma;

        public string Name
        {
            get 
            {
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

        public const int MinimumStat = 0;
        public const int MaximumStat = 100;

        public int Strength { get; set; } = MinimumStat;
        public int Inteligence { get; set; } = MinimumStat;
        public int Agility { get; set; } = MinimumStat;
        public int Constitution { get; set; } = MinimumStat;
        public int Charisma { get; set; } = MinimumStat;
    }
}

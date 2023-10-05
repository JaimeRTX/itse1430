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
        //private string _biography; //TODO: Optional Maybe Do It

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
    }
}

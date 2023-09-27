﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    /// <summary>
    /// Represents an MPAA Rating
    /// </summary>
   public class Rating
    {
        //constructer - instance initilizating 
        public Rating(string name)
        {
            Name = String.IsNullOrEmpty(name) ? "" : name;
        }
        public static readonly Rating G = new Rating("G");
        public static readonly Rating PG = new Rating("PG");
        public static readonly Rating PG13 = new Rating("PG-13");
        public static readonly Rating R = new Rating("R");

        /// <summary>
        ///Gets the rating name
        /// </summary>
        public string Name { get; } //readonly field
        //public string Name
        //{
        //    get { return _name ?? ""; }
        //    //set { _name = value; }

        //}
        //private string _name;
    }
}

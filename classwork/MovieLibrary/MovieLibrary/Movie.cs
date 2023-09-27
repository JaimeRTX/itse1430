namespace MovieLibrary
{
    /// <summary>
    /// Represents a Movie
    /// </summary>
    ///<remarls>
    ///ParaGraphs of Descriptions
    ///</remarls>
    public class Movie
    {
        //Fields-Data

        /// <summary>
        /// Minimum Release Year
        /// </summary>
        public const int MininumReleaseYear = 1900;

        //Const - Compile Time Constant, must recompile to change
        //Readonly- Runtime Contsant, do not recompile to change
        //public const string DefaultRating = "PG";
        public readonly string DefaultRating = "PG";

        private string _title;

        private string _genre;

        /// <summary>
        /// Gets or Sets The Genre of Movie
        /// </summary>
        public string Genre
        {
            get {
                if (String.IsNullOrEmpty(_genre))
                    return "";

                return _genre;
            }
            set { _genre = value; }
        }
        private string _description = "";

        /// <summary>
        /// Gets or Sets The Description of Movie
        /// </summary>
        public string Description
        {
            get {
                if (String.IsNullOrEmpty(_description))
                    return "";

                return _description;
            }
            set {
                _description = value;
            }
        }
        private string _rating = "";

        /// <summary>
        /// Gets or Sets The Rating of Movie
        /// </summary>
        //public string Rating
        //{
        //    get {
        //        if (String.IsNullOrEmpty(_rating))
        //            return "";

        //        return _rating;
        //    }
        //    set {
        //        _rating = value;
        //    }
        //}

        public Rating Rating { get; set; }

        private int _length;

        /// <summary>
        /// Gets or Sets The Rating of Movie
        /// </summary>
        //public int RunLength
        //{
        //    get {
        //        return _length;
        //    }
        //    set {
        //        _length = value;
        //    }
        //}

        //Auto Property Syntax
        public int RunLength
        {
            get;
            set;
        }

        //private int _releaseYear = 1900;

        ///// <summary>
        ///// Gets or Sets The Release Year of Movie
        ///// </summary>
        //public int ReleaseYear
        //{
        //    get {
        //        return _releaseYear;
        //    }
        //    set {
        //        _releaseYear = value;
        //    }
        //}

        public int ReleaseYear { get; set; } = MininumReleaseYear;

        //private bool _isBlackAndWhite;

        ///// <summary>
        ///// Gets or Sets The The True or False if the Movie is Black and White
        ///// </summary>
        //public bool IsBlackAndWhite
        //{
        //    get {
        //        return _isBlackAndWhite;
        //    }
        //    set {
        //        _isBlackAndWhite = value;
        //    }

        //}

        public bool IsBlackAndWhite { get; set; }

        //Calculated Property
        public bool NeedsIntermission
        {
            //Run Length >150
            get {
                return RunLength >= 150;
            }
            //set {

            //}
        }

        //Properties - data wuth functionality

        /// <summary>
        /// Gets or Sets The Title of Movie
        /// </summary>
        public string Title
        {
            //MUst Eventually Return a String
            get {
                if (String.IsNullOrEmpty(_title))
                    return "";


                return _title;
            }
            set {
                if (value != null)
                    value = value.Trim();
                _title = value;

            }
        }

        /// <summary>
        /// Gets the or sets the unique identifier of the movie
        /// </summary>
        public int Id
        { 
            //Mixed Accesibility - getter/setter has different access than property
            get;
            /* set;*/
            private set;
        }

      

        /// <summary>
        /// Download Metadata From the Internet
        /// </summary>
        /// <remarks>
        /// Searches IMDB and TheTVDB.com
        /// </remarks>
        private void DownloadMetadata ()
        {

        }

        /// <summary>
        /// Validates the Movie Instance
        /// </summary>
        /// <returns?>
        /// Error Message if Invalid or empty string otherwise
        /// </returns>
        public string Validate ()
        {
            //Title is Required
            if (String.IsNullOrEmpty(_title))
                return "Title is Required";
            //error
            //Release Year =1900
            if (ReleaseYear < MininumReleaseYear)
                return $"Release Year must be >= {MininumReleaseYear}";
            //Length >= 0
            if (_length < 0)
                return "Length must be at least 0";
            //Rating is in a list
            //If ReleaseYear < 1940 then IsBlackAndWhite must be true
            if (ReleaseYear < 1940 && !IsBlackAndWhite)
                return "Movies Before 1940 must be in Black or White";

            //Valid
            return "";
        }
    }
}
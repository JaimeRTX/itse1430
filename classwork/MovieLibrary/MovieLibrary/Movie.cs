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
        /// Title of Movie
        /// </summary>
        public string title = "";
        public string genre = "";
        public string description = ""; 
        public string rating = "";

        public int length; 
        public int releaseYear = 1900;

        public bool isBlackAndWhite;
        
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
        public string Validate()
        {
            //Title is Required
            if (String.IsNullOrEmpty(title))
                return "Title is Required";
            //error
            //Release Year =1900
            if (releaseYear < 1900)
                return "Release Year must be >= 1900";
            //Length >= 0
            if (length < 0)
                return "Length must be at least 0";
            //Rating is in a list
            //If ReleaseYear < 1940 then IsBlackAndWhite must be true
            if (releaseYear < 1940 && !isBlackAndWhite)
                return "Movies Before 1940 must be in Black or White";

            //Valid
            return "";
        }
    }
}
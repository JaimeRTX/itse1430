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

    }
}
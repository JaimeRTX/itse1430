namespace MovieLibrary;

/// <summary>
/// Represents a Movie
/// </summary>
///<remarls>
///ParaGraphs of Descriptions
///</remarls>
public class Movie : ValidatableObject
{
    //ctors(constructors)- Initilize instance

    //Default Constructor
    public Movie ()
    {
        //In It Anything that fields initlize won't work with
        _initilized = true;
    }
    /// <summary>
    /// Initializes the Movie Class
    /// </summary>
    /// <param name="id">Identifier of the Movie</param>
    public Movie ( int id, string title ):this ()
    {
       Id = id;
       Title = title;

    }

    public Movie(int id) :this(id,"")
    {

    }

    public Movie(string title) :this (0, title)
    {

    }
    /// <summary>
    /// Gets the or sets the unique identifier of the movie
    /// </summary>
    public int Id
    {
        //Mixed Accesibility - getter/setter has different access than property
        get;
        /* set;*/
        set;
    }

    //private void Initialize(int id, string title)
    //{
    //    Id = id;
    //    Title = title;
    //}

    //Fields-Data

    private readonly bool _initilized = false;
    private string _title;
    private string _genre;
    private string _description = "";
    private string _rating = "";
    private int _length;

    //Properties - data wuth functionality

    /// <summary>
    /// Gets or Sets The Title of Movie
    /// </summary>
    public string Title
    {
        //MUst Eventually Return a String
        get {
            return _title ?? "";
            //return _title != null ? _title : "";
            //if (String.IsNullOrEmpty(_title))
            ////If (_title == null)
            ////Both Aproaches Are Vakud
            //    return "";


            //return _title;
        }
        set {
            _title = value?.Trim() ?? "";
            //if (value != null)
            //    value = value.Trim();
            //_title = value;

        }
    }
    /// <summary>
    /// Minimum Release Year
    /// </summary>
    public const int MininumReleaseYear = 1900;

    //Const - Compile Time Constant, must recompile to change
    //Readonly- Runtime Contsant, do not recompile to change
    //public const string DefaultRating = "PG";
    public readonly string DefaultRating = "PG";

    /// <summary>
    /// Gets or Sets The Genre of Movie
    /// </summary>
    public string Genre
    {
        get {
            return _genre ?? "";
        }
        set { _genre = value; }
    }

    /// <summary>
    /// Gets or Sets The Description of Movie
    /// </summary>
    public string Description
    {
        get {
            return _description ?? "";
        }
        set {
            _description = value;
        }
    }

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
    public override bool TryValidate ( out string message )
    {
        //Title is Required
        if (String.IsNullOrEmpty(_title))
        {
            message = "Title is Required";
            return false;
        }
        //error
        //Release Year =1900
        if (ReleaseYear < MininumReleaseYear)
        {
            message = $"Release Year must be >= {MininumReleaseYear}";
            return false;
        }
        //Length >= 0
        if (_length < 0)
        {
            message = "Length must be at least 0";
            return false;
        }
        //Rating is in a list
        //If ReleaseYear < 1940 then IsBlackAndWhite must be true
        if (ReleaseYear < 1940 && !IsBlackAndWhite)
        {
            message ="Movies Before 1940 must be in Black or White";
            return false;
        }

        //Valid
        return base.TryValidate ( out message );
        //message = "";
        //return true;
    }
    public override string ToString()
    {
        return $"{Title} [{ReleaseYear}]";
    }

}
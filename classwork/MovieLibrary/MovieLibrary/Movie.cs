﻿
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary;

/// <summary>
/// Represents a Movie
/// </summary>
///<remarls>
///ParaGraphs of Descriptions
///</remarls>
public class Movie : IValidatableObject
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
    [Required(AllowEmptyStrings =false)] //Check For Null Approach 1
    [StringLength(100)]
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
        //get {
        //    return _genre ?? "";
        //}
        //set { _genre = value; }
        get => _genre ?? "";
        set => _genre = value;
    }

    /// <summary>
    /// Gets or Sets The Description of Movie
    /// </summary>
    public string Description
    {
        //get {
        //    return _description ?? "";
        //}
        //set {
        //    _description = value;
        //}

        get => _description ?? "";
        set => _description = value;
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
    [StringLength(20)]
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
    [Range(0, Int32.MaxValue, ErrorMessage = "Run Length Must be At Least 0!")]
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
    [Range(MininumReleaseYear, 2100)] //Required Parameters to be used
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
    public bool NeedsIntermission => RunLength >= 150;
    //{
    //    //Run Length >150
    //    get {
    //        return RunLength >= 150;
    //    }
    //    //set {

    //    //}
    //}

 

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
    //public bool TryValidate ( out string message )
    //{
    //    //TODO: Replace Soon
    //    //Title is Required
    //    if (String.IsNullOrEmpty(_title))
    //    {
    //        message = "Title is Required";
    //        return false;
    //    }
    //    //error
    //    //Release Year =1900
    //    if (ReleaseYear < MininumReleaseYear)
    //    {
    //        message = $"Release Year must be >= {MininumReleaseYear}";
    //        return false;
    //    }
    //    //Length >= 0
    //    if (_length < 0)
    //    {
    //        message = "Length must be at least 0";
    //        return false;
    //    }
    //    //Rating is in a list
    //    //If ReleaseYear < 1940 then IsBlackAndWhite must be true
    //    if (ReleaseYear < 1940 && !IsBlackAndWhite)
    //    {
    //        message ="Movies Before 1940 must be in Black or White";
    //        return false;
    //    }

    //    //Valid
    //    //return base.TryValidate ( out message );

    //    message = "";
    //    return false;
    //}
    public override string ToString() => $"{Title} [{ReleaseYear}]";
   

    public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
    {

        //if (String.IsNullOrEmpty(_title))
        //    yield return new ValidationResult("Title is Required");
       
        //if (ReleaseYear < MininumReleaseYear)
        //    yield return new ValidationResult($"Release Year must be >= {MininumReleaseYear}");

        if (_length < 0)
            yield return new ValidationResult("Length must be at least 0");
       
        if (ReleaseYear < 1940 && !IsBlackAndWhite)
            yield return new ValidationResult("Movies Before 1940 must be in Black or White");
    }

}
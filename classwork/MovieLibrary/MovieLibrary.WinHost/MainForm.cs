using MovieLibrary.Memory;

namespace MovieLibrary.WinHost;

public partial class MainForm : Form
{
    public MainForm ()
    {
        InitializeComponent();
    }

    //protected override void OnFormClosing (FormClosingEventArgs e)
    //{
    //    if(_movie != null)
    //    {
    //        if(!Confirm("Exit", "Do You Want to Exit?"))
    //        {
    //            e.Cancel = true;
    //            return;
    //        }
    //    };
    //    base.OnFormClosing(e);
    //}

    protected override void OnLoad ( EventArgs e )
    {
        base.OnLoad(e);

        RefreshMovies(true);
    }

    private void OnFileExit ( object sender, EventArgs e )
    {
        Close();
    }

    private void OnAddMovie ( object sender, EventArgs e )
    {
        var dlg = new MovieForm();

        do
        {


            //ShowDialog = modal
            //Show -modeless
            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }


            //Try This
            try
            {
                //Add Movie to Library
                //_movie = dlg.Movie;
                _database.Add(dlg.Movie);
                break;
            } 
            catch(InvalidOperationException)
            {
                MessageBox.Show(this, "Movie Already Added", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(ArgumentException)
            {
                MessageBox.Show(this, "You Fumbled Tbh", "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                //Error Handling
                MessageBox.Show(this, ex.Message, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            break;
            
            //MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } while (true);

        RefreshMovies();
    }

    private void OnEditMovie ( object sender, EventArgs e )
    {
        var movie = GetSelectedMovie();
        if (movie == null)
        {
            return;
        }

        var dlg = new MovieForm();
        dlg.Movie = movie;


        do
        {


            if (dlg.ShowDialog(this) != DialogResult.OK)
            {
                return;
            }

            //_movie = dlg.Movie;
            //_database.Update(movie.Id, dlg.Movie);
            //break;

            try
            {
                //Add Movie to Library
                //_movie = dlg.Movie;
                _database.Update(movie.Id, dlg.Movie);
                break;
            } 
            catch (Exception ex)
            {
                //Error Handling
                MessageBox.Show(this, ex.Message, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            break;
           
        } while (true);

        RefreshMovies();
    }

    private void OnDeleteMovie ( object sender, EventArgs e )
    {
        var movie = GetSelectedMovie();
        if (movie == null)
            return;

        if (!Confirm("Delete", $"Are You Sure You Want To Delete '{movie.Title}'"))
        {
            return;
        }

        //_movie = null;
        //_database.Delete(movie.Id);
        //RefreshMovies();

        try
        {
            _database.Delete(movie.Id);
            RefreshMovies();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OnHelpAbout ( object sender, EventArgs e )
    {
        var about = new AboutBox();
        about.ShowDialog(this);
    }

    private bool Confirm ( string title, string message )
    {
        return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    }

    private Movie GetSelectedMovie ()
    {
        return _lstMovies.SelectedItem as Movie;
    }

    private void RefreshMovies (bool initial = false)
    {
        //_lstMovies.DataSource = null;
        IEnumerable<Movie> movie = null;
        try
        {
         movie = _database.GetAll();

            if (initial && !movie.Any() && Confirm("Seed", "Do You Want to Seed the Database with movies?"))
            {
                //_database.Seed();
                _database.Seed();

                movie =_database.GetAll();
            }         
                movie = from m in movie orderby m.Title, m.ReleaseYear descending select m;
        } catch
        {
            MessageBox.Show(this, "Unable to Retrieve Movies", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } finally
        {
            _lstMovies.DataSource = movie?.ToArray();
        };
        //HACK: Fix This
        //IEnumerable<Movie> movie = _database.GetAll();

       
        
       // var typedMovies = movies.OfType<Movie>();
       //var source = new BindingSource() { DataSource = movie };
       // movie = movie.OrderBy();

      

        //movie.OrderBy(x => x.Title)
        //    .ThenByDescending(x=> x.ReleaseYear);


        //movie[10] = new Movie() { Title = "Bob" };

        //var movies2 = _database.GetAll();
    }

    private readonly IMovieDatabase _database = new Sql.SqlMovieDatabase(Program.GetConnectionString("MovieDatabase"));

    private void _lstMovies_SelectedIndexChanged ( object sender, EventArgs e )
    {

    }

    //private Movie _movie;
    //private MovieLibrary.Movie _movie;
}
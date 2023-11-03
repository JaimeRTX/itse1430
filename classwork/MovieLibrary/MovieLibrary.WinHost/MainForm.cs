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

            //TODO:Add Movie to Library
            //_movie = dlg.Movie;
            var error = _database.Add(dlg.Movie);
            if (String.IsNullOrEmpty(error))
            {
                break;
            }
            MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            var error = _database.Update(movie.Id, dlg.Movie);
            if (String.IsNullOrEmpty(error))
            {
                break;
            }
            MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        _database.Delete(movie.Id);
        RefreshMovies();
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
        _lstMovies.DataSource = null;

        //HACK: Fix This
        var movie = _database.GetAll();

        if (initial && !movie.Any() && Confirm("Seed", "Do You Want to Seed the Database with movies?"))
        {
            //_database.Seed();
            _database.Seed();

            movie =_database.GetAll();
        }

        // var typedMovies = movies.OfType<Movie>();
        //var source = new BindingSource() { DataSource = movie };


        _lstMovies.DataSource = movie.ToArray();

        //movie[10] = new Movie() { Title = "Bob" };

        //var movies2 = _database.GetAll();
    }

    private IMovieDatabase _database = new MemoryMovieDatabase();

    private void _lstMovies_SelectedIndexChanged ( object sender, EventArgs e )
    {

    }

    //private Movie _movie;
    //private MovieLibrary.Movie _movie;
}
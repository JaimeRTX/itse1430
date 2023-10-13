namespace MovieLibrary.WinHost;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    protected override void OnFormClosing (FormClosingEventArgs e)
    {
        if(_movie != null)
        {
            if(!Confirm("Exit", "Do You Want to Exit?"))
            {
                e.Cancel = true;
                return;
            }
        };
        base.OnFormClosing(e);
    }

    private void OnFileExit ( object sender, EventArgs e )
    {
        Close();
    }

    private void OnAddMovie ( object sender, EventArgs e )
    {
        var dlg = new MovieForm();

        //ShowDialog = modal
        //Show -modeless
        if (dlg.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        //TODO:Add Movie to Library
        _movie = dlg.Movie;
        RefreshMovies();
    }

    private void OnEditMovie ( object sender, EventArgs e )
    {
        var movie = GetSelectedMovie();
        if(movie == null)
        {
            return;
        }

        var dlg = new MovieForm();
        dlg.Movie = movie;

        if (dlg.ShowDialog() != DialogResult.OK)
        {
            return;
        }

        _movie = dlg.Movie;
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

        _movie = null;
        RefreshMovies();
    }

    private void OnHelpAbout (object sender, EventArgs e)
    {
        var about = new AboutBox();
        about.ShowDialog();
    }

    private bool Confirm (string title, string message)
    {
       return MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    }

    private Movie GetSelectedMovie()
    {
        return _movie;
    }

    private void RefreshMovies()
    {
        _lstMovies.DataSource = null;
        
        //HACK: Fix This
        if(_movie != null )
        {
            _lstMovies.DataSource = new[] { _movie };
        }
    }

    private Movie _movie;

    //private Movie _movie;
    //private MovieLibrary.Movie _movie;
}
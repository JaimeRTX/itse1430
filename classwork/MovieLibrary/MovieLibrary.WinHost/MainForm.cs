namespace MovieLibrary.WinHost;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
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
        dlg.ShowDialog();
    }

    private void OnEditMovie ( object sender, EventArgs e )
    {
        MessageBox.Show("Edit Not Implemented");
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

    private Movie _movie = new Movie() { Title = "Jaws" };

    //private Movie _movie;
    //private MovieLibrary.Movie _movie;
}
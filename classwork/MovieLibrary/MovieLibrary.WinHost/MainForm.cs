namespace MovieLibrary.WinHost;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }
    private Movie _movie;

    private void OnAddMovie ( object sender, EventArgs e )
    {
        MessageBox.Show("Add Not Implemented");
    }

    private void OnEditMovie ( object sender, EventArgs e )
    {
        MessageBox.Show("Edit Not Implemented");
    }

    private void OnDeleteMovie ( object sender, EventArgs e )
    {
        MessageBox.Show("Delete Not Implemented");
    }
    //private MovieLibrary.Movie _movie;
}
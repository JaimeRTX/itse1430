using JaimeRodriguez.AdventureGame;

namespace JaimeRodriguez.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }

        private void Form1_Load ( object sender, EventArgs e )
        {
        }
        private void OnHelpAbout ( object sender, EventArgs e )
        {
            var about = new AboutBox();
            about.ShowDialog(this);
        }

        private void OnFileExit ( object sender, EventArgs e )
        {
            Close();
        }

        private void OnAddCharacter( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();
            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

            } while (true);
        }

       
    }
}
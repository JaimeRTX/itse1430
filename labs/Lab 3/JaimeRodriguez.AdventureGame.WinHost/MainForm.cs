using System.Windows.Forms;

using JaimeRodriguez.AdventureGame.Memory;

namespace JaimeRodriguez.AdventureGame.WinHost
{
    public partial class MainForm : Form
    {
        public MainForm ()
        {
            InitializeComponent();
        }


        protected override void OnLoad ( EventArgs e )
        {
            base.OnLoad(e);

            RefreshCharacters();
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

        private void OnAddCharacter ( object sender, EventArgs e )
        {
            var dlg = new CharacterForm();
            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                var error = _database.Add(dlg.Characters);
                if (String.IsNullOrEmpty(error))
                {
                    break;
                }
                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
            RefreshCharacters();
        }

        private void OnEditCharacter ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
            {
                return;
            }
            var dlg = new CharacterForm();
            dlg.Characters = character;

            do
            {
                if (dlg.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                var error = _database.Update(character.CharacterId, dlg.Characters);
                if (String.IsNullOrEmpty(error))
                {
                    break;
                }
                MessageBox.Show(this, error, "Add Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } while (true);
            RefreshCharacters();
        }

        private void OnDeleteCharacter ( object sender, EventArgs e )
        {
            var character = GetSelectedCharacter();
            if (character == null)
            {
                return;
            }
            if (!Confirm("Delete", $"Are You Sure You Want to Delete'{character.Name}'"))
            {
                return;
            }
            _database.Delete(character.CharacterId);
            RefreshCharacters();
        }

        private CharacterDatabase _database = new CharacterDatabase();
        private void RefreshCharacters ()
        {
            _lstCharacters.DataSource = null;

            var character = _database.GetAll();

            var source = new BindingSource { DataSource = character };

            _lstCharacters.DataSource = source;
        }

        private AdventureCharacters GetSelectedCharacter ()
        {
            return _lstCharacters.SelectedItem as AdventureCharacters;
        }

        private bool Confirm ( string title, string message )
        {
            return MessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }


    }
}
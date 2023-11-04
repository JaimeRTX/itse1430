using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JaimeRodriguez.AdventureGame.WinHost;

public partial class CharacterForm : Form
{
    public CharacterForm ()
    {
        InitializeComponent();
    }

    public AdventureCharacters Characters { get; set; }


    private void Form1_Load ( object sender, EventArgs e )
    {

    }

    protected override void OnLoad ( EventArgs e )
    {
        base.OnLoad(e);

        if (Characters != null)
        {
            Text = "Edit Character";
            _txtName.Text = Characters.Name;
            _cbProfession.Text = Characters.Profession;
            _cbRace.Text = Characters.Race;
            _txtStrength.Text = Characters.Strength.ToString();
            _txtInteligence.Text = Characters.Inteligence.ToString();
            _txtAgility.Text = Characters.Agility.ToString();
            _txtConstitution.Text = Characters.Constitution.ToString();
            _txtCharisma.Text = Characters.Charisma.ToString();
        }
        ValidateChildren();
    }

    private void OnSave ( object sender, EventArgs e )
    {
        if (!ValidateChildren())
        {
            DialogResult = DialogResult.None;
            return;
        }

        var button = sender as Button;
        var character = new AdventureCharacters();

        character.Name = _txtName.Text;
        character.Profession = _cbProfession.Text;
        character.Race = _cbRace.Text;

        character.Strength = GetInt32(_txtStrength, 1);
        character.Inteligence = GetInt32(_txtInteligence, 1);
        character.Agility = GetInt32(_txtAgility, 1);
        character.Constitution = GetInt32(_txtConstitution, 1);
        character.Charisma = GetInt32(_txtCharisma, 1);

        if (!ObjectValidator.TryValidate(character, out var results))
        {
            var error = results.First();
            MessageBox.Show(this, error.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            DialogResult = DialogResult.None;
            return;
        }
        Characters = character;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void OnCancel ( object sender, EventArgs e )
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void OnValidateName ( object sender, CancelEventArgs e )
    {
        if (String.IsNullOrEmpty(_txtName.Text))
        {
            _errors.SetError(_txtName, "Character Name is Needed");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_txtName, "");
        }
    }

    private void OnValidateProffession ( object sender, CancelEventArgs e )
    {
        if (String.IsNullOrEmpty(_cbProfession.Text))
        {
            _errors.SetError(_cbProfession, "Choose a Profession");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_cbProfession, "");
        }
    }

    private void OnValidateRace ( object sender, CancelEventArgs e )
    {
        if (String.IsNullOrEmpty(_cbRace.Text))
        {
            _errors.SetError(_cbRace, "Choose a Race");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_cbRace, "");
        }
    }

    private void OnValidateStrength ( object sender, CancelEventArgs e )
    {
        var value = GetInt32(_txtStrength, 1);
        if (value > 100 || value < 1)
        {
            _errors.SetError(_txtStrength, "Strength Stat Must be 1-100");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_txtStrength, "");
        }

    }

    private void OnValidateInteligence ( object sender, CancelEventArgs e )
    {
        var value = GetInt32(_txtInteligence, 1);
        if (value > 100 || value < 1)
        {
            _errors.SetError(_txtInteligence, "Inteligence Stat Must be 1-100");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_txtInteligence, "");
        }

    }

    private void OnValidateAgility ( object sender, CancelEventArgs e )
    {
        var value = GetInt32(_txtAgility, 1);
        if (value > 100 || value < 1)
        {
            _errors.SetError(_txtAgility, "Agility Stat Must be 1-100");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_txtAgility, "");
        }

    }

    private void OnValidateConstitution ( object sender, CancelEventArgs e )
    {
        var value = GetInt32(_txtConstitution, 1);
        if (value > 100 || value < 1)
        {
            _errors.SetError(_txtConstitution, "Constitution Stat Must be 1-100");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_txtConstitution, "");
        }

    }

    private void OnValidateCharisma ( object sender, CancelEventArgs e )
    {
        var value = GetInt32(_txtCharisma, 1);
        if (value > 100 || value < 1)
        {
            _errors.SetError(_txtCharisma, "Charisma Stat Must be 1-100");
            e.Cancel = true;
        } else
        {
            _errors.SetError(_txtCharisma, "");
        }

    }

    private int GetInt32 ( Control control, int defaultValue )
    {
        if (Int32.TryParse(control.Text, out var value))
        {
            return value;
        }

        return defaultValue;
    }

    private void CharacterForm_Load ( object sender, EventArgs e )
    {

    }
}

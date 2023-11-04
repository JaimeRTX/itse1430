namespace JaimeRodriguez.AdventureGame.WinHost
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            components=new System.ComponentModel.Container();
            _txtName=new TextBox();
            _cbProfession=new ComboBox();
            _cbRace=new ComboBox();
            _txtStrength=new TextBox();
            _txtInteligence=new TextBox();
            _txtAgility=new TextBox();
            _txtConstitution=new TextBox();
            _txtCharisma=new TextBox();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            label6=new Label();
            label7=new Label();
            label8=new Label();
            _btnSave=new Button();
            _btnCancel=new Button();
            _errors=new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)_errors).BeginInit();
            SuspendLayout();
            // 
            // _txtName
            // 
            _txtName.Location=new Point(85, 17);
            _txtName.Name="_txtName";
            _txtName.Size=new Size(100, 23);
            _txtName.TabIndex=0;
            _txtName.Validating+=OnValidateName;
            // 
            // _cbProfession
            // 
            _cbProfession.FormattingEnabled=true;
            _cbProfession.Items.AddRange(new object[] { "Athlete", "Priest", "Builder", "Botanist", "Hermit" });
            _cbProfession.Location=new Point(85, 46);
            _cbProfession.Name="_cbProfession";
            _cbProfession.Size=new Size(121, 23);
            _cbProfession.TabIndex=1;
            _cbProfession.Validating+=OnValidateProffession;
            // 
            // _cbRace
            // 
            _cbRace.FormattingEnabled=true;
            _cbRace.Items.AddRange(new object[] { "Human", "Elf", "Astral-Born", "Dwarf", "Dragonborn" });
            _cbRace.Location=new Point(85, 75);
            _cbRace.Name="_cbRace";
            _cbRace.Size=new Size(121, 23);
            _cbRace.TabIndex=2;
            _cbRace.Validating+=OnValidateRace;
            // 
            // _txtStrength
            // 
            _txtStrength.Location=new Point(85, 104);
            _txtStrength.Name="_txtStrength";
            _txtStrength.Size=new Size(100, 23);
            _txtStrength.TabIndex=3;
            _txtStrength.Text="50";
            _txtStrength.Validating+=OnValidateStrength;
            // 
            // _txtInteligence
            // 
            _txtInteligence.Location=new Point(85, 133);
            _txtInteligence.Name="_txtInteligence";
            _txtInteligence.Size=new Size(100, 23);
            _txtInteligence.TabIndex=4;
            _txtInteligence.Text="50";
            _txtInteligence.Validating+=OnValidateInteligence;
            // 
            // _txtAgility
            // 
            _txtAgility.Location=new Point(85, 162);
            _txtAgility.Name="_txtAgility";
            _txtAgility.Size=new Size(100, 23);
            _txtAgility.TabIndex=5;
            _txtAgility.Text="50";
            _txtAgility.Validating+=OnValidateAgility;
            // 
            // _txtConstitution
            // 
            _txtConstitution.Location=new Point(85, 191);
            _txtConstitution.Name="_txtConstitution";
            _txtConstitution.Size=new Size(100, 23);
            _txtConstitution.TabIndex=6;
            _txtConstitution.Text="50";
            _txtConstitution.Validating+=OnValidateConstitution;
            // 
            // _txtCharisma
            // 
            _txtCharisma.Location=new Point(85, 220);
            _txtCharisma.Name="_txtCharisma";
            _txtCharisma.Size=new Size(100, 23);
            _txtCharisma.TabIndex=7;
            _txtCharisma.Text="50";
            _txtCharisma.Validating+=OnValidateCharisma;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(40, 25);
            label1.Name="label1";
            label1.Size=new Size(39, 15);
            label1.TabIndex=8;
            label1.Text="Name";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(17, 54);
            label2.Name="label2";
            label2.Size=new Size(62, 15);
            label2.TabIndex=9;
            label2.Text="Profession";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(47, 83);
            label3.Name="label3";
            label3.Size=new Size(32, 15);
            label3.TabIndex=10;
            label3.Text="Race";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(27, 112);
            label4.Name="label4";
            label4.Size=new Size(52, 15);
            label4.TabIndex=11;
            label4.Text="Strength";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(14, 141);
            label5.Name="label5";
            label5.Size=new Size(65, 15);
            label5.TabIndex=12;
            label5.Text="Inteligence";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(38, 170);
            label6.Name="label6";
            label6.Size=new Size(41, 15);
            label6.TabIndex=13;
            label6.Text="Agility";
            // 
            // label7
            // 
            label7.AutoSize=true;
            label7.Location=new Point(6, 199);
            label7.Name="label7";
            label7.Size=new Size(73, 15);
            label7.TabIndex=14;
            label7.Text="Constitution";
            // 
            // label8
            // 
            label8.AutoSize=true;
            label8.Location=new Point(22, 228);
            label8.Name="label8";
            label8.Size=new Size(57, 15);
            label8.TabIndex=15;
            label8.Text="Charisma";
            // 
            // _btnSave
            // 
            _btnSave.Anchor=AnchorStyles.Bottom|AnchorStyles.Right;
            _btnSave.Location=new Point(47, 249);
            _btnSave.Name="_btnSave";
            _btnSave.Size=new Size(75, 23);
            _btnSave.TabIndex=16;
            _btnSave.Text="Save";
            _btnSave.UseVisualStyleBackColor=true;
            _btnSave.Click+=OnSave;
            // 
            // _btnCancel
            // 
            _btnCancel.Location=new Point(131, 249);
            _btnCancel.Name="_btnCancel";
            _btnCancel.Size=new Size(75, 23);
            _btnCancel.TabIndex=17;
            _btnCancel.Text="Cancel";
            _btnCancel.UseVisualStyleBackColor=true;
            _btnCancel.Click+=OnCancel;
            // 
            // _errors
            // 
            _errors.BlinkStyle=ErrorBlinkStyle.NeverBlink;
            _errors.ContainerControl=this;
            // 
            // CharacterForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(269, 281);
            Controls.Add(_btnCancel);
            Controls.Add(_btnSave);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(_txtCharisma);
            Controls.Add(_txtConstitution);
            Controls.Add(_txtAgility);
            Controls.Add(_txtInteligence);
            Controls.Add(_txtStrength);
            Controls.Add(_cbRace);
            Controls.Add(_cbProfession);
            Controls.Add(_txtName);
            MaximumSize=new Size(300, 330);
            MinimumSize=new Size(285, 320);
            Name="CharacterForm";
            Text="Create New Character";
            Load+=CharacterForm_Load;
            ((System.ComponentModel.ISupportInitialize)_errors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _txtName;
        private ComboBox _cbProfession;
        private ComboBox _cbRace;
        private TextBox _txtStrength;
        private TextBox _txtInteligence;
        private TextBox _txtAgility;
        private TextBox _txtConstitution;
        private TextBox _txtCharisma;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button _btnSave;
        private Button _btnCancel;
        private ErrorProvider _errors;
    }
}
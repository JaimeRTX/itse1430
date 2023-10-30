namespace MovieLibrary.WinHost
{
    partial class MovieForm
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
            _txtTitle=new TextBox();
            _btnSave=new Button();
            _btnCancel=new Button();
            _chkBlackWhite=new CheckBox();
            _txtDescription=new TextBox();
            _txtReleaseYear=new TextBox();
            _txtGenre=new TextBox();
            _cbRating=new ComboBox();
            _txtRunLength=new TextBox();
            label1=new Label();
            label2=new Label();
            label3=new Label();
            label4=new Label();
            label5=new Label();
            label6=new Label();
            _errors=new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)_errors).BeginInit();
            SuspendLayout();
            // 
            // _txtTitle
            // 
            _txtTitle.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right;
            _txtTitle.Location=new Point(89, 12);
            _txtTitle.Name="_txtTitle";
            _txtTitle.Size=new Size(223, 23);
            _txtTitle.TabIndex=0;
            _txtTitle.TextChanged+=_txtTitle_TextChanged;
            _txtTitle.Validating+=OnValidateTitle;
            // 
            // _btnSave
            // 
            _btnSave.Anchor=AnchorStyles.Bottom|AnchorStyles.Right;
            _btnSave.DialogResult=DialogResult.OK;
            _btnSave.Location=new Point(134, 326);
            _btnSave.Name="_btnSave";
            _btnSave.Size=new Size(75, 23);
            _btnSave.TabIndex=7;
            _btnSave.Text="Save";
            _btnSave.UseVisualStyleBackColor=true;
            _btnSave.Click+=OnSave;
            // 
            // _btnCancel
            // 
            _btnCancel.Anchor=AnchorStyles.Bottom|AnchorStyles.Right;
            _btnCancel.CausesValidation=false;
            _btnCancel.DialogResult=DialogResult.Cancel;
            _btnCancel.Location=new Point(237, 326);
            _btnCancel.Name="_btnCancel";
            _btnCancel.Size=new Size(75, 23);
            _btnCancel.TabIndex=8;
            _btnCancel.Text="Cancel";
            _btnCancel.UseVisualStyleBackColor=true;
            _btnCancel.Click+=OnCancel;
            // 
            // _chkBlackWhite
            // 
            _chkBlackWhite.AutoSize=true;
            _chkBlackWhite.Location=new Point(85, 182);
            _chkBlackWhite.Name="_chkBlackWhite";
            _chkBlackWhite.Size=new Size(120, 19);
            _chkBlackWhite.TabIndex=5;
            _chkBlackWhite.Text="Is Black Or White?";
            _chkBlackWhite.UseVisualStyleBackColor=true;
            // 
            // _txtDescription
            // 
            _txtDescription.Anchor=AnchorStyles.Top|AnchorStyles.Bottom|AnchorStyles.Left|AnchorStyles.Right;
            _txtDescription.Location=new Point(84, 211);
            _txtDescription.Multiline=true;
            _txtDescription.Name="_txtDescription";
            _txtDescription.Size=new Size(223, 80);
            _txtDescription.TabIndex=6;
            // 
            // _txtReleaseYear
            // 
            _txtReleaseYear.Location=new Point(89, 82);
            _txtReleaseYear.Name="_txtReleaseYear";
            _txtReleaseYear.Size=new Size(75, 23);
            _txtReleaseYear.TabIndex=2;
            _txtReleaseYear.Validating+=OnValidateReleaseYear;
            // 
            // _txtGenre
            // 
            _txtGenre.Anchor=AnchorStyles.Top|AnchorStyles.Left|AnchorStyles.Right;
            _txtGenre.Location=new Point(85, 114);
            _txtGenre.Name="_txtGenre";
            _txtGenre.Size=new Size(121, 23);
            _txtGenre.TabIndex=3;
            // 
            // _cbRating
            // 
            _cbRating.DropDownStyle=ComboBoxStyle.DropDownList;
            _cbRating.FormattingEnabled=true;
            _cbRating.Items.AddRange(new object[] { "G", "PG", "PG-13", "R" });
            _cbRating.Location=new Point(89, 41);
            _cbRating.Name="_cbRating";
            _cbRating.Size=new Size(75, 23);
            _cbRating.TabIndex=1;
            _cbRating.Validating+=OnValidateRating;
            // 
            // _txtRunLength
            // 
            _txtRunLength.Location=new Point(85, 143);
            _txtRunLength.Name="_txtRunLength";
            _txtRunLength.Size=new Size(75, 23);
            _txtRunLength.TabIndex=4;
            _txtRunLength.Text="0";
            _txtRunLength.Validating+=OnValidateRunLength;
            // 
            // label1
            // 
            label1.AutoSize=true;
            label1.Location=new Point(54, 20);
            label1.Name="label1";
            label1.Size=new Size(29, 15);
            label1.TabIndex=9;
            label1.Text="Title";
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Location=new Point(45, 49);
            label2.Name="label2";
            label2.Size=new Size(38, 15);
            label2.TabIndex=10;
            label2.Text="Ratng";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Location=new Point(12, 211);
            label3.Name="label3";
            label3.Size=new Size(67, 15);
            label3.TabIndex=11;
            label3.Text="Description";
            // 
            // label4
            // 
            label4.AutoSize=true;
            label4.Location=new Point(12, 90);
            label4.Name="label4";
            label4.Size=new Size(71, 15);
            label4.TabIndex=12;
            label4.Text="Release Year";
            // 
            // label5
            // 
            label5.AutoSize=true;
            label5.Location=new Point(41, 117);
            label5.Name="label5";
            label5.Size=new Size(38, 15);
            label5.TabIndex=13;
            label5.Text="Genre";
            // 
            // label6
            // 
            label6.AutoSize=true;
            label6.Location=new Point(11, 146);
            label6.Name="label6";
            label6.Size=new Size(68, 15);
            label6.TabIndex=14;
            label6.Text="Run Length";
            // 
            // _errors
            // 
            _errors.BlinkStyle=ErrorBlinkStyle.NeverBlink;
            _errors.ContainerControl=this;
            // 
            // MovieForm
            // 
            AcceptButton=_btnSave;
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            AutoValidate=AutoValidate.EnableAllowFocusChange;
            CancelButton=_btnCancel;
            ClientSize=new Size(354, 361);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(_txtRunLength);
            Controls.Add(_cbRating);
            Controls.Add(_txtGenre);
            Controls.Add(_txtReleaseYear);
            Controls.Add(_txtDescription);
            Controls.Add(_chkBlackWhite);
            Controls.Add(_btnCancel);
            Controls.Add(_btnSave);
            Controls.Add(_txtTitle);
            MaximizeBox=false;
            MaximumSize=new Size(500, 530);
            MinimizeBox=false;
            MinimumSize=new Size(370, 400);
            Name="MovieForm";
            ShowIcon=false;
            StartPosition=FormStartPosition.CenterParent;
            Text="Add Movie";
            Load+=MovieForm_Load;
            ((System.ComponentModel.ISupportInitialize)_errors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox _txtTitle;
        private Button _btnSave;
        private Button _btnCancel;
        private CheckBox _chkBlackWhite;
        private TextBox _txtDescription;
        private TextBox _txtReleaseYear;
        private TextBox _txtGenre;
        private ComboBox _cbRating;
        private TextBox _txtRunLength;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ErrorProvider _errors;
    }
}
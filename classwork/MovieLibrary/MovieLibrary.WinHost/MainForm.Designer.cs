namespace MovieLibrary.WinHost
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            _mainMenu=new MenuStrip();
            fileToolStripMenuItem=new ToolStripMenuItem();
            exitToolStripMenuItem=new ToolStripMenuItem();
            moviesToolStripMenuItem=new ToolStripMenuItem();
            addToolStripMenuItem=new ToolStripMenuItem();
            editToolStripMenuItem=new ToolStripMenuItem();
            deleteToolStripMenuItem=new ToolStripMenuItem();
            helpToolStripMenuItem=new ToolStripMenuItem();
            aboutToolStripMenuItem=new ToolStripMenuItem();
            _lstMovies=new ListBox();
            _mainMenu.SuspendLayout();
            SuspendLayout();
            // 
            // _mainMenu
            // 
            _mainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, moviesToolStripMenuItem, helpToolStripMenuItem });
            _mainMenu.Location=new Point(0, 0);
            _mainMenu.Name="_mainMenu";
            _mainMenu.Size=new Size(800, 24);
            _mainMenu.TabIndex=0;
            _mainMenu.Text="menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            fileToolStripMenuItem.Name="fileToolStripMenuItem";
            fileToolStripMenuItem.Size=new Size(37, 20);
            fileToolStripMenuItem.Text="&File";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name="exitToolStripMenuItem";
            exitToolStripMenuItem.Size=new Size(93, 22);
            exitToolStripMenuItem.Text="Exit";
            exitToolStripMenuItem.Click+=OnFileExit;
            // 
            // moviesToolStripMenuItem
            // 
            moviesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem, editToolStripMenuItem, deleteToolStripMenuItem });
            moviesToolStripMenuItem.Name="moviesToolStripMenuItem";
            moviesToolStripMenuItem.Size=new Size(57, 20);
            moviesToolStripMenuItem.Text="&Movies";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name="addToolStripMenuItem";
            addToolStripMenuItem.ShortcutKeys=Keys.Insert;
            addToolStripMenuItem.Size=new Size(139, 22);
            addToolStripMenuItem.Text="&Add";
            addToolStripMenuItem.Click+=OnAddMovie;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name="editToolStripMenuItem";
            editToolStripMenuItem.ShortcutKeys=Keys.Alt|Keys.Insert;
            editToolStripMenuItem.Size=new Size(139, 22);
            editToolStripMenuItem.Text="&Edit";
            editToolStripMenuItem.Click+=OnEditMovie;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name="deleteToolStripMenuItem";
            deleteToolStripMenuItem.ShortcutKeys=Keys.Delete;
            deleteToolStripMenuItem.Size=new Size(139, 22);
            deleteToolStripMenuItem.Text="&Delete";
            deleteToolStripMenuItem.Click+=OnDeleteMovie;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            helpToolStripMenuItem.Name="helpToolStripMenuItem";
            helpToolStripMenuItem.ShortcutKeys=Keys.F1;
            helpToolStripMenuItem.Size=new Size(44, 20);
            helpToolStripMenuItem.Text="&Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name="aboutToolStripMenuItem";
            aboutToolStripMenuItem.ShortcutKeys=Keys.F1;
            aboutToolStripMenuItem.Size=new Size(126, 22);
            aboutToolStripMenuItem.Text="&About";
            aboutToolStripMenuItem.Click+=OnHelpAbout;
            // 
            // _lstMovies
            // 
            _lstMovies.Dock=DockStyle.Fill;
            _lstMovies.FormattingEnabled=true;
            _lstMovies.ItemHeight=15;
            _lstMovies.Location=new Point(0, 24);
            _lstMovies.Name="_lstMovies";
            _lstMovies.Size=new Size(800, 426);
            _lstMovies.TabIndex=1;
            _lstMovies.SelectedIndexChanged+=_lstMovies_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(_lstMovies);
            Controls.Add(_mainMenu);
            MainMenuStrip=_mainMenu;
            Name="MainForm";
            Text="Movie Library";
            _mainMenu.ResumeLayout(false);
            _mainMenu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip _mainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem moviesToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ListBox _lstMovies;
    }
}
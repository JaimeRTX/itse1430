namespace JaimeRodriguez.AdventureGame.WinHost
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
            menuStrip1=new MenuStrip();
            toolStripMenuItem1=new ToolStripMenuItem();
            exitToolStripMenuItem=new ToolStripMenuItem();
            charactersToolStripMenuItem=new ToolStripMenuItem();
            addToolStripMenuItem=new ToolStripMenuItem();
            editToolStripMenuItem=new ToolStripMenuItem();
            deleteToolStripMenuItem=new ToolStripMenuItem();
            aboutToolStripMenuItem=new ToolStripMenuItem();
            aboutToolStripMenuItem1=new ToolStripMenuItem();
            listBox1=new ListBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, charactersToolStripMenuItem, aboutToolStripMenuItem });
            menuStrip1.Location=new Point(0, 0);
            menuStrip1.Name="menuStrip1";
            menuStrip1.Size=new Size(800, 24);
            menuStrip1.TabIndex=0;
            menuStrip1.Text="menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { exitToolStripMenuItem });
            toolStripMenuItem1.Name="toolStripMenuItem1";
            toolStripMenuItem1.Size=new Size(42, 20);
            toolStripMenuItem1.Text="Files";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name="exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys=Keys.Shift|Keys.Delete;
            exitToolStripMenuItem.Size=new Size(149, 22);
            exitToolStripMenuItem.Text="Exit";
            exitToolStripMenuItem.Click+=OnFileExit;
            // 
            // charactersToolStripMenuItem
            // 
            charactersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { addToolStripMenuItem, editToolStripMenuItem, deleteToolStripMenuItem });
            charactersToolStripMenuItem.Name="charactersToolStripMenuItem";
            charactersToolStripMenuItem.Size=new Size(75, 20);
            charactersToolStripMenuItem.Text="Characters";
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name="addToolStripMenuItem";
            addToolStripMenuItem.Size=new Size(107, 22);
            addToolStripMenuItem.Text="Add";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name="editToolStripMenuItem";
            editToolStripMenuItem.Size=new Size(107, 22);
            editToolStripMenuItem.Text="Edit";
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name="deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size=new Size(107, 22);
            deleteToolStripMenuItem.Text="Delete";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name="aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size=new Size(44, 20);
            aboutToolStripMenuItem.Text="Help";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name="aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.ShortcutKeys=Keys.F1;
            aboutToolStripMenuItem1.Size=new Size(126, 22);
            aboutToolStripMenuItem1.Text="About";
            aboutToolStripMenuItem1.Click+=OnHelpAbout;
            // 
            // listBox1
            // 
            listBox1.Dock=DockStyle.Fill;
            listBox1.FormattingEnabled=true;
            listBox1.ItemHeight=15;
            listBox1.Location=new Point(0, 24);
            listBox1.Name="listBox1";
            listBox1.Size=new Size(800, 426);
            listBox1.TabIndex=1;
            // 
            // MainForm
            // 
            AutoScaleDimensions=new SizeF(7F, 15F);
            AutoScaleMode=AutoScaleMode.Font;
            ClientSize=new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip=menuStrip1;
            Name="MainForm";
            Text="Jaime Rodriguez Adventure Game";
            Load+=Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem charactersToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private ListBox listBox1;
    }
}
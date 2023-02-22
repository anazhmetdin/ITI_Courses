namespace ProductsView
{
    partial class FrmGridView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
        private void InitializeComponent()
        {
            GridView = new DataGridView();
            menuStrip1 = new MenuStrip();
            saveToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)GridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // GridView
            // 
            GridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridView.Dock = DockStyle.Fill;
            GridView.Location = new Point(0, 28);
            GridView.Name = "GridView";
            GridView.RowHeadersWidth = 51;
            GridView.RowTemplate.Height = 29;
            GridView.Size = new Size(800, 422);
            GridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { saveToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(52, 24);
            saveToolStripMenuItem.Text = "save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // FrmGridView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmGridView";
            Text = "Form1";
            Load += FrmGridView_Load;
            ((System.ComponentModel.ISupportInitialize)GridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView GridView;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveToolStripMenuItem;
    }
}
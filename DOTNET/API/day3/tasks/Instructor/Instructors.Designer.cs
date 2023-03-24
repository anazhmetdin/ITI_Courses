namespace Instructor
{
    partial class Instructors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            GridInstructors = new DataGridView();
            menuStrip2 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)GridInstructors).BeginInit();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // GridInstructors
            // 
            GridInstructors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridInstructors.Dock = DockStyle.Fill;
            GridInstructors.Location = new Point(0, 28);
            GridInstructors.Name = "GridInstructors";
            GridInstructors.RowHeadersWidth = 51;
            GridInstructors.RowTemplate.Height = 29;
            GridInstructors.Size = new Size(800, 422);
            GridInstructors.TabIndex = 0;
            // 
            // menuStrip2
            // 
            menuStrip2.ImageScalingSize = new Size(20, 20);
            menuStrip2.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, addToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(800, 28);
            menuStrip2.TabIndex = 1;
            menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(54, 24);
            toolStripMenuItem1.Text = "Save";
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(51, 24);
            addToolStripMenuItem.Text = "Add";
            addToolStripMenuItem.Click += addToolStripMenuItem_Click;
            // 
            // Instructors
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(GridInstructors);
            Controls.Add(menuStrip2);
            MainMenuStrip = menuStrip2;
            Name = "Instructors";
            Text = "Instructors";
            Load += Instructors_Load;
            ((System.ComponentModel.ISupportInitialize)GridInstructors).EndInit();
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView GridInstructors;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem saveToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem addToolStripMenuItem;
    }
}
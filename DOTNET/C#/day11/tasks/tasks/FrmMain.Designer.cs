namespace tasks
{
    partial class FrmMain
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
            this.BtnDialogs = new System.Windows.Forms.Button();
            this.btnPain = new System.Windows.Forms.Button();
            this.BtnDragable = new System.Windows.Forms.Button();
            this.BtnMickey = new System.Windows.Forms.Button();
            this.BtnBall = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDialogs
            // 
            this.BtnDialogs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnDialogs.Location = new System.Drawing.Point(56, 363);
            this.BtnDialogs.Name = "BtnDialogs";
            this.BtnDialogs.Size = new System.Drawing.Size(125, 51);
            this.BtnDialogs.TabIndex = 0;
            this.BtnDialogs.Text = "Dialogs";
            this.BtnDialogs.UseVisualStyleBackColor = true;
            this.BtnDialogs.Click += new System.EventHandler(this.BtnDialogs_Click);
            // 
            // btnPain
            // 
            this.btnPain.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPain.Location = new System.Drawing.Point(196, 363);
            this.btnPain.Name = "btnPain";
            this.btnPain.Size = new System.Drawing.Size(125, 51);
            this.btnPain.TabIndex = 1;
            this.btnPain.Text = "Paint";
            this.btnPain.UseVisualStyleBackColor = true;
            this.btnPain.Click += new System.EventHandler(this.btnPain_Click);
            // 
            // BtnDragable
            // 
            this.BtnDragable.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnDragable.Location = new System.Drawing.Point(336, 363);
            this.BtnDragable.Name = "BtnDragable";
            this.BtnDragable.Size = new System.Drawing.Size(125, 51);
            this.BtnDragable.TabIndex = 2;
            this.BtnDragable.Text = "Dragable";
            this.BtnDragable.UseVisualStyleBackColor = true;
            this.BtnDragable.Click += new System.EventHandler(this.BtnDragable_Click);
            // 
            // BtnMickey
            // 
            this.BtnMickey.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnMickey.Location = new System.Drawing.Point(476, 363);
            this.BtnMickey.Name = "BtnMickey";
            this.BtnMickey.Size = new System.Drawing.Size(125, 51);
            this.BtnMickey.TabIndex = 3;
            this.BtnMickey.Text = "Mickey";
            this.BtnMickey.UseVisualStyleBackColor = true;
            this.BtnMickey.Click += new System.EventHandler(this.BtnMickey_Click);
            // 
            // BtnBall
            // 
            this.BtnBall.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BtnBall.Location = new System.Drawing.Point(616, 363);
            this.BtnBall.Name = "BtnBall";
            this.BtnBall.Size = new System.Drawing.Size(125, 51);
            this.BtnBall.TabIndex = 4;
            this.BtnBall.Text = "Ball";
            this.BtnBall.UseVisualStyleBackColor = true;
            this.BtnBall.Click += new System.EventHandler(this.BtnBall_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnBall);
            this.Controls.Add(this.BtnMickey);
            this.Controls.Add(this.BtnDragable);
            this.Controls.Add(this.btnPain);
            this.Controls.Add(this.BtnDialogs);
            this.MinimumSize = new System.Drawing.Size(700, 200);
            this.Name = "FrmMain";
            this.Text = "D11 tasks";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnDialogs;
        private Button btnPain;
        private Button BtnDragable;
        private Button BtnMickey;
        private Button BtnBall;
    }
}
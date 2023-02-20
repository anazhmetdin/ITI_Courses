namespace tasks
{
    partial class FrmPaint
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
            this.BtnColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnColor
            // 
            this.BtnColor.Location = new System.Drawing.Point(1, 421);
            this.BtnColor.Name = "BtnColor";
            this.BtnColor.Size = new System.Drawing.Size(94, 29);
            this.BtnColor.TabIndex = 0;
            this.BtnColor.Text = "Color";
            this.BtnColor.UseVisualStyleBackColor = true;
            this.BtnColor.Click += new System.EventHandler(this.BtnColor_Click);
            // 
            // FrmPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnColor);
            this.Name = "FrmPaint";
            this.Text = "Paint";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Paint_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Paint_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmPaint_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnColor;
    }
}
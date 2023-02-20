namespace tasks
{
    partial class FrmMickey
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
            this.BtnMove = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnMove
            // 
            this.BtnMove.Location = new System.Drawing.Point(152, 75);
            this.BtnMove.Margin = new System.Windows.Forms.Padding(7);
            this.BtnMove.Name = "BtnMove";
            this.BtnMove.Size = new System.Drawing.Size(61, 65);
            this.BtnMove.TabIndex = 0;
            this.BtnMove.Text = "+";
            this.BtnMove.UseVisualStyleBackColor = true;
            this.BtnMove.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMove_MouseDown);
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(227, 75);
            this.BtnClose.Margin = new System.Windows.Forms.Padding(7);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(61, 65);
            this.BtnClose.TabIndex = 1;
            this.BtnClose.Text = "x";
            this.BtnClose.UseVisualStyleBackColor = true;
            // 
            // FrmMickey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnClose;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BtnMove);
            this.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "FrmMickey";
            this.Text = "FrmMickey";
            this.ResumeLayout(false);

        }

        #endregion

        private Button BtnMove;
        private Button BtnClose;
    }
}
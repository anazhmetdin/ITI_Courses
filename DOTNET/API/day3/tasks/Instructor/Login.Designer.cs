namespace Instructor
{
    partial class Login
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
            email = new TextBox();
            password = new TextBox();
            loginBtn = new Button();
            SuspendLayout();
            // 
            // email
            // 
            email.Location = new Point(256, 149);
            email.Name = "email";
            email.PlaceholderText = "Email";
            email.Size = new Size(257, 27);
            email.TabIndex = 0;
            // 
            // password
            // 
            password.Location = new Point(256, 216);
            password.Name = "password";
            password.PasswordChar = '*';
            password.PlaceholderText = "password";
            password.Size = new Size(257, 27);
            password.TabIndex = 1;
            // 
            // loginBtn
            // 
            loginBtn.Location = new Point(340, 280);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(94, 29);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = true;
            loginBtn.Click += loginBtn_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginBtn);
            Controls.Add(password);
            Controls.Add(email);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox email;
        private TextBox password;
        private Button loginBtn;
    }
}
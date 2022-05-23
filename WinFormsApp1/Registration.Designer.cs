namespace WinFormsApp1
{
    partial class Registration
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
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.retryPasswordTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.emailErrorTextBox = new System.Windows.Forms.TextBox();
            this.passwordErrorTextBox = new System.Windows.Forms.TextBox();
            this.retryPasswordErrorTextBox = new System.Windows.Forms.TextBox();
            this.lastNameErrorTextBox = new System.Windows.Forms.TextBox();
            this.firstNameErrorTextBox = new System.Windows.Forms.TextBox();
            this.usernameErrorTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(12, 12);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.PlaceholderText = "Email";
            this.emailTextBox.Size = new System.Drawing.Size(267, 23);
            this.emailTextBox.TabIndex = 0;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(12, 99);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.PlaceholderText = "Username";
            this.usernameTextBox.Size = new System.Drawing.Size(267, 23);
            this.usernameTextBox.TabIndex = 1;
            // 
            // retryPasswordTextBox
            // 
            this.retryPasswordTextBox.Location = new System.Drawing.Point(12, 70);
            this.retryPasswordTextBox.Name = "retryPasswordTextBox";
            this.retryPasswordTextBox.PlaceholderText = "Retry password";
            this.retryPasswordTextBox.Size = new System.Drawing.Size(267, 23);
            this.retryPasswordTextBox.TabIndex = 3;
            this.retryPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(12, 41);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PlaceholderText = "Password";
            this.passwordTextBox.Size = new System.Drawing.Size(267, 23);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(12, 157);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.PlaceholderText = "Last name";
            this.lastNameTextBox.Size = new System.Drawing.Size(267, 23);
            this.lastNameTextBox.TabIndex = 5;
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(12, 128);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.PlaceholderText = "First name";
            this.firstNameTextBox.Size = new System.Drawing.Size(267, 23);
            this.firstNameTextBox.TabIndex = 4;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(12, 202);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(120, 33);
            this.registerButton.TabIndex = 6;
            this.registerButton.Text = "Register";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.Registration_Click);
            // 
            // emailErrorTextBox
            // 
            this.emailErrorTextBox.Location = new System.Drawing.Point(285, 12);
            this.emailErrorTextBox.Name = "emailErrorTextBox";
            this.emailErrorTextBox.ReadOnly = true;
            this.emailErrorTextBox.Size = new System.Drawing.Size(373, 23);
            this.emailErrorTextBox.TabIndex = 8;
            // 
            // passwordErrorTextBox
            // 
            this.passwordErrorTextBox.Location = new System.Drawing.Point(285, 41);
            this.passwordErrorTextBox.Name = "passwordErrorTextBox";
            this.passwordErrorTextBox.ReadOnly = true;
            this.passwordErrorTextBox.Size = new System.Drawing.Size(373, 23);
            this.passwordErrorTextBox.TabIndex = 9;
            // 
            // retryPasswordErrorTextBox
            // 
            this.retryPasswordErrorTextBox.Location = new System.Drawing.Point(285, 70);
            this.retryPasswordErrorTextBox.Name = "retryPasswordErrorTextBox";
            this.retryPasswordErrorTextBox.ReadOnly = true;
            this.retryPasswordErrorTextBox.Size = new System.Drawing.Size(373, 23);
            this.retryPasswordErrorTextBox.TabIndex = 10;
            // 
            // lastNameErrorTextBox
            // 
            this.lastNameErrorTextBox.Location = new System.Drawing.Point(285, 157);
            this.lastNameErrorTextBox.Name = "lastNameErrorTextBox";
            this.lastNameErrorTextBox.ReadOnly = true;
            this.lastNameErrorTextBox.Size = new System.Drawing.Size(373, 23);
            this.lastNameErrorTextBox.TabIndex = 13;
            // 
            // firstNameErrorTextBox
            // 
            this.firstNameErrorTextBox.Location = new System.Drawing.Point(285, 128);
            this.firstNameErrorTextBox.Name = "firstNameErrorTextBox";
            this.firstNameErrorTextBox.ReadOnly = true;
            this.firstNameErrorTextBox.Size = new System.Drawing.Size(373, 23);
            this.firstNameErrorTextBox.TabIndex = 12;
            // 
            // usernameErrorTextBox
            // 
            this.usernameErrorTextBox.Location = new System.Drawing.Point(285, 99);
            this.usernameErrorTextBox.Name = "usernameErrorTextBox";
            this.usernameErrorTextBox.ReadOnly = true;
            this.usernameErrorTextBox.Size = new System.Drawing.Size(373, 23);
            this.usernameErrorTextBox.TabIndex = 11;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lastNameErrorTextBox);
            this.Controls.Add(this.firstNameErrorTextBox);
            this.Controls.Add(this.usernameErrorTextBox);
            this.Controls.Add(this.retryPasswordErrorTextBox);
            this.Controls.Add(this.passwordErrorTextBox);
            this.Controls.Add(this.emailErrorTextBox);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.retryPasswordTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.emailTextBox);
            this.Name = "Registration";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox emailTextBox;
        private TextBox usernameTextBox;
        private TextBox retryPasswordTextBox;
        private TextBox passwordTextBox;
        private TextBox lastNameTextBox;
        private TextBox firstNameTextBox;
        private Button registerButton;
        private TextBox emailErrorTextBox;
        private TextBox passwordErrorTextBox;
        private TextBox retryPasswordErrorTextBox;
        private TextBox lastNameErrorTextBox;
        private TextBox firstNameErrorTextBox;
        private TextBox usernameErrorTextBox;
    }
}
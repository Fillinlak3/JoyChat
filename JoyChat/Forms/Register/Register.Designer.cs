namespace JoyChat.Forms.Register
{
    partial class Register
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
            TB_Password = new TextBox();
            TB_Username = new TextBox();
            TB_Email = new TextBox();
            TB_DisplayName = new TextBox();
            TB_ConfirmPassword = new TextBox();
            BTN_Register = new Button();
            CB_Agree = new CheckBox();
            SuspendLayout();
            // 
            // TB_Password
            // 
            TB_Password.BackColor = Color.FromArgb(16, 68, 85);
            TB_Password.BorderStyle = BorderStyle.None;
            TB_Password.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Password.ForeColor = Color.White;
            TB_Password.Location = new Point(70, 302);
            TB_Password.Name = "TB_Password";
            TB_Password.PasswordChar = '*';
            TB_Password.PlaceholderText = "Password";
            TB_Password.Size = new Size(400, 54);
            TB_Password.TabIndex = 3;
            TB_Password.TextAlign = HorizontalAlignment.Center;
            // 
            // TB_Username
            // 
            TB_Username.BackColor = Color.FromArgb(16, 68, 85);
            TB_Username.BorderStyle = BorderStyle.None;
            TB_Username.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Username.ForeColor = Color.White;
            TB_Username.Location = new Point(70, 142);
            TB_Username.Name = "TB_Username";
            TB_Username.PlaceholderText = "Username";
            TB_Username.Size = new Size(400, 54);
            TB_Username.TabIndex = 1;
            TB_Username.TextAlign = HorizontalAlignment.Center;
            // 
            // TB_Email
            // 
            TB_Email.BackColor = Color.FromArgb(16, 68, 85);
            TB_Email.BorderStyle = BorderStyle.None;
            TB_Email.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Email.ForeColor = Color.White;
            TB_Email.Location = new Point(70, 62);
            TB_Email.Name = "TB_Email";
            TB_Email.PlaceholderText = "Email";
            TB_Email.Size = new Size(400, 54);
            TB_Email.TabIndex = 0;
            TB_Email.TextAlign = HorizontalAlignment.Center;
            // 
            // TB_DisplayName
            // 
            TB_DisplayName.BackColor = Color.FromArgb(16, 68, 85);
            TB_DisplayName.BorderStyle = BorderStyle.None;
            TB_DisplayName.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TB_DisplayName.ForeColor = Color.White;
            TB_DisplayName.Location = new Point(70, 222);
            TB_DisplayName.Name = "TB_DisplayName";
            TB_DisplayName.PlaceholderText = "Display Name";
            TB_DisplayName.Size = new Size(400, 54);
            TB_DisplayName.TabIndex = 2;
            TB_DisplayName.TextAlign = HorizontalAlignment.Center;
            // 
            // TB_ConfirmPassword
            // 
            TB_ConfirmPassword.BackColor = Color.FromArgb(16, 68, 85);
            TB_ConfirmPassword.BorderStyle = BorderStyle.None;
            TB_ConfirmPassword.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TB_ConfirmPassword.ForeColor = Color.White;
            TB_ConfirmPassword.Location = new Point(70, 382);
            TB_ConfirmPassword.Name = "TB_ConfirmPassword";
            TB_ConfirmPassword.PasswordChar = '*';
            TB_ConfirmPassword.PlaceholderText = "Confirm Password";
            TB_ConfirmPassword.Size = new Size(400, 54);
            TB_ConfirmPassword.TabIndex = 4;
            TB_ConfirmPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // BTN_Register
            // 
            BTN_Register.BackColor = Color.Teal;
            BTN_Register.FlatAppearance.BorderSize = 0;
            BTN_Register.FlatStyle = FlatStyle.Flat;
            BTN_Register.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Register.ForeColor = Color.DeepSkyBlue;
            BTN_Register.Location = new Point(70, 462);
            BTN_Register.Name = "BTN_Register";
            BTN_Register.Size = new Size(400, 80);
            BTN_Register.TabIndex = 6;
            BTN_Register.Text = "REGISTER ACCOUNT";
            BTN_Register.UseVisualStyleBackColor = false;
            BTN_Register.Click += Register_Click;
            // 
            // CB_Agree
            // 
            CB_Agree.AutoSize = true;
            CB_Agree.FlatAppearance.BorderSize = 0;
            CB_Agree.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CB_Agree.ForeColor = SystemColors.ControlDark;
            CB_Agree.Location = new Point(600, 510);
            CB_Agree.Name = "CB_Agree";
            CB_Agree.Size = new Size(303, 32);
            CB_Agree.TabIndex = 5;
            CB_Agree.Text = "Agree to Terms and Conditions";
            CB_Agree.UseVisualStyleBackColor = true;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.FromArgb(10, 52, 66);
            ClientSize = new Size(1000, 600);
            Controls.Add(CB_Agree);
            Controls.Add(BTN_Register);
            Controls.Add(TB_ConfirmPassword);
            Controls.Add(TB_DisplayName);
            Controls.Add(TB_Email);
            Controls.Add(TB_Password);
            Controls.Add(TB_Username);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_Password;
        private TextBox TB_Username;
        private TextBox TB_Email;
        private TextBox TB_DisplayName;
        private TextBox TB_ConfirmPassword;
        private Button BTN_Register;
        private CheckBox CB_Agree;
    }
}
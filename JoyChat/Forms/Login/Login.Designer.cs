namespace JoyChat.Forms.Login
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
            TB_Username = new TextBox();
            TB_Password = new TextBox();
            BTN_Register = new Button();
            BTN_Login = new Button();
            LB_Exit = new Label();
            SuspendLayout();
            // 
            // TB_Username
            // 
            TB_Username.BackColor = Color.FromArgb(16, 68, 85);
            TB_Username.BorderStyle = BorderStyle.None;
            TB_Username.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Username.ForeColor = Color.White;
            TB_Username.Location = new Point(510, 220);
            TB_Username.Name = "TB_Username";
            TB_Username.PlaceholderText = "Username";
            TB_Username.Size = new Size(400, 54);
            TB_Username.TabIndex = 0;
            TB_Username.TextAlign = HorizontalAlignment.Center;
            TB_Username.KeyUp += DebugAutoLogin;
            // 
            // TB_Password
            // 
            TB_Password.BackColor = Color.FromArgb(16, 68, 85);
            TB_Password.BorderStyle = BorderStyle.None;
            TB_Password.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Password.ForeColor = Color.White;
            TB_Password.Location = new Point(510, 300);
            TB_Password.Name = "TB_Password";
            TB_Password.PasswordChar = '*';
            TB_Password.PlaceholderText = "Password";
            TB_Password.Size = new Size(400, 54);
            TB_Password.TabIndex = 1;
            TB_Password.TextAlign = HorizontalAlignment.Center;
            TB_Password.KeyPress += TB_Password_KeyPress;
            // 
            // BTN_Register
            // 
            BTN_Register.BackColor = Color.Teal;
            BTN_Register.FlatAppearance.BorderSize = 0;
            BTN_Register.FlatStyle = FlatStyle.Flat;
            BTN_Register.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Register.ForeColor = Color.DeepSkyBlue;
            BTN_Register.Location = new Point(715, 380);
            BTN_Register.Name = "BTN_Register";
            BTN_Register.Size = new Size(195, 80);
            BTN_Register.TabIndex = 3;
            BTN_Register.TabStop = false;
            BTN_Register.Text = "REGISTER";
            BTN_Register.UseVisualStyleBackColor = false;
            BTN_Register.Click += Register_Click;
            // 
            // BTN_Login
            // 
            BTN_Login.BackColor = Color.Teal;
            BTN_Login.FlatAppearance.BorderSize = 0;
            BTN_Login.FlatStyle = FlatStyle.Flat;
            BTN_Login.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            BTN_Login.ForeColor = Color.DeepSkyBlue;
            BTN_Login.Location = new Point(510, 380);
            BTN_Login.Name = "BTN_Login";
            BTN_Login.Size = new Size(195, 80);
            BTN_Login.TabIndex = 2;
            BTN_Login.Text = "LOGIN";
            BTN_Login.UseVisualStyleBackColor = false;
            BTN_Login.Click += Login_Click;
            // 
            // LB_Exit
            // 
            LB_Exit.AutoSize = true;
            LB_Exit.Font = new Font("Forte", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            LB_Exit.ForeColor = Color.Teal;
            LB_Exit.Location = new Point(954, 9);
            LB_Exit.Name = "LB_Exit";
            LB_Exit.Size = new Size(34, 31);
            LB_Exit.TabIndex = 4;
            LB_Exit.Text = "X";
            LB_Exit.Click += Exit;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.FromArgb(10, 52, 66);
            ClientSize = new Size(1000, 600);
            Controls.Add(LB_Exit);
            Controls.Add(BTN_Login);
            Controls.Add(BTN_Register);
            Controls.Add(TB_Password);
            Controls.Add(TB_Username);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            KeyPreview = true;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_Username;
        private TextBox TB_Password;
        private Button BTN_Register;
        private Button BTN_Login;
        private Label LB_Exit;
    }
}
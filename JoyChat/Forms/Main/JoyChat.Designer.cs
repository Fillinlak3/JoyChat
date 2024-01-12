namespace JoyChat.Forms.Main
{
    partial class JoyChat
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
            PANEL_LeftSide = new Panel();
            PANEL_Conversations = new Panel();
            PANEL_LeftSide_Top_Menu = new Panel();
            PANEL_TB_Placeholder = new Panel();
            TB_Email = new TextBox();
            pictureBox1 = new PictureBox();
            PANEL_EDGE_LEFT = new Panel();
            PANEL_EDGE_RIGHT = new Panel();
            PANEL_EDGE_TOP = new Panel();
            PANEL_EDGE_BOTTOM = new Panel();
            PANEL_Chat = new Panel();
            PANEL_Chat_Messages = new Panel();
            panel2 = new Panel();
            textBox2 = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            textBox1 = new TextBox();
            Panel_Chat_Top = new Panel();
            LABEL_Chat_FriendName = new Label();
            pictureBox3 = new PictureBox();
            PANEL_Chat_Bottom = new Panel();
            TB_SendMessage = new TextBox();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            PANEL_LeftSide.SuspendLayout();
            PANEL_LeftSide_Top_Menu.SuspendLayout();
            PANEL_TB_Placeholder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            PANEL_Chat.SuspendLayout();
            PANEL_Chat_Messages.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            Panel_Chat_Top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            PANEL_Chat_Bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // PANEL_LeftSide
            // 
            PANEL_LeftSide.Controls.Add(PANEL_Conversations);
            PANEL_LeftSide.Controls.Add(PANEL_LeftSide_Top_Menu);
            PANEL_LeftSide.Dock = DockStyle.Left;
            PANEL_LeftSide.Location = new Point(20, 20);
            PANEL_LeftSide.Name = "PANEL_LeftSide";
            PANEL_LeftSide.Size = new Size(500, 713);
            PANEL_LeftSide.TabIndex = 0;
            // 
            // PANEL_Conversations
            // 
            PANEL_Conversations.AutoScroll = true;
            PANEL_Conversations.BackColor = Color.FromArgb(17, 27, 33);
            PANEL_Conversations.Dock = DockStyle.Fill;
            PANEL_Conversations.Location = new Point(0, 150);
            PANEL_Conversations.Name = "PANEL_Conversations";
            PANEL_Conversations.Size = new Size(500, 563);
            PANEL_Conversations.TabIndex = 0;
            // 
            // PANEL_LeftSide_Top_Menu
            // 
            PANEL_LeftSide_Top_Menu.BackColor = Color.FromArgb(32, 44, 51);
            PANEL_LeftSide_Top_Menu.Controls.Add(PANEL_TB_Placeholder);
            PANEL_LeftSide_Top_Menu.Controls.Add(pictureBox1);
            PANEL_LeftSide_Top_Menu.Dock = DockStyle.Top;
            PANEL_LeftSide_Top_Menu.Location = new Point(0, 0);
            PANEL_LeftSide_Top_Menu.Name = "PANEL_LeftSide_Top_Menu";
            PANEL_LeftSide_Top_Menu.Size = new Size(500, 150);
            PANEL_LeftSide_Top_Menu.TabIndex = 0;
            // 
            // PANEL_TB_Placeholder
            // 
            PANEL_TB_Placeholder.BackColor = Color.FromArgb(17, 27, 33);
            PANEL_TB_Placeholder.Controls.Add(TB_Email);
            PANEL_TB_Placeholder.Dock = DockStyle.Bottom;
            PANEL_TB_Placeholder.Location = new Point(0, 90);
            PANEL_TB_Placeholder.Name = "PANEL_TB_Placeholder";
            PANEL_TB_Placeholder.Size = new Size(500, 60);
            PANEL_TB_Placeholder.TabIndex = 1;
            // 
            // TB_Email
            // 
            TB_Email.BackColor = Color.FromArgb(32, 44, 51);
            TB_Email.BorderStyle = BorderStyle.None;
            TB_Email.Cursor = Cursors.IBeam;
            TB_Email.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            TB_Email.ForeColor = Color.White;
            TB_Email.Location = new Point(20, 12);
            TB_Email.Name = "TB_Email";
            TB_Email.PlaceholderText = "Search or start a new chat";
            TB_Email.Size = new Size(435, 36);
            TB_Email.TabIndex = 0;
            TB_Email.TabStop = false;
            TB_Email.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(10, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(80, 80);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // PANEL_EDGE_LEFT
            // 
            PANEL_EDGE_LEFT.BackColor = Color.FromArgb(12, 19, 23);
            PANEL_EDGE_LEFT.Dock = DockStyle.Left;
            PANEL_EDGE_LEFT.Location = new Point(0, 20);
            PANEL_EDGE_LEFT.Name = "PANEL_EDGE_LEFT";
            PANEL_EDGE_LEFT.Size = new Size(20, 713);
            PANEL_EDGE_LEFT.TabIndex = 0;
            // 
            // PANEL_EDGE_RIGHT
            // 
            PANEL_EDGE_RIGHT.BackColor = Color.FromArgb(12, 19, 23);
            PANEL_EDGE_RIGHT.Dock = DockStyle.Right;
            PANEL_EDGE_RIGHT.Location = new Point(1562, 0);
            PANEL_EDGE_RIGHT.Name = "PANEL_EDGE_RIGHT";
            PANEL_EDGE_RIGHT.Size = new Size(20, 733);
            PANEL_EDGE_RIGHT.TabIndex = 0;
            // 
            // PANEL_EDGE_TOP
            // 
            PANEL_EDGE_TOP.BackColor = Color.FromArgb(12, 19, 23);
            PANEL_EDGE_TOP.Dock = DockStyle.Top;
            PANEL_EDGE_TOP.Location = new Point(0, 0);
            PANEL_EDGE_TOP.Name = "PANEL_EDGE_TOP";
            PANEL_EDGE_TOP.Size = new Size(1562, 20);
            PANEL_EDGE_TOP.TabIndex = 0;
            // 
            // PANEL_EDGE_BOTTOM
            // 
            PANEL_EDGE_BOTTOM.BackColor = Color.FromArgb(12, 19, 23);
            PANEL_EDGE_BOTTOM.Dock = DockStyle.Bottom;
            PANEL_EDGE_BOTTOM.Location = new Point(0, 733);
            PANEL_EDGE_BOTTOM.Name = "PANEL_EDGE_BOTTOM";
            PANEL_EDGE_BOTTOM.Size = new Size(1582, 20);
            PANEL_EDGE_BOTTOM.TabIndex = 0;
            // 
            // PANEL_Chat
            // 
            PANEL_Chat.BackColor = Color.Transparent;
            PANEL_Chat.BackgroundImage = Properties.Resources.chat_background;
            PANEL_Chat.Controls.Add(PANEL_Chat_Messages);
            PANEL_Chat.Controls.Add(Panel_Chat_Top);
            PANEL_Chat.Controls.Add(PANEL_Chat_Bottom);
            PANEL_Chat.Dock = DockStyle.Fill;
            PANEL_Chat.Location = new Point(520, 20);
            PANEL_Chat.Name = "PANEL_Chat";
            PANEL_Chat.Size = new Size(1042, 713);
            PANEL_Chat.TabIndex = 1;
            // 
            // PANEL_Chat_Messages
            // 
            PANEL_Chat_Messages.AutoScroll = true;
            PANEL_Chat_Messages.Controls.Add(panel2);
            PANEL_Chat_Messages.Controls.Add(panel1);
            PANEL_Chat_Messages.Dock = DockStyle.Fill;
            PANEL_Chat_Messages.Location = new Point(0, 90);
            PANEL_Chat_Messages.Name = "PANEL_Chat_Messages";
            PANEL_Chat_Messages.Size = new Size(1042, 543);
            PANEL_Chat_Messages.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(label2);
            panel2.Controls.Add(textBox2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 100);
            panel2.Name = "panel2";
            panel2.Size = new Size(1042, 100);
            panel2.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(0, 92, 75);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(822, 35);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(170, 30);
            textBox2.TabIndex = 4;
            textBox2.Text = "Your message";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1042, 100);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(32, 44, 51);
            label1.Font = new Font("Segoe UI", 4.20000029F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(773, 54);
            label1.Name = "label1";
            label1.Size = new Size(32, 11);
            label1.TabIndex = 3;
            label1.Text = "1:11 PM";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(32, 44, 51);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(50, 35);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(755, 25);
            textBox1.TabIndex = 2;
            textBox1.Text = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdas";
            // 
            // Panel_Chat_Top
            // 
            Panel_Chat_Top.BackColor = Color.FromArgb(32, 44, 51);
            Panel_Chat_Top.Controls.Add(LABEL_Chat_FriendName);
            Panel_Chat_Top.Controls.Add(pictureBox3);
            Panel_Chat_Top.Dock = DockStyle.Top;
            Panel_Chat_Top.Location = new Point(0, 0);
            Panel_Chat_Top.Name = "Panel_Chat_Top";
            Panel_Chat_Top.Size = new Size(1042, 90);
            Panel_Chat_Top.TabIndex = 2;
            // 
            // LABEL_Chat_FriendName
            // 
            LABEL_Chat_FriendName.AutoSize = true;
            LABEL_Chat_FriendName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            LABEL_Chat_FriendName.ForeColor = Color.White;
            LABEL_Chat_FriendName.Location = new Point(100, 31);
            LABEL_Chat_FriendName.Name = "LABEL_Chat_FriendName";
            LABEL_Chat_FriendName.Size = new Size(123, 28);
            LABEL_Chat_FriendName.TabIndex = 2;
            LABEL_Chat_FriendName.Text = "FriendName";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(10, 5);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(80, 80);
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // PANEL_Chat_Bottom
            // 
            PANEL_Chat_Bottom.BackColor = Color.FromArgb(32, 44, 51);
            PANEL_Chat_Bottom.Controls.Add(pictureBox2);
            PANEL_Chat_Bottom.Controls.Add(TB_SendMessage);
            PANEL_Chat_Bottom.Dock = DockStyle.Bottom;
            PANEL_Chat_Bottom.Location = new Point(0, 633);
            PANEL_Chat_Bottom.Name = "PANEL_Chat_Bottom";
            PANEL_Chat_Bottom.Size = new Size(1042, 80);
            PANEL_Chat_Bottom.TabIndex = 0;
            // 
            // TB_SendMessage
            // 
            TB_SendMessage.BackColor = Color.FromArgb(42, 57, 66);
            TB_SendMessage.BorderStyle = BorderStyle.None;
            TB_SendMessage.Cursor = Cursors.IBeam;
            TB_SendMessage.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TB_SendMessage.ForeColor = Color.White;
            TB_SendMessage.Location = new Point(140, 20);
            TB_SendMessage.Multiline = true;
            TB_SendMessage.Name = "TB_SendMessage";
            TB_SendMessage.PlaceholderText = "Type a message";
            TB_SendMessage.Size = new Size(810, 40);
            TB_SendMessage.TabIndex = 1;
            TB_SendMessage.TabStop = false;
            TB_SendMessage.TextChanged += WriteMessage;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(0, 92, 75);
            label2.Font = new Font("Cambria", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(940, 50);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 5;
            label2.Text = "1:11 PM";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(962, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(80, 80);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // JoyChat
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.FromArgb(34, 46, 53);
            ClientSize = new Size(1582, 753);
            Controls.Add(PANEL_Chat);
            Controls.Add(PANEL_LeftSide);
            Controls.Add(PANEL_EDGE_LEFT);
            Controls.Add(PANEL_EDGE_TOP);
            Controls.Add(PANEL_EDGE_RIGHT);
            Controls.Add(PANEL_EDGE_BOTTOM);
            DoubleBuffered = true;
            KeyPreview = true;
            Name = "JoyChat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "JoyChat";
            Load += JoyChat_Load;
            Resize += UpdateControlsOnResize;
            PANEL_LeftSide.ResumeLayout(false);
            PANEL_LeftSide_Top_Menu.ResumeLayout(false);
            PANEL_TB_Placeholder.ResumeLayout(false);
            PANEL_TB_Placeholder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            PANEL_Chat.ResumeLayout(false);
            PANEL_Chat_Messages.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            Panel_Chat_Top.ResumeLayout(false);
            Panel_Chat_Top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            PANEL_Chat_Bottom.ResumeLayout(false);
            PANEL_Chat_Bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PANEL_LeftSide;
        private Panel PANEL_EDGE_LEFT;
        private Panel PANEL_EDGE_RIGHT;
        private Panel PANEL_EDGE_TOP;
        private Panel PANEL_EDGE_BOTTOM;
        private Panel PANEL_LeftSide_Top_Menu;
        private Panel PANEL_Conversations;
        private Panel PANEL_Chat;
        private PictureBox pictureBox1;
        private TextBox TB_Email;
        private Panel PANEL_TB_Placeholder;
        private Panel PANEL_Chat_Bottom;
        private TextBox TB_SendMessage;
        private Panel PANEL_Chat_Messages;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Panel Panel_Chat_Top;
        private Label LABEL_Chat_FriendName;
        private PictureBox pictureBox3;
        private Label label2;
        private PictureBox pictureBox2;
    }
}
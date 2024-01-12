using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JoyChat.Classes
{
    public class ConversationLayout : Control
    {
        private Control conversationLayout = new Control();
        // Get the conversation layout.
        public Control Control { get { return conversationLayout; } }
        // Get the name of the conversation.
        public string Name { get { return conversationLayout.Name; } }
        private Conversation conversation;
        private Func<Task> OpenChat;
        // Get the time stamp to order the conversations in the loop.
        private DateTime timeStamp;
        public DateTime TimeStamp { get { return timeStamp; } }
        // When user goes with mouse over the panel.
        private static void FocusControl(Control control)
        {
            control.BackColor = Color.FromArgb(32, 44, 51);
            control.Cursor = Cursors.Hand;
        }
        // When user goes with mouse outside the panel.
        private static void UnfocusControl(Control control)
        {
            control.BackColor = Color.FromArgb(17, 27, 33);
        }

        // Setup
        private void InitializeComponent()
        {
            string friendName = conversation.FriendName;
            string lastMessage = conversation.Messages[conversation.Messages.Count - 1].Text;
            this.timeStamp = conversation.Messages[conversation.Messages.Count - 1].TimeStamp;
            string timeStamp = this.timeStamp.ToString();

            // 
            // label4
            // 
            Label label4 = new Label();
            label4.AutoSize = true;
            label4.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(100, 80);
            label4.Name = "LB_Top_Line";
            label4.TabIndex = 5;
            label4.Text = "______________________________________________________________";
            // 
            // label3
            // 
            Label label3 = new Label();
            label3.AutoSize = true;
            label3.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Name = "LB_Time";
            label3.TabIndex = 4;
            label3.Text = timeStamp;
            label3.Location = new Point(500 - label3.Size.Width - 70, 10);
            // 
            // label2
            // 
            Label label2 = new Label();
            label2.AutoSize = true;
            label2.Font = new Font("Cambria", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(100, 60);
            label2.Name = "LB_LastMessage";
            label2.TabIndex = 3;
            label2.Text = lastMessage;
            // 
            // label1
            // 
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Font = new Font("Cambria Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(100, 30);
            label1.Name = "LB_ChatTitle";
            label1.TabIndex = 2;
            label1.Text = friendName;
            // 
            // pictureBox2
            // 
            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Location = new Point(10, 10);
            pictureBox2.Name = "PB_ProfilePicture";
            pictureBox2.Size = new Size(80, 80);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;

            // 
            // PANEL_Conversation_Message_Layout
            // 
            Panel PANEL_Conversation_Message_Layout = new Panel();
            PANEL_Conversation_Message_Layout.Controls.Add(label4);
            PANEL_Conversation_Message_Layout.Controls.Add(label3);
            PANEL_Conversation_Message_Layout.Controls.Add(label2);
            PANEL_Conversation_Message_Layout.Controls.Add(label1);
            PANEL_Conversation_Message_Layout.Controls.Add(pictureBox2);
            PANEL_Conversation_Message_Layout.Dock = DockStyle.Top;
            PANEL_Conversation_Message_Layout.Location = new Point(0, 0);
            PANEL_Conversation_Message_Layout.Name = friendName;
            PANEL_Conversation_Message_Layout.Size = new Size(500, 100);
            PANEL_Conversation_Message_Layout.TabIndex = 0;

            // MouseHover - Gray-out the background.
            PANEL_Conversation_Message_Layout.MouseEnter +=
                (sender, e) => FocusControl(PANEL_Conversation_Message_Layout);
            PANEL_Conversation_Message_Layout.MouseLeave +=
                (sender, e) => UnfocusControl(PANEL_Conversation_Message_Layout);
            // Click on chat => open chat.
            PANEL_Conversation_Message_Layout.Click +=
                async (sender, e) => await OpenChat();

            for (int i = 0; i < PANEL_Conversation_Message_Layout.Controls.Count; i++)
            {
                // MouseHover - Gray-out the background.
                PANEL_Conversation_Message_Layout.Controls[i].MouseEnter +=
                    (sender, e) => FocusControl(PANEL_Conversation_Message_Layout);
                PANEL_Conversation_Message_Layout.Controls[i].MouseLeave +=
                    (sender, e) => UnfocusControl(PANEL_Conversation_Message_Layout);
                // Click on chat => open chat.
                PANEL_Conversation_Message_Layout.Controls[i].Click +=
                    async (sender, e) => await OpenChat();
            }

            conversationLayout = PANEL_Conversation_Message_Layout;
        }

        public ConversationLayout(Conversation conversation, Func<Task> action)
        {
            this.conversation = conversation;
            OpenChat = action;
            InitializeComponent();
        }
    }
}

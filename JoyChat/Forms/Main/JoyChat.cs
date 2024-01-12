using JoyChat.Classes;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JoyChat.Forms.Main
{
    public partial class JoyChat : Form
    {
        private User currentUser;
        private Conversation currentConversation;
        private bool DarkMode = true;
        private List<ConversationLayout> conversationsLayout;

        public JoyChat()
        {
            InitializeComponent();
        }

        public JoyChat(User user)
        {
            InitializeComponent();
            currentUser = user;
        }

        private async void JoyChat_Load(object sender, EventArgs e)
        {
            currentUser ??= new User();
            conversationsLayout = new List<ConversationLayout>();
            currentConversation = new Conversation();

            // Set form to dark/light mode.
            DwmSetWindowAttribute(this.Handle, 20, ref DarkMode, Marshal.SizeOf(DarkMode));

            // Hide the chat panel.
            PANEL_Chat.Visible = false;

            // Awaiter to prevent the Conversation.Add method to crash the app.
            await currentUser.LoadConversations();
            // Add the conversations to the layout list.
            foreach (var conv in currentUser.Conversations)
                conversationsLayout.Add(new ConversationLayout(conv, async () => await OpenChat(conv)));
            conversationsLayout = conversationsLayout.OrderByDescending(conv => Math.Abs((DateTime.Now - conv.TimeStamp).Ticks)).ToList();
            // For each layout conv add to the panel list.
            foreach (var convControl in conversationsLayout)
                PANEL_Conversations.Controls.Add(convControl.Control);

            // Smooth loading.
            await Task.Delay(100);
        }

        public async Task OpenChat(Conversation conversation)
        {
            // Daca este aceeasi conversatie nu se intampla nimic.
            if (conversation.FriendName == currentConversation.FriendName)
            {
                Debug.WriteLine("The same conversation is already opened. Cancelling the action.");
                return;
            }
            // Daca e conversatie noua se incepe o noua conversatie.
            // Change the thread to the new conversation and clear the old conv messages displayed.
            PANEL_Chat.Visible = false;
            currentConversation = conversation;
            LABEL_Chat_FriendName.Text = conversation.FriendName;
            PANEL_Chat_Messages.Controls.Clear();

            // Se va itera fiecare mesaj si se va adauga in PANEL_Chat_Messages cate un panel
            // conform mesajului (daca e trimis sau primit).
            List<Panel> message_lines = new List<Panel>();
            foreach (var message in conversation.Messages)
            {
                Label timeStamp = new Label();
                timeStamp.AutoSize = true;
                timeStamp.BackColor = Color.FromArgb(32, 44, 51);
                timeStamp.Font = new Font("Cambria", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
                timeStamp.ForeColor = Color.White;
                timeStamp.TabIndex = 3;
                timeStamp.Text = message.TimeStamp.ToString("h:mm tt");

                TextBox message_text = new TextBox();
                message_text.BorderStyle = BorderStyle.None;
                message_text.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                message_text.ForeColor = Color.White;
                message_text.Multiline = true;
                message_text.ReadOnly = true;
                message_text.TabIndex = 2;
                message_text.Text = message.Text;

                // Make the textbox change its size based on number of chars.
                // Default values.
                int textbox_width = (int)message_text.Font.Size + 50;
                int textbox_height = TextRenderer.MeasureText(message_text.Text, message_text.Font, new Size(message_text.Width, int.MaxValue), TextFormatFlags.WordBreak).Height;
                // Adapt the width and height of the textbox to fit it's elements.
                if (message_text.Text.Length <= 80) textbox_width += message_text.Text.Where(c => !char.IsWhiteSpace(c)).ToArray().Length * (int)message_text.Font.Size;
                else textbox_width += 81 * (int)message_text.Font.Size;

                // Update the size.
                message_text.Size = new Size(textbox_width, textbox_height);

                Panel message_line = new Panel();
                message_line.Dock = DockStyle.Top;
                message_line.Name = "panel1";
                int panel_height = 5 + message_text.Height;
                message_line.Size = new Size(1042, panel_height);
                message_line.TabIndex = 0;

                // If the message is `received` (GRAY)
                if (message.SenderName == currentUser.Username)
                {
                    message_text.BackColor = Color.FromArgb(32, 44, 51);
                    message_text.Location = new Point(50, 5);
                    message_text.Name = "message_receive";
                    timeStamp.BackColor = Color.FromArgb(32, 44, 51);
                    timeStamp.Location = new Point(message_text.Width - 5, panel_height - 15);
                    timeStamp.Name = "timestamp_receive";
                }
                // else if the message is `sent` (GREEN)
                else
                {
                    message_text.BackColor = Color.FromArgb(0, 92, 75);
                    message_text.Location = new Point(PANEL_Chat.Width - message_text.Width - 50, 5);
                    message_text.Name = "message_sent";
                    timeStamp.BackColor = Color.FromArgb(0, 92, 75);
                    timeStamp.Location = new Point(PANEL_Chat.Width - 50 - 55, panel_height - 15);
                    timeStamp.Name = "timestamp_sent";
                }

                // Add the elements to the panel, then add the panel to the Parent `PANEL_Chat_Messages`
                message_line.Controls.Add(message_text);
                message_line.Controls.Add(timeStamp);

                // The timestamp should be on top of the textbox in the bottom-right corner.
                message_text.SendToBack();
                timeStamp.BringToFront();

                // Add the message line to the list.
                message_lines.Add(message_line);
            }

            // Display the messages in order from the oldest to the newest and scroll to the end.
            message_lines.Reverse();
            foreach (var message in message_lines)
                PANEL_Chat_Messages.Controls.Add(message);

            PANEL_Chat_Messages.AutoScrollPosition = new Point(0, PANEL_Chat_Messages.VerticalScroll.Maximum);

            message_lines.Clear();
            message_lines = null;

            PANEL_Chat.Update();
            await Task.Delay(100);
            PANEL_Chat.Visible = true;
        }

        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref bool attrValue, int attrSize);

        private void WriteMessage(object sender, EventArgs e)
        {
            int multiplier = (int)Math.Abs((double)TB_SendMessage.Text.Length / 81) + 1;
            if (multiplier < 3) TB_SendMessage.ScrollBars = ScrollBars.None;
            else
            {
                multiplier = 3;
                TB_SendMessage.ScrollBars = ScrollBars.Vertical;
            }
            int adapt_height = (Panel_Chat_Top.Height - 10) * multiplier;
            PANEL_Chat_Bottom.Size = new Size(PANEL_Chat_Bottom.Width, adapt_height);
            TB_SendMessage.Size = new Size(TB_SendMessage.Width, adapt_height - 40);
        }

        private async void UpdateControlsOnResize(object sender, EventArgs e)
        {
            PANEL_Chat_Messages.SuspendLayout();

            await Task.Run(() =>
            {
                foreach (Control message_line in PANEL_Chat_Messages.Controls)
                {
                    int panel_height = 0;
                    Control timestamp = null;
                    foreach (Control message in message_line.Controls)
                    {
                        if (message.Name == "message_sent")
                        {
                            // The message.
                            panel_height = 5 + message.Height;
                            message.Invoke((MethodInvoker)delegate
                            {
                                message.Location = new Point(PANEL_Chat.Width - message.Width - 50, 5);
                            });
                        }
                        else if (message.Name == "timestamp_sent")
                        {
                            // The timestamp.
                            timestamp = message;
                        }
                    }

                    if (timestamp != null)
                    {
                        timestamp.Invoke((MethodInvoker)delegate
                        {
                            timestamp.Location = new Point(PANEL_Chat.Width - 50 - 55, panel_height - 15);
                        });
                    }
                }
            });

            TB_SendMessage.Width = (int)Math.Round((double)PANEL_Chat_Bottom.Width / 1.2);
            pictureBox2.Location = new Point(PANEL_Chat_Bottom.Width - pictureBox2.Width, pictureBox2.Location.Y);

            PANEL_Chat_Messages.ResumeLayout();
            PANEL_Chat.Update();
        }
    }
}
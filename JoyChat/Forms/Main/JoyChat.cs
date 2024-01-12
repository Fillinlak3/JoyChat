using JoyChat.Classes;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

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
                Panel message_line = new Panel();
                message_line.Dock = DockStyle.Top;
                message_line.Name = "panel1";
                message_line.Padding = new Padding(5);
                message_line.TabIndex = 0;

                Label timeStamp = new Label();
                timeStamp.AutoSize = true;
                timeStamp.BackColor = Color.FromArgb(32, 44, 51);
                timeStamp.Font = new Font("Cambria", 7.8F, FontStyle.Regular, GraphicsUnit.Point);
                timeStamp.ForeColor = Color.White;
                timeStamp.TabIndex = 2;
                timeStamp.Text = message.TimeStamp.ToString("h:mm tt");

                TextBox message_text = new TextBox();
                message_text.BorderStyle = BorderStyle.None;
                message_text.Font = new Font("Cambria", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
                message_text.ForeColor = Color.White;
                message_text.AutoSize = true;
                message_text.Multiline = true;
                message_text.WordWrap = true;
                message_text.ReadOnly = true;
                message_text.TabIndex = 1;
                message_text.TabStop = false;
                message_text.Text = message.Text;

                // Make the textbox change its size dynamically based on number of chars.
                int prefferedWidth = Math.Min(700, TextRenderer.MeasureText(message.Text, message_text.Font).Width + timeStamp.Width); // You might want to use a fixed width or adjust as needed
                int preferredHeight = 0;
                {
                    // Split the text by newline character
                    string[] lines = message.Text.Split('\n');

                    int wordwrapOverridedLines = 0;
                    /* 
                        If there are lines that go over 80 chars, then those are word-wrap overrided lines
                        so, for each of these lines we need to keep track of how many lines were `used` by
                        the word-wrap to fit the text. Those lines are not considered in `.Lines` property.
                        Those lines are just the word-wrap overlapping which I keep track of with this loop.
                     */
                    foreach (var line in lines.Where(line => line.Length >= 80))
                        // Take the absolute value of occurrence and add it.
                        wordwrapOverridedLines += (int)Math.Abs((double)prefferedWidth / line.Length);

                    /*
                        So, after all when we found out on how many lines did the word wrap extend to fit the
                        text string, we add them to the real line count of the string.
                        In conclusion, what we know to be a string line is the entire, but a word-wrap
                        overrided line is the one that is concluded by the word-wrapper working around to fit
                        the text on `multiple lines` which aren't real lines counted in `.Lines` property.
                     */
                    int lineCount = lines.Length + wordwrapOverridedLines;
                    preferredHeight = (int)(message_text.Font.GetHeight() * lineCount) + message_line.Padding.Vertical;
                }
                // Setting size for the TextBox
                message_text.Size = new Size(prefferedWidth, preferredHeight);

                message_line.Size = new Size(1042, preferredHeight + message_line.Padding.Vertical);

                // If the message is `received` (GRAY)
                if (message.SenderName == currentUser.Username)
                {
                    message_text.BackColor = Color.FromArgb(32, 44, 51);
                    message_text.Location = new Point(50, 5);
                    message_text.Name = "message_receive";
                    timeStamp.BackColor = Color.FromArgb(32, 44, 51);
                    timeStamp.Location = new Point(message_text.Width - 5, message_line.Height - 20);
                    timeStamp.Name = "timestamp_receive";
                }
                // else if the message is `sent` (GREEN)
                else
                {
                    message_text.BackColor = Color.FromArgb(0, 92, 75);
                    message_text.Location = new Point(PANEL_Chat.Width - message_text.Width - 50, 5);
                    message_text.Name = "message_sent";
                    timeStamp.BackColor = Color.FromArgb(0, 92, 75);
                    timeStamp.Location = new Point(PANEL_Chat.Width - 50 - 55, message_line.Height - 20);
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
            static int CalculateCharactersPerLine(TextBox textBox)
            {
                using (Graphics g = textBox.CreateGraphics())
                {
                    Font font = textBox.Font;
                    SizeF charSize = g.MeasureString("A", font); // Measure the width of a single character

                    int width = (int)textBox.Width; // Width of the RichTextBox
                    int charactersPerLine = (int)(width / charSize.Width); // Calculate characters per line
                    return charactersPerLine * 2 + 1;
                }
            }

            int multiplier = (int)Math.Abs((double)TB_SendMessage.Text.Length / CalculateCharactersPerLine(TB_SendMessage)) + 1;
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

            TB_SendMessage.Width = (int)Math.Round((double)PANEL_Chat_Bottom.Width / 1.2) - pictureBox2.Width;
            pictureBox2.Location = new Point(PANEL_Chat_Bottom.Width - pictureBox2.Width, pictureBox2.Location.Y);

            PANEL_Chat_Messages.ResumeLayout();
            PANEL_Chat.Update();
            await Task.Delay(100);
        }
    }
}
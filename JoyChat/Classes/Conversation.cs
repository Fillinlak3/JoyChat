using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JoyChat.Classes
{
    public class Conversation
    {
        public enum LastSeenParticipants
        {
            sender,
            receiver
        }

        private string ChatFile { get; set; }
        public string FriendName { get; set; }
        public List<Message> Messages { get; set; }
        public LastSeenParticipants LastSeen {  get; set; }

        public Conversation()
        {
            ChatFile = string.Empty;
            FriendName = string.Empty;
            Messages = new List<Message>();
        }

        public Conversation(string friend_name, string chatFile, string chat_data)
        {
            Messages = new List<Message>();
            FriendName = friend_name;
            ChatFile = chatFile;

            using (StringReader reader = new StringReader(chat_data))
            {
                string line;
                while ((line = reader.ReadLine()!) != null)
                {
                    // Extract SenderName, Date, Time, Text, and Seen
                    string pattern = @"\[(.*?)@(.*?)-(.*?)#seen:(.*?)\]:\s(.*?)(?:\n|$)";
                    string pattern2 = @"(.*?)(?:\n|$)";
                    Match match = Regex.Match(line, pattern);
                    Match match_continue_message = Regex.Match(line, pattern2);

                    if (match.Success)
                    {
                        string senderName = match.Groups[1].Value;
                        string date = match.Groups[2].Value;
                        string time = match.Groups[3].Value;
                        bool seen = bool.Parse(match.Groups[4].Value.ToLower()); // Convert "true" or "false" to boolean
                        string text = match.Groups[5].Value;
                        DateTime parsedDateTime = DateTime.Parse($"{date} {time}");

                        Messages.Add(new Message(senderName, parsedDateTime, seen, text));
                    }
                    else if(match_continue_message.Success)
                    {
                        Messages[Messages.Count - 1].Text += $"{Environment.NewLine}{match_continue_message.Groups[1]}";
                    }
                    else
                    {
                        Debug.WriteLine($"[Conversation-Constructor] Message couldn't be read: {line}");
                    }
                }
            }
        }

        public bool isEmpty()
        {
            return Messages.Count == 0 && 
                string.IsNullOrEmpty(FriendName) && 
                string.IsNullOrEmpty(ChatFile);
        }
    }
}

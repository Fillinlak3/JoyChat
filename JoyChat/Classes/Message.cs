using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoyChat.Classes
{
    public class Message
    {
        public string SenderName { get; set; }
        public string Text { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Seen { get; set; }

        public Message(string sender_name, DateTime timestamp, bool seen, string text)
        {
            SenderName = sender_name;
            TimeStamp = timestamp;
            Seen = seen;
            Text = text;
        }
    }
}

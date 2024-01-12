using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JoyChat.Classes
{
    public class User
    {
        public string DisplayName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PrivateKey { get; set; }
        public List<string> ChatFiles { get; set; }
        public List<string> Friends { get; set; }
        public List<Conversation> Conversations { get; set; }

        public User()
        {
            DisplayName = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            PrivateKey = string.Empty;
            ChatFiles = new List<string>();
            Friends = new List<string>();
            Conversations = new List<Conversation>();
        }

        public User(string display_name, string username, string password, string email, string private_key, List<string> chat_files)
        {
            DisplayName = display_name;
            Username = username;
            Password = password;
            Email = email;
            PrivateKey = private_key;
            ChatFiles = chat_files;
            Friends = new List<string>();
            Conversations = new List<Conversation>();
        }

        public void GetFriends()
        {
            Friends.Clear();

            foreach (string line in ChatFiles)
                Friends.Add(GetFriendsName(line));
        }

        private string GetFriendsName(string chatFile)
        {
            string first = chatFile.Substring(0, chatFile.IndexOf('-'));
            chatFile = chatFile.Remove(0, chatFile.IndexOf('-') + 1);
            string second = chatFile.Substring(0, chatFile.IndexOf('.'));
            
            return (Username == first ? second : first);
        }

        public async Task LoadConversationWith(string friend_name)
        {
            if (Friends.Count == 0 || ChatFiles.Count == 0)
                throw new Exception($"Couldn't load conversation with {friend_name}.");

            string chat_file = ChatFiles[Friends.IndexOf(friend_name)];
            string chat_data = await Authentificator.ReadChat(chat_file);

            Conversations.Add(new Conversation(friend_name, chat_file, chat_data));
        }

        public async Task LoadConversations()
        {
            if (Friends.Count == 0 || ChatFiles.Count == 0)
                throw new Exception("Couldn't load user's conversations.");

            string friend_name;
            string chat_data;
            // Read gist chat files and add conv obj into the list.
            foreach (var chat in ChatFiles)
            {
                friend_name = chat_data = string.Empty;
                try
                {
                    friend_name = Friends[ChatFiles.IndexOf(chat)];
                    chat_data = await Authentificator.ReadChat(chat);

                    Conversations.Add(new Conversation(friend_name, chat, chat_data));
                }
                catch(FileNotFoundException)
                {
                    MessageBox.Show($"Unable to load conversation with {friend_name}.", "JoyChat - FATAL ERROR while loading conversations");
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Something went wrong: {ex.Message}", "JoyChat - FATAL ERROR while loading conversations");
                }
            }
        }
    }
}

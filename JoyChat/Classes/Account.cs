using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JoyChat.Classes
{
    internal class Account
    {
        /// <summary>
        /// Returns a json containing the user's credentials for registering.
        /// </summary>
        static public string Save(User user)
        {
            string json = string.Empty;
            try
            {
                // Transform the user to the desired structure
                var transformedAccount = new
                {
                    DisplayName = user.DisplayName,
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    PrivateKey = user.PrivateKey,
                    ChatFiles = user.ChatFiles
                };

                // Serialize the transformed account to JSON
                json = JsonSerializer.Serialize(transformedAccount, new JsonSerializerOptions { WriteIndented = true });

                Debug.WriteLine($"[Account-Save] Successfully converted to JSON.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Account-Save] Error converting account to JSON: {ex.Message}");
            }
            return json;
        }

        /// <summary>
        /// Returns an User instance for login.
        /// </summary>
        static public User Get(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                Debug.WriteLine($"[Account-Get] Empty json.");
                throw new Exception("Cannot retrieve user's data.");
            }

            User user = new User();

            // Parse JSON manually
            JsonDocument jsonDocument = JsonDocument.Parse(json);

            // Access the root object
            JsonElement root = jsonDocument.RootElement;

            // Extract individual properties
            user.DisplayName = root.GetProperty("DisplayName").GetString()!;
            user.Username = root.GetProperty("Username").GetString()!;
            user.Password = root.GetProperty("Password").GetString()!;
            user.Email = root.GetProperty("Email").GetString()!;
            user.PrivateKey = root.GetProperty("PrivateKey").GetString()!;

            // Extract the "Conversations" array
            JsonElement chatFilesArray = root.GetProperty("Conversations");
            foreach (JsonElement conversationElement in chatFilesArray.EnumerateArray())
                user.ChatFiles.Add(conversationElement.ToString());

            user.GetFriends();
            return user;
        }
    }
}

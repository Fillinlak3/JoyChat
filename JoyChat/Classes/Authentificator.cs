using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace JoyChat.Classes
{
    /// <summary>
    /// GIST API
    /// </summary>
    public class Authentificator
    {
        private static readonly HttpClient HttpClient;
        private static readonly string GistId = @"41b6c0b21c6bc7f59468f3994e4f4fef";
        private static readonly string AccessToken = @"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";
        private static readonly string ApiUrl = $"https://api.github.com/gists/{GistId}";

        static Authentificator()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "JoyChat");
        }

        class Gist
        {
            public static async Task<(bool Success, string Content)> Read(string file)
            {
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", AccessToken);

                HttpResponseMessage response = await HttpClient.GetAsync(ApiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();

                    // Parse the JSON using System.Text.Json.JsonSerializer
                    JsonDocument doc = JsonDocument.Parse(jsonContent);

                    // Access the properties in a more type-safe manner
                    JsonElement root = doc.RootElement;
                    JsonElement filesElement = root.GetProperty("files");
                    if (filesElement.TryGetProperty(file, out JsonElement accountsFileElement))
                    {
                        string content = accountsFileElement.GetProperty("content").GetString()!;
                        return (true, content);
                    }
                    return (false, string.Empty);
                }
                else
                {
                    Debug.WriteLine($"[Authentificator-Gist-Read] Error reading Gist. Status Code: {response.StatusCode}");
                    Debug.WriteLine($"[Authentificator-Gist-Read] More information: {await response.Content.ReadAsStringAsync()}");
                    throw new HttpRequestException($"Error reading the database. Status Code: {response.StatusCode}");
                }
            }

            public static async Task Update(string file, string newContent, bool overWrite = false)
            {
                string combinedContent = string.Empty;
                if (overWrite == false)
                {
                    var result = await Read(file);
                    string existingContent = string.Empty;

                    if (result.Success)
                        existingContent = result.Content;
                    else
                        throw new Exception("Failed to update the gist.");

                    combinedContent = existingContent + "\n" + newContent;
                }
                else
                {
                    combinedContent = newContent;
                }

                var payload = new Dictionary<string, object>
                {
                    {
                        "files", new Dictionary<string, object>
                        {
                            {
                                file, new Dictionary<string, object>
                                {
                                    { "content", combinedContent }
                                }
                            }
                        }
                    }
                };

                string jsonPayload = JsonSerializer.Serialize(payload);

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", AccessToken);

                HttpContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClient.PatchAsync(ApiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine("[Authentificator-Gist-Update] Database updated successfully!");
                }
                else
                {
                    Debug.WriteLine($"[Authentificator-Gist-Update] Error whilst updating Gist. Status Code: {response.StatusCode}");
                    Debug.WriteLine($"[Authentificator-Gist-Update] More information: {await response.Content.ReadAsStringAsync()}");
                    throw new HttpRequestException($"Error whilst updating the database. Status Code: {response.StatusCode}");
                }
            }

            public static async Task Create(string file, string content)
            {
                var payload = new Dictionary<string, object>
                {
                    {
                        "files", new Dictionary<string, object>
                        {
                            {
                                file, new Dictionary<string, object>
                                {
                                    { "content", content }
                                }
                            }
                        }
                    }
                };

                string jsonPayload = JsonSerializer.Serialize(payload);

                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", AccessToken);

                HttpContent httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await HttpClient.PatchAsync(ApiUrl, httpContent);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine($"[Authentificator-Gist-Create] Database {file} successfully created!");
                }
                else
                {
                    Debug.WriteLine($"[Authentificator-Gist-Create] Error whilst creating Gist. Status Code: {response.StatusCode}");
                    Debug.WriteLine($"[Authentificator-Gist-Create] More information: {await response.Content.ReadAsStringAsync()}");
                    throw new HttpRequestException($"Error whilst creating the database. Status Code: {response.StatusCode}");
                }
            }
        }

        public static async Task<User> FetchUser(string username)
        {
            var result = await Gist.Read(username);

            if(result.Success)
                return Account.Get(result.Content);
            else throw new FileNotFoundException();
        }

        public static async Task AddUser(User user)
        {
            string content = Account.Save(user);
            await Gist.Create(user.Username, content);
            await Gist.Update("UsedPrivateKeys", user.PrivateKey);
        }

        public static async Task UpdateUser(User user)
        {
            string content = Account.Save(user);
            await Gist.Update(user.Username, content, overWrite: true);
        }

        public static async Task<bool> AvailablePrivateKey(string private_key)
        {
            var result = await Gist.Read("UsedPrivateKeys");
            if (result.Success)
            {
                if (result.Content.Contains(private_key))
                    return false;
                return true;
            }
            else throw new FileNotFoundException();
        }

        public static async Task<bool> AvailableUser(string username)
        {
            // If there is an error thrown, it means the user is available (the gist file
            // doesnt exist).
            var result = await Gist.Read(username);
            if (result.Success) return false;
            else return true;
        }

        public static async Task<string> ReadChat(string chat_file)
        {
            var result = await Gist.Read(chat_file);
            if (result.Success) return result.Content;
            else throw new FileNotFoundException();
        }

        //public static async Task DeleteUser(string username)
        //{
        //    await UpdateUsers(User.Account.Remove(await FetchUsers(), username));
        //}
    }
}

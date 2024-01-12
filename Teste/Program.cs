using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Teste
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string line = "[iambucuriee@05/23/2023-13:07:20#seen:true]: toate bune?";

            // Extract SenderName, Date, Time, Text, and Seen
            string pattern = @"\[(.*?)@(.*?)-(.*?)#seen:(.*?)\]: (.*)";
            Match match = Regex.Match(line, pattern);

            if (match.Success)
            {
                string senderName = match.Groups[1].Value;
                string date = match.Groups[2].Value;
                string time = match.Groups[3].Value;
                bool seen = bool.Parse(match.Groups[4].Value.ToLower()); // Convert "true" or "false" to boolean
                string text = match.Groups[5].Value;

                TimeSpan parsedTime = TimeSpan.Parse(time);
                DateTime parsedDateTime = DateTime.Parse($"{date} {time}");

                Console.WriteLine($"{senderName} - {parsedTime} - {parsedDateTime} - {seen} - {text}");
            }
        }
    }
}
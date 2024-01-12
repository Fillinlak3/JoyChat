using JoyChat.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoyChat.Forms.Register
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        public static bool IsValidUsername(string username)
        {
            string pattern = @"^[a-zA-Z0-9](?!.*[._-]{2})[a-zA-Z0-9._-]*[a-zA-Z0-9]$";
            return Regex.IsMatch(username, pattern);
        }
        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private static bool IsValidName(string lastName)
        {
            string pattern = @"^[a-zA-Z]+[- ]?[a-zA-Z]+$";
            return Regex.IsMatch(lastName, pattern);
        }

        public static string GeneratePrivateKey()
        {
            short length = 32;
            const string availablecharacters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz1234567890~!@#$%^*()-_=[]{}|;:,./?";
            Random rand = new Random();

            string privatekey = new string(availablecharacters
            .OrderBy(c => rand.Next(0, availablecharacters.Length - 1))
            .Distinct()
            .Take(length)
            .ToArray());

            return privatekey;
        }

        private async void Register_Click(object sender, EventArgs e)
        {
            try
            {
                // (!) Check if all fields are filled.
                if (string.IsNullOrWhiteSpace(TB_Email.Text) || string.IsNullOrWhiteSpace(TB_Username.Text) ||
                string.IsNullOrWhiteSpace(TB_DisplayName.Text) || string.IsNullOrWhiteSpace(TB_Password.Text) ||
                string.IsNullOrWhiteSpace(TB_ConfirmPassword.Text))
                    throw new Exception("Please fill out the empty fields!");

                // (!) Check if email, user, pass, etc are valid and allowed strings.
                // Email restrictions.
                if (String.IsNullOrWhiteSpace(TB_Email.Text))
                    throw new Exception("Email cannot be an empty field!");
                if (IsValidEmail(TB_Email.Text) == false)
                    throw new Exception("Email doesn't follow the specific rules. See the help for more information.");

                // Username restrictions.
                if (String.IsNullOrWhiteSpace(TB_Username.Text))
                    throw new Exception("Username cannot be an empty field!");
                if (TB_Username.Text.Contains(' '))
                    throw new Exception("Username cannot have whitespaces!");
                if (IsValidUsername(TB_Username.Text) == false)
                    throw new Exception("Username contains unallowed characters. See the help for more information.");

                // Display Name restrictions.
                if (String.IsNullOrWhiteSpace(TB_DisplayName.Text))
                    throw new Exception("Display Name cannot be an empty field!");

                // Password restrictions.
                if (String.IsNullOrWhiteSpace(TB_Password.Text))
                    throw new Exception("Password cannot be an empty field!");
                if (IsValidPassword(TB_Password.Text) == false)
                    throw new Exception("Password must have at least one uppercase letter, one lowercase letter, one digit, one special character, and a minimum length of 8 characters. See the help for more information.");

                // (!) Check if username already exists.
                bool availableUser = await Authentificator.AvailableUser(TB_Username.Text);
                if (availableUser == false)
                {
                    TB_Username.Text = string.Empty;
                    throw new Exception("The username is already taken!");
                }

                // (!) Check if passwords match.
                if (TB_Password.Text != TB_ConfirmPassword.Text)
                {
                    TB_Password.Text = TB_ConfirmPassword.Text = string.Empty;
                    throw new Exception("Passwords do not match!");
                }

                // (!) Check if the CheckBox is checked.
                if (CB_Agree.Checked == false)
                    throw new Exception("Confirm your account registration by checking Agree the Terms and Conditions.");

                // (!) Generate the private key.
                string Private_Key = string.Empty;
                bool validPrivateKey = false;
                do
                {
                    Private_Key = GeneratePrivateKey();
                    validPrivateKey = await Authentificator.AvailablePrivateKey(Private_Key);
                } while (validPrivateKey == false);

                // (!) Try to save account.
                User user = new()
                {
                    Email = TB_Email.Text,
                    Username = TB_Username.Text,
                    DisplayName = TB_DisplayName.Text,
                    Password = TB_Password.Text,
                    PrivateKey = Private_Key,
                    Conversations = new List<Conversation>()
                };
                
                await Authentificator.AddUser(user);

                MessageBox.Show("Acount successfully registered!", "JoyChat - Account Register", MessageBoxButtons.OK);
                this.Hide();
                new Login.Login().ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured whilst registering your account: {ex.Message}", "JoyChat - Account Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

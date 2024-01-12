using JoyChat.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JoyChat.Forms.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        // Move the Form on the screen.
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            /*
                Constants in Windows API
                0x84 = WM_NCHITTEST - Mouse Capture Test
                0x1 = HTCLIENT - Application Client Area
                0x2 = HTCAPTION - Application Title Bar

                This function intercepts all the commands sent to the application. 
                It checks to see of the message is a mouse click in the application. 
                It passes the action to the base action by default. It reassigns 
                the action to the title bar if it occured in the client area
                to allow the drag and move behavior.
            */
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TB_Username.Text) || string.IsNullOrWhiteSpace(TB_Password.Text))
            {
                MessageBox.Show("Please fill out the empty fields", "JoyChat - Account Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User user = await Authentificator.FetchUser(TB_Username.Text);

                if (user.Username == TB_Username.Text && user.Password == TB_Password.Text)
                {
                    this.Hide();
                    new Main.JoyChat(user).ShowDialog();
                    this.Close();
                }
                else throw new KeyNotFoundException();
            }
            catch (KeyNotFoundException)
            {
                MessageBox.Show("Wrong username or password", "JoyChat - Account Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Wrong username or password", "JoyChat - Account Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occured: {ex.Message}", "JoyChat - Account Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Register.Register().ShowDialog();
            this.Close();
        }

        private void TB_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int ENTER_KEY = 13;
            if (e.KeyChar == ENTER_KEY)
                Login_Click(sender, e);
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void DebugAutoLogin(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                TB_Username.Text = "iambucuriee";
                TB_Password.Text = "Mirosila8742.";
                await Task.Delay(200);
                Login_Click(sender, e);
            }
        }
    }
}

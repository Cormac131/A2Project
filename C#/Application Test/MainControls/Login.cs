using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Test
{
    public partial class Login : UserControl
    {
        string uname = "",
            pwd = "";

        public Login()
        {
            InitializeComponent();
        }

        private void _login()
        {
            if (txtUsername.Text == "" && txtPassword.Text == "")
            {
                Program.LoggedIn = false;
                MessageBox.Show("You must enter a username and password to log in!");
            }
            else if (txtUsername.Text == "admin")
            {
                if (txtPassword.Text == "password")
                {
                    Program.MainForm.ShowControl(ControlsEnum.DASHBOARD);
                    Program.LoggedIn = true;
                }
                else
                {
                    Program.LoggedIn = false;
                    MessageBox.Show("Password is incorrect!");
                    txtPassword.Clear();
                    txtUsername.Clear();
                }                
            }
            else
            {
                Program.LoggedIn = false;
                MessageBox.Show("Username is incorrect!");
                txtPassword.Clear();
                txtUsername.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _login();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            uname = this.txtUsername.Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            pwd = this.txtPassword.Text;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                _login();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Test
{
    public enum ControlsEnum
    {
        DASHBOARD,
        LOGIN,
        NEWMEMBER,
        FINDMEMBER,
        SETTINGS,
        PAYMENT,
        SCHEDULE,
        BOOKINGACLASS,
        VIEWALLBOOKINGS,
        VIEWALLMEMBERS,
        PERSONSONSITE,
        SIGNIN,
        SIGNOUT
    }

    public partial class FrmMain : Form
    {
        private IDictionary<ControlsEnum, Control> controls = new Dictionary<ControlsEnum, Control>();

        public static bool SplashScreenLoad = false;

        public const string pdfFileName = @"User Guide.pdf";

        public FrmMain()
        {
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();

            while (!SplashScreenLoad)
            {
                if (SplashScreenLoad)
                {
                    Thread.Sleep(800);
                    break;
                }
            }

            InitializeComponent();
            ShowControl(ControlsEnum.LOGIN);
        }

        public void SplashScreen()
        {
            Application.Run(new FrmSplashScreen());
        }

        public void ShowControl(ControlsEnum ctrl)
        {
            Control new_ctrl = null;

            if (controls.ContainsKey(ctrl))
            {
                new_ctrl = controls[ctrl];
            }
            else
            {
                new_ctrl = CreateControl(ctrl);
                controls[ctrl] = new_ctrl;
            }

            new_ctrl.Parent = this;
            new_ctrl.Dock = DockStyle.Fill;
            new_ctrl.BringToFront();
            new_ctrl.Show();
        }

        private Control CreateControl(ControlsEnum ctrl)
        {
            switch (ctrl)
            {
                case ControlsEnum.LOGIN:
                    return new Login();
                case ControlsEnum.DASHBOARD:
                    return new Dashboard();
                case ControlsEnum.NEWMEMBER:
                    return new NewMember();
                case ControlsEnum.FINDMEMBER:
                    return new FindMember();
                case ControlsEnum.PAYMENT:
                    return new MainControls.Payment();
                case ControlsEnum.SETTINGS:
                    return new MainControls.Settings();
                case ControlsEnum.SCHEDULE:
                    return new BookingControls.Schedule();
                case ControlsEnum.BOOKINGACLASS:
                    return new BookingControls.BookingAClass();
                case ControlsEnum.VIEWALLBOOKINGS:
                    return new Reports.ViewAllBookings();
                case ControlsEnum.VIEWALLMEMBERS:
                    return new Reports.ViewAllMembers();
                case ControlsEnum.PERSONSONSITE:
                    return new Reports.PersonsOnSite();
                case ControlsEnum.SIGNIN:
                    return new SignInOut.SignIn();
                case ControlsEnum.SIGNOUT:
                    return new SignInOut.SignOut();
                default:
                    return null;
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.NEWMEMBER);
            else
                MessageBox.Show("Please log in first!","Log In!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.DASHBOARD);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void findMemberToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.FINDMEMBER);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void classesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.SCHEDULE);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void treatmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.SCHEDULE);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
            {
                Program.MainForm.ShowControl(ControlsEnum.LOGIN);
                MessageBox.Show("You have been logged out!", "Logged Out!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.LoggedIn = false;
            }
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void bookAClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Book a Class

        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Class Payments
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.PAYMENT);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void personsOnSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.PERSONSONSITE);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void viewAllBookingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.VIEWALLBOOKINGS);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void viewAllMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.VIEWALLMEMBERS);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.PAYMENT);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.SIGNIN);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.SIGNOUT);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(pdfFileName);
        }
    }
}

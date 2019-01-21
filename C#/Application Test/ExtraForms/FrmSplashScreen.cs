using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Test
{
    public partial class FrmSplashScreen : Form
    {
        public FrmSplashScreen()
        {
            InitializeComponent();

            statusBar.Value = 0;
        }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
            statusBar.Maximum = 500;
            timer1.Enabled = true;
            timer1.Interval = 1;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            statusBar.Value += 2;

            if (statusBar.Value == 500)
            {
                timer1.Stop();
                FrmMain.SplashScreenLoad = true;
                Application.Exit();
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Test
{
    static class Program
    {
        public static bool LoggedIn = false;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //create new instance of Form1 (our main form)
            form1 = new FrmMain();
            //run the application for the first time
            Application.Run(form1);
        }

        //private variable that holds the main form
        private static FrmMain form1;

        //public property that provides a getter for main form
        public static FrmMain MainForm
        {
            get { return form1; }
        }
    }
}
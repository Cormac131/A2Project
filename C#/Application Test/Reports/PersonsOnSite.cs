using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Application_Test.Reports
{
    public partial class PersonsOnSite : UserControl
    {
        public PersonsOnSite()
        {
            InitializeComponent();
        }

        private void PersonsOnSite_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studio2_Systems_DBDataSet.Member' table. You can move, or remove it, as needed.
            this.signInTableAdapter.Fill(this.studio2_Systems_DBDataSet2.SignIn);
        }
    }
}

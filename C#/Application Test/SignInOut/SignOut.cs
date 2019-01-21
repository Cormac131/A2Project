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

namespace Application_Test.SignInOut
{
    public partial class SignOut : UserControl
    {
        static int SignInID = 0,
        lstSelectedIndex = 0;

        public SignOut()
        {
            InitializeComponent();
            LoadAllMembers();
        }

        private void LoadAllMembers()
        {
            lstShowAllMembers.Items.Clear();

            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                string sqlString = "SELECT SignInID AS SignInID, " +
	                                      "Firstname AS Firstname, " +
	                                      "Surname AS Surname, " +
                                          "SignInDateTime AS SignInDateTime, " +
                                          "AccountedFor AS AccountedFor " +
                                    "FROM SignIn " +
                                    "INNER JOIN Member " +
                                    "ON Member.MemberID = SignIn.MemberID";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection1))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(myReader["SignInID"].ToString());
                            lvi.SubItems.Add(myReader["Firstname"].ToString());
                            lvi.SubItems.Add(myReader["Surname"].ToString());
                            lvi.SubItems.Add(myReader["SignInDateTime"].ToString());
                            lvi.SubItems.Add(myReader["AccountedFor"].ToString());
                            lstShowAllMembers.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lstShowAllMembers.Items.Clear();
            LoadAllMembers();
        }

        private void lstShowAllMembers_Click(object sender, EventArgs e)
        {
            SignInID = int.Parse(lstShowAllMembers.SelectedItems[lstSelectedIndex].SubItems[0].Text);
        }

        private void lstShowAllMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstSelectedIndex = lstShowAllMembers.FocusedItem.Index;
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                string sqlString = "DELETE FROM SignIn WHERE SignInID = "+SignInID+";";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection1))
                {
                    myCommand.ExecuteNonQuery();
                    myConnection1.Close();
                }
            }

            lstShowAllMembers.Items.Clear();
            LoadAllMembers();

            MessageBox.Show("Member has been signed out of the system.", "Member Signed Out!");
        }
    }
}
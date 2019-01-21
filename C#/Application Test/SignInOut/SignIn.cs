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
    public partial class SignIn : UserControl
    {
        string _membershipType;
        static int memberID = 0,
                lstSelectedIndex = 0;

        public SignIn()
        {
            InitializeComponent();
            LoadAllMembers();
            FillMembershipTypeCbx();
        }

        private void LoadAllMembers()
        {
            lstFindMembers.Items.Clear();

            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                string sqlString = "SELECT Member.MemberID AS MemberID, " +
                                        "Member.FirstName AS Firstname, " +
                                        "Member.Surname AS Surname,  " +
                                        "MembershipType.MembershipName AS MembershipType  " +
                                    "FROM Member  " +
                                    "INNER JOIN MembershipType  " +
                                    "ON Member.MembershipTypeID=MembershipType.MembershipTypeID " +
                                    "WHERE MembershipType.MembershipTypeID != 12";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection1))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(myReader["MemberID"].ToString());
                            lvi.SubItems.Add(myReader["Firstname"].ToString());
                            lvi.SubItems.Add(myReader["Surname"].ToString());
                            lvi.SubItems.Add(myReader["MembershipType"].ToString());
                            lstFindMembers.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void FindMembers()
        {
            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {
                string sqlString = "SELECT Member.MemberID AS MemberID,  " +
                                "Member.FirstName AS Firstname,  " +
                                "Member.Surname AS Surname,  " +
                                "MembershipType.MembershipName AS MembershipType  " +
                                "FROM Member  " +
                                "INNER JOIN MembershipType  " +
                                "ON Member.MembershipTypeID=MembershipType.MembershipTypeID  " +
                                "WHERE MembershipType.MembershipName = @memberType;";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection2))
                {
                    myCommand.Parameters.AddWithValue("@memberType", _membershipType);
                    myConnection2.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(myReader["MemberID"].ToString());
                            lvi.SubItems.Add(myReader["Firstname"].ToString());
                            lvi.SubItems.Add(myReader["Surname"].ToString());
                            lvi.SubItems.Add(myReader["MembershipType"].ToString());
                            lstFindMembers.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void cbxMembershipType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cbxMembershipType.SelectedIndex)
            {
                case 0:
                    _membershipType = "Individual";
                    break;
                case 1:
                    _membershipType = "Off Peak";
                    break;
                case 2:
                    _membershipType = "Concessionary (Over 60)";
                    break;
                case 3:
                    _membershipType = "Concessionary off peak (Over 60)";
                    break;
                case 4:
                    _membershipType = "Student";
                    break;
                case 5:
                    _membershipType = "Non Member";
                    break;
            }
        }

        private void FillMembershipTypeCbx()
        {
            string sqlStirng = "SELECT MembershipType.MembershipName AS MembershipName " +
                                "FROM MembershipType " +
                                "WHERE (MembershipType.MembershipTypeID % 2) <> 0 " +
                                "ORDER BY MembershipType.MembershipTypeID ASC;";

            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlStirng, myConnection2))
                {
                    myConnection2.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            cbxMembershipType.Items.Add(myReader["MembershipName"].ToString());
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lstFindMembers.Items.Clear();
            FindMembers();
        }

        private void lstFindMembers_Click(object sender, EventArgs e)
        {
            
        }

        private void lstFindMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            memberID = int.Parse(lstFindMembers.FocusedItem.SubItems[0].Text);
        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.NEWMEMBER);
        }

        private void btnSignInMember_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                string sqlString = "INSERT INTO SignIn VALUES ("+ memberID +",GETDATE(), 'YES')";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection1))
                {
                    myCommand.ExecuteNonQuery();
                    myConnection1.Close();
                }
            }

            lstFindMembers.Items.Clear();
            LoadAllMembers();

            MessageBox.Show("Member has been signed in to the system.", "Member Signed In!");
        }
    }
}

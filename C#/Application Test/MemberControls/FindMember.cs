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

namespace Application_Test
{
    public partial class FindMember : UserControl
    {

        #region SetSearchVars
        int _memberID = 0;
        string _surname = "";
        string _firstName = "";
        string _membershipType = "";
        DataSet dsSampleDatabase = new DataSet();
        Button[] btns = new Button[26];
        #endregion

        #region MembersVars
        public static string MemberID,
                            Title,
                            Gender,
                            Firstname,
                            Surname,
                            DOB,
                            Address1,
                            Address2,
                            Town,
                            County,
                            Postcode,
                            ContactHomeNo,
                            ContactMobileNo,
                            Email,
                            CardNo,
                            CardType,
                            CardName,
                            ExpiryMonth,
                            ExpiryYear,
                            MembershipTypeID,
                            MembershipTypeName,
                            MembershipLength,
                            MembershipMonthlyCost,
                            MembershipSingleCost;
        #endregion

        public FindMember()
        {
            InitializeComponent();

            connectAlphaButtons();
            LoadMembers();
            FillMembershipTypeCbx();
        }
        private void LoadMembersDetails(int _memberID)
        {
            Console.WriteLine(_memberID);

            #region SQL
            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {
                string sqlString = "SELECT Member.MemberID AS MemberID, " +
                                        "Member.Title AS Title, " +
                                        "Member.Gender AS Gender, " +
                                        "Member.FirstName AS Firstname, " +
                                        "Member.Surname AS Surname, " +
                                        "Member.DOB AS DOB, " +
                                        "Member.Address1 AS Address1, " +
                                        "Member.Address2 AS Address2, " +
                                        "Member.Town AS Town, " +
                                        "Member.County AS County, " +
                                        "Member.Postcode AS Postcode, " +
                                        "Member.ContactHomeNo AS ContactHomeNo, " +
                                        "Member.ContactMobileNo AS ContactMobileNo, " +
                                        "Member.Email AS Email, " +
                                        "Member.CardNo AS CardNo, " +
                                        "PaymentCard.CardType AS CardType, " +
                                        "PaymentCard.CardName AS CardName, " +
                                        "PaymentCard.ExpiryMonth AS ExpiryMonth, " +
                                        "PaymentCard.ExpiryYear AS ExpiryYear, " +
                                        "Member.MembershipTypeID AS MembershipTypeID, " +
                                        "MembershipType.MembershipName AS MembershipTypeName, " +
                                        "MembershipType.MembershipLength AS MembershipLength, " +
                                        "MembershipType.MembershipMonthlyCost AS MembershipMonthlyCost, " +
                                        "MembershipType.MembershipSingleCost AS MembershipSingleCost " +
                                        "FROM Member " +
                                        "INNER JOIN MembershipType " +
                                        "ON Member.MembershipTypeID=MembershipType.MembershipTypeID " +
                                        "INNER JOIN PaymentCard " +
                                        "ON Member.CardNo=PaymentCard.CardNo " +
                                        "WHERE Member.MemberID = @memberID;";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection2))
                {
                    myCommand.Parameters.AddWithValue("@memberID", _memberID);
                    myConnection2.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            MemberID = _memberID.ToString();
                            Title = myReader["Title"].ToString();
                            Gender = myReader["Gender"].ToString();
                            Firstname = myReader["Firstname"].ToString();
                            Surname = myReader["Surname"].ToString();
                            DOB = myReader["DOB"].ToString();
                            Address1 = myReader["Address1"].ToString();
                            Address2 = myReader["Address2"].ToString();
                            Town = myReader["Town"].ToString();
                            County = myReader["County"].ToString();
                            Postcode = myReader["Postcode"].ToString();
                            ContactHomeNo = myReader["ContactHomeNo"].ToString();
                            ContactMobileNo = myReader["ContactMobileNo"].ToString();
                            Email = myReader["Email"].ToString();
                            CardNo = myReader["CardNo"].ToString();
                            CardType = myReader["CardType"].ToString();
                            CardName = myReader["CardName"].ToString();
                            ExpiryMonth = myReader["ExpiryMonth"].ToString();
                            ExpiryYear = myReader["ExpiryYear"].ToString();
                            MembershipTypeID = myReader["MembershipTypeID"].ToString();
                            MembershipTypeName = myReader["MembershipTypeName"].ToString();
                            MembershipLength = myReader["MembershipLength"].ToString();
                            MembershipMonthlyCost = myReader["MembershipMonthlyCost"].ToString();
                            MembershipSingleCost = myReader["MembershipSingleCost"].ToString();
                        }                        
                    }
                }
            }
            #endregion

            MemberControls.FrmLoadMemberDetails loadMembersDetails = new MemberControls.FrmLoadMemberDetails();
            loadMembersDetails.Show();
        }

        private void LoadMembers()
        {
            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                string sqlString = "SELECT Member.MemberID AS MemberID, " +
                                        "Member.FirstName AS Firstname, " +
                                        "Member.Surname AS Surname,  " +
                                        "Member.DOB AS DOB,  " +
                                        "Member.Address1 AS Address1,  " +
                                        "Member.Address2 AS Address2,  " +
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
                            lvi.SubItems.Add(myReader["DOB"].ToString());
                            lvi.SubItems.Add(myReader["Address1"].ToString());
                            lvi.SubItems.Add(myReader["Address2"].ToString());                           
                            lvi.SubItems.Add(myReader["MembershipType"].ToString());
                            lstViewMembers.Items.Add(lvi);
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
                                "WHERE (Member.MemberID = @memberID  " +
                                "OR Member.FirstName = @firstname  " +
                                "OR Member.Surname = @surname " +
                                "OR MembershipType.MembershipName = @memberType);";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection2))
                {
                    myCommand.Parameters.AddWithValue("@memberID", _memberID);
                    myCommand.Parameters.AddWithValue("@firstname", _firstName);
                    myCommand.Parameters.AddWithValue("@surname", _surname);
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

        private void connectAlphaButtons()
        {
            for (int i = 0; i < 26; i++)
            {
                btns[i] = (Button)grpAlpha.Controls[26 - i];
                btns[i].Text = "" + (char)(65 + i);
                btns[i].Enabled = false;
                btns[i].BackColor = Color.Black;
                btns[i].Click += new EventHandler(btnLetters_Click);
            }

            using (SqlConnection myConnection = new SqlConnection(DataConnection.serverstring))
            {
                string sqlString = @"SELECT DISTINCT Surname FROM Member ORDER BY Surname;";
                SqlDataAdapter daLetters = new SqlDataAdapter(sqlString, myConnection);
                
                daLetters.Fill(dsSampleDatabase, "Letters");

                int no;
                foreach (DataRow dr in dsSampleDatabase.Tables["Letters"].Rows)
                {
                    no = (int)dr["surname"].ToString()[0] - 65;
                    Console.WriteLine(no.ToString());
                    btns[no].Enabled = true;
                    btns[no].BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
                    btns[no].ForeColor = Color.Green;
                }
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

        private void txtMemberID_TextChanged(object sender, EventArgs e)
        {
            if (this.txtMemberID.Text.Trim() == "")
            {
                _memberID = 0;
            }
            else
            {
                _memberID = int.Parse(this.txtMemberID.Text);
            }
        }

        private void txtSurame_TextChanged(object sender, EventArgs e)
        {
            _surname = this.txtSurame.Text;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            _firstName = this.txtFirstName.Text;
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

        private void button1_Click(object sender, EventArgs e)
        {
            lstFindMembers.Items.Clear();
            FindMembers();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            lstFindMembers.Items.Clear();
            using (SqlConnection myConnection = new SqlConnection(DataConnection.serverstring))
            {
                myConnection.Open();
                using (SqlCommand myCommand = new SqlCommand("SELECT Member.MemberID AS MemberID, Member.DOB AS DOB, Member.FirstName AS Firstname, Member.Surname AS Surname, MembershipType.MembershipName AS MembershipType FROM Member INNER JOIN MembershipType ON Member.MembershipTypeID=MembershipType.MembershipTypeID WHERE Member.MembershipTypeID!=12;", myConnection))
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

        private void btnLetters_Click(object sender, EventArgs e)
        {
            lstFindMembers.Items.Clear();

            Button b = (Button)sender;
            string str = "'[" + b.Text.ToLower().Trim() + "]%'";

            string sqlString = "SELECT Member.MemberID AS MemberID,  " +
                                "Member.FirstName AS Firstname,  " +
                                "Member.Surname AS Surname,  " +
                                "MembershipType.MembershipName AS MembershipType  " +
                                "FROM Member  " +
                                "INNER JOIN MembershipType  " +
                                "ON Member.MembershipTypeID=MembershipType.MembershipTypeID  " +
                                "WHERE Surname LIKE " + str +";";

            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection2))
                {
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

        private void FindMember_Load(object sender, EventArgs e)
        {
            connectAlphaButtons();
        }

        private void lstFindMembers_DoubleClick(object sender, EventArgs e)
        {
            String text = lstFindMembers.SelectedItems[0].Text;
            LoadMembersDetails(int.Parse(text));
        }

        private void lstViewMembers_DoubleClick(object sender, EventArgs e)
        {
            String text = lstViewMembers.SelectedItems[0].Text;
            LoadMembersDetails(int.Parse(text));
        }
    }
}

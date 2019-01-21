using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Test.ExtraForms
{
    public partial class FrmFindMember : Form
    {
        #region Set Vars
        int _memberID = 0;
        string _surname = "";
        string _firstName = "";
        string _membershipType = "";
        DataSet dsSampleDatabase = new DataSet();
        Button[] btns = new Button[26];
        public static int MemberID;
        public static string Firstname,
                            Surname,
                            MembershipTypeName;
        public static bool thisIsOpen = true;
        #endregion

        public FrmFindMember()
        {
            InitializeComponent();

            FillMembershipTypeCbx();
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

        private void conncetAlphaButtons()
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
                                "WHERE Surname LIKE " + str + ";";

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

        private void FrmFindMember_Load(object sender, EventArgs e)
        {
            conncetAlphaButtons();
        }

        private void lstFindMembers_DoubleClick(object sender, EventArgs e)
        {
            MemberID = int.Parse(lstFindMembers.SelectedItems[0].SubItems[0].Text);            
            Firstname = lstFindMembers.SelectedItems[0].SubItems[1].Text;
            Surname = lstFindMembers.SelectedItems[0].SubItems[2].Text;
            MembershipTypeName = lstFindMembers.SelectedItems[0].SubItems[3].Text;

            thisIsOpen = false;
            this.Close();
        }

        public static void setText(Control _txt1,Control _txt2,Control _txt3,Control _cbx1) 
        {
            TextBox txt1 = (TextBox)_txt1;
            TextBox txt2 = (TextBox)_txt2;
            TextBox txt3 = (TextBox)_txt3;
            ComboBox cbx1 = (ComboBox)_cbx1;

            txt1.Text = ExtraForms.FrmFindMember.MemberID.ToString();
            txt2.Text = ExtraForms.FrmFindMember.Firstname;
            txt3.Text = ExtraForms.FrmFindMember.Surname;
            cbx1.SelectedItem = ExtraForms.FrmFindMember.MembershipTypeName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.NEWMEMBER);
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application_Test;
using System.Data.SqlClient;

namespace Application_Test
{
    public partial class NewMember : UserControl
    {
        #region Define Vars
        private static string title = "",
                            gender = "",
                            surname = "",
                            firstname = "",
                            address1 = "",
                            address2 = "",
                            town = "",
                            county = "",
                            postcode = "",
                            email = "",
                            nameOnCard = "",
                            cardType = "",
                            homePhoneNo = "",
                            mobilePhoneNo = "",
                            membershipName = "";
        private static int  expiryMonth = 0,
                            expiryYear = 0,
                            membershipTypeID = 0,
                            membershipLength = 0;
        private static double cardNo = 0;
        private static bool cardSelected = false;
        DateTime DOB = new DateTime();
        string[] membershipTypes = new string[6];
        #endregion

        public NewMember()
        {
            InitializeComponent();
        }

        public bool formValidated()
        {
            bool ok = true;

            if (ValidationMethods.validComboBox(cbxTitle, lblTitle) == false)
                ok = false;
            else if (ValidationMethods.validComboBox(cbxGender, lblGender) == false)
                ok = false;
            else if (ValidationMethods.validString(txtSurname, 0, 30, lblSurname) == false)
                ok = false;
            else if (ValidationMethods.validString(txtFirstname, 0, 30, lblFirstname) == false)
                ok = false;
            else if (ValidationMethods.validDateTimePicker(dtpDOB) == false)
                ok = false;
            else if (ValidationMethods.validString(txtAddress1, 0, 100, lblAddress1) == false)
                ok = false;
            else if (ValidationMethods.validString(txtAddress2, 0, 100, lblAddress2) == false)
                ok = false;
            else if (ValidationMethods.validString(txtTown, 0, 30, lblTown) == false)
                ok = false;
            else if (ValidationMethods.validString(txtCounty, 0, 30, lblCounty) == false)
                ok = false;
            else if (ValidationMethods.validPostcode(txtPostcode, 6, 8, lblPostcode) == false)             
                ok = false;
            else if (ValidationMethods.validString(txtHomePhoneNo, 11, 11, lblHomePhone) == false)
                ok = false;
            else if (ValidationMethods.validString(txtMobilePhoneNo, 11, 11, lblMobilePhone) == false)
                ok = false;
            else if (ValidationMethods.validEmail(txtEmail,lblEmail) == false)                     
                ok = false;
            else if (cbCard.Checked)
            {
                if (ValidationMethods.validCheckBox(cbCard, cbCash, lblPaymentOption) == false)
                    ok = false;
                else if (ValidationMethods.validInt(txtCardNumber, 16, 16, lblCardNo) == false)
                    ok = false;
                else if (ValidationMethods.validComboBox(cbxCardType, lblCardType) == false)
                    ok = false;
                else if (ValidationMethods.validString(txtNameOnCard, 10, 30, lblNameOnCard) == false)
                    ok = false;
                else if (ValidationMethods.validComboBox(cbxExpiryMonth, lblExpiryMonth) == false)
                    ok = false;
                else if (ValidationMethods.validComboBox(cbxExpiryYear, lblExpiryYear) == false)
                    ok = false;

            }
            else if (ValidationMethods.validComboBox(cbxMembershipTypeID, lblMembershipType) == false)
                ok = false;

            return ok;
        }

        public void addMemberDB()
        {
            if (formValidated() == true)
            {
                if (cbCard.Checked)
                {
                    using (SqlConnection myConnection = new SqlConnection(DataConnection.serverstring))
                    {
                        DateTime reDOB = DOB.Date + DateTime.Now.TimeOfDay;

                        string myQueryString = "INSERT INTO Member " +
                                                "VALUES (@title,@gender,@surname,@firstname,@DOB,@address1,@address2 " +
                                                        ",@town,@county,@postcode,@contactHomeNo,@contactMobileNo, " +
                                                        "@email,@cardNo,@membershipTypeID); " +

                                                "INSERT INTO PaymentCard " +
                                                "VALUES (@cardNo,@cardType,@cardName,@expiryMonth,@expiryYear);";
                        using (SqlCommand myCommand = new SqlCommand(myQueryString, myConnection))
                        {
                            myCommand.Parameters.AddWithValue("@title", title);
                            myCommand.Parameters.AddWithValue("@gender", gender);
                            myCommand.Parameters.AddWithValue("@surname", surname);
                            myCommand.Parameters.AddWithValue("@firstname", firstname);
                            myCommand.Parameters.AddWithValue("@DOB", reDOB.Date);
                            myCommand.Parameters.AddWithValue("@address1", address1);
                            myCommand.Parameters.AddWithValue("@address2", address2);
                            myCommand.Parameters.AddWithValue("@town", town);
                            myCommand.Parameters.AddWithValue("@county", county);  
                            myCommand.Parameters.AddWithValue("@postcode", postcode);
                            myCommand.Parameters.AddWithValue("@contactHomeNo", homePhoneNo.ToString());
                            myCommand.Parameters.AddWithValue("@contactMobileNo", mobilePhoneNo.ToString());
                            myCommand.Parameters.AddWithValue("@email", email);
                            myCommand.Parameters.AddWithValue("@cardNo", cardNo);
                            myCommand.Parameters.AddWithValue("@membershipTypeID", membershipTypeID);                                                      
                            myCommand.Parameters.AddWithValue("@cardType", cardType);
                            myCommand.Parameters.AddWithValue("@cardName", nameOnCard);
                            myCommand.Parameters.AddWithValue("@expiryMonth", expiryMonth);
                            myCommand.Parameters.AddWithValue("@expiryYear", expiryYear);
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                        }
                    }
                }
                else if (cbCash.Checked)
                {
                    DateTime reDOB = DOB.Date + DateTime.Now.TimeOfDay;

                    using (SqlConnection myConnection = new SqlConnection(DataConnection.serverstring))
                    {
                        string myQueryString = "INSERT INTO Member (Title,Gender,Surname,FirstName,DOB,Address1,Address2,Town,County,Postcode, " +
                                                            "ContactHomeNo,ContactMobileNo,Email,MembershipTypeID) " +
                                                "VALUES (@title,@gender,@surname,@firstname,@DOB,@address1,@address2 " +
                                                        ",@town,@county,@postcode,@contactHomeNo,@contactMobileNo, " +
                                                        "@email,@membershipTypeID);";
                        using (SqlCommand myCommand = new SqlCommand(myQueryString, myConnection))
                        {
                            myCommand.Parameters.AddWithValue("@title", title);
                            myCommand.Parameters.AddWithValue("@gender", gender);
                            myCommand.Parameters.AddWithValue("@surname", surname);
                            myCommand.Parameters.AddWithValue("@firstname", firstname);
                            myCommand.Parameters.AddWithValue("@DOB", reDOB.Date);
                            myCommand.Parameters.AddWithValue("@address1", address1);
                            myCommand.Parameters.AddWithValue("@address2", address2);
                            myCommand.Parameters.AddWithValue("@town", town);
                            myCommand.Parameters.AddWithValue("@county", county);
                            myCommand.Parameters.AddWithValue("@postcode", postcode);
                            myCommand.Parameters.AddWithValue("@contactHomeNo", homePhoneNo.ToString());
                            myCommand.Parameters.AddWithValue("@contactMobileNo", mobilePhoneNo.ToString());
                            myCommand.Parameters.AddWithValue("@email", email);
                            myCommand.Parameters.AddWithValue("@membershipTypeID", membershipTypeID);                            
                            
                            myConnection.Open();
                            myCommand.ExecuteNonQuery();
                            myConnection.Close();
                        }
                    }
                }
            }
        }

        public void loadMembershipTypes()
        {
            string sqlStirng = "SELECT MembershipType.MembershipName AS MembershipName " +
                                "FROM MembershipType " +
                                "WHERE (MembershipType.MembershipTypeID % 2) <> 0 " +
                                "ORDER BY MembershipType.MembershipTypeID ASC;";

            using (SqlConnection myConnection = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlStirng, myConnection))
                {
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        int i = 0;
                        while (myReader.Read())
                        {
                            cbxMembershipTypeID.Items.Add(myReader["MembershipName"].ToString());
                            membershipTypes[i] = myReader["MembershipName"].ToString();
                            i++;
                        }
                    }
                }
            }
        }

        public void ClearAll()
        {
            cbxTitle.ResetText();
            cbxGender.ResetText();
            txtSurname.ResetText();
            txtFirstname.ResetText();
            dtpDOB.ResetText();
            txtAddress1.Clear();
            txtAddress2.Clear();
            txtTown.Clear();
            txtCounty.Clear();
            txtPostcode.Clear();
            txtHomePhoneNo.Clear();
            txtMobilePhoneNo.Clear();
            txtEmail.Clear();
            cbCard.CheckState = CheckState.Unchecked;
            cbCash.CheckState = CheckState.Unchecked;
            txtCardNumber.Clear();
            cbxCardType.ResetText();
            txtNameOnCard.Clear();
            cbxExpiryMonth.ResetText();
            cbxExpiryYear.ResetText();
            cbxMembershipTypeID.ResetText();
            cbSixMonths.CheckState = CheckState.Unchecked;
            cbTwelveMonths.CheckState = CheckState.Unchecked;
            //re-enable disabled fields
            txtCardNumber.Enabled = true;
            cbxCardType.Enabled = true;
            txtNameOnCard.Enabled = true;
            cbxExpiryMonth.Enabled = true;
            cbxExpiryYear.Enabled = true;
            cardSelected = true;
        }

        public void getMemebershipID()
        {
            string sqlStirng = "SELECT MembershipType.MembershipTypeID AS MembershipTypeID " +
                                "FROM MembershipType " +
                                "WHERE MembershipType.MembershipName = @membershipName " +
                                "AND MembershipType.MembershipLength = @membershipLength;";

            using (SqlConnection myConnection = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlStirng, myConnection))
                {
                    myCommand.Parameters.AddWithValue("@membershipLength", membershipLength);
                    myCommand.Parameters.AddWithValue("@membershipName", membershipName);
                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            membershipTypeID = int.Parse(myReader["MembershipTypeID"].ToString());
                        }
                    }
                }
            }
        }

        #region UpdateInputs
        private void cbxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            title = this.cbxTitle.SelectedItem.ToString();
        }

        private void cbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            gender = this.cbxGender.SelectedItem.ToString();
        }

        private void txtSurname_TextChanged(object sender, EventArgs e)
        {
            surname = this.txtSurname.Text;
        }

        private void txtFirstname_TextChanged(object sender, EventArgs e)
        {
            firstname = this.txtFirstname.Text;
        }

        private void dtpDOB_ValueChanged(object sender, EventArgs e)
        {
            DOB = this.dtpDOB.Value;
        }

        private void txtAddress1_TextChanged(object sender, EventArgs e)
        {
            address1 = this.txtAddress1.Text;
        }

        private void txtAddress2_TextChanged(object sender, EventArgs e)
        {
            address2 = this.txtAddress2.Text;
        }

        private void txtTown_TextChanged(object sender, EventArgs e)
        {
            town = this.txtTown.Text;
        }

        private void txtCounty_TextChanged(object sender, EventArgs e)
        {
            county = this.txtCounty.Text;
        }

        private void txtPostcode_TextChanged(object sender, EventArgs e)
        {
            postcode = this.txtPostcode.Text;
        }

        private void txtHomePhoneNo_TextChanged(object sender, EventArgs e)
        {
            homePhoneNo = this.txtHomePhoneNo.Text;
        }

        private void txtMobilePhoneNo_TextChanged(object sender, EventArgs e)
        {
            mobilePhoneNo = this.txtMobilePhoneNo.Text;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            email = this.txtEmail.Text;
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            cardNo = double.Parse(this.txtCardNumber.Text);
        }

        private void cbxCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cardType = this.cbxCardType.SelectedItem.ToString();
        }

        private void txtNameOnCard_TextChanged(object sender, EventArgs e)
        {
            nameOnCard = this.txtNameOnCard.Text;
        }

        private void cbxExpiryMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            expiryMonth = int.Parse(this.cbxExpiryMonth.SelectedItem.ToString());
        }

        private void cbxExpiryYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            expiryYear = int.Parse(this.cbxExpiryYear.SelectedItem.ToString());
        }
        
        private void cbCash_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbCash.Checked)
            {
                cardSelected = true;
                txtCardNumber.Enabled = false;
                cbxCardType.Enabled = false;
                txtNameOnCard.Enabled = false;
                cbxExpiryMonth.Enabled = false;
                cbxExpiryYear.Enabled = false;
                cbCard.CheckState = CheckState.Unchecked;
            }
            else
            {
                txtCardNumber.Enabled = true;
                cbxCardType.Enabled = true;
                txtNameOnCard.Enabled = true;
                cbxExpiryMonth.Enabled = true;
                cbxExpiryYear.Enabled = true;
            }
        }

        private void cbxMembershipTypeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = this.cbxMembershipTypeID.SelectedIndex;
            switch (id)
            {
                case 0:
                    membershipName = membershipTypes[0];
                    break;
                case 1:
                    membershipName = membershipTypes[1];
                    break;
                case 2:
                    membershipName = membershipTypes[2];
                    break;
                case 3:
                    membershipName = membershipTypes[3];
                    break;
                case 4:
                    membershipName = membershipTypes[4];
                    break;
                case 5:
                    membershipName = membershipTypes[5];
                    break;
            }
        }

        private void cbSixMonths_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSixMonths.CheckState == CheckState.Checked)
            {
                membershipLength = 6;
                cbTwelveMonths.CheckState = CheckState.Unchecked;
            }
        }

        private void cbTwelveMonths_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTwelveMonths.CheckState == CheckState.Checked)
            {
                membershipLength = 12;
                cbSixMonths.CheckState = CheckState.Unchecked;
            }
        }

        private void cbCard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCard.Checked)
            {
                cbCash.CheckState = CheckState.Unchecked;
            }
        }
        #endregion

        private void NewMember_Load(object sender, EventArgs e)
        {
            loadMembershipTypes();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            getMemebershipID();
            Console.WriteLine(membershipTypeID.ToString());
            if (formValidated() == true)
            {
                getMemebershipID();
                addMemberDB();
                ClearAll();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btnAddAnother_Click(object sender, EventArgs e)
        {
            if (formValidated() == true)
            {
                getMemebershipID();
                addMemberDB();
            }
        }
    }
}

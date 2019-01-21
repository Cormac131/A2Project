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

namespace Application_Test.MemberControls
{
    public partial class FrmLoadMemberDetails : Form
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
        private static int expiryMonth = 0,
                            expiryYear = 0,
                            membershipTypeID = 0,
                            membershipLength = 0;
        private static double cardNo = 0;                            
        private static bool cardSelected = false;
        DateTime DOB = new DateTime();
        string[] membershipTypes = new string[6];
        public bool editForm = false;
        #endregion

        public FrmLoadMemberDetails()
        {
            InitializeComponent();
            FillMembershipTypeCbx();
            loadMemberInformation();
            lockControls(editForm);
        }

        public void loadMemberInformation()
        {
            cbxTitle.SelectedItem = FindMember.Title;
            cbxGender.SelectedItem = FindMember.Gender;            
            txtSurname.Text = FindMember.Surname;
            txtFirstname.Text = FindMember.Surname;
            dtpDOB.Text = FindMember.DOB;
            txtAddress1.Text = FindMember.Address1;
            txtAddress2.Text = FindMember.Address2;
            txtTown.Text = FindMember.Town;
            txtCounty.Text = FindMember.County;
            txtPostcode.Text = FindMember.Postcode;
            txtHomePhoneNo.Text = FindMember.ContactHomeNo;
            txtMobilePhoneNo.Text = FindMember.ContactMobileNo;
            txtEmail.Text = FindMember.Email;

            if (FindMember.CardNo != null)
            {
                cbCash.Checked = true;
                cbCard.Checked = false;
            }
            else
            {
                cbCard.Checked = true;
                cbCash.Checked = false;
            }

            txtCardNumber.Text = FindMember.CardNo;
            cbxCardType.SelectedItem = FindMember.CardType;
            txtNameOnCard.Text = FindMember.CardName;
            cbxExpiryMonth.SelectedItem = FindMember.ExpiryMonth;
            cbxExpiryYear.SelectedItem = FindMember.ExpiryYear;
            cbxMembershipTypeID.SelectedItem = FindMember.MembershipTypeName;

            if (FindMember.MembershipLength == "6")
            {
                cbSixMonths.Checked = true;
                cbTwelveMonths.Checked = false;
            }
            else
            {
                cbSixMonths.Checked = false;
                cbTwelveMonths.Checked = true;
            }            
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
            else if (ValidationMethods.validEmail(txtEmail, lblEmail) == false)
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

        public void lockControls(bool _enabled)
        {
            cbxTitle.Enabled = _enabled;
            cbxGender.Enabled = _enabled;
            txtSurname.Enabled = _enabled;
            txtFirstname.Enabled = _enabled;
            dtpDOB.Enabled = _enabled;
            txtAddress1.Enabled = _enabled;
            txtAddress2.Enabled = _enabled;
            txtTown.Enabled = _enabled;
            txtCounty.Enabled = _enabled;
            txtPostcode.Enabled = _enabled;
            txtHomePhoneNo.Enabled = _enabled;
            txtMobilePhoneNo.Enabled = _enabled;
            txtEmail.Enabled = _enabled;
            cbCard.Enabled = _enabled;
            cbCash.Enabled = _enabled;
            txtCardNumber.Enabled = _enabled;
            cbxCardType.Enabled = _enabled;
            txtNameOnCard.Enabled = _enabled;
            cbxExpiryMonth.Enabled = _enabled;
            cbxExpiryYear.Enabled = _enabled;
            cbxMembershipTypeID.Enabled = _enabled;
            cbSixMonths.Enabled = _enabled;
            cbTwelveMonths.Enabled = _enabled;
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
                            cbxMembershipTypeID.Items.Add(myReader["MembershipName"].ToString());
                        }
                    }
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editForm == true)
            {
                editForm = false;
            }
            else
            {
                editForm = true;
                lockControls(editForm);
            }            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SAVE TO DB DETAILS USING SQL
            if ((formValidated() == true ) && (editForm == true))
            {                
                addMemberDB();

                DialogResult result;
                result = MessageBox.Show("Member details saved!", "Saved!", MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
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
            if (this.txtCardNumber.Text != null)
            {
                cardNo = double.Parse(this.txtCardNumber.Text);
            }            
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
    }
}

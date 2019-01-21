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

namespace Application_Test.MainControls
{
    public partial class Payment : UserControl
    {

        public Payment()
        {
            InitializeComponent();
            loadPaymentRecords();
        }

        public void loadPaymentRecords()
        {
            lstShowAllPayments.Items.Clear();

            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                string sqlString = "SELECT Payment.PaymentID AS paymentID, " +
                                    "Payment.PaidAmount AS paidAmount, " +
                                    "Payment.DateOfPayment AS dateOfPayment, " +
                                    "Member.FirstName AS firstname, " +
                                    "Member.Surname AS surname " +
                                    "FROM Booking " +
                                    "INNER JOIN Member " +
                                    "ON Booking.MemberID = Member.MemberID " +
                                    "INNER JOIN Payment " +
                                    "ON Booking.PaymentID = Payment.PaymentID " +
                                    "ORDER BY Booking.PaymentID ASC; ";

                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection1))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            ListViewItem lvi = new ListViewItem(myReader["paymentID"].ToString());
                            lvi.SubItems.Add(myReader["firstname"].ToString());
                            lvi.SubItems.Add(myReader["surname"].ToString());
                            lvi.SubItems.Add(myReader["dateOfPayment"].ToString());
                            lvi.SubItems.Add(myReader["paidAmount"].ToString());
                            lstShowAllPayments.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            loadPaymentRecords();
        }

        private void lstShowAllPayments_DoubleClick(object sender, EventArgs e)
        {
            string str = lstShowAllPayments.SelectedItems.ToString();
            Console.WriteLine(str);
        }
    }
}

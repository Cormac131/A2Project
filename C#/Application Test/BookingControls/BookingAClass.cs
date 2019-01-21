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
using Application_Test.Class;

namespace Application_Test.BookingControls
{
    public partial class BookingAClass : UserControl
    {
        private static int classesFound = 1,
                        lst1SelectedIndex = 0,
                        lst2SelectedIndex = 0;
        private static string className = "",
                        classLevel = "",
                        _classDay = "",
                        _className = "",
                        _classLevel = "";
        int[] slotIDs = new int[classesFound];
        string[,] classes = new string[6, 5];
        DateTime[] classDates = new DateTime[6];        
        int[] id = new int[6];

        public BookingAClass()
        {            
            InitializeComponent();
        }

        public void loadClassNameCbx()
        {
            string sqlStirng = "SELECT ClassType.ClassType AS ClassName " +
                                "FROM ClassType " +
                                "WHERE ClassType.ClassID = 3 " +
	                                "OR ClassType.ClassID = 6 " +
	                                "OR ClassType.ClassID = 9 " +
	                                "OR ClassType.ClassID = 12 " +
	                                "OR ClassType.ClassID = 15 " +
                                "ORDER BY ClassType.ClassID ASC;";

            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlStirng, myConnection2))
                {
                    myConnection2.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            cbxClassName.Items.Add(myReader["ClassName"].ToString());
                        }
                    }
                }
            }

            switch (className)
            {
                case "Yoga":
                    cbxClassName.SelectedIndex = 0;
                    break;
                case "Tai Chi":
                    cbxClassName.SelectedIndex = 1;
                    break;
                case "Judo":
                    cbxClassName.SelectedIndex = 2;
                    break;
                case "Pilates":
                    cbxClassName.SelectedIndex = 3;
                    break;
                case "Keep Fit":
                    cbxClassName.SelectedIndex = 4;
                    break;
            }
        }

        public void loadClassLevelCbx()
        {
            string sqlStirng = "SELECT ClassType.ClassLevel AS ClassLevel " +
                                "FROM ClassType " +
                                "WHERE ClassType.ClassID = 1 " +
                                    "OR ClassType.ClassID = 2 " +
                                    "OR ClassType.ClassID = 3 " +
                                "ORDER BY ClassType.ClassID ASC;";

            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlStirng, myConnection2))
                {
                    myConnection2.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            cbxClassLevel.Items.Add(myReader["ClassLevel"].ToString());
                        }
                    }
                }
            }

            switch (classLevel)
            {
                case "Beginner":
                    cbxClassLevel.SelectedIndex = 0;
                    break;
                case "Intermediate":
                    cbxClassLevel.SelectedIndex = 1;
                    break;
                case "Advanced":
                    cbxClassLevel.SelectedIndex = 2;
                    break;
            }
        }

        public void findSlotID()
        {
            if (_classDay != "")
            {
                switch (_classDay)
                {
                    case "Monday":
                        id[0] = 1;
                        id[1] = 2;
                        id[2] = 3;
                        id[3] = 4;
                        id[4] = 5;
                        id[5] = 6;
                        break;
                    case "Tuesday":
                        id[0] = 7;
                        id[1] = 8;
                        id[2] = 9;
                        id[3] = 10;
                        id[4] = 11;
                        id[5] = 12;
                        break;
                    case "Wednesday":
                        id[0] = 13;
                        id[1] = 14;
                        id[2] = 15;
                        id[3] = 16;
                        id[4] = 17;
                        id[5] = 18;
                        break;
                    case "Thursday":
                        id[0] = 19;
                        id[1] = 20;
                        id[2] = 21;
                        id[3] = 22;
                        id[4] = 23;
                        id[5] = 24;
                        break;
                    case "Friday":
                        id[0] = 25;
                        id[1] = 26;
                        id[2] = 27;
                        id[3] = 28;
                        id[4] = 29;
                        id[5] = 30;
                        break;
                    case "Saturday":
                        id[0] = 31;
                        id[1] = 32;
                        id[2] = 33;
                        id[3] = 0;
                        id[4] = 0;
                        id[5] = 0;
                        break;
                }
            }
        }

        public void loadSameClass()
        {
            findSlotID();

            string sqlStirng = "SELECT ClassType.ClassType AS ClassName, " +
                            "ClassType.ClassLevel AS ClassLevel " +
                            "FROM Schedule " +
                            "INNER JOIN ClassType " +
                            "ON Schedule.ClassID = ClassType.ClassID " +
                            "WHERE Schedule.SlotID = @slotID " +
                            "OR (ClassType.ClassType = @className " +
                            "AND ClassType.ClassType = @classLevel " +
                            "AND (Schedule.SlotID = @ID1  " +
                            "OR Schedule.SlotID = @ID2  " +
                            "OR Schedule.SlotID = @ID3  " +
                            "OR Schedule.SlotID = @ID4  " +
                            "OR Schedule.SlotID = @ID5  " +
                            "OR Schedule.SlotID = @ID6));";

            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlStirng, myConnection2))
                {
                    myCommand.Parameters.AddWithValue("@slotID", Schedule.slotID);
                    myCommand.Parameters.AddWithValue("@className", _className);
                    myCommand.Parameters.AddWithValue("@classLevel", _classLevel);
                    myCommand.Parameters.AddWithValue("@ID1", id[0]);
                    myCommand.Parameters.AddWithValue("@ID2", id[1]);
                    myCommand.Parameters.AddWithValue("@ID3", id[2]);
                    myCommand.Parameters.AddWithValue("@ID4", id[3]);
                    myCommand.Parameters.AddWithValue("@ID5", id[4]);
                    myCommand.Parameters.AddWithValue("@ID6", id[5]);
                    myConnection2.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            className = myReader["ClassName"].ToString();
                            classLevel = myReader["ClassLevel"].ToString();
                        }
                    }
                }
            }
        }

        //search class feature
        private void searchClass(string cName, string cLevel, string cDay)
        {
            int classID = 0,
                classCount = 0;

            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {

                //find the class id from name and level
                myConnection2.Open();

                string sqlQuery = "SELECT ClassID AS ClassID " +
                                    "FROM ClassType " +
                                    "WHERE ClassType = " + cName +
                                    " AND ClassLevel = " + cLevel + ";";
                using (SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection2))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            classID = int.Parse(myReader["ClassID"].ToString());
                        }
                    }
                }
                myConnection2.Close();

                //count slot ids with same class id on a day

                myConnection2.Open();

                string sqlCount = "SELECT COUNT(*) AS ClassCount " +
                                    "FROM Schedule " +
                                    "WHERE ClassID = " + classID + " " +
                                    "AND SlotDay = " + cDay + "; ";
                using (SqlCommand myCommand = new SqlCommand(sqlCount, myConnection2))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            classCount = int.Parse(myReader["ClassCount"].ToString());
                        }
                    }
                }

                if (classCount == 0)
                {
                    //Message box saying no available classes
                }
                else if (classCount == 1)
                {
                    
                }
            }
        }

        public void getClassDates(ListView lst)
        {
            //clear previous results
            lst.Items.Clear();

            //find date of next class
            DateTime todaysDate = DateTime.Today;

            //load class details
            loadSameClass();

            //load next class dates (6 weeks)            
            classDates[0] = Class.BookingMethods.nextDay(todaysDate, Class.BookingMethods.slotDay());

            for (int i = 1; i < 6; i++)
            {
                classDates[i] = classDates[0].AddDays(7 * i);                
            }

            //set the classes equal
            for (int i = 0; i < 6; i++)
            {
                classes[i, 0] = Schedule.slotID.ToString();
                classes[i, 1] = className;
                classes[i, 2] = classLevel;
                classes[i, 3] = classDates[i].Date.ToString("yyyy-MM-dd");
                classes[i, 4] = i.ToString();

                if (BookingMethods.classBookings(int.Parse(classes[i,0]), classes[i,3]) == true)
                {
                    ListViewItem lvi = new ListViewItem(classes[i, 1]);
                    lvi.SubItems.Add(classes[i, 2]);
                    lvi.SubItems.Add(classes[i, 3]);
                    lst.Items.Add(lvi);
                }                        
            }
        }

        private void BookingAClass_Load(object sender, EventArgs e)
        {
            //load info
            loadClassLevelCbx();
            loadClassNameCbx();
            getClassDates(lstAvailableClasses);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getClassDates(lstAvailableClasses);
        }

        private void cbxClassDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            _classDay = cbxClassDay.SelectedText;
        }

        private void cbxClassName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _className = cbxClassName.SelectedText;
        }

        private void cbxClassLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            _classLevel = cbxClassLevel.SelectedText;
        }

        private void lstAvailableClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAvailableClasses.SelectedItems.Count > 6)
            {
                lst1SelectedIndex = lstAvailableClasses.FocusedItem.Index;
            }            
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            try
            {
                addClass(lstAvailableClasses, lstSelectedClasses);
            }
            catch
            {
                MessageBox.Show("Please select a class.", "Select a class!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addClass(ListView lst1, ListView lst2)
        {
            int slotID = Schedule.slotID;
            string className = lst1.SelectedItems[lst1SelectedIndex].SubItems[0].Text;
            string classLevel = lst1.SelectedItems[lst1SelectedIndex].SubItems[1].Text;
            string classDate = lst1.SelectedItems[lst1SelectedIndex].SubItems[2].Text;
            lst1.SelectedItems[lst1SelectedIndex].Remove();

            ListViewItem lvi = new ListViewItem(className);
            lvi.SubItems.Add(classLevel);
            lvi.SubItems.Add(classDate);
            lst2.Items.Add(lvi);  
        }

        public void removeClass(ListView lst1, ListView lst2)
        {
            int slotID = Schedule.slotID;
            string className = lst2.SelectedItems[lst2SelectedIndex].SubItems[0].Text;
            string classLevel = lst2.SelectedItems[lst2SelectedIndex].SubItems[1].Text;
            string classDate = lst2.SelectedItems[lst2SelectedIndex].SubItems[2].Text;
            lst2.SelectedItems[lst2SelectedIndex].Remove();

            ListViewItem lvi = new ListViewItem(className);
            lvi.SubItems.Add(classLevel);
            lvi.SubItems.Add(classDate);
            lst1.Items.Add(lvi);
        }

        private void btnRemoveClass_Click(object sender, EventArgs e)
        {
            try
            {
                removeClass(lstAvailableClasses, lstSelectedClasses);
            }
            catch
            {
                MessageBox.Show("Please select a class.", "Select a class!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lstSelectedClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedClasses.SelectedItems.Count > 6)
            {
                lst2SelectedIndex = lstSelectedClasses.FocusedItem.Index;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExtraForms.FrmFindMember FrmFindMember = new ExtraForms.FrmFindMember();
            FrmFindMember.Show();

            //while (ExtraForms.FrmFindMember.thisIsOpen == true)
            //{
            //    ExtraForms.FrmFindMember.setText(txtMemberID, txtFirstname, txtSurname, cbxMembershipType);
            //}
        }

        private void resetLists()
        {
            int count = lstSelectedClasses.Items.Count;

            for (int i = 0; i < count; i++)
            {
                int b = i + 1;
                int slotID = Schedule.slotID;
                string className = lstSelectedClasses.SelectedItems[b].SubItems[0].Text;
                string classLevel = lstSelectedClasses.SelectedItems[b].SubItems[1].Text;
                string classDate = lstSelectedClasses.SelectedItems[b].SubItems[2].Text;
                lstSelectedClasses.SelectedItems[b].Remove();

                ListViewItem lvi = new ListViewItem(className);
                lvi.SubItems.Add(classLevel);
                lvi.SubItems.Add(classDate);
                lstAvailableClasses.Items.Add(lvi);                
            }
            
        }

        private int getPaymentID()
        {
            // get count of records in payment for payment id
            string sqlStirng1 = "SELECT Count(*) AS TotalCount FROM Payment";
            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {

                using (SqlCommand myCommand = new SqlCommand(sqlStirng1, myConnection2))
                {
                    myConnection2.Open();

                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            return (int.Parse(myReader["TotalCount"].ToString()));
                        }
                    }
                }
            }
            return 0;
        }

        private void btnBook_Click(object sender, EventArgs e)
        {
            int count = lstSelectedClasses.Items.Count;

            if (count > 1)
            {
                string[,] cb = new string[count + 1, 6];

                DateTime dT = DateTime.Now;
                double PaidAmount;

                if (count == 6)
                    PaidAmount = (count * 20) * 0.9;
                else
                    PaidAmount = count * 20;

                cb[count, 0] = getPaymentID().ToString(); // PaymentID
                cb[count, 1] = PaidAmount.ToString(); // PaidAmount / got from the amount of records selected.
                cb[count, 2] = "NO"; // Single Payment?
                cb[count, 3] = dT.Date.ToString("yyyy-MM-dd"); // Date of Payment

                using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
                {
                    string sqlStirng2 = "INSERT INTO Payment VALUES (@PaidAmount, @SinglePayment, @DateOfPayment)";
                    using (SqlCommand myCommand = new SqlCommand(sqlStirng2, myConnection2))
                    {
                        myCommand.Parameters.AddWithValue("@PaidAmount", int.Parse(cb[count, 1]));
                        myCommand.Parameters.AddWithValue("@SinglePayment", cb[count, 2]);
                        myCommand.Parameters.AddWithValue("@DateOfPayment", cb[count, 3]);
                        myConnection2.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection2.Close();
                    }
                }

                for (int i = 0; i < count; i++)
                {
                    cb[i, 0] = ExtraForms.FrmFindMember.MemberID.ToString(); //MemberID
                    cb[i, 1] = Schedule.slotID.ToString(); // slotID
                    cb[i, 2] = getPaymentID().ToString(); //count the payments in payment table and add 1 / PaymentID
                    cb[i, 3] = "NA"; //attended?
                    cb[i, 4] = lstSelectedClasses.Items[i].SubItems[2].Text.TrimEnd(' ','0','0',':','0','0',':','0','0');// date of class
                    cb[i, 5] = "YES"; // Paid?

                    Console.WriteLine(cb[i, 0] + " - " + cb[i, 1] + " - " + cb[i, 2] + " - " + cb[i, 3] + " - " + cb[i, 4] + " - " + cb[i, 5]);

                    using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
                    {
                        string sqlStirng1 = "INSERT INTO Booking " + 
                                            "VALUES(" + int.Parse(cb[i, 0]) + "," + int.Parse(cb[i, 1])
                                            + ", " + int.Parse(cb[i, 2]) + ", '" + cb[i, 3] + "','"+cb[i, 4]+"','" + cb[i, 5] + "');";

                        using (SqlCommand myCommand = new SqlCommand(sqlStirng1, myConnection2))
                        {
                            myConnection2.Open();
                            myCommand.ExecuteNonQuery();
                            myConnection2.Close();
                        }
                    }
                }

                // User response
                //resetLists();
                MessageBox.Show("All classes have been booked./n You can view them on the bookings page.", "Classes Booked", MessageBoxButtons.OK);
            }
            else if (count == 1) 
            {
                string[,] cb = new string[2, 6];
                DateTime dT = DateTime.Now;
                int PaidAmount = count * 20;

                cb[1, 0] = getPaymentID().ToString(); // PaymentID
                cb[1, 1] = "20"; // PaidAmount / got from the amount of records selected.
                cb[1, 2] = "YES"; // Single Payment?
                cb[1, 3] = dT.ToString().TrimEnd(' ', '0', '0', ':', '0', '0', ':', '0', '0'); // Date of Payment

                using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
                {
                    string sqlStirng2 = "INSERT INTO Payment VALUES (@PaidAmount, @SinglePayment, @DateOfPayment)";
                    using (SqlCommand myCommand = new SqlCommand(sqlStirng2, myConnection2))
                    {
                        myCommand.Parameters.AddWithValue("@PaidAmount", int.Parse(cb[1, 1]));
                        myCommand.Parameters.AddWithValue("@SinglePayment", cb[1, 2]);
                        myCommand.Parameters.AddWithValue("@DateOfPayment", cb[1, 3]);
                        myConnection2.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection2.Close();
                    }
                }

                cb[0, 0] = ExtraForms.FrmFindMember.MemberID.ToString(); //MemberID
                cb[0, 1] = Schedule.slotID.ToString(); // slotID
                cb[0, 2] = "YES"; // Paid?
                cb[0, 3] = getPaymentID().ToString(); //count the payments in payment table and add 1 / PaymentID
                cb[0, 4] = "N/A"; //attended?
                cb[0, 5] = lstSelectedClasses.Items[0].SubItems[2].Text.TrimEnd(' ', '0', '0', ':', '0', '0', ':', '0', '0');// date of class

                using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
                {
                    string sqlStirng1 = "INSERT INTO Booking " +
                    "VALUES(" + int.Parse(cb[0, 0]) + "," + int.Parse(cb[0, 1])
                    + ", " + int.Parse(cb[0, 2]) + ", '" + cb[0, 3] + "','" + cb[0, 4] + "','" + cb[0, 5] + "');";

                    using (SqlCommand myCommand = new SqlCommand(sqlStirng1, myConnection2))
                    {
                        myConnection2.Open();
                        myCommand.ExecuteNonQuery();
                        myConnection2.Close();
                    }
                }

                // User response
                resetLists();
                MessageBox.Show("All classes have been booked./n You can view them on the bookings page.", "Classes Booked", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please select classes for booking!", "No Classes Selected!", MessageBoxButtons.OK);
            }
        }
    }
}

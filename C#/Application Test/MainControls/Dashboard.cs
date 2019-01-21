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
    public partial class Dashboard : UserControl
    {
        int totalMembers = 0;

        public Dashboard()
        {
            InitializeComponent();

            try
            {
                SQLCommands();
            }
            catch (Exception)
            {
                DialogResult result;

                result = MessageBox.Show("Database log in failed!", "Database Connection Issue", MessageBoxButtons.RetryCancel);

                if (result == DialogResult.Retry)
                {
                    try
                    {
                        SQLCommands();
                    }
                    catch (Exception)
                    {
                        result = MessageBox.Show("Database log in failed again!\nPlease restart the system.", "Database Connection Issue", MessageBoxButtons.OK);

                        if (result == DialogResult.OK)
                        {
                            Program.MainForm.Close();
                        }
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    Program.MainForm.Close();
                }
            }
        }

        private void SQLCommands()
        {
            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                using (SqlCommand myCommand = new SqlCommand("SELECT COUNT(*) AS Members FROM Member WHERE MembershipTypeID!=11;", myConnection1))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            totalMembers = int.Parse(myReader["Members"].ToString());
                            string textToShow;

                            if (totalMembers <= 1)
                                textToShow = "Member";
                            else
                                textToShow = "Members";                            

                            dMember.Text = totalMembers.ToString() +" " + textToShow + " Registered";
                        }
                    }
                }
            }
            //Get total amount of visitors
            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection2.Open();
                using (SqlCommand myCommand = new SqlCommand("SELECT COUNT(*) AS Visitors FROM SignIn;", myConnection2))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            string textToShow;

                            if (int.Parse(myReader["Visitors"].ToString()) == 1)
                                textToShow = "Visitor";
                            else
                                textToShow = "Visitors";

                            dVisitor.Text = myReader["Visitors"].ToString() + " " + textToShow + " Registered";
                        }
                    }
                }
            }
            //Get total amount of people on site
            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection2.Open();
                using (SqlCommand myCommand = new SqlCommand("SELECT COUNT(*) AS SignIn FROM SignIn", myConnection2))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            string textToShow;

                            if (int.Parse(myReader["SignIn"].ToString()) <= 1)
                                textToShow = "Person";
                            else
                                textToShow = "Persons";

                            lblPersonsOnSite.Text = myReader["SignIn"].ToString() + " " + textToShow + " on site";
                        }
                    }
                }
            }
            //Get next Schedule
            DateTime today = DateTime.Today;
            string todaysDate = today.ToString("dddd");

            DateTime time = DateTime.Now;
            string timeString = time.ToString("H:mm");
            string[] timeSplit = timeString.Split(':');

            string timeToInt = "";

            foreach (string _time in timeSplit)
            {
                timeToInt += _time;
            }

            int timeNow = int.Parse(timeToInt);

            if ((timeNow >= 2000 && todaysDate == "Monday") || (timeNow >= 1900 && todaysDate == "Tuesday") || (timeNow >= 1830 && todaysDate == "Wednesday") || (timeNow >= 1830 && todaysDate == "Thursday") || (timeNow >= 1830 && todaysDate == "Friday"))
            {
                dClasses.Text = "Classes resume tomorrow";
            }
            else if ((timeNow >= 1100 && todaysDate == "Saturday") || (todaysDate == "Sunday"))
            {
                dClasses.Text = "Classes resume Monday";
            }
            else
            {
                using (SqlConnection myConnection3 = new SqlConnection(DataConnection.serverstring))
                {
                    string myQueryString = "SELECT ClassLevel AS classLevel, ClassType AS classType FROM ClassType WHERE ClassID = (SELECT ClassID FROM ( SELECT TOP 1 * FROM Schedule  WHERE SlotDay = @todaysDate AND SlotStartTime >= @timeNow) AS classID);";
                    using (SqlCommand myCommand = new SqlCommand(myQueryString, myConnection3))
                    {
                        myCommand.Parameters.AddWithValue("@todaysDate", todaysDate);
                        myCommand.Parameters.AddWithValue("@timeNow", timeNow);
                        myConnection3.Open();

                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            while (myReader.Read())
                            {
                                dClasses.Text = myReader["classType"].ToString() + " " + myReader["classLevel"].ToString();
                            }
                        }
                    }
                }
            }
        }

        #region Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.NEWMEMBER);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.FINDMEMBER);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.SIGNIN);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.SIGNOUT);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.SCHEDULE);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Program.MainForm.ShowControl(ControlsEnum.SCHEDULE);
        }
        #endregion

        private void button5_Click(object sender, EventArgs e)
        {
            if (Program.LoggedIn == true)
                Program.MainForm.ShowControl(ControlsEnum.PERSONSONSITE);
            else
                MessageBox.Show("Please log in first!", "Log In!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnSio_Click(object sender, EventArgs e)
        {

        }
    }
}

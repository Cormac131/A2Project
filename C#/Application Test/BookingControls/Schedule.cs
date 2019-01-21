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

namespace Application_Test.BookingControls
{
    public partial class Schedule : UserControl
    {
        Button[] slots = new Button[33];
        string[] slotText = new string[33];
        string[] classType = new string[33];
        public static int slotID;
        public static int classBookings = 0;

        public Schedule()
        {
            InitializeComponent();
        }

        public void getButtonText()
        {
            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                myConnection1.Open();
                string sqlString = "SELECT ClassType.ClassType AS ClassName, " +
                                    "ClassType.ClassLevel AS ClassLevel, " +
                                    "Schedule.SlotStartTime AS ClassStartTime, " +
                                    "Schedule.SlotLength AS ClassLength " +
                                    "FROM Schedule " +
                                    "INNER JOIN ClassType " +
                                    "ON Schedule.ClassID=ClassType.ClassID;";
                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection1))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        int i = 0;
                        while (myReader.Read())
                        {
                            int finishTime = int.Parse(myReader["ClassStartTime"].ToString()) + 
                                int.Parse(myReader["ClassLength"].ToString()) * 100;

                            //Add a : to start and finish times
                            string sT = myReader["ClassStartTime"].ToString();
                            int halfST = sT.Length / 2;
                            string end = "00";
                            if (sT.Substring(halfST, halfST) == "0")
                            {
                                end = "00";
                            }
                            else
                            {
                                end = sT.Substring(halfST, halfST);
                            }

                            string newST = sT.Substring(0, halfST) + ":" + end;
                            
                            string fT = finishTime.ToString();
                            int halfFT = fT.Length / 2;
                            string newFT = fT.Substring(0, halfFT) + ":" + fT.Substring(halfFT, halfFT);

                            classType[i] = myReader["ClassName"].ToString();

                            slotText[i] = classType[i] + "\n" + myReader["ClassLevel"].ToString() + "\n" + newST + "-" + newFT;
                            i++;

                            if (i == 33)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void Schedule_Load(object sender, EventArgs e)
        {
            getButtonText();

            for (int i = 0; i < slots.Length + 0; i++)
            {
                slots[i] = (Button)this.scheduleLayout.Controls[32 - i];
                slots[i].Text = slotText[i];
                slots[i].FlatStyle = FlatStyle.Flat;
                slots[i].BackColor = Color.Gray;
                slots[i].MouseClick += new MouseEventHandler(Slot1_MouseClick);
                switch (classType[i])
                {
                    case "Yoga":
                        slots[i].ForeColor = Color.Gold;
                        break;
                    case "Tai Chi":
                        slots[i].ForeColor = Color.Blue;
                        break;
                    case "Judo":
                        slots[i].ForeColor = Color.Red;
                        break;
                    case "Pilates":
                        slots[i].ForeColor = Color.Lime;
                        break;
                    case "Keep Fit":
                        slots[i].ForeColor = Color.Purple;
                        break;
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine(sender.ToString());
        }

        private void Slot1_MouseClick(object sender, MouseEventArgs e)
        {
            //check if class is avaliable
            string buttonText = sender.ToString();
            char[] removeChars = { 'S', 'y', 's', 't', 'e', 'm', '.', 'W', 'i', 'n', 'd', 'o', 'w', 's', '.', 'F', 'o', 'r', 'm', 's', '.', 'B', 'u', 'B', 't', 'o', 'n', ',', ' ', 'T', 'e', 'x', 't', ':', ' ' };
            string newBText = buttonText.TrimStart(removeChars);
            string[] classInfo = newBText.Split('\n');
            string startTime = "";
            string St = "";
            char[] trim = { 'S', 'l', 'o', 't'};
            Button slotBtn = (Button)sender;
            string slotIDName = slotBtn.Name;
            slotID = int.Parse(slotIDName.TrimStart(trim));

            if (classInfo[2].Length == 10)
            {
                startTime = classInfo[2].Substring(0, 4);
                St = startTime.Substring(0, 1) + startTime.Substring(2, 2);
            }
            else
            {
                startTime = classInfo[2].Substring(0, classInfo[2].Length / 2);
                St = startTime.Substring(0, startTime.Length / 2) + startTime.Substring(3, startTime.Length / 2);
            }

            using (SqlConnection myConnection1 = new SqlConnection(DataConnection.serverstring))
            {
                string sqlString = "SELECT COUNT(*) AS totalBooked " +
                                    "FROM Booking  " +
                                    "WHERE SlotID = @SlotID;";
                using (SqlCommand myCommand = new SqlCommand(sqlString, myConnection1))
                {
                    myCommand.Parameters.AddWithValue("@SlotID", slotID);
                    myConnection1.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            classBookings = int.Parse(myReader["totalBooked"].ToString());
                        }

                        Console.WriteLine(classBookings.ToString());
                    }
                }
            }

            //BookingAClass.loadSelectedClass();
            if (classBookings != 15)
            {
                Program.MainForm.ShowControl(ControlsEnum.BOOKINGACLASS);
            }
            else if (classBookings == 15)
            {
                MessageBox.Show("Some of the chosen classes are full\nand won't be available for selection.", "Classes are full!");
                Program.MainForm.ShowControl(ControlsEnum.BOOKINGACLASS);
            }
            
        }
    }
}

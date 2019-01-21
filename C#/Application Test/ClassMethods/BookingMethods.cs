using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Test.Class
{
    public static class BookingMethods
    {
        public static DayOfWeek slotDay()
        {
            DayOfWeek day;
            day = DayOfWeek.Sunday; //set the vars
            switch (BookingControls.Schedule.slotID)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    day = DayOfWeek.Monday;
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    day = DayOfWeek.Tuesday;
                    break;
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                    day = DayOfWeek.Wednesday;
                    break;
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    day = DayOfWeek.Thursday;
                    break;
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                    day = DayOfWeek.Friday;
                    break;
                case 31:
                case 32:
                case 33:
                    day = DayOfWeek.Saturday;
                    break;
            }
            return day;
        }

        public static DateTime nextDay(this DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
                target += 7;
            return from.AddDays(target - start);
        }

        public static bool classBookings(int SlotID, string SlotDate)
        {
            using (SqlConnection myConnection2 = new SqlConnection(DataConnection.serverstring))
            {
                //do a count on the slotID in the bbokins table with the same date
                myConnection2.Open();

                string sqlQuery = "SELECT COUNT(*) AS BookingsCount " +
                                    "FROM Booking " +
                                    "WHERE SlotID = " + SlotID + " " +
                                    "AND DateOfClass = '" + SlotDate + "'; ";
                using (SqlCommand myCommand = new SqlCommand(sqlQuery, myConnection2))
                {
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        while (myReader.Read())
                        {
                            if (int.Parse(myReader["BookingsCount"].ToString()) >= 15)
                            {
                                return false;
                            }
                        }
                    }
                }
                myConnection2.Close();
            }

            return true;
        }
    }
}

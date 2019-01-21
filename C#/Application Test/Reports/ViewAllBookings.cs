using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Test.Reports
{
    public partial class ViewAllBookings : UserControl
    {
        public ViewAllBookings()
        {
            InitializeComponent();
        }

        private void ViewAllBookings_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studio2_Systems_DBDataSet2.Booking' table. You can move, or remove it, as needed.
            this.bookingTableAdapter.Fill(this.studio2_Systems_DBDataSet2.Booking);

            this.reportViewer1.RefreshReport();
        }
    }
}

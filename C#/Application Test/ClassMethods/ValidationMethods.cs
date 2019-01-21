using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_Test
{
    class ValidationMethods
    {
        public static bool validString(Control txt, int min, int max, Control label)
        {
            bool ok = true;
            TextBox txtB = (TextBox)txt;
            Label cbLabel = (Label)label;
            string formatText = cbLabel.Text.Substring(0, cbLabel.Text.Length - 1);

            if (String.IsNullOrEmpty(txtB.Text))
            {
                ok = false;
                MessageBox.Show(formatText + " is a required field - data must be entered. ", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtB.Text.Length < min || txtB.Text.Length > max)
	        {
                ok = false;
                MessageBox.Show(formatText + " must have a minimum of " + min + " chars and a maximum of " + max, "Text is too long!", MessageBoxButtons.OK, MessageBoxIcon.Error);
	        }

            return ok;
        }

        public static bool validPostcode(Control txt, int min, int max, Control label)
        {
            bool ok = true;
            TextBox txtB = (TextBox)txt;
            Label cbLabel = (Label)label;
            string formatText = cbLabel.Text.Substring(0, cbLabel.Text.Length - 1);
            string strRegex = @"(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKPSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})";
            Regex re = new Regex(strRegex);

            if (String.IsNullOrEmpty(txtB.Text))
            {
                ok = false;
                MessageBox.Show(formatText + " is a required field - data must be entered. ", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtB.Text.Length < min || txtB.Text.Length > max)
            {
                ok = false;
                MessageBox.Show(formatText + " must have a minimum of " + min + " chars and a maximum of " + max, "Text is too long!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!re.IsMatch(txtB.Text))
            { 
                ok = false;
                MessageBox.Show(formatText + " must have a valid postcode entered - Please enter a valid postcode.", "Postcode Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ok;
        }

        public static bool validComboBox(Control cbx, Control label)
        {
            bool ok = true;
            ComboBox cbxB = (ComboBox)cbx;
            Label cbLabel = (Label)label;

            string formatText = cbLabel.Text.Substring(0, cbLabel.Text.Length - 1);
            if (cbxB.SelectedIndex == -1)
            {
                ok = false;
                MessageBox.Show(formatText + " is a required field - data must be selected. ", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ok;
        }

        public static bool validCheckBox(Control cb1, Control cb2, Control label)
        {
            bool ok = true;
            CheckBox cbA = (CheckBox)cb1;
            CheckBox cbB = (CheckBox)cb2;
            Label cbLabel = (Label)label;

            string formatText = cbLabel.Text.Substring(0, cbLabel.Text.Length - 1);
            if (cbA.CheckState == CheckState.Unchecked && cbA.CheckState == CheckState.Unchecked)
            {
                ok = false;
                MessageBox.Show(formatText + " is a required field - please select an option. ", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ok;
        } 

        public static bool validInt(Control txt, int min, int max, Control label)
        {
            bool ok = true;
            TextBox txtB = (TextBox)txt;
            Label cbLabel = (Label)label;

            string formatText = cbLabel.Text.Substring(0, cbLabel.Text.Length - 1);
            if (String.IsNullOrEmpty(txtB.Text))
            {
                ok = false;
                MessageBox.Show(formatText + " is a required field - data must be entered. ", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtB.Text.Length < min || txtB.Text.Length > max)
            {
                ok = false;
                MessageBox.Show(formatText + " must have a minimum of " + min + " chars and a maximum of " + max, "Text is too long!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else try
                {
                    int.Parse(txtB.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show(formatText + " is a number field - enter only digits. ", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }

            return ok;
        }

        public static bool validDateTimePicker(Control dtp)
        {
            bool ok = true;
            DateTimePicker dtpB = (DateTimePicker)dtp;
            DateTime now = DateTime.Today;
            if (dtpB.Value >= now)
            {
                ok = false;
                MessageBox.Show("Please select a date in the past for your DOB.", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ok;
        }

        public static bool validEmail(Control txt, Control label)
        {
            bool ok = true;
            TextBox txtB = (TextBox)txt;
            Label cbLabel = (Label)label;
            string strRegex = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
            Regex re = new Regex(strRegex);            

            string formatText = cbLabel.Text.Substring(0, cbLabel.Text.Length - 1);
            if (String.IsNullOrEmpty(txtB.Text))
            {
                ok = false;
                MessageBox.Show(formatText + " is a required field - data must be entered. ", "Required Field!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!re.IsMatch(txtB.Text))
            { 
                ok = false;
                MessageBox.Show(formatText + " must have a valid email entered - Please enter a valid email.", "Email Invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return ok;
        }
    }
}

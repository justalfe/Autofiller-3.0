using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DYMO.Label.Framework;
using Label = DYMO.Label.Framework.Label;

namespace AutoFiller_APP.Manager
{
    class DymoManager
    {
        public static void Print(string firstName, string lastName, DateTime dob)
        {
            try
            {
                var label = Label.Open("./resources/base.label");
                label.SetObjectText("name", lastName + ", " + firstName);
                label.SetObjectText("dob", "DOB " + dob.Month.ToString("00") + "/" + dob.Day.ToString("00") + "/" + dob.Year.ToString("0000"));
                label.SetObjectText("datetime", "Taken At ");
                //label.SetObjectText("datetime", "Taken At " + DateTime.Now.Month.ToString("00") + "/" + DateTime.Now.Day.ToString("00") + "/" + DateTime.Now.Year.ToString("0000"));
                label.Print("DYMO LabelWriter 450");
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Access the Printer | "+e.ToString());
            }
        }
    }
}

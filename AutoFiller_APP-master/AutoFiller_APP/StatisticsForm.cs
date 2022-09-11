using AutoFiller_APP.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class StatisticsForm : Form
    {

        List<DateTime> serverDates;
        public StatisticsForm()
        {
            InitializeComponent();
            serverDates = APIManager.GetExistingStatistics();
            for (int i=0;i< serverDates.Count;i++)
            {
                _listOfDates.Items.Add("Report: "+serverDates[i].ToString("MMM", CultureInfo.InvariantCulture) + " "+serverDates[i].Year);
            }
            if (serverDates.Count != 0)
                _listOfDates.SelectedIndex = 0;
        }

        private void _downloadButton_Click(object sender, EventArgs e)
        {
            if (_listOfDates.SelectedIndex==-1)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }
            var qs = APIManager.GetStatistics(serverDates[_listOfDates.SelectedIndex]);
            StatisticsManager.GenerateStatisticsFile(qs);
        }
    }
}

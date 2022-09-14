using AutoFiller_APP.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class CivilSurgeonList : Form
    {
        public static CivilSurgeonList _instance;
        public CivilSurgeonList()
        {
            InitializeComponent();
            _instance = this;
            _surgeonData.Columns.Add("First Name", "First Name");
            _surgeonData.Columns.Add("Middle Name", "Middle Name");
            _surgeonData.Columns.Add("Last Name", "Last Name");
            _surgeonData.Columns.Add("Organization", "Organization");
            RefreshTable();
            RefreshSelected();
        }

        private void _addCivilSurgeonButton_Click(object sender, EventArgs e)
        {
            var csf = new CivilSurgeonForm(null);
            csf.Visible = true;
        }

        private void _surgeonData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
                return;
            var csf = new CivilSurgeonForm(Main._instance._surgeons[_surgeonData.SelectedCells[0].RowIndex]);
            csf.Visible = true;
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }
            var ok = APIManager.DeleteCivilSurgeonPreparer(Main._instance._surgeons[_surgeonData.SelectedCells[0].RowIndex]._id, false);
            if (ok)
            {
                Main._instance.LoadCSP();
                RefreshTable();
            }
        }

        public void RefreshTable()
        {
            _surgeonData.Rows.Clear();
            foreach (var entry in Main._instance._surgeons)
            {
                _surgeonData.Rows.Add(entry._name, entry._middleName, entry._lastName, entry._organization);
            }

            foreach (var entry in Main._instance._surgeons)
            {
                APIManager.SaveCivilSurgeonFromFile(entry._id, false);
            }

        }

        private void _selectButton_Click(object sender, EventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }
            Main._instance._selectedSurgeon = Main._instance._surgeons[_surgeonData.SelectedCells[0].RowIndex];
            RefreshSelected();
            this.Close();
        }

        private void _unselectButton_Click(object sender, EventArgs e)
        {
            Main._instance._selectedSurgeon = null;
            RefreshSelected();
            this.Close();
        }

        public void RefreshSelected()
        {
            Main._instance.RefreshSelectedSurgeonPreparer();
            if (Main._instance._selectedSurgeon != null)
                _selectedCivilSurgeonPreview.Text = "Selected: " + Main._instance._selectedSurgeon._name + " " + Main._instance._selectedSurgeon._lastName + " " + Main._instance._selectedSurgeon._organization;
            else
                _selectedCivilSurgeonPreview.Text = "Selected: None";
        }
    }
}

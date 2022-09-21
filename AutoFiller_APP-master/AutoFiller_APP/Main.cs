using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class Main : Form
    {
        public static Main _instance;
        public List<I693> _forms = new List<I693>();                
        public CivilSurgeon_Preparer _selectedSurgeon = null;
        public CivilSurgeon_Preparer _selectedPreparer = null;
        public Main()
        {
            InitializeComponent();
            _instance = this;
            Utility.LoadServer();          
            RefreshSelectedSurgeonPreparer();
            _existingForms.Columns.Add("Last Name", "Last Name");
            _existingForms.Columns.Add("First Name", "First Name");
            _existingForms.Columns.Add("Alien Number", "Alien Number");
            _existingForms.Columns.Add("USCIS Number", "USCIS Number");
            _existingForms.Columns.Add("Date", "Date");
            _existingForms.Columns.Add("ID", "ID");
            _existingForms.Columns["ID"].Visible = false;
        }

        private void _refresh_Click(object sender, EventArgs e)
        {
            _forms = APIManager.GetForm();
            
            if (_forms.Count > 0)
            {
                APIManager.SavePatients(_forms);
            }

            DisplayForms();
        }

        private void _saveServer_Click(object sender, EventArgs e)
        {
            Utility.SaveServer(_serverIP.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (APIManager.CheckServer())
                MessageBox.Show("Connected");
            else
                MessageBox.Show(Utility.Constants.UNABLE_TO_RETRIEVE_DATA);
        }
        public void DisplayForms()
        {
            _existingForms.Rows.Clear();
            foreach (var form in _forms)
            {
                _existingForms.Rows.Add(form._lastname, form._firstname, form._alienRegistrationNumber, form._uscis, form._dateOfCreation, form._uniqueId);
            }
            _existingForms.Sort(_existingForms.Columns["Date"], ListSortDirection.Descending);
            _existingForms.Columns["Date"].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
        }

        private void _existingForms_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;
            var formWindow = new I693Form(_forms.Where(x => x._uniqueId == (string)_existingForms.Rows[e.RowIndex].Cells["ID"].Value).FirstOrDefault());
            formWindow.Show();
        }

        private void _existingForms_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;
            if (_existingForms.SelectedRows.Count == 0)
                return;
            if (_existingForms.SelectedRows[0].Index <= -1)
                return;
            var formToDelete = _forms.Where(x => x._uniqueId == (string)_existingForms.Rows[_existingForms.SelectedRows[0].Index].Cells["ID"].Value).FirstOrDefault();
            if (formToDelete == null)
                return;
            var result = APIManager.DeleteForm(formToDelete._uniqueId);
            if (!result)
                MessageBox.Show(Utility.Constants.UNABLE_TO_DELETE);
            else
            {
                _forms = APIManager.GetForm();
                DisplayForms();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var surgeonList = new CivilSurgeonList();
            surgeonList.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var preparerList = new PreparerList();
            preparerList.Show();
        }
        public void RefreshSelectedSurgeonPreparer()
        {
            if (_selectedSurgeon != null)
                _selectedCivilSurgeonPreview.Text = "Selected: " + _selectedSurgeon._name + " " + _selectedSurgeon._lastName + " " + _selectedSurgeon._organization;
            else
                _selectedCivilSurgeonPreview.Text = "Selected: None";

            if (_selectedPreparer != null)
                _selectedPreparerPreview.Text = "Selected: " + _selectedPreparer._name + " " + _selectedPreparer._lastName + " " + _selectedPreparer._organization;
            else
                _selectedPreparerPreview.Text = "Selected: None";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var statistics = new StatisticsForm();
            statistics.Show();
        }

        private void ExportData_Click(object sender, EventArgs e)
        {
            var exportsExcel = new ExportForm();
            exportsExcel.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var dbConfigForm = new DbConfigForm();
            dbConfigForm.Show();
        }
    }
}

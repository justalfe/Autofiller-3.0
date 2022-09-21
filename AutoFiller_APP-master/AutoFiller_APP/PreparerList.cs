using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using Newtonsoft.Json;
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
    public partial class PreparerList : Form
    {
        public static PreparerList _instance;
        public PreparerList()
        {
            InitializeComponent();
            _instance = this;
            _preparerData.Columns.Add("Unique Id", "Unique Id");
            _preparerData.Columns.Add("First Name", "First Name");
            _preparerData.Columns.Add("Middle Name", "Middle Name");
            _preparerData.Columns.Add("Last Name", "Last Name");
            _preparerData.Columns.Add("Organization", "Organization");
            RefreshTable();
            RefreshSelected();
        }

        private void _surgeonData_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_preparerData.SelectedCells.Count == 0)
                return;

            var selectedId = _preparerData.SelectedCells[0].Value.ToString();
            using (var db = new AutoDBContext())
            {
                var data = db.Preparers.Where(d => d.FormId == selectedId).FirstOrDefault();
                if (data != null)
                {
                    var civilData = JsonConvert.DeserializeObject<CivilSurgeon_Preparer>(data.FormData);

                    var csf = new PreparerForm(civilData);
                    csf.Visible = true;
                }
            }
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            /* if (_preparerData.SelectedCells.Count == 0)
             {
                 MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                 return;
             }
             var ok = APIManager.DeleteCivilSurgeonPreparer(Main._instance._preparers[_preparerData.SelectedCells[0].RowIndex]._id,true);
             if (ok)
             {
                 Main._instance.LoadCSP();
                 RefreshTable();
             }*/

            if (_preparerData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }

            var _id = _preparerData.SelectedCells[0].Value.ToString();
            using (var db = new AutoDBContext())
            {
                var data = db.Preparers.Where(d => d.FormId == _id).FirstOrDefault();
                if (data != null)
                {
                    db.Preparers.Remove(data);
                    db.SaveChanges();
                    RefreshTable();
                }
            }

            //_preparerData.Rows.Clear();
            //using (var context = new AutoDBContext())
            //{
            //    var preparersList = context.Preparers;
            //    foreach (Preparer preparer in preparersList)
            //    {
            //        PreparerExportModel model = JsonConvert.DeserializeObject<PreparerExportModel>(preparer.FormData);
            //        _preparerData.Rows.Add(model._id, model._name, model._middleName, model._lastName, model._organization);

            //    }
            //}
        }

        public void RefreshTable()
        {
            _preparerData.Rows.Clear();
            using (var context = new AutoDBContext())
            {
                var preparersList = context.Preparers;
                foreach (Preparer sergeon in preparersList)
                {
                    PreparerExportModel model = JsonConvert.DeserializeObject<PreparerExportModel>(sergeon.FormData);
                    _preparerData.Rows.Add(model._id, model._name, model._middleName, model._lastName, model._organization);

                }
            }

        }

        public void RefreshTableOld()
        {
            _preparerData.Rows.Clear();
            foreach (var entry in Main._instance._preparers)
            {
                _preparerData.Rows.Add(entry._name, entry._middleName, entry._lastName, entry._organization);
            }
            foreach (var entry in Main._instance._preparers)
            {
                APIManager.SaveCivilSurgeonFromFile(entry._id, true);
            }
        }

        private void _selectButton_Click(object sender, EventArgs e)
        {
            if (_preparerData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }
            var selectedId = _preparerData.CurrentRow.Cells[0].Value.ToString();

            using (var db = new AutoDBContext())
            {
                var data = db.Preparers.Where(d => d.FormId == selectedId).FirstOrDefault();
                if (data != null)
                {
                    var civilData = JsonConvert.DeserializeObject<CivilSurgeon_Preparer>(data.FormData);
                    Main._instance._selectedPreparer = civilData;
                    RefreshSelected();
                    this.Close();
                }
            }
        }

        private void _unselectButton_Click(object sender, EventArgs e)
        {
            Main._instance._selectedPreparer = null;
            RefreshSelected();
            this.Close();
        }

        public void RefreshSelected()
        {
            Main._instance.RefreshSelectedSurgeonPreparer();
            if (Main._instance._selectedPreparer != null)
                _selectedCivilSurgeonPreview.Text = "Selected: " + Main._instance._selectedPreparer._name + " " + Main._instance._selectedPreparer._lastName + " " + Main._instance._selectedPreparer._organization;
            else
                _selectedCivilSurgeonPreview.Text = "Selected: None";
        }

        private void _addCivilSurgeonButton_Click(object sender, EventArgs e)
        {
            var csf = new PreparerForm(null);
            csf.Visible = true;
        }
    }
}

using AutoFiller_APP.Entites;
using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using DocumentFormat.OpenXml.Office2010.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
            _surgeonData.Columns.Add("UniqueId", "Unique Id");
            _surgeonData.Columns["UniqueId"].Visible = false;
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

            var selectedId = _surgeonData.SelectedCells[0].Value.ToString();

            using (var db = new AutoDBContext())
            {
                var data = db.CivilSurgeons.Where(d => d.FormId == selectedId).FirstOrDefault();
                if (data != null)
                {
                    var civilData = JsonConvert.DeserializeObject<CivilSurgeon_Preparer>(data.FormData);

                    var csf = new CivilSurgeonForm(civilData);
                    csf.Visible = true;
                }
            }
        }

        private void _deleteButton_Click(object sender, EventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }

            var _id = _surgeonData.SelectedCells[0].Value.ToString();
            using (var db = new AutoDBContext())
            {
                var data = db.CivilSurgeons.Where(d => d.FormId == _id).FirstOrDefault();
                if (data != null)
                {
                    db.CivilSurgeons.Remove(data);
                    db.SaveChanges();
                    RefreshTable();
                }
            }
        }

        public void RefreshTable()
        {
            _surgeonData.Rows.Clear();
            using (var context = new AutoDBContext())
            {
                var sergeonsList = context.CivilSurgeons;
                foreach (CivilSurgeon sergeon in sergeonsList)
                {
                    CivilSurgeonsExportModel model = JsonConvert.DeserializeObject<CivilSurgeonsExportModel>(sergeon.FormData);
                    _surgeonData.Rows.Add(model._id, model._name, model._middleName, model._lastName, model._organization);

                }
            }

        }

        private void _selectButton_Click(object sender, EventArgs e)
        {
            if (_surgeonData.SelectedCells.Count == 0)
            {
                MessageBox.Show(Utility.Constants.NO_ENTRY_SELECTED);
                return;
            }
            var selectedId = _surgeonData.CurrentRow.Cells[0].Value.ToString();
            using (var db = new AutoDBContext())
            {
                var data = db.CivilSurgeons.Where(d => d.FormId == selectedId).FirstOrDefault();
                if (data != null)
                {
                    var civilData = JsonConvert.DeserializeObject<CivilSurgeon_Preparer>(data.FormData);
                    Main._instance._selectedSurgeon = civilData;
                    RefreshSelected();
                    this.Close();
                }
            }
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

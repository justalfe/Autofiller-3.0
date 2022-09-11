using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
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
    public partial class PreparerForm : Form
    {
        public string _id = null;
        public PreparerForm(CivilSurgeon_Preparer preparer)
        {
            InitializeComponent();

            foreach (var state in (I693.States[])Enum.GetValues(typeof(I693.States)))
            {
                _mailingAddressState.Items.Add(state.ToString());
            }

            _mailingAddressSubType.Items.Add("APT");
            _mailingAddressSubType.Items.Add("STE");
            _mailingAddressSubType.Items.Add("FLR");

            if (preparer != null)
            {
                _id = preparer._id;
                _surgeonLastname.Text = preparer._lastName;
                _surgeonFirstname.Text = preparer._name;
                _surgeonMiddlename.Text = preparer._middleName;
                _surgeonOrg.Text = preparer._organization;
                _mailingAddress.Text = preparer._mailingStreetAddress;
                _mailingAddressSubType.SelectedIndex = (int)preparer._mailingAddressType;
                _mailingAddressNumber.Text = preparer._mailingAddressNumber;
                _mailingAddressCity.Text = preparer._mailingCity;
                _mailingAddressState.SelectedIndex = (int)preparer._mailingState;
                _mailingZip.Text = preparer._mailingZip;
                _surgeonPhone.Text = preparer._Phone;
                _surgeonMobilePhone.Text = preparer._MobilePhone;
                _surgeonEmail.Text = preparer._Email;
                _radioButtonA.Checked = preparer._preparerStatementA;
                _radioButtonB.Checked = !preparer._preparerStatementA;
                _radioButtonExtends.Checked = preparer._preparerExtatementExtends;
                _radioButtonNoExtend.Checked = !preparer._preparerExtatementExtends;

                _province.Text = preparer._province;
                _country.Text = preparer._country;
                _postalCode.Text = preparer._postalCode;
            }

        }

        public bool SavePreparer()
        {
            var ok = APIManager.SaveCivilSurgeonPreparer(new CivilSurgeon_Preparer(_id, _surgeonLastname.Text, _surgeonFirstname.Text, _surgeonMiddlename.Text, _surgeonOrg.Text, "", I693.AddressType.NONE, "",
                "", I693.States.NONE, "",_province.Text,_postalCode.Text,_country.Text, _mailingAddress.Text, (I693.AddressType)_mailingAddressSubType.SelectedIndex, _mailingAddressNumber.Text, _mailingAddressCity.Text, (I693.States)_mailingAddressState.SelectedIndex,
                _mailingZip.Text, _surgeonPhone.Text, _surgeonMobilePhone.Text, _surgeonEmail.Text, _radioButtonA.Checked, _radioButtonExtends.Checked),true);
            return ok;
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (SavePreparer())
            {
                Main._instance.LoadCSP();
                PreparerList._instance.RefreshTable();
                this.Close();
            }
        }

        private void PreparerForm_Load(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

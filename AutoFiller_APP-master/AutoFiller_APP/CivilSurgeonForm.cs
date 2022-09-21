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
    public partial class CivilSurgeonForm : Form
    {
        public string _id = null;
        public CivilSurgeonForm(CivilSurgeon_Preparer surgeon)
        {
            InitializeComponent();

            foreach (var state in (I693.States[])Enum.GetValues(typeof(I693.States)))
            {
                _addressState.Items.Add(state.ToString());
                _mailingAddressState.Items.Add(state.ToString());
            }
            _addressType.Items.Add("APT");
            _addressType.Items.Add("STE");
            _addressType.Items.Add("FLR");

            _mailingAddressSubType.Items.Add("APT");
            _mailingAddressSubType.Items.Add("STE");
            _mailingAddressSubType.Items.Add("FLR");

            if (surgeon != null)
            {
                _id = surgeon._id;
                _surgeonLastname.Text = surgeon._lastName;
                _surgeonFirstname.Text = surgeon._name;
                _surgeonMiddlename.Text = surgeon._middleName;
                _surgeonOrg.Text = surgeon._organization;
                _addressStreet.Text = surgeon._streetAddress;
                _addressType.SelectedIndex = (int)surgeon._addressType;
                _addressNumber.Text = surgeon._addressNumber;
                _addressCity.Text = surgeon._city;
                _addressState.SelectedIndex = (int)surgeon._state;
                _addressZip.Text = surgeon._zip;
                _mailingAddress.Text = surgeon._mailingStreetAddress;
                _mailingAddressSubType.SelectedIndex = (int)surgeon._mailingAddressType;
                _mailingAddressNumber.Text = surgeon._mailingAddressNumber;
                _mailingAddressCity.Text = surgeon._city;
                _mailingAddressState.SelectedIndex = (int)surgeon._mailingState;
                _mailingZip.Text = surgeon._mailingZip;
                _surgeonPhone.Text = surgeon._Phone;
                _surgeonMobilePhone.Text = surgeon._MobilePhone;
                _surgeonEmail.Text = surgeon._Email;
            }

        }

        public bool SaveSurgeon()
        {
            /*var ok = APIManager.SaveCivilSurgeonPreparer(new CivilSurgeon_Preparer(_id, _surgeonLastname.Text, _surgeonFirstname.Text, _surgeonMiddlename.Text, _surgeonOrg.Text, _addressStreet.Text, (I693.AddressType)_addressType.SelectedIndex, _addressNumber.Text,
                _addressCity.Text, (I693.States)_addressState.SelectedIndex, _addressZip.Text,"","","", _mailingAddress.Text, (I693.AddressType)_mailingAddressSubType.SelectedIndex, _mailingAddressNumber.Text, _mailingAddressCity.Text, (I693.States)_mailingAddressState.SelectedIndex,
                _mailingZip.Text, _surgeonPhone.Text, _surgeonMobilePhone.Text, _surgeonEmail.Text,false,false),false);
            return ok;*/

            //SAVE IN DATABASE

            CivilSurgeon_Preparer csEntity = new CivilSurgeon_Preparer(_id, _surgeonLastname.Text, _surgeonFirstname.Text, _surgeonMiddlename.Text, _surgeonOrg.Text, _addressStreet.Text, (I693.AddressType)_addressType.SelectedIndex, _addressNumber.Text,
                _addressCity.Text, (I693.States)_addressState.SelectedIndex, _addressZip.Text, "", "", "", _mailingAddress.Text, (I693.AddressType)_mailingAddressSubType.SelectedIndex, _mailingAddressNumber.Text, _mailingAddressCity.Text, (I693.States)_mailingAddressState.SelectedIndex,
                _mailingZip.Text, _surgeonPhone.Text, _surgeonMobilePhone.Text, _surgeonEmail.Text, false, false);

            int res = 0;
            using (var context = new AutoDBContext())
            {
                if (!context.CivilSurgeons.Any(cs => cs.FormId.Equals(csEntity._id)))
                {
                    var sergeon = new CivilSurgeon();
                    sergeon.FormId = Utility.GenerateSringToken();
                    csEntity._id = sergeon.FormId;
                    sergeon.FormData = JsonConvert.SerializeObject(csEntity);
                    sergeon.CreatedDate = DateTime.Now;
                    context.CivilSurgeons.Add(sergeon);
                    res = context.SaveChanges();
                }
                else
                {
                    var sergeon = context.CivilSurgeons.Single(cs => cs.FormId.Equals(_id));
                    if (sergeon != null)
                    {
                        sergeon.FormData = JsonConvert.SerializeObject(csEntity);
                        sergeon.LastUpdated = DateTime.Now;
                        res = context.SaveChanges();
                    }
                }
            }
            //END

            return (res > 0);
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            if (SaveSurgeon())
            {
                Main._instance.LoadCSP();
                CivilSurgeonList._instance.RefreshTable();
                this.Close();
            }
        }
    }
}

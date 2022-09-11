using AutoFiller_APP.Manager;
using AutoFiller_APP.Model;
using System;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class I693Form : Form
    {
        public I693 _sourceForm;
        public I693Form(I693 form)
        {
            InitializeComponent();
            _sourceForm = form;
            foreach (var state in (I693.States[])Enum.GetValues(typeof(I693.States)))
            {
                _addressState.Items.Add(state.ToString());
                _interpreterState.Items.Add(state.ToString());
            }
            _addressType.Items.Add("APT");
            _addressType.Items.Add("STE");
            _addressType.Items.Add("FLR");

            _interpreterAddressType.Items.Add("APT");
            _interpreterAddressType.Items.Add("STE");
            _interpreterAddressType.Items.Add("FLR");

            _sex.Items.Add("Male");
            _sex.Items.Add("Female");

            _lastname.Text = _sourceForm._lastname;
            _firstname.Text = _sourceForm._firstname;

            _middlename.Text = _sourceForm._middlename;
            _addressStreet.Text = _sourceForm._addressStreet;
            _addressType.SelectedIndex = (int)_sourceForm._addressType;
            _addressNumber.Text = _sourceForm._addressNumber;
            _addressCity.Text = _sourceForm._addressCity;
            _addressState.SelectedIndex = (int)_sourceForm._addressState;
            _addressZip.Text = _sourceForm._addressZip;

            _sex.SelectedIndex = (int)_sourceForm._sex;
            _birth.Value = _sourceForm._birth;
            _birthCity.Text = _sourceForm._birthCity;
            _birthCountry.Text = _sourceForm._birthCountry;
            _alienRegistrationNumber.Text = _sourceForm._alienRegistrationNumber;
            _uscis.Text = _sourceForm._uscis;

            _applicantIdentificationType.Text = _sourceForm._applicantIdentificationType;
            _applicantIdentificationNumber.Text = _sourceForm._applicantIdentificationNumber;


            if (_sourceForm._applicationStatement1aORb)
                _applicantStatemenntA.Checked = true;
            else
            {
                _applicantStatemenntB.Checked = true;
                _applicationStatetemnt1bfield.Text = _sourceForm._applicationStatetemnt1bfield;
            }

            _applicantPhoneNumber.Text = _sourceForm._applicantPhoneNumber;
            _applicantMobileNumber.Text = _sourceForm._applicantMobileNumber;
            _applicantEmail.Text = _sourceForm._applicantEmail;

            _applicantDateOfSignature.Value = _sourceForm._applicantDateOfSignature;
            _interpreterLastName.Text = _sourceForm._interpreterLastName;
            _interpreterName.Text = _sourceForm._interpreterName;
            _interpreterOrganization.Text = _sourceForm._interpreterOrganization;

            _interpreterStreetAddress.Text = _sourceForm._interpreterStreetAddress;
            _interpreterAddressType.SelectedIndex = (int)_sourceForm._interpreterAddressType;
            _interpreterAddressNumber.Text = _sourceForm._interpreterAddressNumber;
            _interpreterCity.Text = _sourceForm._interpreterCity;
            _interpreterState.SelectedIndex = (int)_sourceForm._interpreterState;

            _interpreterZip.Text = _sourceForm._interpreterZip;
            _interpreterProvince.Text = _sourceForm._interpreterProvince;
            _interpreterPostalCode.Text = _sourceForm._interpreterPostalCode;
            _interpreterCountry.Text = _sourceForm._interpreterCountry;
            _interpreterCity.Text = _sourceForm._interpreterCity;

            _interpreterPhone.Text = _sourceForm._interpreterPhone;
            _interpreterMobilePhone.Text = _sourceForm._interpreterMobilePhone;
            _interpreterEmail.Text = _sourceForm._interpreterEmail;

            _interpreterLanguage.Text = _sourceForm._interpreterLanguage;
            _interpreterSignatureDate.Value = _sourceForm._interpreterSignatureDate;
        }

        private void _exportButton_Click(object sender, EventArgs e)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.FileName = _lastname.Text.Replace(" ", "") + ".pdf";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileSplit = fileDialog.FileName.Split('.');
                if (fileSplit[fileSplit.Length - 1].ToLower() != "pdf")
                    fileDialog.FileName += ".pdf";

                var formData = new I693("", _lastname.Text, _firstname.Text, _middlename.Text, _addressStreet.Text, (I693.AddressType)_addressType.SelectedIndex, _addressNumber.Text,
                _addressCity.Text, (I693.States)_addressState.SelectedIndex, _addressZip.Text, (I693.Sex)_sex.SelectedIndex, _birth.Value, _birthCity.Text, _birthCountry.Text, _alienRegistrationNumber.Text,
                _uscis.Text, (_applicantStatemenntA.Checked) ? true : false, _applicationStatetemnt1bfield.Text, _applicantPhoneNumber.Text, _applicantMobileNumber.Text, _applicantEmail.Text,
                "", _applicantDateOfSignature.Value, _interpreterLastName.Text, _interpreterName.Text, _interpreterOrganization.Text, _interpreterStreetAddress.Text, (I693.AddressType)_interpreterAddressType.SelectedIndex,
                _interpreterAddressNumber.Text, _interpreterCity.Text, (I693.States)_interpreterState.SelectedIndex, _interpreterZip.Text, _interpreterProvince.Text, _interpreterPostalCode.Text, _interpreterCountry.Text,
                _interpreterPhone.Text, _interpreterMobilePhone.Text, _interpreterEmail.Text, _interpreterLanguage.Text, "", _interpreterSignatureDate.Value, _applicantIdentificationType.Text,
                _applicantIdentificationNumber.Text, _sourceForm._dateOfCreation);

                formData._uniqueId = _sourceForm._uniqueId;

                PDFManager.ExportPDF(formData,
                fileDialog.FileName, Main._instance._selectedSurgeon, Main._instance._selectedPreparer);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DymoManager.Print(_firstname.Text, _lastname.Text, _birth.Value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP.Model
{

    public class CivilSurgeonsExportModel
    {
        public string _id { get; set; }
        public string _lastName { get; set; }
        public string _name { get; set; }
        public string _middleName { get; set; }
        public string _organization { get; set; }
        public string _streetAddress { get; set; }
        public int _addressType { get; set; }
        public string _addressNumber { get; set; }
        public string _city { get; set; }
        public int _state { get; set; }
        public string _zip { get; set; }
        public string _province { get; set; }
        public string _postalCode { get; set; }
        public string _country { get; set; }
        public string _mailingStreetAddress { get; set; }
        public int _mailingAddressType { get; set; }
        public string _mailingAddressNumber { get; set; }
        public string _mailingCity { get; set; }
        public int _mailingState { get; set; }
        public string _mailingZip { get; set; }
        public string _Phone { get; set; }
        public string _MobilePhone { get; set; }
        public string _Email { get; set; }
        public bool _preparerStatementA { get; set; }
        public bool _preparerExtatementExtends { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PreparerExportModel
    {
        public string _id { get; set; }
        public string _lastName { get; set; }
        public string _name { get; set; }
        public string _middleName { get; set; }
        public string _organization { get; set; }
        public string _streetAddress { get; set; }
        public int _addressType { get; set; }
        public string _addressNumber { get; set; }
        public string _city { get; set; }
        public int _state { get; set; }
        public string _zip { get; set; }
        public string _province { get; set; }
        public string _postalCode { get; set; }
        public string _country { get; set; }
        public string _mailingStreetAddress { get; set; }
        public int _mailingAddressType { get; set; }
        public string _mailingAddressNumber { get; set; }
        public string _mailingCity { get; set; }
        public int _mailingState { get; set; }
        public string _mailingZip { get; set; }
        public string _Phone { get; set; }
        public string _MobilePhone { get; set; }
        public string _Email { get; set; }
        public bool _preparerStatementA { get; set; }
        public bool _preparerExtatementExtends { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class PdfDataExportModel
    {
        public string surgeon_fullname { get; set; }
        public string preparer_fullname { get; set; }
        public string _uniqueId { get; set; }
        public string _lastname { get; set; }
        public string _firstname { get; set; }
        public string _middlename { get; set; }
        public string _addressStreet { get; set; }
        public int _addressType { get; set; }
        public string _addressNumber { get; set; }
        public string _addressCity { get; set; }
        public int _addressState { get; set; }
        public string _addressZip { get; set; }
        public int _sex { get; set; }
        public DateTime _birth { get; set; }
        public string _birthCity { get; set; }
        public string _birthCountry { get; set; }
        public string _alienRegistrationNumber { get; set; }
        public string _uscis { get; set; }
        public bool _applicationStatement1aORb { get; set; }
        public string _applicationStatetemnt1bfield { get; set; }
        public string _applicantPhoneNumber { get; set; }
        public string _applicantMobileNumber { get; set; }
        public string _applicantEmail { get; set; }
        public string _applicantSignature { get; set; }
        public DateTime _applicantDateOfSignature { get; set; }
        public string _interpreterLastName { get; set; }
        public string _interpreterName { get; set; }
        public string _interpreterOrganization { get; set; }
        public string _interpreterStreetAddress { get; set; }
        public int _interpreterAddressType { get; set; }
        public string _interpreterAddressNumber { get; set; }
        public string _interpreterCity { get; set; }
        public int _interpreterState { get; set; }
        public string _interpreterZip { get; set; }
        public string _interpreterProvince { get; set; }
        public string _interpreterPostalCode { get; set; }
        public string _interpreterCountry { get; set; }
        public string _interpreterPhone { get; set; }
        public string _interpreterMobilePhone { get; set; }
        public string _interpreterEmail { get; set; }
        public string _interpreterLanguage { get; set; }
        public string _interpreterSignature { get; set; }
        public DateTime _interpreterSignatureDate { get; set; }
        public string _applicantIdentificationType { get; set; }
        public string _applicantIdentificationNumber { get; set; }
        public string _dateOfCreation { get; set; }
    }



}

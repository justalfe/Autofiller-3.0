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
    public class PatientExportModel
    {
        public enum Sex
        {
            M = 0,
            F = 1
        }

        public enum AddressType
        {
            NONE = -1,
            APT = 0,
            STE = 1,
            FLR = 2
        }
        public enum States
        {
            NONE = 0,
            AA = 1,
            AE = 2,
            AK = 3,
            AL = 4,
            AP = 5,
            AR = 6,
            AS = 7,
            AZ = 8,
            CA = 9,
            CO = 10,
            CT = 11,
            DC = 12,
            DE = 13,
            FL = 14,
            FM = 15,
            GA = 16,
            GU = 17,
            HI = 18,
            IA = 19,
            ID = 20,
            IL = 21,
            IN = 22,
            KS = 23,
            KY = 24,
            LA = 25,
            MA = 26,
            MD = 27,
            ME = 28,
            MH = 29,
            MI = 30,
            MN = 31,
            MO = 32,
            MP = 33,
            MS = 34,
            MT = 35,
            NC = 36,
            ND = 37,
            NE = 38,
            NH = 39,
            NJ = 40,
            NM = 41,
            NV = 42,
            NY = 43,
            OH = 44,
            OK = 45,
            OR = 46,
            PA = 47,
            PR = 48,
            PW = 49,
            RI = 50,
            SC = 51,
            SD = 52,
            TN = 53,
            TX = 54,
            UT = 55,
            VA = 56,
            VI = 57,
            VT = 58,
            WA = 59,
            WI = 60,
            WV = 61,
            WY = 62,
        }
        //P1
        public string _uniqueId;
        public string _lastname { get; set; }
        public string _firstname { get; set; }
        public string _middlename { get; set; }
        public string _addressStreet { get; set; }
        public AddressType _addressType { get; set; }
        public string _addressCity { get; set; }
        public int _addressState { get; set; }
        public string _addressZip { get; set; }
        public Sex _sex { get; set; }
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

        //P2
        public string _applicantSignature { get; set; }
        public DateTime _applicantDateOfSignature { get; set; }
        public string _interpreterLastName { get; set; }
        public string _interpreterName { get; set; }
        public string _interpreterOrganization { get; set; }

        //P3
        public string _interpreterStreetAddress { get; set; }
        public AddressType _interpreterAddressType { get; set; }
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

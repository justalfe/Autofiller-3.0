using AutoFiller_API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFiller_APP.Model
{
    public class I693
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
        public string _uniqueId;


        public string _lastname;
        public string _firstname;
        public string _middlename;
        public string _addressStreet;
        public AddressType _addressType;
        public string _addressNumber;
        public string _addressCity;
        public States _addressState;
        public string _addressZip;
        public Sex _sex;
        public DateTime _birth;
        public string _birthCity;
        public string _birthCountry;
        public string _alienRegistrationNumber;
        public string _uscis;
        public bool _applicationStatement1aORb;
        public string _applicationStatetemnt1bfield;
        public string _applicantPhoneNumber;
        public string _applicantMobileNumber;
        public string _applicantEmail;

        //P2
        public string _applicantSignature;
        public DateTime _applicantDateOfSignature;
        public string _interpreterLastName;
        public string _interpreterName;
        public string _interpreterOrganization;

        //P3
        public string _interpreterStreetAddress;
        public AddressType _interpreterAddressType;
        public string _interpreterAddressNumber;
        public string _interpreterCity;
        public States _interpreterState;
        public string _interpreterZip;
        public string _interpreterProvince;
        public string _interpreterPostalCode;
        public string _interpreterCountry;
        public string _interpreterPhone;
        public string _interpreterMobilePhone;
        public string _interpreterEmail;
        public string _interpreterLanguage;
        public string _interpreterSignature;
        public DateTime _interpreterSignatureDate;
        public string _applicantIdentificationType;
        public string _applicantIdentificationNumber;

        public DateTime _dateOfCreation;


        public I693()
        {
            _uniqueId = Utility.GenerateSringToken();
        }

        public I693(string uniqueId, string lastname, string firstname, string middlename, string addressStreet, AddressType addressType, string addressNumber, string addressCity,
            States addressState, string addressZip, Sex sex, DateTime birth, string birthCity, string birthCountry, string alienRegistrationNumber, string uscis, bool applicationStatement1aORb, 
            string applicationStatetemnt1bfield, string applicantPhoneNumber, string applicantMobileNumber, string applicantEmail, string applicantSignature, DateTime applicantDateOfSignature,
            string interpreterLastName, string interpreterName, string interpreterOrganization, string interpreterStreetAddress, AddressType interpreterAddressType, string interpreterAddressNumber,
            string interpreterCity, States interpreterState, string interpreterZip, string interpreterProvince, string interpreterPostalCode, string interpreterCountry, string interpreterPhone, 
            string interpreterMobilePhone, string interpreterEmail, string interpreterLanguage, string interpreterSignature, DateTime interpreterSignatureDate, string interpreterIdentificationType,
            string interpreterIdentificationNumber, DateTime dateOfCreation)
        {
            _uniqueId = uniqueId;
            _lastname = lastname;
            _firstname = firstname;
            _middlename = middlename;
            _addressStreet = addressStreet;
            _addressType = addressType;
            _addressNumber = addressNumber;
            _addressCity = addressCity;
            _addressState = addressState;
            _addressZip = addressZip;
            _sex = sex;
            _birth = birth;
            _birthCity = birthCity;
            _birthCountry = birthCountry;
            _alienRegistrationNumber = alienRegistrationNumber;
            _uscis = uscis;
            _applicationStatement1aORb = applicationStatement1aORb;
            _applicationStatetemnt1bfield = applicationStatetemnt1bfield;
            _applicantPhoneNumber = applicantPhoneNumber;
            _applicantMobileNumber = applicantMobileNumber;
            _applicantEmail = applicantEmail;
            _applicantSignature = applicantSignature;
            _applicantDateOfSignature = applicantDateOfSignature;
            _interpreterLastName = interpreterLastName;
            _interpreterName = interpreterName;
            _interpreterOrganization = interpreterOrganization;
            _interpreterStreetAddress = interpreterStreetAddress;
            _interpreterAddressType = interpreterAddressType;
            _interpreterAddressNumber = interpreterAddressNumber;
            _interpreterCity = interpreterCity;
            _interpreterState = interpreterState;
            _interpreterZip = interpreterZip;
            _interpreterProvince = interpreterProvince;
            _interpreterPostalCode = interpreterPostalCode;
            _interpreterCountry = interpreterCountry;
            _interpreterPhone = interpreterPhone;
            _interpreterMobilePhone = interpreterMobilePhone;
            _interpreterEmail = interpreterEmail;
            _interpreterLanguage = interpreterLanguage;
            _interpreterSignature = interpreterSignature;
            _interpreterSignatureDate = interpreterSignatureDate;
            _applicantIdentificationType = interpreterIdentificationType;
            _applicantIdentificationNumber = interpreterIdentificationNumber;
            _dateOfCreation = dateOfCreation;

            if (_addressZip!="")
            {
                //while (_addressZip.Length < 5)
                //    _addressZip = "0" + _addressZip;
            }
            if (_alienRegistrationNumber!="")
            {
                //while (_alienRegistrationNumber.Length < 9)
                //    _alienRegistrationNumber = "0" + _alienRegistrationNumber;
            }
        }

        public class Storage
        {

            public const string FILE = "./forms.json";
            public static void Store(List<I693> forms)
            {
                var f = File.CreateText(FILE);
                f.Write(JsonConvert.SerializeObject(forms));
                f.Close();
            }

            public static List<I693> Get()
            {
                if (!File.Exists(FILE))
                    return new List<I693>();
                var forms = JsonConvert.DeserializeObject<List<I693>>(File.ReadAllText(FILE));
                if (forms == null)
                    return new List<I693>();
                else
                    return forms;
            }
        }
    }
}

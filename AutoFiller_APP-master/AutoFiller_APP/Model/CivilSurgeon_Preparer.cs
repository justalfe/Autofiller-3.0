using AutoFiller_API;
using AutoFiller_APP.Entites;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AutoFiller_APP.Model.I693;

namespace AutoFiller_APP.Model
{
    public class CivilSurgeon_Preparer
    {
        public string _id;
        public string _lastName;
        public string _name;
        public string _middleName;
        public string _organization;

        public string _streetAddress;
        public AddressType _addressType;
        public string _addressNumber;
        public string _city;
        public States _state;
        public string _zip;
        public string _province;
        public string _postalCode;
        public string _country;

        public string _mailingStreetAddress;
        public AddressType _mailingAddressType;
        public string _mailingAddressNumber;
        public string _mailingCity;
        public States _mailingState;
        public string _mailingZip;

        public string _Phone;
        public string _MobilePhone;
        public string _Email;

        public bool _preparerStatementA;
        public bool _preparerExtatementExtends;

        public CivilSurgeon_Preparer()
        {

        }

        public CivilSurgeon_Preparer(string id, string lastName, string name, string middleName, string organization, string streetAddress, AddressType addressType, string addressNumber, string city, States state, string zip, string province, string postalCode, string country, string mailingStreetAddress, AddressType mailingAddressType, string mailingAddressNumber, string mailingCity, States mailingState, string mailingZip, string Phone, string MobilePhone, string Email, bool preparerStatementA, bool preparerExtatementExtends)
        {
            _id = id;
            _lastName = lastName;
            _name = name;
            _middleName = middleName;
            _organization = organization;
            _streetAddress = streetAddress;
            _addressType = addressType;
            _addressNumber = addressNumber;
            _city = city;
            _state = state;
            _zip = zip;
            _province = province;
            _postalCode = postalCode;
            _country = country;
            _mailingStreetAddress = mailingStreetAddress;
            _mailingAddressType = mailingAddressType;
            _mailingAddressNumber = mailingAddressNumber;
            _mailingCity = mailingCity;
            _mailingState = mailingState;
            _mailingZip = mailingZip;
            _Phone = Phone;
            _MobilePhone = MobilePhone;
            _Email = Email;
            _preparerStatementA = preparerStatementA;
            _preparerExtatementExtends = preparerExtatementExtends;
        }

        public class Storage
        {

            public const string FILE_CIVIL_SURGEON = "./cs.json";
            public const string FILE_PREPARER = "./p.json";

            public static string GetDirectory(bool preparer)
            {
                if (preparer)
                    return FILE_PREPARER;
                else
                    return FILE_CIVIL_SURGEON;
            }

            static void Store(List<CivilSurgeon_Preparer> forms, bool preparer)
            {
                var f = File.CreateText(GetDirectory(preparer));
                f.WriteLine(JsonConvert.SerializeObject(forms));
                f.Close();

            }

            public static List<CivilSurgeon_Preparer> Get(bool preparer)
            {
                if (!File.Exists(GetDirectory(preparer)))
                    return new List<CivilSurgeon_Preparer>();
                var textContent = File.ReadAllText(GetDirectory(preparer));
                var content = JsonConvert.DeserializeObject<List<CivilSurgeon_Preparer>>(textContent);
                if (content == null)
                    return new List<CivilSurgeon_Preparer>();
                else
                    return content;
            }

            public static void Add(CivilSurgeon_Preparer entry, bool preparer)
            {
                if (entry._id != null)
                    Delete(entry._id, preparer);
                else
                    entry._id = Utility.GenerateSringToken();
                var content = Get(preparer);
                content.Add(entry);
                Store(content, preparer);
            }

            public static void Delete(string id, bool preparer)
            {
                var forms = Get(preparer);
                forms.RemoveAll(x => x._id == id);
                Store(forms, preparer);
            }
        }
    }
}

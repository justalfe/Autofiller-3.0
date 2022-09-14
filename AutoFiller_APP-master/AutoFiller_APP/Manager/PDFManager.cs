using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP.Manager
{
    class PDFManager
    {
        //public const string SOURCE_PDF_FILE = "./resources/i693d.pdf";
        public const string SOURCE_PDF_FILE = "./resources/i-693.pdf";
        //public const string OUTPUT_PDF_FILE = "./out.pdf";
        public static void ExportPDF(I693 source, string _destinationFile, CivilSurgeon_Preparer surgeon, CivilSurgeon_Preparer preparer)
        {
            try
            {
                //string[] checkboxstates = pdfFormFields.GetAppearanceStates("form1[0].#subform[0].Pt1Line2_Unit[2]");
                PdfReader pdfReader = new PdfReader(SOURCE_PDF_FILE);
                PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(_destinationFile, FileMode.Create));
                AcroFields pdfFormFields = pdfStamper.AcroFields;

                var keys = pdfFormFields.Fields.Keys.Cast<string>().ToList();
                pdfFormFields.SetField("form1[0].#subform[5].Pt5Line2_DateoExam[0]", GetDateStringFormat(source._dateOfCreation));
                pdfFormFields.SetField("form1[0].#subform[8].Pt7Line1B2_Findings[0]", "A");
                pdfFormFields.SetField("form1[0].#subform[8].Pt7Line1c2_Findings[2]", "A");
                pdfFormFields.SetField("form1[0].#subform[9].Pt7Line1C1_Findings[0]", "a");
                pdfFormFields.SetField("form1[0].#subform[13].P9_Results[2]", "C");


                pdfFormFields.SetField("form1[0].#subform[1].Pt1Line1a_FamilyName[0]", source._lastname.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[1].Pt1Line1b_GivenName[0]", source._firstname.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[1].Pt1Line1c_MiddleName[0]", source._middlename.ToUpper());
                UpdateEntries("form1[0].#subform[0].Pt1Line2_StreetNumberName[0]", keys, pdfFormFields, source._addressStreet.ToUpper());
                switch (source._addressType)
                {
                    case I693.AddressType.APT:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_Unit[2]", " APT ");
                        UpdateEntries("form1[0].#subform[0].Pt1Line2_AptSteFlrNumber[0]", keys, pdfFormFields, source._addressNumber.ToUpper());
                        break;
                    case I693.AddressType.STE:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_Unit[1]", " STE ");
                        UpdateEntries("form1[0].#subform[0].Pt1Line2_AptSteFlrNumber[0]", keys, pdfFormFields, source._addressNumber.ToUpper());
                        break;
                    case I693.AddressType.FLR:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line2_Unit[0]", " FLR ");
                        UpdateEntries("form1[0].#subform[0].Pt1Line2_AptSteFlrNumber[0]", keys, pdfFormFields, source._addressNumber.ToUpper());
                        break;
                }
                UpdateEntries("form1[0].#subform[0].P1Line2_CityOrTown[0]", keys, pdfFormFields, source._addressCity.ToUpper());
                UpdateEntries("form1[0].#subform[0].P1Line2_ZipCode[0]", keys, pdfFormFields, source._addressZip.ToUpper());

                if (source._addressState != I693.States.NONE)
                    pdfFormFields.SetField("form1[0].#subform[0].P1Line2_State[0]", source._addressState.ToString());

                switch (source._sex)
                {
                    case I693.Sex.M:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3_Gender[0]", I693.Sex.M.ToString());
                        break;
                    case I693.Sex.F:
                        pdfFormFields.SetField("form1[0].#subform[0].Pt1Line3_Gender[1]", I693.Sex.F.ToString());
                        break;
                }

                UpdateEntries("form1[0].#subform[0].Pt1Line7_DateOfBirth[0]", keys, pdfFormFields, GetDateStringFormat(source._birth));
                UpdateEntries("form1[0].#subform[0].Pt1Line8_CityTownVillageofBirth[0]", keys, pdfFormFields, source._birthCity.ToUpper());
                UpdateEntries("form1[0].#subform[0].Pt1Line9_CountryofBirth[0]", keys, pdfFormFields, source._birthCountry.ToUpper());
                UpdateEntries("form1[0].#subform[0].#area[0].Pt1Line3e_AlienNumber[0]", keys, pdfFormFields, source._alienRegistrationNumber.ToUpper());
                UpdateEntries("form1[0].#subform[0].Pt1Line2_USCISELISAcctNumber[0]", keys, pdfFormFields, source._uscis.ToUpper());


                if (source._applicationStatement1aORb)
                    pdfFormFields.SetField("form1[0].#subform[0].Pt2Line1_Checkbox", "A");
                else
                {
                    pdfFormFields.SetField("form1[0].#subform[0].Pt2Line1_Checkbox[1]", "B");
                    pdfFormFields.SetField("form1[0].#subform[0].Pt2Line1_Language[0]", source._applicationStatetemnt1bfield.ToUpper());
                }

                pdfFormFields.SetField("form1[0].#subform[0].Pt2Line2_DaytimePhone[0]", source._applicantPhoneNumber.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].Pt2Line3_Mobilephone[0]", source._applicantMobileNumber.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[0].Pt2Line4_EmailAddress[0]", source._applicantEmail.ToUpper());


                if (!source._applicationStatement1aORb)
                {
                    //pdfFormFields.SetField("form1[0].#subform[1].Pt1Line13_ApplicantSignature[0]", source._applicantSignature);
                    //pdfFormFields.SetField("form1[0].#subform[1].Pt2Line5_DateofSignature[0]", GetDateStringFormat(source._applicantDateOfSignature));
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line1_InterpreterFamilyName[0]", source._interpreterLastName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line1_InterpreterGivenName[0]", source._interpreterName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[1].Pt3Line2_NameofBusinessorOrgName[0]", source._interpreterOrganization.ToUpper());

                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_StreetNumberName[0]", source._interpreterStreetAddress.ToUpper());

                   switch (source._interpreterAddressType)
                    {
                        case I693.AddressType.APT:
                            pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_Unit[2]", " APT ");
                            break;
                        case I693.AddressType.STE:
                            pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_Unit[0]", " STE ");
                            break;
                        case I693.AddressType.FLR:
                            pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_Unit[1]", " FLR ");
                            break;
                    }

                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_AptSteFlrNumber[0]", source._interpreterAddressNumber.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_CityOrTown[0]", source._interpreterCity.ToUpper());
                    if (source._interpreterState != I693.States.NONE)
                        pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_State[0]", source._interpreterState.ToString());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_ZipCode[0]", source._interpreterZip.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_Province[0]", source._interpreterProvince.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_PostalCode[0]", source._interpreterPostalCode.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line3_Country[0]", source._interpreterCountry.ToUpper());

                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line4_DaytimePhone[0]", source._interpreterPhone.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line5_MobilePhone[0]", source._interpreterMobilePhone.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line6_EmailAddress[0]", source._interpreterEmail.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt3Line_NameOfLanguage[0]", source._interpreterLanguage.ToUpper());

                    //pdfFormFields.SetField("form1[0].#subform[2].Pt2Line6b_Signature[0]", source._interpreterSignature);
                    //pdfFormFields.SetField("form1[0].#subform[2].Pt3Line_DateofSignature[0]", GetDateStringFormat(source._interpreterSignatureDate));
                }

                pdfFormFields.SetField("form1[0].#subform[2].Pt4Line1_ApplicantFormOfID[0]", source._applicantIdentificationType.ToUpper());
                pdfFormFields.SetField("form1[0].#subform[2].Pt4Line2_IDNumber[0]", source._applicantIdentificationNumber.ToUpper());
                if (surgeon != null)
                {
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line1_FamilyName[0]", surgeon._lastName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line1_GivenName[0]", surgeon._name.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line1_MiddleName[0]", surgeon._middleName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line2_MedPracticeName[0]", surgeon._organization.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line3_State[0]", surgeon._state.ToString());

                    switch (surgeon._addressType)
                    {
                        case I693.AddressType.APT:
                            pdfFormFields.SetField("form1[0].#subform[5].Pt6Line3_Unit[2]", " APT ");
                            break;
                        case I693.AddressType.STE:
                            pdfFormFields.SetField("form1[0].#subform[5].Pt6Line3_Unit[1]", " STE ");
                            break;
                        case I693.AddressType.FLR:
                            pdfFormFields.SetField("form1[0].#subform[5].Pt6Line3_Unit[0]", " FLR ");
                            break;
                    }

                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line3_ZipCode[0]", surgeon._zip.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line3_StreetNumberName[0]", surgeon._streetAddress.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line3_CityOrTown[0]", surgeon._city.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line3_AptSteFlrNumber[0]", surgeon._addressNumber.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line4_State[0]", surgeon._mailingState.ToString());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line4_CityOrTown[0]", surgeon._mailingCity.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line4_AptSteFlrNumber[0]", surgeon._mailingAddressNumber.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line4_ZipCode[0]", surgeon._mailingZip.ToUpper());

                    switch (surgeon._mailingAddressType)
                    {
                        case I693.AddressType.APT:
                            pdfFormFields.SetField("form1[0].#subform[5].Pt6Line4_Unit[2]", " APT ");
                            break;
                        case I693.AddressType.STE:
                            pdfFormFields.SetField("form1[0].#subform[5].Pt6Line4_Unit[1]", " STE ");
                            break;
                        case I693.AddressType.FLR:
                            pdfFormFields.SetField("form1[0].#subform[5].Pt6Line4_Unit[0]", " FLR ");
                            break;
                    }

                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line4_StreetNumberName[0]", surgeon._mailingStreetAddress.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line5_DaytimePhone[0]", surgeon._Phone.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line6_MobilePhone[0]", surgeon._MobilePhone.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt6Line6_EmailAddress[0]", surgeon._Email.ToUpper());
                    UpdateEntries("form1[0].#subform[7].Pt7Line1A3_InitialScreening[0]", keys, pdfFormFields, "A");
                }

                if (preparer != null)
                {
                    pdfFormFields.SetField("form1[0].#subform[0].Pt2Line2_Checkbox[0]", "PREP");

                    pdfFormFields.SetField("form1[0].#subform[0].Part2_Item2_PreparerName[0]", preparer._name.ToUpper() + " " + preparer._lastName.ToUpper());

                    pdfFormFields.SetField("form1[0].#subform[2].Pt4Line1_PreparerFamilyName[0]", preparer._lastName.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt4Line1_PreparerGivenName[0]", preparer._name.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[2].Pt4Line2_PreparerNameofBusinessorOrgName[0]", preparer._organization.ToUpper());

                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt3Line3_ZipCode[0]", preparer._mailingZip.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt3Line3_StreetNumberName[0]", preparer._mailingStreetAddress.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt3Line3_CityOrTown[0]", preparer._mailingCity.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt4Line3_AptSteFlrNumber[0]", preparer._mailingAddressNumber.ToUpper());

                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt3Line3_State[0]", preparer._mailingState.ToString());
                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt3Line3_Province[0]", preparer._province.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt3Line3_PostalCode[0]", preparer._postalCode.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt3Line3_Country[0]", preparer._country.ToUpper());

                    switch (preparer._mailingAddressType)
                    {
                        case I693.AddressType.APT:
                            pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt4Line3_Unit[2]", " APT ");
                            break;
                        case I693.AddressType.STE:
                            pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt4Line3_Unit[0]", " STE ");
                            break;
                        case I693.AddressType.FLR:
                            pdfFormFields.SetField("form1[0].#subform[3].PreparersAddress[0].Pt4Line3_Unit[1]", " FLR ");
                            break;
                    }

                    pdfFormFields.SetField("form1[0].#subform[3].Pt4Line4_DaytimePhone[0]", preparer._Phone.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt4Line5_MobilePhone[0]", preparer._MobilePhone.ToUpper());
                    pdfFormFields.SetField("form1[0].#subform[3].Pt4Line6_EmailAddress[0]", preparer._Email.ToUpper());

                    if (preparer._preparerStatementA)
                        pdfFormFields.SetField("form1[0].#subform[3].Part9_Item7_AttorneyCB[1]", "N");
                    else
                    {
                        pdfFormFields.SetField("form1[0].#subform[3].Part9_Item7_AttorneyCB[0]", "Y");
                        if (preparer._preparerExtatementExtends)
                            pdfFormFields.SetField("form1[0].#subform[3].Part9_Item7b_Extend[0]", "Y");
                        else
                            pdfFormFields.SetField("form1[0].#subform[3].Part9_Item7b_NotExtend[0]", "N");
                    }
                }
                pdfStamper.FormFlattening = true;
                pdfStamper.Close();

                System.Diagnostics.Process.Start(_destinationFile);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to save the PDF File. Make sure any PDF file is closed.");
            }
        }

        public static void UpdateEntries(string key, List<string> allKeys, AcroFields fields, string content)
        {
            var entries = allKeys.Where(x => x.Contains(key));
            foreach (var entry in entries)
                fields.SetField(entry, content);
        }

        public static string GetDateStringFormat(DateTime t)
        {
            return string.Format("{0}/{1}/{2}", t.Month.ToString("00"), t.Day.ToString("00"), t.Year);
        }
    }
}

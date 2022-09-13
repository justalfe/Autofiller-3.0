using AutoFiller_APP.Entites;
using AutoFiller_APP.Model;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AutoFiller_APP
{
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
        }

        private void ExportSCExcel_Click(object sender, EventArgs e)
        {
            using (var db = new AutoDBContext())
            {
                var surgeons = db.CivilSurgeons.AsEnumerable().Select(d => JsonConvert.DeserializeObject<CivilSurgeonsExportModel>(d.FormData)).ToList();

                if (surgeons.Count > 0)
                {
                    try
                    {
                        //saving file in location 
                        using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                DataTable dt = new DataTable("SurgeonGrid");
                                dt.Columns.AddRange(new DataColumn[25] {
                                            new DataColumn("Id"),
                                            new DataColumn("First name"),
                                            new DataColumn("Middle Name"),
                                            new DataColumn("Last Name"),
                                            new DataColumn("Organization"),
                                            new DataColumn("Street Address"),
                                            new DataColumn("Address Type"),
                                            new DataColumn("Address Number"),
                                            new DataColumn("City"),
                                            new DataColumn("State"),
                                            new DataColumn("Zip"),
                                            new DataColumn("Province"),
                                            new DataColumn("Postal Code"),
                                            new DataColumn("Country"),
                                            new DataColumn("Mailing Street Address"),
                                            new DataColumn("Mailing Address Type"),
                                            new DataColumn("Mailing Address Number"),
                                            new DataColumn("Mailing City"),
                                            new DataColumn("Mailing State"),
                                            new DataColumn("Mailing Zip"),
                                            new DataColumn("Phone"),
                                            new DataColumn("Mobile Phone"),
                                            new DataColumn("Email"),
                                            new DataColumn("Preparer Statement A"),
                                            new DataColumn("Preparer Extatement Extends")
                         });


                                foreach (var item in surgeons)
                                {
                                    dt.Rows.Add(item._id, item._name, item._middleName, item._lastName,
                                        item._organization,
                                        item._streetAddress,
                                        item._addressType,
                                        item._addressNumber,
                                        item._city,
                                        item._state,
                                        item._zip,
                                        item._province,
                                        item._postalCode,
                                        item._country,
                                        item._mailingStreetAddress,
                                        item._mailingAddressType,
                                        item._mailingAddressNumber,
                                        item._mailingCity,
                                        item._mailingState,
                                        item._mailingZip,
                                        item._Phone,
                                        item._MobilePhone,
                                        item._Email,
                                        item._preparerStatementA,
                                        item._preparerExtatementExtends);
                                }


                                using (XLWorkbook workbook = new XLWorkbook())
                                {
                                    workbook.Worksheets.Add(dt, "CivilSurgeons");
                                    workbook.SaveAs(sfd.FileName);
                                    MessageBox.Show("Civil Surgeon data exported successfully.");
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception occured in export process.");
                    }

                }
            }
        }

        private void ExportPrpExcel_Click(object sender, EventArgs e)
        {
            using (var db = new AutoDBContext())
            {
                var preparerModel = db.Preparers.AsEnumerable().Select(d => JsonConvert.DeserializeObject<PreparerExportModel>(d.FormData)).ToList();

                if (preparerModel.Count > 0)
                {
                    try
                    {
                        //saving file in location 
                        using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                DataTable dt = new DataTable("PreparerTable");
                                dt.Columns.AddRange(new DataColumn[25] {
                                            new DataColumn("Id"),
                                            new DataColumn("First Name"),
                                            new DataColumn("Middle Name"),
                                            new DataColumn("Last Name"),
                                            new DataColumn("Organization"),
                                            new DataColumn("Street Address"),
                                            new DataColumn("Address Type"),
                                            new DataColumn("Address Number"),
                                            new DataColumn("City"),
                                            new DataColumn("State"),
                                            new DataColumn("Zip"),
                                            new DataColumn("Province"),
                                            new DataColumn("PostalCode"),
                                            new DataColumn("Country"),
                                            new DataColumn("Mailing Street Address"),
                                            new DataColumn("Mailing Address Type"),
                                            new DataColumn("Mailing Address Number"),
                                            new DataColumn("Mailing City"),
                                            new DataColumn("Mailing State"),
                                            new DataColumn("Mailing Zip"),
                                            new DataColumn("Phone"),
                                            new DataColumn("Mobile Phone"),
                                            new DataColumn("Email"),
                                            new DataColumn("Preparer Statement A"),
                                            new DataColumn("Preparer Extatement Extends")
                         });


                                foreach (var item in preparerModel)
                                {
                                    dt.Rows.Add(item._id,  item._name, item._middleName, item._lastName,
                                        item._organization,
                                        item._streetAddress,
                                        item._addressType,
                                        item._addressNumber,
                                        item._city,
                                        item._state,
                                        item._zip,
                                        item._province,
                                        item._postalCode,
                                        item._country,
                                        item._mailingStreetAddress,
                                        item._mailingAddressType,
                                        item._mailingAddressNumber,
                                        item._mailingCity,
                                        item._mailingState,
                                        item._mailingZip,
                                        item._Phone,
                                        item._MobilePhone,
                                        item._Email,
                                        item._preparerStatementA,
                                        item._preparerExtatementExtends);
                                }


                                using (XLWorkbook workbook = new XLWorkbook())
                                {
                                    workbook.Worksheets.Add(dt, "Preparers");
                                    workbook.SaveAs(sfd.FileName);
                                    MessageBox.Show("Preparers data exported successfully.");
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception occured in export process.");
                    }

                }
            }
        }

        private void ExportPatientData_Click(object sender, EventArgs e)
        {
            using (var db = new AutoDBContext())
            {
                var patientModel = db.Patients.AsEnumerable().Select(d => MapPatientDataSet(d.Source, d.Surgeon, d.Preparer)).ToList();
                if (patientModel.Count > 0)
                {
                    try
                    {
                        //saving file in location 
                        using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                var properties = typeof(PatientExportModel).GetProperties();

                                DataTable dt = new DataTable("PatientDataTable");

                                /*foreach (PropertyInfo p in properties)
                                {
                                    dt.Columns.Add(p.Name, p.PropertyType);
                                }*/

                                dt.Columns.AddRange(new DataColumn[46] {
                                            new DataColumn("UniqueId"),
                                            new DataColumn("Surgeon Full Name"),
                                            new DataColumn("Preparer Full Name"),
                                            new DataColumn("Applicant First Name"),
                                            new DataColumn("Applicant Middle Name"),
                                            new DataColumn("Applicant Last Name"),                                            
                                            new DataColumn("Applicant Address Type"),
                                            new DataColumn("Applicant Address Number"),
                                            new DataColumn("Applicant Street"),
                                            new DataColumn("Applicant City"),
                                            new DataColumn("Applicant State"),
                                            new DataColumn("Applicant Zip"),
                                            new DataColumn("Applicant Birth"),
                                            new DataColumn("Applicant Birth City"),
                                            new DataColumn("Applicant Birth Country"),
                                            new DataColumn("Applicant Sex"),                                           
                                            new DataColumn("Applicant Alien Registration Number"),
                                            new DataColumn("Applicant Uscis"),
                                            new DataColumn("Applicant Statement 1aORb"),
                                            new DataColumn("Applicant Statetemnt 1bfield"),
                                            new DataColumn("Applicant Phone Number"),
                                            new DataColumn("Applicant Mobile Phone"),
                                            new DataColumn("Applicant Email"),
                                            new DataColumn("Applicant Signature"),
                                            new DataColumn("Applicant Date Of Signature"),
                                            new DataColumn("Applicant Identification Type "),
                                            new DataColumn("Applicant Identification Number"),
                                            new DataColumn("Interpreter First Name"),
                                            new DataColumn("Interpreter Last Name"),
                                            new DataColumn("Interpreter Organization"),                                            
                                            new DataColumn("Interpreter Street Address"),
                                            new DataColumn("Interpreter Address Type"),
                                            new DataColumn("Interpreter Address Number"),
                                            new DataColumn("Interpreter City"),
                                            new DataColumn("Interpreter State"),
                                            new DataColumn("Interpreter Zip"),
                                            new DataColumn("Interpreter Province"),
                                            new DataColumn("Interpreter Postal Code"),
                                            new DataColumn("Interpreter Country"),
                                            new DataColumn("Interpreter Phone"),
                                            new DataColumn("Interpreter Mobile Phone"),
                                            new DataColumn("Interpreter Email"),
                                            new DataColumn("Interpreter Language"),
                                            new DataColumn("Interpreter Signature"),
                                            new DataColumn("Interpreter Signature Date"),                                            
                                            new DataColumn("Exported PDF Date")

                         }); 


                                foreach (var item in patientModel)
                                {
                                    dt.Rows.Add(item._uniqueId,
                                        item.surgeon_fullname,
                                        item.preparer_fullname,
                                        item._firstname,
                                        item._middlename,
                                        item._lastname,
                                        item._addressType,
                                        item._addressNumber,
                                        item._addressStreet,
                                        item._addressCity,
                                        item._addressState,
                                        item._addressZip,                                        
                                        item._birth,
                                        item._birthCity,
                                        item._birthCountry,
                                        item._sex,
                                        item._alienRegistrationNumber,
                                        item._uscis,
                                        item._applicationStatement1aORb,
                                        item._applicationStatetemnt1bfield,
                                        item._applicantPhoneNumber,
                                        item._applicantMobileNumber,
                                        item._applicantEmail,
                                        item._applicantSignature,
                                        item._applicantDateOfSignature,
                                        item._applicantIdentificationType,
                                        item._applicantIdentificationNumber,
                                        item._interpreterName,
                                        item._interpreterLastName,
                                        item._interpreterOrganization,
                                        item._interpreterStreetAddress,
                                        item._interpreterAddressType,
                                        item._interpreterAddressNumber,
                                        item._interpreterCity,
                                        item._interpreterState,
                                        item._interpreterZip,
                                        item._interpreterProvince,
                                        item._interpreterPostalCode,
                                        item._interpreterCountry,
                                        item._interpreterPhone,
                                        item._interpreterMobilePhone,
                                        item._interpreterEmail,
                                        item._interpreterLanguage,
                                        item._interpreterSignature,
                                        item._interpreterSignatureDate,                                        
                                        item._dateOfCreation
                                        );
                                }


                                using (XLWorkbook workbook = new XLWorkbook())
                                {
                                    workbook.Worksheets.Add(dt, "PatientsSheet");
                                    workbook.SaveAs(sfd.FileName);
                                    MessageBox.Show("Patients exported successfully.");
                                }

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception occured in export process.");
                    }

                }
            }
        }

        private PatientExportModel MapPatientDataSet(string source, string surgeon, string preparer)
        {
            if (!string.IsNullOrEmpty(source))
            {
                var sourceModel = JsonConvert.DeserializeObject<PatientExportModel>(source);
                var surgeonModel = string.IsNullOrEmpty(surgeon) ? new CivilSurgeonsExportModel() : JsonConvert.DeserializeObject<CivilSurgeonsExportModel>(surgeon);
                var prepnModel = string.IsNullOrEmpty(preparer) ? new PreparerExportModel() : JsonConvert.DeserializeObject<PreparerExportModel>(preparer);
                //set surgeon full name and prep full name
                sourceModel.surgeon_fullname = $"{surgeonModel._name} {surgeonModel._middleName} {surgeonModel._lastName}";
                sourceModel.preparer_fullname = $"{prepnModel._name} {prepnModel._middleName} {prepnModel._lastName}";
                return sourceModel;
            }
            else
            {
                return new PatientExportModel();
            }
        }
    }
}

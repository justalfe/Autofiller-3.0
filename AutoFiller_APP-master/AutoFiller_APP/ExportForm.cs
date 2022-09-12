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
                                            new DataColumn("_id"),
                                            new DataColumn("_lastName"),
                                            new DataColumn("_name"),
                                            new DataColumn("_middleName"),
                                            new DataColumn("_organization"),
                                            new DataColumn("_streetAddress"),
                                            new DataColumn("_addressType"),
                                            new DataColumn("_addressNumber"),
                                            new DataColumn("_city"),
                                            new DataColumn("_state"),
                                            new DataColumn("_zip"),
                                            new DataColumn("_province"),
                                            new DataColumn("_postalCode"),
                                            new DataColumn("_country"),
                                            new DataColumn("_mailingStreetAddress"),
                                            new DataColumn("_mailingAddressType"),
                                            new DataColumn("_mailingAddressNumber"),
                                            new DataColumn("_mailingCity"),
                                            new DataColumn("_mailingState"),
                                            new DataColumn("_mailingZip"),
                                            new DataColumn("_Phone"),
                                            new DataColumn("_MobilePhone"),
                                            new DataColumn("_Email"),
                                            new DataColumn("_preparerStatementA"),
                                            new DataColumn("_preparerExtatementExtends")
                         });


                                foreach (var item in surgeons)
                                {
                                    dt.Rows.Add(item._id, item._lastName, item._name, item._middleName,
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
                                            new DataColumn("_id"),
                                            new DataColumn("_lastName"),
                                            new DataColumn("_name"),
                                            new DataColumn("_middleName"),
                                            new DataColumn("_organization"),
                                            new DataColumn("_streetAddress"),
                                            new DataColumn("_addressType"),
                                            new DataColumn("_addressNumber"),
                                            new DataColumn("_city"),
                                            new DataColumn("_state"),
                                            new DataColumn("_zip"),
                                            new DataColumn("_province"),
                                            new DataColumn("_postalCode"),
                                            new DataColumn("_country"),
                                            new DataColumn("_mailingStreetAddress"),
                                            new DataColumn("_mailingAddressType"),
                                            new DataColumn("_mailingAddressNumber"),
                                            new DataColumn("_mailingCity"),
                                            new DataColumn("_mailingState"),
                                            new DataColumn("_mailingZip"),
                                            new DataColumn("_Phone"),
                                            new DataColumn("_MobilePhone"),
                                            new DataColumn("_Email"),
                                            new DataColumn("_preparerStatementA"),
                                            new DataColumn("_preparerExtatementExtends")
                         });


                                foreach (var item in preparerModel)
                                {
                                    dt.Rows.Add(item._id, item._lastName, item._name, item._middleName,
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

        private void ExportPDFData_Click(object sender, EventArgs e)
        {
            using (var db = new AutoDBContext())
            {
                var pdfDataModel = db.PDFExportDatas.AsEnumerable().Select(d => MapPdfDataSet(d.Source, d.Surgeon, d.Preparer)).ToList();
                if (pdfDataModel.Count > 0)
                {
                    try
                    {
                        //saving file in location 
                        using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
                        {
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                var properties = typeof(PdfDataExportModel).GetProperties();

                                DataTable dt = new DataTable("PdfDataTable");

                                foreach (PropertyInfo p in properties)
                                {
                                    dt.Columns.Add(p.Name, p.PropertyType);
                                }


                                foreach (var item in pdfDataModel)
                                {
                                    dt.Rows.Add(item.surgeon_fullname, item.preparer_fullname, item._uniqueId, item._lastname, item._firstname, item._middlename,
                                        item._addressStreet,
                                        item._addressType,
                                        item._addressNumber,
                                        item._addressCity,
                                        item._addressState,
                                        item._addressZip,
                                        item._sex,
                                        item._birth,
                                        item._birthCity,
                                        item._birthCountry,
                                        item._alienRegistrationNumber,
                                        item._uscis,
                                        item._applicationStatement1aORb,
                                        item._applicationStatetemnt1bfield,
                                        item._applicantPhoneNumber,
                                        item._applicantMobileNumber,
                                        item._applicantEmail,
                                        item._applicantSignature,
                                        item._applicantDateOfSignature,
                                        item._interpreterLastName,
                                        item._interpreterName,
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
                                        item._applicantIdentificationType,
                                        item._applicantIdentificationNumber,
                                        item._dateOfCreation
                                        );
                                }


                                using (XLWorkbook workbook = new XLWorkbook())
                                {
                                    workbook.Worksheets.Add(dt, "PdfDataSheet");
                                    workbook.SaveAs(sfd.FileName);
                                    MessageBox.Show("Pdf data exported successfully.");
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

        private PdfDataExportModel MapPdfDataSet(string source, string surgeon, string preparer)
        {
            if (!string.IsNullOrEmpty(source))
            {
                var sourceModel = JsonConvert.DeserializeObject<PdfDataExportModel>(source);
                var surgeonModel = string.IsNullOrEmpty(surgeon) ? new CivilSurgeonsExportModel() : JsonConvert.DeserializeObject<CivilSurgeonsExportModel>(surgeon);
                var prepnModel = string.IsNullOrEmpty(preparer) ? new PreparerExportModel() : JsonConvert.DeserializeObject<PreparerExportModel>(preparer);
                //set surgeon full name and prep full name
                sourceModel.surgeon_fullname = $"{surgeonModel._name} {surgeonModel._middleName} {surgeonModel._lastName}";
                sourceModel.preparer_fullname = $"{prepnModel._name} {prepnModel._middleName} {prepnModel._lastName}";
                return sourceModel;
            }
            else
            {
                return new PdfDataExportModel();
            }
        }
    }
}

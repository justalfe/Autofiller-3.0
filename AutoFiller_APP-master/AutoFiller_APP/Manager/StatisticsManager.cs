using AutoFiller_API.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFiller_APP.Manager
{
    class StatisticsManager
    {
        const string TEMPLATE_PATH = "./resources/statistics.xlsx";
        public static void GenerateStatisticsFile(QuestionnaireStatistics qs)
        {
            FileInfo newFile = new FileInfo(TEMPLATE_PATH);

            ExcelPackage pck = new ExcelPackage(newFile);

            var ws = pck.Workbook.Worksheets[1];
            ws.Cells[2, 1].Formula = ((qs._googleCount!=0)? "=" + qs._googleCount.ToString():"");
            ws.Cells[2, 2].Formula = ((qs._facebookCount != 0) ? "=" + qs._facebookCount.ToString() : "");
            ws.Cells[2, 3].Formula =  ((qs._yelpCount != 0) ? "=" + qs._yelpCount.ToString() : "");
            ws.Cells[2, 4].Formula =  ((qs._lawyerCount != 0) ? "=" + qs._lawyerCount.ToString() : "");
            ws.Cells[2, 5].Formula = ((qs._tvCount != 0) ? "=" + qs._tvCount.ToString() : "");
            ws.Cells[2, 6].Formula = ((qs._newspaperCount != 0) ? "=" + qs._newspaperCount.ToString() : "");
            ws.Cells[2, 7].Formula = ((qs._radioCount != 0) ? "=" + qs._radioCount.ToString() : "");
            ws.Cells[2, 8].Formula = ((qs._bingCount != 0) ? "=" + qs._bingCount.ToString() : "");
            ws.Cells[2, 9].Formula = ((qs._other.Count != 0) ? "=" + qs._other.Count.ToString() : "");

            for (int i=0;i<qs._other.Count;i++)
                ws.Cells[6 + i, 1].Value = qs._other[i];

            var fileDialog = new SaveFileDialog();
            fileDialog.FileName = "statistics_"+qs._dateTime.Year+"_"+qs._dateTime.Month+".xlsx";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileSplit = fileDialog.FileName.Split('.');
                if (fileSplit[fileSplit.Length - 1].ToLower() != "xlsx")
                    fileDialog.FileName += ".xlsx";
                pck.SaveAs(new FileInfo(fileDialog.FileName));
                System.Diagnostics.Process.Start(fileDialog.FileName);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using Models;

namespace ConsoleApp1
{
    class WLRCensusReportService
    {
        public void buildWorksheet(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            WLRCensusDAO dao = new WLRCensusDAO();
            Location location = dao.GetLocation(locationId);
            Console.WriteLine($"Location is {location}");

            List<WLRCensusRecord> list = dao.GetWLRCensusRecords(4, startDate, endDate, facilityTypeCode);
            Console.WriteLine($"Found {list.Count} records");

            var recordsGroupedByPayorType = list.GroupBy(record => record.PayorType);
            foreach (var group in recordsGroupedByPayorType)
            {
                Console.WriteLine("Records with Payor Type: " + group.Key + ":");
                var recordsGroupedByAdmissionStatus = group.GroupBy(item => item.AdmissionStatus);
                foreach (var group2 in recordsGroupedByAdmissionStatus)
                {
                    Console.WriteLine("Records with Admission Status: " + group2.Key + ":");
                    foreach (WLRCensusRecord record in group2)
                        Console.WriteLine("* " + record.FirstName + " " + record.LastName);
                }
            }

            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("MySheet");
                //ws.Cells["A1"].Value = "This is cell A1";
                buildHeader(ws, location, startDate, endDate, facilityTypeCode);
                //p.SaveAs(new FileInfo(@"D:\Users\i3Setup\source\repos\ConsoleApp1\myworkbook.xlsx"));
                p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\myworkbook.xlsx"));

            }
        }

        private void buildHeader(ExcelWorksheet ws, Location location, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            ws.Cells["A1:B1"].Merge = true;
            //ws.Cells["A1:B1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["A1:B1"].Value = location.Name;
            ws.Cells["A2"].Value = "For Facility Type " + facilityTypeCode;
            ws.Cells["B2"].Value = "For Unit Assignment Code ALL";

            ws.Cells["A3:N3"].Merge = true;
            ws.Cells["A3:N3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["A3:N3"].Style.Font.Size = 17;
            ws.Cells["A3:N3"].Style.Font.Bold = true;
            ws.Cells["A3:N3"].Value = "Roster for " + facilityTypeCode + " " + startDate.ToString("MM/dd/yyyy") + " thru " + endDate.ToString("MM/dd/yyyy") + " Sequence - By Payor Type + Census Status - All";
            ws.View.FreezePanes(3, 15);
        }
    }
}

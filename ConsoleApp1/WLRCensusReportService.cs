using System;
using System.Collections.Generic;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

namespace ConsoleApp1
{
    class WLRCensusReportService
    {
        public void buildWorksheet(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("MySheet");
                //ws.Cells["A1"].Value = "This is cell A1";
                buildHeader(ws);
                //p.SaveAs(new FileInfo(@"D:\Users\i3Setup\source\repos\ConsoleApp1\myworkbook.xlsx"));
                p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\myworkbook.xlsx"));
            
            }
        }

        private void buildHeader(ExcelWorksheet ws)
        {
            ws.Cells["A1:B1"].Merge = true;
           //ws.Cells["A1:B1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells["A1:B1"].Value = "King Farm Presbyterian Community Inc.";
            ws.Cells["A2"].Value = "Facility";
            ws.Cells["B2"].Value = "Memory Support Assisted Living";

        }
    }
}

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

            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("Census Report - WLR");
                int rowNumber = addPageHeaderSection(ws, location, startDate, endDate, facilityTypeCode);
                rowNumber = addColumnHeaders(ws, rowNumber);
                

                List<WLRCensusRecord> list = dao.GetWLRCensusRecords(4, startDate, endDate, facilityTypeCode);
                Console.WriteLine($"Found {list.Count} records");

                var recordsByPayorType = list.GroupBy(record => record.PayorType);
                foreach (var group in recordsByPayorType)
                {
                    //Console.WriteLine("Records with Payor Type: " + group.Key + ":");
                    rowNumber = addPayorTypeHeader(ws, group.Key, rowNumber);

                    var recordsByAdmissionStatus = group.GroupBy(item => item.AdmissionStatus);
                    foreach (var group2 in recordsByAdmissionStatus)
                    {
                        //Console.WriteLine("Records with Admission Status: " + group2.Key + ":");
                        string admissionStatusDescription = null;
                        foreach (WLRCensusRecord record in group2)
                        {
                            rowNumber = addGridRow(ws, record, rowNumber);
                            //Console.WriteLine("* " + record.FirstName + " " + record.LastName);
                            if(admissionStatusDescription == null)
                            {
                                admissionStatusDescription = record.AdmissionStatusDescription;
                            }
                        }
                        rowNumber = addSubTotalRow(ws, group2.Key, admissionStatusDescription, group2.Count(), rowNumber);
                    }
                }
                ws.Cells["A:N"].AutoFitColumns();
                p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\myworkbook.xlsx"));
            }
        }

        private int addPageHeaderSection(ExcelWorksheet ws, Location location, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            //Columns A and B
            int rowNumber = 1;
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 2];
            range.Merge = true;
            range.Value = location.Name;


            //Columns A and B
            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "For Facility Type " + facilityTypeCode;
            ws.Cells[rowNumber, 2].Value = "For Unit Assignment Code ALL";


            //Colums A to N
            rowNumber++;
            range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Size = 17;
            range.Style.Font.Bold = true;
            range.Style.Font.UnderLine = true;
            range.Value = "Roster for " + facilityTypeCode + " " + startDate.ToString("MM/dd/yyyy") + " thru " + endDate.ToString("MM/dd/yyyy") + " Sequence - By Payor Type + Census Status - All";
            ws.View.FreezePanes(3, 15);
            return ++rowNumber;
        }

        private int addColumnHeaders(ExcelWorksheet ws, int rowNumber)
        {
            ws.Cells[rowNumber, 1].Value = "Last Name";
            ws.Cells[rowNumber, 2].Value = "First Name";
            ws.Cells[rowNumber, 3].Value = "Medical Record #";
            ws.Cells[rowNumber, 4].Value = "Profile ID";
            ws.Cells[rowNumber, 5].Value = "Admit No.";
            ws.Cells[rowNumber, 6].Value = "St";
            ws.Cells[rowNumber, 7].Value = "Leave/Discharge To";
            ws.Cells[rowNumber, 8].Value = "Unit Number";
            ws.Cells[rowNumber, 9].Value = "Unit Type";
            ws.Cells[rowNumber, 10].Value = "Unit Loctn";
            ws.Cells[rowNumber, 11].Value = "Level of Care";
            ws.Cells[rowNumber, 12].Value = " ";
            ws.Cells[rowNumber, 13].Value = " ";
            ws.Cells[rowNumber, 14].Value = " ";

            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            return ++rowNumber;
        }

        private int addPayorTypeHeader(ExcelWorksheet ws, string payorTypeCode, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Payor Type: " + payorTypeCode;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            //range.Style.Font.UnderLine = true;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            return ++rowNumber;
        }

        private int addGridRow(ExcelWorksheet ws, WLRCensusRecord record, int rowNumber)
        {
            ws.Cells[rowNumber, 1].Value = record.LastName;
            ws.Cells[rowNumber, 2].Value = record.FirstName;
            ws.Cells[rowNumber, 3].Value = record.ResidentID;
            ws.Cells[rowNumber, 4].Value = record.ResidentID;
            ws.Cells[rowNumber, 5].Value = record.AdmissionNumber;
            ws.Cells[rowNumber, 6].Value = record.AdmissionStatus;
            ws.Cells[rowNumber, 7].Value = record.DischargeTo;
            ws.Cells[rowNumber, 8].Value = record.UnitNumber;
            ws.Cells[rowNumber, 9].Value = record.UnitType;
            ws.Cells[rowNumber, 10].Value = record.Building;
            ws.Cells[rowNumber, 11].Value = record.LevelOfCare;
            ws.Cells[rowNumber, 12].Value = " ";
            ws.Cells[rowNumber, 13].Value = " ";
            ws.Cells[rowNumber, 14].Value = " ";

            return ++rowNumber;
        }

        private int addSubTotalRow(ExcelWorksheet ws, string statusTypeCode, string statusTypeDescription, int numberOfRecords, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Status Type: " + statusTypeCode + " - " + statusTypeDescription + "\t\t\t\t\t\tSub-Total: " + numberOfRecords;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            //range.Style.Font.UnderLine = true;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            return ++rowNumber;
        }
    }
}

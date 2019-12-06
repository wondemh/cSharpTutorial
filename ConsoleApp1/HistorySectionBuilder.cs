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
    public class HistorySectionBuilder
    {
        public static int BuildHistorySection(ExcelWorksheet ws, List<CensusHistoryRecord> censusHistoryRecords, Location location, FacilityType facilityType, DateTime startDate, DateTime endDate, int rowNumber)
        {
            rowNumber = AddPageHeaderSection(ws, location, facilityType, startDate, endDate, rowNumber);
            rowNumber = AddColumnHeaders(ws, rowNumber);
            foreach (var record in censusHistoryRecords)
            {
                rowNumber = AddGridRow(ws, record, location, startDate, endDate, rowNumber);
            }
            rowNumber = AddTotalsSection(ws, censusHistoryRecords, rowNumber);

            return ++rowNumber;
        }

        private static int AddPageHeaderSection(ExcelWorksheet ws, Location location, FacilityType facilityType, DateTime startDate, DateTime endDate, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 4];
            range.Merge = true;
            range.Value = location.Name;

            range = ws.Cells[rowNumber, 16, rowNumber, 20];
            range.Merge = true;
            range.Value = DateTime.Now.ToString("MM/dd/yyyy           HH:mm");
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            rowNumber++;
            ws.Cells[rowNumber, 1, rowNumber, 2].Value = "Facility " + facilityType.FacilType + " " + facilityType.Title;

            range = ws.Cells[rowNumber, 16, rowNumber, 20];
            range.Merge = true;
            range.Value = "Report Definition           ad hoc";
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            rowNumber++;
            range = ws.Cells[rowNumber, 1, rowNumber, 20];
            range.Merge = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Size = 17;
            range.Style.Font.Bold = true;
            range.Value = "Resident Census History Report by Resident Name";

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Unit Locations";
            ws.Cells[rowNumber, 2].Value = "ALL";
            ws.Cells[rowNumber, 19].Value = "Census From Date";
            ws.Cells[rowNumber, 20].Value = startDate.ToString("MM/dd/yyyy");

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Admission Statuses";
            ws.Cells[rowNumber, 2].Value = "ALL";
            ws.Cells[rowNumber, 19].Value = "Census Thru Date";
            ws.Cells[rowNumber, 20].Value = endDate.ToString("MM/dd/yyyy");

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Levels of Care";
            ws.Cells[rowNumber, 2].Value = "ALL";
            ws.Cells[rowNumber, 19].Value = "Medicare (Mc) Certified";
            ws.Cells[rowNumber, 20].Value = "Include";

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Payor Types";
            ws.Cells[rowNumber, 2].Value = "ALL";
            ws.Cells[rowNumber, 19].Value = "Medicaid (Md) Certified";
            ws.Cells[rowNumber, 20].Value = "Include";

            return ++rowNumber;
        }

        private static int AddColumnHeaders(ExcelWorksheet ws, int rowNumber)
        {
            ws.Cells[rowNumber, 1].Value = "Name";
            ws.Cells[rowNumber, 2].Value = "Medical Record #";
            ws.Cells[rowNumber, 3].Value = "ID";
            ws.Cells[rowNumber, 4].Value = "Census From Date";
            ws.Cells[rowNumber, 5].Value = "Census Thru Date";
            ws.Cells[rowNumber, 6].Value = "Unit Lctn";
            ws.Cells[rowNumber, 7].Value = "Bill Days";
            ws.Cells[rowNumber, 8].Value = "Non Bill Days";
            ws.Cells[rowNumber, 9].Value = "Payor1";
            ws.Cells[rowNumber, 10].Value = "Payor2";
            ws.Cells[rowNumber, 11].Value = "Co-Ins";
            ws.Cells[rowNumber, 12].Value = "Unit No.";
            ws.Cells[rowNumber, 13].Value = "Level of Care";
            ws.Cells[rowNumber, 14].Value = "Med A Admission Date";
            ws.Cells[rowNumber, 15].Value = "Med A Days";
            ws.Cells[rowNumber, 16].Value = "Mc/Md";
            ws.Cells[rowNumber, 17].Value = "Status";
            ws.Cells[rowNumber, 18].Value = "Adm#";
            ws.Cells[rowNumber, 19].Value = "Adm Date";
            ws.Cells[rowNumber, 20].Value = "Skilled Care End Date";

            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 20];
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            return ++rowNumber;
        }

        private static int AddGridRow(ExcelWorksheet ws, CensusHistoryRecord record, Location location, DateTime startDate, DateTime endDate, int rowNumber)
        {
            ws.Cells[rowNumber, 1].Value = record.LastName + ", " + record.FirstName + " " + (record.MidInit ?? "");
            ws.Cells[rowNumber, 2].Value = record.ResidentID;
            ws.Cells[rowNumber, 3].Value = record.ResidentID;
            ws.Cells[rowNumber, 4].Value = startDate.ToString("MM/dd/yyyy");
            ws.Cells[rowNumber, 5].Value = endDate.ToString("MM/dd/yyyy");
            ws.Cells[rowNumber, 6].Value = location.Id;
            ws.Cells[rowNumber, 7].Value = record.BillDays;
            ws.Cells[rowNumber, 8].Value = "N/A";
            ws.Cells[rowNumber, 9].Value = record.PayorType;
            ws.Cells[rowNumber, 10].Value = "N/A";
            ws.Cells[rowNumber, 11].Value = "N/A";
            ws.Cells[rowNumber, 12].Value = record.UnitNumber;
            ws.Cells[rowNumber, 13].Value = record.LevelOfCare;
            ws.Cells[rowNumber, 14].Value = "N/A"; //Med A Admission Date
            ws.Cells[rowNumber, 15].Value = "N/A"; //Med A Days
            ws.Cells[rowNumber, 16].Value = "N/A"; //Mc/Md
            ws.Cells[rowNumber, 17].Value = record.Status; //Status
            ws.Cells[rowNumber, 18].Value = record.AdmissionNumber; //Adm #
            ws.Cells[rowNumber, 19].Value = "N/A"; //Adm Date. Can't use census date because we are aggregating for this report
            ws.Cells[rowNumber, 20].Value = "N/A"; //Skilled Care End Date

            return ++rowNumber;
        }

        private static int AddTotalsSection(ExcelWorksheet ws, List<CensusHistoryRecord> records, int rowNumber)
        {
            rowNumber++;//add empty row
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 5];
            range.Merge = true;
            range.Value = "Total Number of Days by 1st Payor Type";
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "";
            ws.Cells[rowNumber, 2].Value = "";
            ws.Cells[rowNumber, 3].Value = "Total Billable";
            ws.Cells[rowNumber, 4].Value = "Total";
            ws.Cells[rowNumber, 5].Value = "Total Days";
            ws.Cells[rowNumber, 6].Value = "";
            ws.Cells[rowNumber, 7].Value = "";
            ws.Cells[rowNumber, 1, rowNumber, 7].Style.Font.Bold = true;

            var groupsByPayorType = records.GroupBy(item => item.PayorType);
            foreach (var group in groupsByPayorType)
            {
                rowNumber++;
                ws.Cells[rowNumber, 1].Value = group.Key;
                ws.Cells[rowNumber, 2].Value = group.First().PayorTypeDescription;
                ws.Cells[rowNumber, 3].Value = group.Sum(item => item.BillDays);
                ws.Cells[rowNumber, 4].Value = "N/A";
                ws.Cells[rowNumber, 5].Value = group.Sum(item => item.BillDays);
            }
            return ++rowNumber;
        }
    }

}

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
    public class RosterSectionBuilder
    {
        public static int BuildRosterSection(ExcelWorksheet ws, string facilityTypeCode, List<CensusRecord> list, Location location, DateTime startDate, DateTime endDate)
        {
            int rowNumber = AddPageHeaderSection(ws, location, startDate, endDate, facilityTypeCode);
            rowNumber = AddColumnHeaders(ws, rowNumber);

            var recordsByPayorType = list.GroupBy(record => record.GetPayorTypeCodeAndDescription());
            foreach (var group in recordsByPayorType)
            {
                rowNumber = AddPayorTypeHeader(ws, group.Key, rowNumber);
                var recordsByAdmissionStatus = group.GroupBy(item => item.AdmissionStatus);
                foreach (var group2 in recordsByAdmissionStatus)
                {
                    string admissionStatusDescription = null;
                    foreach (CensusRecord record in group2)
                    {
                        rowNumber = AddGridRow(ws, record, rowNumber);
                        if (admissionStatusDescription == null)
                        {
                            admissionStatusDescription = record.AdmissionStatusDescription;
                        }
                    }
                    rowNumber = AddSubTotalRow(ws, group2.Key, admissionStatusDescription, group2.Count(), rowNumber);
                }
            }
            rowNumber = AddCensusStatusTotalsRow(ws, list.Count, rowNumber);
            return ++rowNumber;
        }

        private static int AddPageHeaderSection(ExcelWorksheet ws, Location location, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            //Columns A and B
            int rowNumber = 1;
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 4];
            range.Merge = true;
            range.Value = location.Name;

            range = ws.Cells[rowNumber, 8, rowNumber, 14];
            range.Merge = true;
            range.Value = DateTime.Now.ToString("MM/dd/yyyy           HH:mm");
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

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
            string dateDescription = startDate.ToString("MM/dd/yyyy");
            if (startDate.Date != endDate.Date)
            {
                dateDescription += (" thru " + endDate.ToString("MM/dd/yyyy"));
            }
            range.Value = "Roster for " + facilityTypeCode + " " + dateDescription + " Sequence - By Payor Type + Census Status - All";
            //ws.View.FreezePanes(5, 15);
            return ++rowNumber;
        }

        private static int AddColumnHeaders(ExcelWorksheet ws, int rowNumber)
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

        private static int AddPayorTypeHeader(ExcelWorksheet ws, string payorTypeCode, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Payor Type: " + payorTypeCode;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            return ++rowNumber;
        }

        private static int AddGridRow(ExcelWorksheet ws, CensusRecord record, int rowNumber)
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

        private static int AddSubTotalRow(ExcelWorksheet ws, string statusTypeCode, string statusTypeDescription, int numberOfRecords, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 7];
            range.Merge = true;
            range.Value = "Status Type: " + statusTypeCode + " - " + statusTypeDescription;
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            range = ws.Cells[rowNumber, 8, rowNumber, 14];
            range.Merge = true;
            range.Value = "Sub-Total:      " + numberOfRecords;
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            return ++rowNumber;
        }

        private static int AddCensusStatusTotalsRow(ExcelWorksheet ws, int numberOfRecords, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Census Status Totals for - All: " + numberOfRecords;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            return ++rowNumber;
        }

    }
}

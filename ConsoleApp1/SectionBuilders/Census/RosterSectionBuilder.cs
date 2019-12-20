using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using ReportApp.Model;
using System.Globalization;
using System.Diagnostics.Contracts;

namespace ReportApp
{
    public static class RosterSectionBuilder
    {
        public static int BuildRosterSection(ExcelWorksheet ws, string facilityTypeCode, List<CensusItem> list, Location location, DateTime startDate, DateTime endDate)
        {
            Contract.Requires(ws != null);
            Contract.Requires(facilityTypeCode != null);
            Contract.Requires(list != null);
            Contract.Requires(location != null);
            Contract.Requires(startDate != null);
            Contract.Requires(endDate != null);

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
                    foreach (CensusItem record in group2)
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
            StringBuilder leftHeader = new StringBuilder();
            leftHeader.Append(location.Name).Append("\n");
            leftHeader.Append("For Facility Type " + facilityTypeCode);
            leftHeader.Append("    ").Append("For Unit Assignment Code ALL"); 
            
            ws.HeaderFooter.EvenHeader.LeftAlignedText = leftHeader.ToString();
            ws.HeaderFooter.OddHeader.LeftAlignedText = leftHeader.ToString();

            string dateInfo = startDate.ToString("MM/dd/yyyy", CultureInfo.CurrentCulture);
            if (startDate.Date != endDate.Date)
            {
                dateInfo += (" thru " + endDate.ToString("MM/dd/yyyy", CultureInfo.CurrentCulture));
            }
            //&17 means font size 17
            //&B means bold
            string centerHeader = "&17&BRoster for " + facilityTypeCode + " " + dateInfo + " Sequence - By Payor Type + Census Status - All";
            ws.HeaderFooter.EvenHeader.CenteredText = centerHeader;
            ws.HeaderFooter.OddHeader.CenteredText = centerHeader;

            string rightHeader = DateTime.Now.ToString("MM/dd/yyyy    HH:mm", CultureInfo.CurrentCulture) + "    Page: &P";
            ws.HeaderFooter.EvenHeader.RightAlignedText = rightHeader;
            ws.HeaderFooter.OddHeader.RightAlignedText = rightHeader;

            int rowNumber = 1;
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

        private static int AddGridRow(ExcelWorksheet ws, CensusItem record, int rowNumber)
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

            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Style.Border.Top.Style = ExcelBorderStyle.Hair;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Hair;
            range.Style.Border.Left.Style = ExcelBorderStyle.Hair;
            range.Style.Border.Right.Style = ExcelBorderStyle.Hair;

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

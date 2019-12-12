using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using ReportApp.Model;

namespace ReportApp
{
    public class OccupancyTableBuilder
    {
        public static int BuildRosterSection(ExcelWorksheet ws, List<OccupancyRecord> list, Location location, DateTime reportDate)
        {
            int rowNumber = AddPageHeaderSection(ws, location, reportDate);
            rowNumber = AddColumnHeaders(ws, rowNumber);
            return ++rowNumber;
        }

        private static int AddPageHeaderSection(ExcelWorksheet ws, Location location, DateTime reportDate)
        {
            //StringBuilder leftHeader = new StringBuilder();
            //leftHeader.Append(location.Name).Append("\n");
            //leftHeader.Append("For Facility Type " + facilityTypeCode);
            //leftHeader.Append("    ").Append("For Unit Assignment Code ALL"); 
            
            //ws.HeaderFooter.EvenHeader.LeftAlignedText = leftHeader.ToString();
            //ws.HeaderFooter.OddHeader.LeftAlignedText = leftHeader.ToString();

            //string dateInfo = startDate.ToString("MM/dd/yyyy");
            //if (startDate.Date != endDate.Date)
            //{
            //    dateInfo += (" thru " + endDate.ToString("MM/dd/yyyy"));
            //}
            ////&17 means font size 17
            ////&B means bold
            //string centerHeader = "&17&BRoster for " + facilityTypeCode + " " + dateInfo + " Sequence - By Payor Type + Census Status - All";
            //ws.HeaderFooter.EvenHeader.CenteredText = centerHeader;
            //ws.HeaderFooter.OddHeader.CenteredText = centerHeader;

            //string rightHeader = DateTime.Now.ToString("MM/dd/yyyy    HH:mm") + "    Page: &P";
            //ws.HeaderFooter.EvenHeader.RightAlignedText = rightHeader;
            //ws.HeaderFooter.OddHeader.RightAlignedText = rightHeader;

            int rowNumber = 1;
            return ++rowNumber;
        }

        private static int AddColumnHeaders(ExcelWorksheet ws, int rowNumber)
        {
            ws.Cells[rowNumber, 4].Value = "Jan";
            ws.Cells[rowNumber, 5].Value = "Feb";
            ws.Cells[rowNumber, 6].Value = "Mar";
            ws.Cells[rowNumber, 7].Value = "Apr";
            ws.Cells[rowNumber, 8].Value = "May";
            ws.Cells[rowNumber, 9].Value = "Jun";
            ws.Cells[rowNumber, 10].Value = "Jul";
            ws.Cells[rowNumber, 11].Value = "Aug";
            ws.Cells[rowNumber, 12].Value = "Sep";
            ws.Cells[rowNumber, 13].Value = "Oct";
            ws.Cells[rowNumber, 14].Value = "Nov";
            ws.Cells[rowNumber, 15].Value = "Dec";

            ExcelRange range = ws.Cells[rowNumber, 4, rowNumber, 15];
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Bold = true;
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

            return ++rowNumber;
        }



    }
}

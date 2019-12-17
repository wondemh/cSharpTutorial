using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using ReportApp.Model;
using ReportApp.DAO;
using ReportApp.Model.Occupancy;
using System.Globalization;

namespace ReportApp
{
    public abstract class OccupancySectionBuilder
    {

        internal static int AddPageHeader(ExcelWorksheet ws, string locationName, DateTime reportDate, int rowNumber)
        {
            int initialRowNumber = rowNumber;
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = locationName.ToUpper(CultureInfo.CurrentCulture);

            rowNumber++;
            range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "OCCUPANCY STATISTICS";

            rowNumber++;
            range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "AS OF " + reportDate.ToString("MM/dd/yyyy", CultureInfo.CurrentCulture); ;

            range = ws.Cells[initialRowNumber, 1, rowNumber, 14];
            range.Style.Font.Size = 15;
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            return rowNumber + 3;
        }

        internal static int AddSectionHeader(ExcelWorksheet ws, string headerText, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = headerText;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            range.Style.Font.UnderLine = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            return ++rowNumber;
        }

        internal static int AddColumnHeaders(ExcelWorksheet ws, int rowNumber)
        {
            ws.Cells[rowNumber, 2].Value = "Jan";
            ws.Cells[rowNumber, 3].Value = "Feb";
            ws.Cells[rowNumber, 4].Value = "Mar";
            ws.Cells[rowNumber, 5].Value = "Apr";
            ws.Cells[rowNumber, 6].Value = "May";
            ws.Cells[rowNumber, 7].Value = "Jun";
            ws.Cells[rowNumber, 8].Value = "Jul";
            ws.Cells[rowNumber, 9].Value = "Aug";
            ws.Cells[rowNumber, 10].Value = "Sep";
            ws.Cells[rowNumber, 11].Value = "Oct";
            ws.Cells[rowNumber, 12].Value = "Nov";
            ws.Cells[rowNumber, 13].Value = "Dec";
            ws.Cells[rowNumber, 14].Value = "Tot/Avg";

            ExcelRange range = ws.Cells[rowNumber, 2, rowNumber, 14];
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Bold = true;
            return ++rowNumber;
        }

        internal static int AddGridRow(ExcelWorksheet ws, OccupancyRecord record, string description, int rowNumber, string rowFormat = null)
        {
            if (record != null)
            {
                ws.Cells[rowNumber, 1].Value = description;
                ws.Cells[rowNumber, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                ws.Cells[rowNumber, 2].Value = record.JanuaryValue;
                ws.Cells[rowNumber, 3].Value = record.FebruaryValue;
                ws.Cells[rowNumber, 4].Value = record.MarchValue;
                ws.Cells[rowNumber, 5].Value = record.AprilValue;
                ws.Cells[rowNumber, 6].Value = record.MayValue;
                ws.Cells[rowNumber, 7].Value = record.JuneValue;
                ws.Cells[rowNumber, 8].Value = record.JulyValue;
                ws.Cells[rowNumber, 9].Value = record.AugustValue;
                ws.Cells[rowNumber, 10].Value = record.SeptemberValue;
                ws.Cells[rowNumber, 11].Value = record.OctoberValue;
                ws.Cells[rowNumber, 12].Value = record.NovemberValue;
                ws.Cells[rowNumber, 13].Value = record.DecemberValue;
                ws.Cells[rowNumber, 14].Value = record.TotalOrAverageValue;
                
                ws.Cells[rowNumber, 2, rowNumber, 14].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                if (rowFormat != null)
                {
                    ws.Cells[rowNumber, 2, rowNumber, 14].Style.Numberformat.Format = rowFormat;
                }

                return ++rowNumber;
            }
            return rowNumber;
        }
    }
}

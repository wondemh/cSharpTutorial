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

        public const string ActualSectionColor = "#FF8633";
        public const string BudgetSectionColor = "#3FC3E1";

        internal LocationCode Location { get; set; }
        internal DateTime ReportDate { get; set; }

        internal static int BuildPageHeader(ExcelWorksheet ws, string locationName, DateTime reportDate, int rowNumber)
        {
            int initialRowNumber = rowNumber;
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 15];
            range.Merge = true;
            range.Value = locationName.ToUpper(CultureInfo.CurrentCulture);

            rowNumber++;
            range = ws.Cells[rowNumber, 1, rowNumber, 15];
            range.Merge = true;
            range.Value = "OCCUPANCY STATISTICS";

            rowNumber++;
            range = ws.Cells[rowNumber, 1, rowNumber, 15];
            range.Merge = true;
            range.Value = "AS OF " + reportDate.ToString("MM/dd/yyyy", CultureInfo.CurrentCulture); ;

            range = ws.Cells[initialRowNumber, 1, rowNumber, 15];
            range.Style.Font.Size = 15;
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            return rowNumber + 3;
        }

        internal static int BuildSectionHeader(ExcelWorksheet ws, string headerText, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 15];
            range.Merge = true;
            range.Value = headerText;
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            range.Style.Font.UnderLine = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            return ++rowNumber;
        }

        internal static void BuildSectionSideBar(ExcelWorksheet ws, string sidebarText, int startRowNumber, int endRowNumber, string hexColor)
        {
            ExcelRange range = ws.Cells[startRowNumber, 1, endRowNumber, 1];
            range.Merge = true;
            range.Value = sidebarText;
            range.Style.Font.Size = 12;
            range.Style.TextRotation = 90;
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            System.Drawing.Color colorFromHex = System.Drawing.ColorTranslator.FromHtml(hexColor);
            range.Style.Fill.BackgroundColor.SetColor(colorFromHex);
        }

        internal static int BuildColumnHeaders(ExcelWorksheet ws, int rowNumber)
        {
            ws.Cells[rowNumber, 3].Value = "Jan";
            ws.Cells[rowNumber, 4].Value = "Feb";
            ws.Cells[rowNumber, 5].Value = "Mar";
            ws.Cells[rowNumber, 6].Value = "Apr";
            ws.Cells[rowNumber, 7].Value = "May";
            ws.Cells[rowNumber, 8].Value = "Jun";
            ws.Cells[rowNumber, 9].Value = "Jul";
            ws.Cells[rowNumber, 10].Value = "Aug";
            ws.Cells[rowNumber, 11].Value = "Sep";
            ws.Cells[rowNumber, 12].Value = "Oct";
            ws.Cells[rowNumber, 13].Value = "Nov";
            ws.Cells[rowNumber, 14].Value = "Dec";
            ws.Cells[rowNumber, 15].Value = "Tot/Avg";

            ExcelRange range = ws.Cells[rowNumber, 3, rowNumber, 15];
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Font.Bold = true;
            return ++rowNumber;
        }

        internal static int BuildGridRow(ExcelWorksheet ws, OccupancyRecord record, string description, int rowNumber, string rowFormat = null)
        {
            if (record != null)
            {
                ws.Cells[rowNumber, 2].Value = description;
                ws.Cells[rowNumber, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                //.Value.ToString() : "";
                //ws.Cells[rowNumber, 5].Value = record.March.HasValue ? record.March.Value : (float?)null;
                ws.Cells[rowNumber, 3].Value = record.January;
                ws.Cells[rowNumber, 4].Value = record.February;
                ws.Cells[rowNumber, 5].Value = record.March;
                ws.Cells[rowNumber, 6].Value = record.April;
                ws.Cells[rowNumber, 7].Value = record.May;
                ws.Cells[rowNumber, 8].Value = record.June;
                ws.Cells[rowNumber, 9].Value = record.July;
                ws.Cells[rowNumber, 10].Value = record.August;
                ws.Cells[rowNumber, 11].Value = record.September;
                ws.Cells[rowNumber, 12].Value = record.October;
                ws.Cells[rowNumber, 13].Value = record.November;
                ws.Cells[rowNumber, 14].Value = record.December;

                ws.Cells[rowNumber, 15].Value = record.TotalOrAverage;

                ws.Cells[rowNumber, 3, rowNumber, 15].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                if (rowFormat != null)
                {
                    ws.Cells[rowNumber, 3, rowNumber, 15].Style.Numberformat.Format = rowFormat;
                }
                ws.Cells[rowNumber, 2, rowNumber, 15].Style.Font.Size = 10;

                return ++rowNumber;
            }
            return rowNumber;
        }

        internal static void DrawRowBottomBorder(ExcelWorksheet ws, int rowNumber)
        {
            ws.Cells[rowNumber, 1, rowNumber, 15].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
        }
    }
}

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
    public static class GrandTotalsSectionBuilder
    {

        public static int AddGrandTotalsSection(ExcelWorksheet ws, List<CensusItem> list, int vacantUnitsCount, int allUnitsCount, int rowNumber, DateTime startDate, DateTime? endDate = null)
        {
            Contract.Requires(ws != null);

            if (list == null || list.Count == 0)
            {
                return rowNumber;
            }

            int admittedCount = list.Where(c => c.Status.Equals("Admitted", StringComparison.OrdinalIgnoreCase)).Count();
            int holdCount = list.Where(c => c.Status.Equals("On Hold", StringComparison.OrdinalIgnoreCase)).Count();
            int leaveCount = list.Where(c => c.Status.Equals("On Leave", StringComparison.OrdinalIgnoreCase)).Count();
            int dischargedCount = list.Where(c => c.Status.Equals("Discharged", StringComparison.OrdinalIgnoreCase)).Count();
            int expiredCount = list.Where(c => c.Status.Equals("Expired", StringComparison.OrdinalIgnoreCase)).Count();
            int totalOccupied = admittedCount + holdCount + leaveCount;
            string totalOccupiedPercent = (((float)totalOccupied / (float)allUnitsCount) * 100).ToString("0.00", CultureInfo.CurrentCulture);
            bool sectionIsForDateRange = endDate.HasValue;

            Console.WriteLine($"totalOccupied: {totalOccupied},  allUnitsCount : {allUnitsCount}, occupiedPercent: {totalOccupiedPercent}");

            int initialRowNumber = rowNumber;

            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Grand Total for : " + startDate.ToString("MM/dd/yyyy", CultureInfo.CurrentCulture) + (endDate.HasValue ? (" thru " + endDate.Value.ToString("MM/dd/yyyy", CultureInfo.CurrentCulture)) : "");
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Total Admitted:";
            ws.Cells[rowNumber, 2].Value = admittedCount;
            ws.Cells[rowNumber, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[rowNumber, 3].Value = "Total Discharged Billable:";
            ws.Cells[rowNumber, 4].Value = dischargedCount;
            ws.Cells[rowNumber, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[rowNumber, 5].Value = "Total Discharged Non Billable:";
            ws.Cells[rowNumber, 6].Value = dischargedCount;
            ws.Cells[rowNumber, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[rowNumber, 7].Value = "Total Non Billable:";
            ws.Cells[rowNumber, 8].Value = "0";
            ws.Cells[rowNumber, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Total Hold:";
            ws.Cells[rowNumber, 2].Value = holdCount;
            ws.Cells[rowNumber, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[rowNumber, 3].Value = "Total Expired Billable:";
            ws.Cells[rowNumber, 4].Value = expiredCount;
            ws.Cells[rowNumber, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[rowNumber, 5].Value = "Total Expired Non Billable:";
            ws.Cells[rowNumber, 6].Value = expiredCount;
            ws.Cells[rowNumber, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[rowNumber, 7].Value = "Total Leave:";
            ws.Cells[rowNumber, 8].Value = leaveCount;
            ws.Cells[rowNumber, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Total Vacant:";
            ws.Cells[rowNumber, 2].Value = vacantUnitsCount;
            ws.Cells[rowNumber, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            ws.Cells[rowNumber, 3].Value = "Total Percent Occupancy:";
            ws.Cells[rowNumber, 4].Value = totalOccupiedPercent;
            ws.Cells[rowNumber, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            if (sectionIsForDateRange)
            {
                ws.Cells[rowNumber, 5].Value = "Total # of Units Occupied:";
                ws.Cells[rowNumber, 6].Value = totalOccupied;
                ws.Cells[rowNumber, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                ws.Cells[rowNumber, 7].Value = "Total Units:";
                ws.Cells[rowNumber, 8].Value = allUnitsCount;
                ws.Cells[rowNumber, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
            }
            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Total # of Residents:";
            ws.Cells[rowNumber, 2].Value = list.Count;
            ws.Cells[rowNumber, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

            range = ws.Cells[rowNumber, 3, rowNumber, 14];
            range.Merge = true;
            range.Value = "Note: Residents with multiple open admissions or multiple units are counted as 1.";
            ws.Cells[rowNumber, 1, rowNumber, 14].Style.Font.Bold = true;

            if (sectionIsForDateRange)
            {
                rowNumber++;
                range = ws.Cells[rowNumber, 3, rowNumber, 14];
                range.Merge = true;
                range.Value = "Recreated Admissions on the same day with the same Fac, Unit#, and LOC + Payor Type are not detailed.";
                ws.Cells[rowNumber, 1, rowNumber, 14].Style.Font.Bold = true;
                ws.Cells[rowNumber, 1, rowNumber, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
            }

            rowNumber++;
            range = ws.Cells[rowNumber, 3, rowNumber, 14];
            range.Merge = true;
            range.Value = "Total Units = Total Vacant + Total # Units Occupied";
            ws.Cells[rowNumber, 1, rowNumber, 14].Style.Font.Bold = true;
            ws.Cells[rowNumber, 1, rowNumber, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            //Clear all borders for this section
            ws.Cells[initialRowNumber, 1, rowNumber, 14].Style.Border.BorderAround(ExcelBorderStyle.None);

            //Finally, set bottom border
            ws.Cells[rowNumber, 1, rowNumber, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            return ++rowNumber;
        }

    }
}

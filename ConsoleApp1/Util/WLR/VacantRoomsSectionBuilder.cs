using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;

using ConsoleApp1.Model;

namespace ConsoleApp1
{
    public class VacantRoomsSectionBuilder
    {
        public static int AddVacantRoomsSection(ExcelWorksheet ws, List<Unit> units, DateTime date, int rowNumber)
        {
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Vacant Rooms for : " + date.ToString("MM/dd/yyyy");
            range.Style.Font.Size = 13;
            range.Style.Font.Bold = true;
            range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            rowNumber++;
            ws.Cells[rowNumber, 1].Value = "Unit Number";
            ws.Cells[rowNumber, 2].Value = "Unit Type";
            ws.Cells[rowNumber, 3].Value = "Location";
            ws.Cells[rowNumber, 4].Value = "Medicare Certified";
            ws.Cells[rowNumber, 5].Value = "Reserved";
            ws.Cells[rowNumber, 1, rowNumber, 5].Style.Font.Bold = true;

            foreach (Unit unit in units)
            {
                rowNumber++;
                ws.Cells[rowNumber, 1].Value = unit.UnitNumber;
                ws.Cells[rowNumber, 2].Value = unit.UnitType;
                ws.Cells[rowNumber, 3].Value = unit.Building;
                ws.Cells[rowNumber, 4].Value = "";
                ws.Cells[rowNumber, 5].Value = unit.AvailabilityStart != null && unit.AvailabilityStart > date ? "Yes" : "No";
            }

            rowNumber++;
            range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Total Vacant Rooms: " + units.Count;
            range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
            range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

            return ++rowNumber;
        }
    }
}

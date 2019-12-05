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
    public class WLRCensusReportService
    {
        public void buildWorksheet(int locationId, DateTime startDate, DateTime endDate, string facilityTypeCode)
        {
            WLRCensusDAO reportDAO = new WLRCensusDAO();
            Location location = reportDAO.GetLocation(locationId);
            Console.WriteLine($"Location is {location}");

            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("Census Report - WLR");
                int rowNumber = addPageHeaderSection(ws, location, startDate, endDate, facilityTypeCode);
                rowNumber = addColumnHeaders(ws, rowNumber);
                

                List<WLRCensusRecord> listForDateRange = reportDAO.GetWLRCensusRecords(4, startDate, endDate, facilityTypeCode);
                Console.WriteLine($"Found {listForDateRange.Count} records");

                var recordsByPayorType = listForDateRange.GroupBy(record => record.getPayorTypeCodeAndDescription());
                foreach (var group in recordsByPayorType)
                {
                    rowNumber = addPayorTypeHeader(ws, group.Key, rowNumber);

                    var recordsByAdmissionStatus = group.GroupBy(item => item.AdmissionStatus);
                    foreach (var group2 in recordsByAdmissionStatus)
                    {
                        string admissionStatusDescription = null;
                        foreach (WLRCensusRecord record in group2)
                        {
                            rowNumber = addGridRow(ws, record, rowNumber);
                            if(admissionStatusDescription == null)
                            {
                                admissionStatusDescription = record.AdmissionStatusDescription;
                            }
                        }
                        rowNumber = addSubTotalRow(ws, group2.Key, admissionStatusDescription, group2.Count(), rowNumber);
                    }
                }
                List<Unit> vacantUnits = reportDAO.GetVacantUnits(startDate);
                int countOfAllUnits = reportDAO.GetCountOfAllUnits();
                rowNumber = addCensusStatusTotalsRow(ws, listForDateRange.Count, rowNumber);
                if(startDate.Date != endDate.Date)
                {
                    List<WLRCensusRecord> listForSingleDate = reportDAO.GetWLRCensusRecords(4, startDate, startDate, facilityTypeCode);
                    rowNumber = addGrandTotalsSection(ws, listForSingleDate, vacantUnits.Count, countOfAllUnits, rowNumber, startDate);
                }
                else
                {
                    rowNumber = addGrandTotalsSection(ws, listForDateRange, vacantUnits.Count, countOfAllUnits, rowNumber, startDate);
                }
                rowNumber = addGrandTotalsSection(ws, listForDateRange, vacantUnits.Count, countOfAllUnits, rowNumber, startDate, endDate);
                rowNumber = addVacantRoomsSection(ws, vacantUnits, startDate, rowNumber);

                ws.Cells["A:N"].AutoFitColumns();
                p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\Census Report - WLR - " + facilityTypeCode + ".xlsx"));
            }
        }

        private int addPageHeaderSection(ExcelWorksheet ws, Location location, DateTime startDate, DateTime endDate, string facilityTypeCode)
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
            range.Value = "Roster for " + facilityTypeCode + " " + startDate.ToString("MM/dd/yyyy") + " thru " + endDate.ToString("MM/dd/yyyy") + " Sequence - By Payor Type + Census Status - All";
            ws.View.FreezePanes(5, 15);
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

        private int addCensusStatusTotalsRow(ExcelWorksheet ws, int numberOfRecords, int rowNumber)
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

        private int addGrandTotalsSection(ExcelWorksheet ws, List<WLRCensusRecord> list, int vacantUnitsCount, int allUnitsCount, int rowNumber, DateTime startDate, DateTime? endDate = null)
        {
            int admittedCount = list.Where(c => c.Status.Equals("Admitted")).Count();
            int holdCount = list.Where(c => c.Status.Equals("On Hold")).Count();
            int leaveCount = list.Where(c => c.Status.Equals("On Leave")).Count();
            int dischargedCount = list.Where(c => c.Status.Equals("Discharged")).Count();
            int expiredCount = list.Where(c => c.Status.Equals("Expired")).Count();
            int totalOccupied = admittedCount + holdCount + leaveCount;
            string totalOccupiedPercent = (((float)totalOccupied / (float)allUnitsCount) * 100).ToString("0.00");
            bool sectionIsForDateRange = endDate.HasValue;

            Console.WriteLine($"totalOccupied: {totalOccupied},  allUnitsCount : {allUnitsCount}, occupiedPercent: {totalOccupiedPercent}");

            int initialRowNumber = rowNumber;
            
            ExcelRange range = ws.Cells[rowNumber, 1, rowNumber, 14];
            range.Merge = true;
            range.Value = "Grand Total for : " + startDate.ToString("MM/dd/yyyy") + (endDate.HasValue ? (" thru " + endDate.Value.ToString("MM/dd/yyyy")) : "");
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

            if(sectionIsForDateRange)
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

        private int addVacantRoomsSection(ExcelWorksheet ws, List<Unit> units, DateTime date, int rowNumber)
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

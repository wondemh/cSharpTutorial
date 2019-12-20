using OfficeOpenXml;
using ReportApp.DAO;
using ReportApp.Model;
using ReportApp.Model.Occupancy;
using System;
using System.Collections.Generic;
using System.IO;

namespace ReportApp
{
    public static class OccupancyReportService
    {
        

        public static void BuildReport(LocationCodes locationId, DateTime reportDate)
        {
            Dictionary<LocationCodes, string> reportSections = new Dictionary<LocationCodes, string>
            {
                {LocationCodes.IRC, "IL.A,IL.B,AL.A,AL.B,MS.A,MS.B,HC.A,HC.B" },
                {LocationCodes.IKF, "IL.A,IL.B,AL.A,AL.B,MS.A,MS.B,HC.A,HC.B" },
                {LocationCodes.WLR, "IL.A,AP,CO,IL.B,AL.A,AL.B,HC.A,HC.B" }
            };

            Dictionary<string, string> sectionBuilders = new Dictionary<string, string>
            {
                //WLR Independent Living Section Builders
                {"WLR:IL.A", "ReportApp.IndependentLivingSectionBuilder" },
                {"WLR:AP.A", "ReportApp.IndependentLivingSectionBuilder" },
                {"WLR:CO.A", "ReportApp.IndependentLivingSectionBuilder" },
                {"WLR:IL.B", "ReportApp.IndependentLivingSectionBuilder" },

                //WLR Assisted Living Section Builders
                {"WLR:AL.A", "ReportApp.WLRAssistedLivingSectionBuilder" },
                {"WLR:AL.B", "ReportApp.WLRAssistedLivingSectionBuilder" },

                 //WLR Skilled Nurse Section Builders
                 {"WLR:HC.A", "ReportApp.WLRSkilledNurseSectionBuilder" },
                 {"WLR:HC.B", "ReportApp.WLRSkilledNurseSectionBuilder" },

                //IKF Independent Living Section Builders
                {"IKF:IL.A", "ReportApp.IndependentLivingSectionBuilder" },
                {"IKF:IL.B", "ReportApp.IndependentLivingSectionBuilder" },
                
                //IKF Assisted Living Section Builders
                {"IKF:AL.A", "ReportApp.IKFAssistedLivingSectionBuilder" },
                {"IKF:AL.B", "ReportApp.IKFAssistedLivingSectionBuilder" },

                //IKF Memory Support Section Builders
                {"IKF:MS.A", "ReportApp.IKFMemorySupportSectionBuilder" },
                {"IKF:MS.B", "ReportApp.IKFMemorySupportSectionBuilder" },

                //IKF Skilled Nurse Section Builders
                {"IKF:HC.A", "ReportApp.IKFSkilledNurseSectionBuilder" },
                {"IKF:HC.B", "ReportApp.IKFSkilledNurseSectionBuilder" },
                
                //IRC Independent Living Section Builders
                {"IRC:IL.A", "ReportApp.IndependentLivingSectionBuilder" },
                {"IRC:IL.B", "ReportApp.IndependentLivingSectionBuilder" },

                //IRC Assisted Living Section Builders
                {"IRC:AL.A", "ReportApp.IRCAssistedLivingSectionBuilder" },
                {"IRC:AL.B", "ReportApp.IRCAssistedLivingSectionBuilder" },

                //IRC Memory Support Section Builders
                {"IRC:MS.A", "ReportApp.IRCMemorySupportSectionBuilder" },
                {"IRC:MS.B", "ReportApp.IRCMemorySupportSectionBuilder" },

                //IRC Skilled Nurse Section Builders
                {"IRC:HC.A", "ReportApp.IKFSkilledNurseSectionBuilder" },
                {"IRC:HC.B", "ReportApp.IKFSkilledNurseSectionBuilder" }
            };

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();

            using var p = new ExcelPackage();
            var ws = p.Workbook.Worksheets.Add("Occupancy Report");

            Location location = OccupancyReportDAO.GetLocation(locationId);

            int rowNumber = 1;
            rowNumber = OccupancySectionBuilder.BuildPageHeader(ws, location.Name, reportDate, rowNumber);
            string[] sections = reportSections[locationId].Split(new char[] { ',' });
            foreach(string section in sections)
            {
                string sectionKey = string.Format("{0}:{1}", locationId.ToString(), section);
                OccupancySectionBuilder sectionBuilder = (OccupancySectionBuilder) assembly.CreateInstance(sectionKey);
                if(sectionKey.EndsWith(".A"))
                {
                    rowNumber = sectionBuilder.buildSectionHeader();
                    rowNumber = sectionBuilder.buildActualSection();
                }
                else if(sectionKey.EndsWith(".B"))
                {
                    rowNumber = sectionBuilder.buildBudgetSection();
                }
                else
                {
                    rowNumber = sectionBuilder.buildActualSection();
                }

                switch (section)
                {
                    case "IL.A":
                        //Insert Actual IL section
                        switch(locationId)
                        {
                            case LocationCodes.IRC:
                                break;

                        }
                        break;
                    case "AP.A":
                        //This is only going to happen for WLR
                        break;

                }
            }
            //foreach (var facilityType in facilityTypes)
            //{
            //    //If IL, AP, CO, PS,  add Assisted Living section
            //    if (independentLivingFacilityTypeCodes.IndexOf(facilityType.FacilType) >= 0 && !addedIndependentLivingSection)
            //    {
            //        rowNumber = IndependentLivingSectionBuilder.AddIndependentLivingSection(ws, locationId, reportDate, rowNumber);
            //        addedIndependentLivingSection = true;
            //    }

            //    //If AL, add Assisted Living section
            //    if (facilityType.FacilType.Equals("AL", StringComparison.Ordinal) && !addedAssistedLivingSection)
            //    {
            //        rowNumber = AssistedLivingSectionBuilder.AddAssistedLivingSection(ws, locationId, reportDate, ++rowNumber);
            //        addedAssistedLivingSection = true;
            //    }

            //    //If MS, add Memory Support section
            //    if (facilityType.FacilType.Equals("MS", StringComparison.Ordinal) && !addedMemorySupportSection)
            //    {
            //        rowNumber = MemorySupportSectionBuilder.AddMemorySupportSection(ws, locationId, reportDate, ++rowNumber);
            //        addedMemorySupportSection = true;
            //    }

            //    //If MS, add Skilled Nurse section
            //    if (facilityType.FacilType.Equals("HC", StringComparison.Ordinal) && !addedSkilledNurseSection)
            //    {
            //        rowNumber = SkilledNurseSectionBuilder.AddSkilledNurseSection(ws, locationId, reportDate, ++rowNumber);
            //        addedSkilledNurseSection = true;
            //    }
            //}

            ws.PrinterSettings.PaperSize = ePaperSize.A4;
            ws.PrinterSettings.Orientation = eOrientation.Portrait;
            ws.PrinterSettings.HorizontalCentered = true;
            ws.PrinterSettings.LeftMargin = new decimal(0.5);
            ws.PrinterSettings.Scale = 200;
            ws.PrinterSettings.FitToPage = true;
            ws.PrinterSettings.FitToWidth = 1;
            ws.PrinterSettings.FitToHeight = 0;

            //Repeat title row on every page
            //ws.PrinterSettings.RepeatRows = new ExcelAddress("1:1");

            ws.Cells["A:N"].AutoFitColumns();
            p.SaveAs(new FileInfo(@"C:\Users\wondemh\source\repos\cSharpTutorial\OccupancyReport.xlsx"));
        }
        
    }
}

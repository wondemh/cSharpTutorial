using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCSkilledNurseActual
    {
        public OccupancyRecord BedsAvailable { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord FFSDirectAdmit { get; set; }
        public OccupancyRecord AverageMemoryCare { get; set; }
        public OccupancyRecord AverageMedicare { get; set; }
        public OccupancyRecord AverageMedicaid { get; set; }

        public OccupancyRecord TotalAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AverageLCFirst.January + AverageLCSecond.January + FFSDirectAdmit.January + AverageMemoryCare.January + AverageMedicare.January + AverageMedicaid.January,
                    February = AverageLCFirst.February + AverageLCSecond.February + FFSDirectAdmit.February + AverageMemoryCare.February + AverageMedicare.February + AverageMedicaid.February,
                    March = AverageLCFirst.March + AverageLCSecond.March + FFSDirectAdmit.March + AverageMemoryCare.March + AverageMedicare.March + AverageMedicaid.March,
                    April = AverageLCFirst.April + AverageLCSecond.April + FFSDirectAdmit.April + AverageMemoryCare.April + AverageMedicare.April + AverageMedicaid.April,
                    May = AverageLCFirst.May + AverageLCSecond.May + FFSDirectAdmit.May + AverageMemoryCare.May + AverageMedicare.May + AverageMedicaid.May,
                    June = AverageLCFirst.June + AverageLCSecond.June + FFSDirectAdmit.June + AverageMemoryCare.June + AverageMedicare.June + AverageMedicaid.June,
                    July = AverageLCFirst.July + AverageLCSecond.July + FFSDirectAdmit.July + AverageMemoryCare.July + AverageMedicare.July + AverageMedicaid.July,
                    August = AverageLCFirst.August + AverageLCSecond.August + FFSDirectAdmit.August + AverageMemoryCare.August + AverageMedicare.August + AverageMedicaid.August,
                    September = AverageLCFirst.September + AverageLCSecond.September + FFSDirectAdmit.September + AverageMemoryCare.September + AverageMedicare.September + AverageMedicaid.September,
                    October = AverageLCFirst.October + AverageLCSecond.October + FFSDirectAdmit.October + AverageMemoryCare.October + AverageMedicare.October + AverageMedicaid.October,
                    November = AverageLCFirst.November + AverageLCSecond.November + FFSDirectAdmit.November + AverageMemoryCare.November + AverageMedicare.November + AverageMedicaid.November,
                    December = AverageLCFirst.December + AverageLCSecond.December + FFSDirectAdmit.December + AverageMemoryCare.December + AverageMedicare.December + AverageMedicaid.December
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        public OccupancyRecord PercentOccupancy
        {
            get
            {

                return new OccupancyRecord
                {
                    January = BedsAvailable.January > 0 ? (float)Math.Round(TotalAverageOccupancy.January / BedsAvailable.January, 0) : 0,
                    February = BedsAvailable.February > 0 ? (float)Math.Round(TotalAverageOccupancy.February / BedsAvailable.February, 0) : 0,
                    March = BedsAvailable.March > 0 ? (float)Math.Round(TotalAverageOccupancy.March / BedsAvailable.March, 0) : 0,
                    April = BedsAvailable.April > 0 ? (float)Math.Round(TotalAverageOccupancy.April / BedsAvailable.April, 0) : 0,
                    May = BedsAvailable.May > 0 ? (float)Math.Round(TotalAverageOccupancy.May / BedsAvailable.May, 0) : 0,
                    June = BedsAvailable.June > 0 ? (float)Math.Round(TotalAverageOccupancy.June / BedsAvailable.June, 0) : 0,
                    July = BedsAvailable.July > 0 ? (float)Math.Round(TotalAverageOccupancy.July / BedsAvailable.July, 0) : 0,
                    August = BedsAvailable.August > 0 ? (float)Math.Round(TotalAverageOccupancy.August / BedsAvailable.August, 0) : 0,
                    September = BedsAvailable.September > 0 ? (float)Math.Round(TotalAverageOccupancy.September / BedsAvailable.September, 0) : 0,
                    October = BedsAvailable.October > 0 ? (float)Math.Round(TotalAverageOccupancy.October / BedsAvailable.October, 0) : 0,
                    November = BedsAvailable.November > 0 ? (float)Math.Round(TotalAverageOccupancy.November / BedsAvailable.November, 0) : 0,
                    December = BedsAvailable.December > 0 ? (float)Math.Round(TotalAverageOccupancy.December / BedsAvailable.December, 0) : 0,
                    TotalOrAverage = BedsAvailable.TotalOrAverage > 0 ? (float)Math.Round(TotalAverageOccupancy.TotalOrAverage / BedsAvailable.TotalOrAverage, 0) : 0
                };
            }
        }

    }
}

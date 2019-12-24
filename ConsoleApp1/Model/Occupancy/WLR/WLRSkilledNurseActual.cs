using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRSkilledNurseActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _totalAverageOccupancy;
        private OccupancyRecord _percentOccupancy;

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
                if (_totalAverageOccupancy == null)
                {
                    _totalAverageOccupancy = new OccupancyRecord
                    {
                        January = ZeroIfNull(AverageLCFirst.January) + ZeroIfNull(AverageLCSecond.January) + ZeroIfNull(FFSDirectAdmit.January) + ZeroIfNull(AverageMemoryCare.January) + ZeroIfNull(AverageMedicare.January) + ZeroIfNull(AverageMedicaid.January),
                        February = ZeroIfNull(AverageLCFirst.February) + ZeroIfNull(AverageLCSecond.February) + ZeroIfNull(FFSDirectAdmit.February) + ZeroIfNull(AverageMemoryCare.February) + ZeroIfNull(AverageMedicare.February) + ZeroIfNull(AverageMedicaid.February),
                        March = ZeroIfNull(AverageLCFirst.March) + ZeroIfNull(AverageLCSecond.March) + ZeroIfNull(FFSDirectAdmit.March) + ZeroIfNull(AverageMemoryCare.March) + ZeroIfNull(AverageMedicare.March) + ZeroIfNull(AverageMedicaid.March),
                        April = ZeroIfNull(AverageLCFirst.April) + ZeroIfNull(AverageLCSecond.April) + ZeroIfNull(FFSDirectAdmit.April) + ZeroIfNull(AverageMemoryCare.April) + ZeroIfNull(AverageMedicare.April) + ZeroIfNull(AverageMedicaid.April),
                        May = ZeroIfNull(AverageLCFirst.May) + ZeroIfNull(AverageLCSecond.May) + ZeroIfNull(FFSDirectAdmit.May) + ZeroIfNull(AverageMemoryCare.May) + ZeroIfNull(AverageMedicare.May) + ZeroIfNull(AverageMedicaid.May),
                        June = ZeroIfNull(AverageLCFirst.June) + ZeroIfNull(AverageLCSecond.June) + ZeroIfNull(FFSDirectAdmit.June) + ZeroIfNull(AverageMemoryCare.June) + ZeroIfNull(AverageMedicare.June) + ZeroIfNull(AverageMedicaid.June),
                        July = ZeroIfNull(AverageLCFirst.July) + ZeroIfNull(AverageLCSecond.July) + ZeroIfNull(FFSDirectAdmit.July) + ZeroIfNull(AverageMemoryCare.July) + ZeroIfNull(AverageMedicare.July) + ZeroIfNull(AverageMedicaid.July),
                        August = ZeroIfNull(AverageLCFirst.August) + ZeroIfNull(AverageLCSecond.August) + ZeroIfNull(FFSDirectAdmit.August) + ZeroIfNull(AverageMemoryCare.August) + ZeroIfNull(AverageMedicare.August) + ZeroIfNull(AverageMedicaid.August),
                        September = ZeroIfNull(AverageLCFirst.September) + ZeroIfNull(AverageLCSecond.September) + ZeroIfNull(FFSDirectAdmit.September) + ZeroIfNull(AverageMemoryCare.September) + ZeroIfNull(AverageMedicare.September) + ZeroIfNull(AverageMedicaid.September),
                        October = ZeroIfNull(AverageLCFirst.October) + ZeroIfNull(AverageLCSecond.October) + ZeroIfNull(FFSDirectAdmit.October) + ZeroIfNull(AverageMemoryCare.October) + ZeroIfNull(AverageMedicare.October) + ZeroIfNull(AverageMedicaid.October),
                        November = ZeroIfNull(AverageLCFirst.November) + ZeroIfNull(AverageLCSecond.November) + ZeroIfNull(FFSDirectAdmit.November) + ZeroIfNull(AverageMemoryCare.November) + ZeroIfNull(AverageMedicare.November) + ZeroIfNull(AverageMedicaid.November),
                        December = ZeroIfNull(AverageLCFirst.December) + ZeroIfNull(AverageLCSecond.December) + ZeroIfNull(FFSDirectAdmit.December) + ZeroIfNull(AverageMemoryCare.December) + ZeroIfNull(AverageMedicare.December) + ZeroIfNull(AverageMedicaid.December)
                    };
                    _totalAverageOccupancy.TotalOrAverage = _totalAverageOccupancy.CalculateAverageValue();
                }
                return _totalAverageOccupancy;
            }
        }

        public OccupancyRecord PercentOccupancy
        {
            get
            {
                if (_percentOccupancy == null)
                {
                    _percentOccupancy = new OccupancyRecord
                    {
                        January = TotalAverageOccupancy.January.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.January, BedsAvailable.January), 0) : (float?)null,
                        February = TotalAverageOccupancy.February.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.February, BedsAvailable.February), 0) : (float?)null,
                        March = TotalAverageOccupancy.March.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.March, BedsAvailable.March), 0) : (float?)null,
                        April = TotalAverageOccupancy.April.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.April, BedsAvailable.April), 0) : (float?)null,
                        May = TotalAverageOccupancy.May.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.May, BedsAvailable.May), 0) : (float?)null,
                        June = TotalAverageOccupancy.June.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.June, BedsAvailable.June), 0) : (float?)null,
                        July = TotalAverageOccupancy.July.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.July, BedsAvailable.July), 0) : (float?)null,
                        August = TotalAverageOccupancy.August.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.August, BedsAvailable.August), 0) : (float?)null,
                        September = TotalAverageOccupancy.September.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.September, BedsAvailable.September), 0) : (float?)null,
                        October = TotalAverageOccupancy.October.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.October, BedsAvailable.October), 0) : (float?)null,
                        November = TotalAverageOccupancy.November.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.November, BedsAvailable.November), 0) : (float?)null,
                        December = TotalAverageOccupancy.December.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.December, BedsAvailable.December), 0) : (float?)null,
                        TotalOrAverage = TotalAverageOccupancy.December.HasValue ? (float)Math.Round(Divide(TotalAverageOccupancy.December, BedsAvailable.December), 0) : (float?)null
                    };
                }
                return _percentOccupancy;
            }
        }

    }
}

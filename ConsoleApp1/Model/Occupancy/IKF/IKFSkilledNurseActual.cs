using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFSkilledNurseActual : OccupancyRecordsContainer
    {
        private OccupancyRecord _totalAverageOccupancy;
        private OccupancyRecord _percentOccupancy;

        public OccupancyRecord BedsAvailable { get; set; }
        public OccupancyRecord AveragePrivatePay { get; set; }
        public OccupancyRecord AveragePrivateMedicaidPending { get; set; }
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
                        January = ZeroIfNull(AveragePrivatePay.January) + ZeroIfNull(AveragePrivateMedicaidPending.January) + ZeroIfNull(AverageMedicare.January) + ZeroIfNull(AverageMedicaid.January),
                        February = ZeroIfNull(AveragePrivatePay.February) + ZeroIfNull(AveragePrivateMedicaidPending.February) + ZeroIfNull(AverageMedicare.February) + ZeroIfNull(AverageMedicaid.February),
                        March = ZeroIfNull(AveragePrivatePay.March) + ZeroIfNull(AveragePrivateMedicaidPending.March) + ZeroIfNull(AverageMedicare.March) + ZeroIfNull(AverageMedicaid.March),
                        April = ZeroIfNull(AveragePrivatePay.April) + ZeroIfNull(AveragePrivateMedicaidPending.April) + ZeroIfNull(AverageMedicare.April) + ZeroIfNull(AverageMedicaid.April),
                        May = ZeroIfNull(AveragePrivatePay.May) + ZeroIfNull(AveragePrivateMedicaidPending.May) + ZeroIfNull(AverageMedicare.May) + ZeroIfNull(AverageMedicaid.May),
                        June = ZeroIfNull(AveragePrivatePay.June) + ZeroIfNull(AveragePrivateMedicaidPending.June) + ZeroIfNull(AverageMedicare.June) + ZeroIfNull(AverageMedicaid.June),
                        July = ZeroIfNull(AveragePrivatePay.July) + ZeroIfNull(AveragePrivateMedicaidPending.July) + ZeroIfNull(AverageMedicare.July) + ZeroIfNull(AverageMedicaid.July),
                        August = ZeroIfNull(AveragePrivatePay.August) + ZeroIfNull(AveragePrivateMedicaidPending.August) + ZeroIfNull(AverageMedicare.August) + ZeroIfNull(AverageMedicaid.August),
                        September = ZeroIfNull(AveragePrivatePay.September) + ZeroIfNull(AveragePrivateMedicaidPending.September) + ZeroIfNull(AverageMedicare.September) + ZeroIfNull(AverageMedicaid.September),
                        October = ZeroIfNull(AveragePrivatePay.October) + ZeroIfNull(AveragePrivateMedicaidPending.October) + ZeroIfNull(AverageMedicare.October) + ZeroIfNull(AverageMedicaid.October),
                        November = ZeroIfNull(AveragePrivatePay.November) + ZeroIfNull(AveragePrivateMedicaidPending.November) + ZeroIfNull(AverageMedicare.November) + ZeroIfNull(AverageMedicaid.November),
                        December = ZeroIfNull(AveragePrivatePay.December) + ZeroIfNull(AveragePrivateMedicaidPending.December) + ZeroIfNull(AverageMedicare.December) + ZeroIfNull(AverageMedicaid.December)
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
                        January = TotalAverageOccupancy.January.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.January, BedsAvailable.January), 1) : (float?)null,
                        February = TotalAverageOccupancy.February.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.February, BedsAvailable.February), 1) : (float?)null,
                        March = TotalAverageOccupancy.March.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.March, BedsAvailable.March), 1) : (float?)null,
                        April = TotalAverageOccupancy.April.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.April, BedsAvailable.April), 1) : (float?)null,
                        May = TotalAverageOccupancy.May.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.May, BedsAvailable.May), 1) : (float?)null,
                        June = TotalAverageOccupancy.June.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.June, BedsAvailable.June), 1) : (float?)null,
                        July = TotalAverageOccupancy.July.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.July, BedsAvailable.July), 1) : (float?)null,
                        August = TotalAverageOccupancy.August.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.August, BedsAvailable.August), 1) : (float?)null,
                        September = TotalAverageOccupancy.September.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.September, BedsAvailable.September), 1) : (float?)null,
                        October = TotalAverageOccupancy.October.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.October, BedsAvailable.October), 1) : (float?)null,
                        November = TotalAverageOccupancy.November.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.November, BedsAvailable.November), 1) : (float?)null,
                        December = TotalAverageOccupancy.December.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.December, BedsAvailable.December), 1) : (float?)null,
                        TotalOrAverage = BedsAvailable.TotalOrAverage.HasValue ? (float)Math.Round(Percent(TotalAverageOccupancy.TotalOrAverage, BedsAvailable.TotalOrAverage), 1) : (float?)null
                    };
                }
                return _percentOccupancy;
            }
        }

    }
}

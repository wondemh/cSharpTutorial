using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFSkilledNurseActual : OccupancyRecordsContainer
    {
        public OccupancyRecord BedsAvailable { get; set; }
        public OccupancyRecord AveragePrivatePay { get; set; }
        public OccupancyRecord AveragePrivateMedicaidPending { get; set; }
        public OccupancyRecord AverageMedicare { get; set; }
        public OccupancyRecord AverageMedicaid { get; set; }

        public OccupancyRecord TotalAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
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
                    January = TotalAverageOccupancy.January ?? (float)Math.Round(Divide(TotalAverageOccupancy.January, BedsAvailable.January), 0),
                    February = TotalAverageOccupancy.February ?? (float)Math.Round(Divide(TotalAverageOccupancy.February, BedsAvailable.February), 0),
                    March = TotalAverageOccupancy.March ?? (float)Math.Round(Divide(TotalAverageOccupancy.March, BedsAvailable.March), 0),
                    April = TotalAverageOccupancy.April ?? (float)Math.Round(Divide(TotalAverageOccupancy.April, BedsAvailable.April), 0),
                    May = TotalAverageOccupancy.May ?? (float)Math.Round(Divide(TotalAverageOccupancy.May, BedsAvailable.May), 0),
                    June = TotalAverageOccupancy.June ?? (float)Math.Round(Divide(TotalAverageOccupancy.June, BedsAvailable.June), 0),
                    July = TotalAverageOccupancy.July ?? (float)Math.Round(Divide(TotalAverageOccupancy.July, BedsAvailable.July), 0),
                    August = TotalAverageOccupancy.August ?? (float)Math.Round(Divide(TotalAverageOccupancy.August, BedsAvailable.August), 0),
                    September = TotalAverageOccupancy.September ?? (float)Math.Round(Divide(TotalAverageOccupancy.September, BedsAvailable.September), 0),
                    October = TotalAverageOccupancy.October ?? (float)Math.Round(Divide(TotalAverageOccupancy.October, BedsAvailable.October), 0),
                    November = TotalAverageOccupancy.November ?? (float)Math.Round(Divide(TotalAverageOccupancy.November, BedsAvailable.November), 0),
                    December = TotalAverageOccupancy.December ?? (float)Math.Round(Divide(TotalAverageOccupancy.December, BedsAvailable.December), 0),
                    TotalOrAverage = BedsAvailable.TotalOrAverage ?? (float)Math.Round(Divide(TotalAverageOccupancy.TotalOrAverage, BedsAvailable.TotalOrAverage), 0)
                };
            }
        }

    }
}

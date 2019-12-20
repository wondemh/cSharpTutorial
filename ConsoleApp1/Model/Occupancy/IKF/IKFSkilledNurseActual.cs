using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFSkilledNurseActual : OccupancyRecordsContainer
    {
        public OccupancyRecord BedsAvailable { get; set; }
        public OccupancyRecord AveragePrivatePay { get; set; }
        public OccupancyRecord AverageprivatePrivateMedicaidPending { get; set; }
        public OccupancyRecord AverageMedicare { get; set; }
        public OccupancyRecord AverageMedicaid { get; set; }

        public OccupancyRecord TotalAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AveragePrivatePay.January + AverageprivatePrivateMedicaidPending.January + AverageMedicare.January + AverageMedicare.January + AverageMedicaid.January,
                    February = AveragePrivatePay.February + AverageprivatePrivateMedicaidPending.February + AverageMedicare.February + AverageMedicare.February + AverageMedicaid.February,
                    March = AveragePrivatePay.March + AverageprivatePrivateMedicaidPending.March + AverageMedicare.March + AverageMedicare.March + AverageMedicaid.March,
                    April = AveragePrivatePay.April + AverageprivatePrivateMedicaidPending.April + AverageMedicare.April + AverageMedicare.April + AverageMedicaid.April,
                    May = AveragePrivatePay.May + AverageprivatePrivateMedicaidPending.May + AverageMedicare.May + AverageMedicare.May + AverageMedicaid.May,
                    June = AveragePrivatePay.June + AverageprivatePrivateMedicaidPending.June + AverageMedicare.June + AverageMedicare.June + AverageMedicaid.June,
                    July = AveragePrivatePay.July + AverageprivatePrivateMedicaidPending.July + AverageMedicare.July + AverageMedicare.July + AverageMedicaid.July,
                    August = AveragePrivatePay.August + AverageprivatePrivateMedicaidPending.August + AverageMedicare.August + AverageMedicare.August + AverageMedicaid.August,
                    September = AveragePrivatePay.September + AverageprivatePrivateMedicaidPending.September + AverageMedicare.September + AverageMedicare.September + AverageMedicaid.September,
                    October = AveragePrivatePay.October + AverageprivatePrivateMedicaidPending.October + AverageMedicare.October + AverageMedicare.October + AverageMedicaid.October,
                    November = AveragePrivatePay.November + AverageprivatePrivateMedicaidPending.November + AverageMedicare.November + AverageMedicare.November + AverageMedicaid.November,
                    December = AveragePrivatePay.December + AverageprivatePrivateMedicaidPending.December + AverageMedicare.December + AverageMedicare.December + AverageMedicaid.December
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

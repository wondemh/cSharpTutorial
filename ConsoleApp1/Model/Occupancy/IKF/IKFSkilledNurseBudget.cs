using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFSkilledNurseBudget : OccupancyRecordsContainer
    {
        public IKFSkilledNurseActual SkilledNurseActual { get; set; }
        public OccupancyRecord PrivatePay { get; set; }
        public OccupancyRecord Medicare { get; set; }
        public OccupancyRecord Medicaid { get; set; }

        public OccupancyRecord PrivatePayVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = SkilledNurseActual.AveragePrivatePay.January ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.January) - ZeroIfNull(PrivatePay.January);
                record.February = SkilledNurseActual.AveragePrivatePay.February ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.February) - ZeroIfNull(PrivatePay.February);
                record.March = SkilledNurseActual.AveragePrivatePay.March ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.March) - ZeroIfNull(PrivatePay.March);
                record.April = SkilledNurseActual.AveragePrivatePay.April ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.April) - ZeroIfNull(PrivatePay.April);
                record.May = SkilledNurseActual.AveragePrivatePay.May ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.May) - ZeroIfNull(PrivatePay.May);
                record.June = SkilledNurseActual.AveragePrivatePay.June ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.June) - ZeroIfNull(PrivatePay.June);
                record.July = SkilledNurseActual.AveragePrivatePay.July ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.July) - ZeroIfNull(PrivatePay.July);
                record.August = SkilledNurseActual.AveragePrivatePay.August ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.August) - ZeroIfNull(PrivatePay.August);
                record.September = SkilledNurseActual.AveragePrivatePay.September ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.September) - ZeroIfNull(PrivatePay.September);
                record.October = SkilledNurseActual.AveragePrivatePay.October ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.October) - ZeroIfNull(PrivatePay.October);
                record.November = SkilledNurseActual.AveragePrivatePay.November ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.November) - ZeroIfNull(PrivatePay.November);
                record.December = SkilledNurseActual.AveragePrivatePay.December ?? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.December) - ZeroIfNull(PrivatePay.December);
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord PrivateMedicaidPending
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord PrivateMedicaidPendingVarianceFromBudget 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = SkilledNurseActual.AveragePrivateMedicaidPending.January ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.January) - ZeroIfNull(PrivateMedicaidPending.January);
                record.February = SkilledNurseActual.AveragePrivateMedicaidPending.February ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.February) - ZeroIfNull(PrivateMedicaidPending.February);
                record.March = SkilledNurseActual.AveragePrivateMedicaidPending.March ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.March) - ZeroIfNull(PrivateMedicaidPending.March);
                record.April = SkilledNurseActual.AveragePrivateMedicaidPending.April ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.April) - ZeroIfNull(PrivateMedicaidPending.April);
                record.May = SkilledNurseActual.AveragePrivateMedicaidPending.May ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.May) - ZeroIfNull(PrivateMedicaidPending.May);
                record.June = SkilledNurseActual.AveragePrivateMedicaidPending.June ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.June) - ZeroIfNull(PrivateMedicaidPending.June);
                record.July = SkilledNurseActual.AveragePrivateMedicaidPending.July ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.July) - ZeroIfNull(PrivateMedicaidPending.July);
                record.August = SkilledNurseActual.AveragePrivateMedicaidPending.August ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.August) - ZeroIfNull(PrivateMedicaidPending.August);
                record.September = SkilledNurseActual.AveragePrivateMedicaidPending.September ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.September) - ZeroIfNull(PrivateMedicaidPending.September);
                record.October = SkilledNurseActual.AveragePrivateMedicaidPending.October ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.October) - ZeroIfNull(PrivateMedicaidPending.October);
                record.November = SkilledNurseActual.AveragePrivateMedicaidPending.November ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.November) - ZeroIfNull(PrivateMedicaidPending.November);
                record.December = SkilledNurseActual.AveragePrivateMedicaidPending.December ?? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.December) - ZeroIfNull(PrivateMedicaidPending.December);
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        public OccupancyRecord MedicareVarianceFromBudget 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = SkilledNurseActual.AverageMedicare.January ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.January) - ZeroIfNull(Medicare.January),
                    February = SkilledNurseActual.AverageMedicare.February ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.February) - ZeroIfNull(Medicare.February),
                    March = SkilledNurseActual.AverageMedicare.March ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.March) - ZeroIfNull(Medicare.March),
                    April = SkilledNurseActual.AverageMedicare.April ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.April) - ZeroIfNull(Medicare.April),
                    May = SkilledNurseActual.AverageMedicare.May ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.May) - ZeroIfNull(Medicare.May),
                    June = SkilledNurseActual.AverageMedicare.June ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.June) - ZeroIfNull(Medicare.June),
                    July = SkilledNurseActual.AverageMedicare.July ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.July) - ZeroIfNull(Medicare.July),
                    August = SkilledNurseActual.AverageMedicare.August ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.August) - ZeroIfNull(Medicare.August),
                    September = SkilledNurseActual.AverageMedicare.September ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.September) - ZeroIfNull(Medicare.September),
                    October = SkilledNurseActual.AverageMedicare.October ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.October) - ZeroIfNull(Medicare.October),
                    November = SkilledNurseActual.AverageMedicare.November ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.November) - ZeroIfNull(Medicare.November),
                    December = SkilledNurseActual.AverageMedicare.December ?? ZeroIfNull(SkilledNurseActual.AverageMedicare.December) - ZeroIfNull(Medicare.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        
        public OccupancyRecord MedicaidVarianceFromBudget 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = SkilledNurseActual.AverageMedicaid.January ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.January) - ZeroIfNull(Medicaid.January),
                    February = SkilledNurseActual.AverageMedicaid.February ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.February) - ZeroIfNull(Medicaid.February),
                    March = SkilledNurseActual.AverageMedicaid.March ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.March) - ZeroIfNull(Medicaid.March),
                    April = SkilledNurseActual.AverageMedicaid.April ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.April) - ZeroIfNull(Medicaid.April),
                    May = SkilledNurseActual.AverageMedicaid.May ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.May) - ZeroIfNull(Medicaid.May),
                    June = SkilledNurseActual.AverageMedicaid.June ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.June) - ZeroIfNull(Medicaid.June),
                    July = SkilledNurseActual.AverageMedicaid.July ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.July) - ZeroIfNull(Medicaid.July),
                    August = SkilledNurseActual.AverageMedicaid.August ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.August) - ZeroIfNull(Medicaid.August),
                    September = SkilledNurseActual.AverageMedicaid.September ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.September) - ZeroIfNull(Medicaid.September),
                    October = SkilledNurseActual.AverageMedicaid.October ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.October) - ZeroIfNull(Medicaid.October),
                    November = SkilledNurseActual.AverageMedicaid.November ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.November) - ZeroIfNull(Medicaid.November),
                    December = SkilledNurseActual.AverageMedicaid.December ?? ZeroIfNull(SkilledNurseActual.AverageMedicaid.December) - ZeroIfNull(Medicaid.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        public OccupancyRecord TotalOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = ZeroIfNull(PrivatePay.January) + ZeroIfNull(Medicare.January) + ZeroIfNull(Medicaid.January),
                    February = ZeroIfNull(PrivatePay.February) + ZeroIfNull(Medicare.February) + ZeroIfNull(Medicaid.February),
                    March = ZeroIfNull(PrivatePay.March) + ZeroIfNull(Medicare.March) + ZeroIfNull(Medicaid.March),
                    April = ZeroIfNull(PrivatePay.April) + ZeroIfNull(Medicare.April) + ZeroIfNull(Medicaid.April),
                    May = ZeroIfNull(PrivatePay.May) + ZeroIfNull(Medicare.May) + ZeroIfNull(Medicaid.May),
                    June = ZeroIfNull(PrivatePay.June) + ZeroIfNull(Medicare.June) + ZeroIfNull(Medicaid.June),
                    July = ZeroIfNull(PrivatePay.July) + ZeroIfNull(Medicare.July) + ZeroIfNull(Medicaid.July),
                    August = ZeroIfNull(PrivatePay.August) + ZeroIfNull(Medicare.August) + ZeroIfNull(Medicaid.August),
                    September = ZeroIfNull(PrivatePay.September) + ZeroIfNull(Medicare.September) + ZeroIfNull(Medicaid.September),
                    October = ZeroIfNull(PrivatePay.October) + ZeroIfNull(Medicare.October) + ZeroIfNull(Medicaid.October),
                    November = ZeroIfNull(PrivatePay.November) + ZeroIfNull(Medicare.November) + ZeroIfNull(Medicaid.November),
                    December = ZeroIfNull(PrivatePay.December) + ZeroIfNull(Medicare.December) + ZeroIfNull(Medicaid.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        
        public OccupancyRecord TotalOccupancyVarianceFromBudget 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = SkilledNurseActual.TotalAverageOccupancy.January ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.January) - ZeroIfNull(TotalOccupancy.January),
                    February = SkilledNurseActual.TotalAverageOccupancy.February ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.February) - ZeroIfNull(TotalOccupancy.February),
                    March = SkilledNurseActual.TotalAverageOccupancy.March ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.March) - ZeroIfNull(TotalOccupancy.March),
                    April = SkilledNurseActual.TotalAverageOccupancy.April ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.April) - ZeroIfNull(TotalOccupancy.April),
                    May = SkilledNurseActual.TotalAverageOccupancy.May ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.May) - ZeroIfNull(TotalOccupancy.May),
                    June = SkilledNurseActual.TotalAverageOccupancy.June ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.June) - ZeroIfNull(TotalOccupancy.June),
                    July = SkilledNurseActual.TotalAverageOccupancy.July ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.July) - ZeroIfNull(TotalOccupancy.July),
                    August = SkilledNurseActual.TotalAverageOccupancy.August ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.August) - ZeroIfNull(TotalOccupancy.August),
                    September = SkilledNurseActual.TotalAverageOccupancy.September ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.September) - ZeroIfNull(TotalOccupancy.September),
                    October = SkilledNurseActual.TotalAverageOccupancy.October ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.October) - ZeroIfNull(TotalOccupancy.October),
                    November = SkilledNurseActual.TotalAverageOccupancy.November ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.November) - ZeroIfNull(TotalOccupancy.November),
                    December = SkilledNurseActual.TotalAverageOccupancy.December ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.December) - ZeroIfNull(TotalOccupancy.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
    }
}

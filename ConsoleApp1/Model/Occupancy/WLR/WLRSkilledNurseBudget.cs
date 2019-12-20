using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRSkilledNurseBudget :OccupancyRecordsContainer
    {
        public WLRSkilledNurseActual SkilledNurseActual { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCFirstVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = SkilledNurseActual.AverageLCFirst.January ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.January) - ZeroIfNull(AverageLCFirst.January),
                    February = SkilledNurseActual.AverageLCFirst.February ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.February) - ZeroIfNull(AverageLCFirst.February),
                    March = SkilledNurseActual.AverageLCFirst.March ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.March) - ZeroIfNull(AverageLCFirst.March),
                    April = SkilledNurseActual.AverageLCFirst.April ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.April) - ZeroIfNull(AverageLCFirst.April),
                    May = SkilledNurseActual.AverageLCFirst.May ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.May) - ZeroIfNull(AverageLCFirst.May),
                    June = SkilledNurseActual.AverageLCFirst.June ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.June) - ZeroIfNull(AverageLCFirst.June),
                    July = SkilledNurseActual.AverageLCFirst.July ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.July) - ZeroIfNull(AverageLCFirst.July),
                    August = SkilledNurseActual.AverageLCFirst.August ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.August) - ZeroIfNull(AverageLCFirst.August),
                    September = SkilledNurseActual.AverageLCFirst.September ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.September) - ZeroIfNull(AverageLCFirst.September),
                    October = SkilledNurseActual.AverageLCFirst.October ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.October) - ZeroIfNull(AverageLCFirst.October),
                    November = SkilledNurseActual.AverageLCFirst.November ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.November) - ZeroIfNull(AverageLCFirst.November),
                    December = SkilledNurseActual.AverageLCFirst.December ?? ZeroIfNull(SkilledNurseActual.AverageLCFirst.December) - ZeroIfNull(AverageLCFirst.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord AverageLCSecondVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = SkilledNurseActual.AverageLCSecond.January ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.January) - ZeroIfNull(AverageLCSecond.January),
                    February = SkilledNurseActual.AverageLCSecond.February ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.February) - ZeroIfNull(AverageLCSecond.February),
                    March = SkilledNurseActual.AverageLCSecond.March ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.March) - ZeroIfNull(AverageLCSecond.March),
                    April = SkilledNurseActual.AverageLCSecond.April ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.April) - ZeroIfNull(AverageLCSecond.April),
                    May = SkilledNurseActual.AverageLCSecond.May ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.May) - ZeroIfNull(AverageLCSecond.May),
                    June = SkilledNurseActual.AverageLCSecond.June ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.June) - ZeroIfNull(AverageLCSecond.June),
                    July = SkilledNurseActual.AverageLCSecond.July ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.July) - ZeroIfNull(AverageLCSecond.July),
                    August = SkilledNurseActual.AverageLCSecond.August ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.August) - ZeroIfNull(AverageLCSecond.August),
                    September = SkilledNurseActual.AverageLCSecond.September ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.September) - ZeroIfNull(AverageLCSecond.September),
                    October = SkilledNurseActual.AverageLCSecond.October ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.October) - ZeroIfNull(AverageLCSecond.October),
                    November = SkilledNurseActual.AverageLCSecond.November ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.November) - ZeroIfNull(AverageLCSecond.November),
                    December = SkilledNurseActual.AverageLCSecond.December ?? ZeroIfNull(SkilledNurseActual.AverageLCSecond.December) - ZeroIfNull(AverageLCSecond.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord MemoryCare { get; set; }
        public OccupancyRecord MemoryCareVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = SkilledNurseActual.AverageMemoryCare.January ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.January) - ZeroIfNull(MemoryCare.January),
                    February = SkilledNurseActual.AverageMemoryCare.February ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.February) - ZeroIfNull(MemoryCare.February),
                    March = SkilledNurseActual.AverageMemoryCare.March ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.March) - ZeroIfNull(MemoryCare.March),
                    April = SkilledNurseActual.AverageMemoryCare.April ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.April) - ZeroIfNull(MemoryCare.April),
                    May = SkilledNurseActual.AverageMemoryCare.May ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.May) - ZeroIfNull(MemoryCare.May),
                    June = SkilledNurseActual.AverageMemoryCare.June ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.June) - ZeroIfNull(MemoryCare.June),
                    July = SkilledNurseActual.AverageMemoryCare.July ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.July) - ZeroIfNull(MemoryCare.July),
                    August = SkilledNurseActual.AverageMemoryCare.August ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.August) - ZeroIfNull(MemoryCare.August),
                    September = SkilledNurseActual.AverageMemoryCare.September ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.September) - ZeroIfNull(MemoryCare.September),
                    October = SkilledNurseActual.AverageMemoryCare.October ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.October) - ZeroIfNull(MemoryCare.October),
                    November = SkilledNurseActual.AverageMemoryCare.November ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.November) - ZeroIfNull(MemoryCare.November),
                    December = SkilledNurseActual.AverageMemoryCare.December ?? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.December) - ZeroIfNull(MemoryCare.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord FFSDirectAdmit { get; set; }
        public OccupancyRecord FFSDirectAdmitVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = SkilledNurseActual.FFSDirectAdmit.January ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.January) - ZeroIfNull(FFSDirectAdmit.January),
                    February = SkilledNurseActual.FFSDirectAdmit.February ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.February) - ZeroIfNull(FFSDirectAdmit.February),
                    March = SkilledNurseActual.FFSDirectAdmit.March ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.March) - ZeroIfNull(FFSDirectAdmit.March),
                    April = SkilledNurseActual.FFSDirectAdmit.April ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.April) - ZeroIfNull(FFSDirectAdmit.April),
                    May = SkilledNurseActual.FFSDirectAdmit.May ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.May) - ZeroIfNull(FFSDirectAdmit.May),
                    June = SkilledNurseActual.FFSDirectAdmit.June ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.June) - ZeroIfNull(FFSDirectAdmit.June),
                    July = SkilledNurseActual.FFSDirectAdmit.July ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.July) - ZeroIfNull(FFSDirectAdmit.July),
                    August = SkilledNurseActual.FFSDirectAdmit.August ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.August) - ZeroIfNull(FFSDirectAdmit.August),
                    September = SkilledNurseActual.FFSDirectAdmit.September ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.September) - ZeroIfNull(FFSDirectAdmit.September),
                    October = SkilledNurseActual.FFSDirectAdmit.October ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.October) - ZeroIfNull(FFSDirectAdmit.October),
                    November = SkilledNurseActual.FFSDirectAdmit.November ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.November) - ZeroIfNull(FFSDirectAdmit.November),
                    December = SkilledNurseActual.FFSDirectAdmit.December ?? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.December) - ZeroIfNull(FFSDirectAdmit.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord Medicare { get; set; }
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
        public OccupancyRecord Medicaid { get; set; }
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
                    January = ZeroIfNull(AverageLCFirst.January) + ZeroIfNull(AverageLCSecond.January) + ZeroIfNull(Medicare.January) + ZeroIfNull(Medicaid.January) + ZeroIfNull(FFSDirectAdmit.January) + ZeroIfNull(MemoryCare.January),
                    February = ZeroIfNull(AverageLCFirst.February) + ZeroIfNull(AverageLCSecond.February) + ZeroIfNull(Medicare.February) + ZeroIfNull(Medicaid.February) + ZeroIfNull(FFSDirectAdmit.February) + ZeroIfNull(MemoryCare.February),
                    March = ZeroIfNull(AverageLCFirst.March) + ZeroIfNull(AverageLCSecond.March) + ZeroIfNull(Medicare.March) + ZeroIfNull(Medicaid.March) + ZeroIfNull(FFSDirectAdmit.March) + ZeroIfNull(MemoryCare.March),
                    April = ZeroIfNull(AverageLCFirst.April) + ZeroIfNull(AverageLCSecond.April) + ZeroIfNull(Medicare.April) + ZeroIfNull(Medicaid.April) + ZeroIfNull(FFSDirectAdmit.April) + ZeroIfNull(MemoryCare.April),
                    May = ZeroIfNull(AverageLCFirst.May) + ZeroIfNull(AverageLCSecond.May) + ZeroIfNull(Medicare.May) + ZeroIfNull(Medicaid.May) + ZeroIfNull(FFSDirectAdmit.May) + ZeroIfNull(MemoryCare.May),
                    June = ZeroIfNull(AverageLCFirst.June) + ZeroIfNull(AverageLCSecond.June) + ZeroIfNull(Medicare.June) + ZeroIfNull(Medicaid.June) + ZeroIfNull(FFSDirectAdmit.June) + ZeroIfNull(MemoryCare.June),
                    July = ZeroIfNull(AverageLCFirst.July) + ZeroIfNull(AverageLCSecond.July) + ZeroIfNull(Medicare.July) + ZeroIfNull(Medicaid.July) + ZeroIfNull(FFSDirectAdmit.July) + ZeroIfNull(MemoryCare.July),
                    August = ZeroIfNull(AverageLCFirst.August) + ZeroIfNull(AverageLCSecond.August) + ZeroIfNull(Medicare.August) + ZeroIfNull(Medicaid.August) + ZeroIfNull(FFSDirectAdmit.August) + ZeroIfNull(MemoryCare.August),
                    September = ZeroIfNull(AverageLCFirst.September) + ZeroIfNull(AverageLCSecond.September) + ZeroIfNull(Medicare.September) + ZeroIfNull(Medicaid.September) + ZeroIfNull(FFSDirectAdmit.September) + ZeroIfNull(MemoryCare.September),
                    October = ZeroIfNull(AverageLCFirst.October) + ZeroIfNull(AverageLCSecond.October) + ZeroIfNull(Medicare.October) + ZeroIfNull(Medicaid.October) + ZeroIfNull(FFSDirectAdmit.October) + ZeroIfNull(MemoryCare.October),
                    November = ZeroIfNull(AverageLCFirst.November) + ZeroIfNull(AverageLCSecond.November) + ZeroIfNull(Medicare.November) + ZeroIfNull(Medicaid.November) + ZeroIfNull(FFSDirectAdmit.November) + ZeroIfNull(MemoryCare.November),
                    December = ZeroIfNull(AverageLCFirst.December) + ZeroIfNull(AverageLCSecond.December) + ZeroIfNull(Medicare.December) + ZeroIfNull(Medicaid.December) + ZeroIfNull(FFSDirectAdmit.December) + ZeroIfNull(MemoryCare.December)
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
                    December = SkilledNurseActual.TotalAverageOccupancy.December ?? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.December) - ZeroIfNull(TotalOccupancy.December),
                    TotalOrAverage = (float)Math.Round(Divide(TotalOccupancy.TotalOrAverage, SkilledNurseActual.BedsAvailable.TotalOrAverage), 1)
                };
                return record;
            }
        }
    }
}

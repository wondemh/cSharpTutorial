using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCMemorySupportBudget : OccupancyRecordsContainer
    {
        public IRCMemorySupportActual MemorySupportActual { get; set; }
        public OccupancyRecord AverageMSFFSFirst { get; set; }
        public OccupancyRecord AverageMSFFSSecond { get; set; }
        public OccupancyRecord AverageMSLCFirst { get; set; }
        public OccupancyRecord AverageMSLCSecond { get; set; }
        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = ZeroIfNull(AverageMSFFSFirst.January) + ZeroIfNull(AverageMSFFSSecond.January) + ZeroIfNull(AverageMSLCFirst.January) + ZeroIfNull(AverageMSLCSecond.January),
                    February = ZeroIfNull(AverageMSFFSFirst.February) + ZeroIfNull(AverageMSFFSSecond.February) + ZeroIfNull(AverageMSLCFirst.February) + ZeroIfNull(AverageMSLCSecond.February),
                    March = ZeroIfNull(AverageMSFFSFirst.March) + ZeroIfNull(AverageMSFFSSecond.March) + ZeroIfNull(AverageMSLCFirst.March) + ZeroIfNull(AverageMSLCSecond.March),
                    April = ZeroIfNull(AverageMSFFSFirst.April) + ZeroIfNull(AverageMSFFSSecond.April) + ZeroIfNull(AverageMSLCFirst.April) + ZeroIfNull(AverageMSLCSecond.April),
                    May = ZeroIfNull(AverageMSFFSFirst.May) + ZeroIfNull(AverageMSFFSSecond.May) + ZeroIfNull(AverageMSLCFirst.May) + ZeroIfNull(AverageMSLCSecond.May),
                    June = ZeroIfNull(AverageMSFFSFirst.June) + ZeroIfNull(AverageMSFFSSecond.June) + ZeroIfNull(AverageMSLCFirst.June) + ZeroIfNull(AverageMSLCSecond.June),
                    July = ZeroIfNull(AverageMSFFSFirst.July) + ZeroIfNull(AverageMSFFSSecond.July) + ZeroIfNull(AverageMSLCFirst.July) + ZeroIfNull(AverageMSLCSecond.July),
                    August = ZeroIfNull(AverageMSFFSFirst.August) + ZeroIfNull(AverageMSFFSSecond.August) + ZeroIfNull(AverageMSLCFirst.August) + ZeroIfNull(AverageMSLCSecond.August),
                    September = ZeroIfNull(AverageMSFFSFirst.September) + ZeroIfNull(AverageMSFFSSecond.September) + ZeroIfNull(AverageMSLCFirst.September) + ZeroIfNull(AverageMSLCSecond.September),
                    October = ZeroIfNull(AverageMSFFSFirst.October) + ZeroIfNull(AverageMSFFSSecond.October) + ZeroIfNull(AverageMSLCFirst.October) + ZeroIfNull(AverageMSLCSecond.October),
                    November = ZeroIfNull(AverageMSFFSFirst.November) + ZeroIfNull(AverageMSFFSSecond.November) + ZeroIfNull(AverageMSLCFirst.November) + ZeroIfNull(AverageMSLCSecond.November),
                    December = ZeroIfNull(AverageMSFFSFirst.December) + ZeroIfNull(AverageMSFFSSecond.December) + ZeroIfNull(AverageMSLCFirst.December) + ZeroIfNull(AverageMSLCSecond.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        public OccupancyRecord EndingAverageOccupancyVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = MemorySupportActual.EndingAverageOccupancy.January ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.January) - ZeroIfNull(EndingAverageOccupancy.January),
                    February = MemorySupportActual.EndingAverageOccupancy.February ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.February) - ZeroIfNull(EndingAverageOccupancy.February),
                    March = MemorySupportActual.EndingAverageOccupancy.March ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.March) - ZeroIfNull(EndingAverageOccupancy.March),
                    April = MemorySupportActual.EndingAverageOccupancy.April ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.April) - ZeroIfNull(EndingAverageOccupancy.April),
                    May = MemorySupportActual.EndingAverageOccupancy.May ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.May) - ZeroIfNull(EndingAverageOccupancy.May),
                    June = MemorySupportActual.EndingAverageOccupancy.June ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.June) - ZeroIfNull(EndingAverageOccupancy.June),
                    July = MemorySupportActual.EndingAverageOccupancy.July ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.July) - ZeroIfNull(EndingAverageOccupancy.July),
                    August = MemorySupportActual.EndingAverageOccupancy.August ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.August) - ZeroIfNull(EndingAverageOccupancy.August),
                    September = MemorySupportActual.EndingAverageOccupancy.September ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.September) - ZeroIfNull(EndingAverageOccupancy.September),
                    October = MemorySupportActual.EndingAverageOccupancy.October ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.October) - ZeroIfNull(EndingAverageOccupancy.October),
                    November = MemorySupportActual.EndingAverageOccupancy.November ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.November) - ZeroIfNull(EndingAverageOccupancy.November),
                    December = MemorySupportActual.EndingAverageOccupancy.December ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.December) - ZeroIfNull(EndingAverageOccupancy.December)
                };
                return record;
            }
        }

        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = ZeroIfNull(AverageMSFFSFirst.January) + ZeroIfNull(AverageMSFFSSecond.January) + ZeroIfNull(AverageMSLCFirst.January) + ZeroIfNull(AverageMSLCSecond.January),
                    February = ZeroIfNull(AverageMSFFSFirst.February) + ZeroIfNull(AverageMSFFSSecond.February) + ZeroIfNull(AverageMSLCFirst.February) + ZeroIfNull(AverageMSLCSecond.February),
                    March = ZeroIfNull(AverageMSFFSFirst.March) + ZeroIfNull(AverageMSFFSSecond.March) + ZeroIfNull(AverageMSLCFirst.March) + ZeroIfNull(AverageMSLCSecond.March),
                    April = ZeroIfNull(AverageMSFFSFirst.April) + ZeroIfNull(AverageMSFFSSecond.April) + ZeroIfNull(AverageMSLCFirst.April) + ZeroIfNull(AverageMSLCSecond.April),
                    May = ZeroIfNull(AverageMSFFSFirst.May) + ZeroIfNull(AverageMSFFSSecond.May) + ZeroIfNull(AverageMSLCFirst.May) + ZeroIfNull(AverageMSLCSecond.May),
                    June = ZeroIfNull(AverageMSFFSFirst.June) + ZeroIfNull(AverageMSFFSSecond.June) + ZeroIfNull(AverageMSLCFirst.June) + ZeroIfNull(AverageMSLCSecond.June),
                    July = ZeroIfNull(AverageMSFFSFirst.July) + ZeroIfNull(AverageMSFFSSecond.July) + ZeroIfNull(AverageMSLCFirst.July) + ZeroIfNull(AverageMSLCSecond.July),
                    August = ZeroIfNull(AverageMSFFSFirst.August) + ZeroIfNull(AverageMSFFSSecond.August) + ZeroIfNull(AverageMSLCFirst.August) + ZeroIfNull(AverageMSLCSecond.August),
                    September = ZeroIfNull(AverageMSFFSFirst.September) + ZeroIfNull(AverageMSFFSSecond.September) + ZeroIfNull(AverageMSLCFirst.September) + ZeroIfNull(AverageMSLCSecond.September),
                    October = ZeroIfNull(AverageMSFFSFirst.October) + ZeroIfNull(AverageMSFFSSecond.October) + ZeroIfNull(AverageMSLCFirst.October) + ZeroIfNull(AverageMSLCSecond.October),
                    November = ZeroIfNull(AverageMSFFSFirst.November) + ZeroIfNull(AverageMSFFSSecond.November) + ZeroIfNull(AverageMSLCFirst.November) + ZeroIfNull(AverageMSLCSecond.November),
                    December = ZeroIfNull(AverageMSFFSFirst.December) + ZeroIfNull(AverageMSFFSSecond.December) + ZeroIfNull(AverageMSLCFirst.December) + ZeroIfNull(AverageMSLCSecond.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord EndingAvgPersonOccupancyVarianceFromBudget
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = MemorySupportActual.EndingAveragePersonOccupancy.January ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.January) - ZeroIfNull(EndingAveragePersonOccupancy.January),
                    February = MemorySupportActual.EndingAveragePersonOccupancy.February ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.February) - ZeroIfNull(EndingAveragePersonOccupancy.February),
                    March = MemorySupportActual.EndingAveragePersonOccupancy.March ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.March) - ZeroIfNull(EndingAveragePersonOccupancy.March),
                    April = MemorySupportActual.EndingAveragePersonOccupancy.April ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.April) - ZeroIfNull(EndingAveragePersonOccupancy.April),
                    May = MemorySupportActual.EndingAveragePersonOccupancy.May ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.May) - ZeroIfNull(EndingAveragePersonOccupancy.May),
                    June = MemorySupportActual.EndingAveragePersonOccupancy.June ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.June) - ZeroIfNull(EndingAveragePersonOccupancy.June),
                    July = MemorySupportActual.EndingAveragePersonOccupancy.July ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.July) - ZeroIfNull(EndingAveragePersonOccupancy.July),
                    August = MemorySupportActual.EndingAveragePersonOccupancy.August ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.August) - ZeroIfNull(EndingAveragePersonOccupancy.August),
                    September = MemorySupportActual.EndingAveragePersonOccupancy.September ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.September) - ZeroIfNull(EndingAveragePersonOccupancy.September),
                    October = MemorySupportActual.EndingAveragePersonOccupancy.October ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.October) - ZeroIfNull(EndingAveragePersonOccupancy.October),
                    November = MemorySupportActual.EndingAveragePersonOccupancy.November ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.November) - ZeroIfNull(EndingAveragePersonOccupancy.November),
                    December = MemorySupportActual.EndingAveragePersonOccupancy.December ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.December) - ZeroIfNull(EndingAveragePersonOccupancy.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IRCAssistedLivingBudget : OccupancyRecordsContainer
    {
        public IRCAssistedLivingActual AssistedLivingActual { get; set; }
        public OccupancyRecord AverageFFSFirst { get; set; }
        public OccupancyRecord AverageFFSSecond { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord EndingAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageLCFirst.January),
                    February = ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageFFSSecond.February) + ZeroIfNull(AverageLCFirst.February),
                    March = ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageFFSSecond.March) + ZeroIfNull(AverageLCFirst.March),
                    April = ZeroIfNull(AverageFFSFirst.April) + ZeroIfNull(AverageFFSSecond.April) + ZeroIfNull(AverageLCFirst.April),
                    May = ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageFFSSecond.May) + ZeroIfNull(AverageLCFirst.May),
                    June = ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageFFSSecond.June) + ZeroIfNull(AverageLCFirst.June),
                    July = ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageFFSSecond.July) + ZeroIfNull(AverageLCFirst.July),
                    August = ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageFFSSecond.August) + ZeroIfNull(AverageLCFirst.August),
                    September = ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageFFSSecond.September) + ZeroIfNull(AverageLCFirst.September),
                    October = ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageFFSSecond.October) + ZeroIfNull(AverageLCFirst.October),
                    November = ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageFFSSecond.November) + ZeroIfNull(AverageLCFirst.November),
                    December = ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageFFSSecond.December) + ZeroIfNull(AverageLCFirst.December)
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
                    January = AssistedLivingActual.EndingAverageOccupancy.January ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.January) - ZeroIfNull(EndingAverageOccupancy.January),
                    February = AssistedLivingActual.EndingAverageOccupancy.February ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.February) - ZeroIfNull(EndingAverageOccupancy.February),
                    March = AssistedLivingActual.EndingAverageOccupancy.March ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.March) - ZeroIfNull(EndingAverageOccupancy.March),
                    April = AssistedLivingActual.EndingAverageOccupancy.April ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.April) - ZeroIfNull(EndingAverageOccupancy.April),
                    May = AssistedLivingActual.EndingAverageOccupancy.May ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.May) - ZeroIfNull(EndingAverageOccupancy.May),
                    June = AssistedLivingActual.EndingAverageOccupancy.June ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.June) - ZeroIfNull(EndingAverageOccupancy.June),
                    July = AssistedLivingActual.EndingAverageOccupancy.July ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.July) - ZeroIfNull(EndingAverageOccupancy.July),
                    August = AssistedLivingActual.EndingAverageOccupancy.August ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.August) - ZeroIfNull(EndingAverageOccupancy.August),
                    September = AssistedLivingActual.EndingAverageOccupancy.September ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.September) - ZeroIfNull(EndingAverageOccupancy.September),
                    October = AssistedLivingActual.EndingAverageOccupancy.October ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.October) - ZeroIfNull(EndingAverageOccupancy.October),
                    November = AssistedLivingActual.EndingAverageOccupancy.November ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.November) - ZeroIfNull(EndingAverageOccupancy.November),
                    December = AssistedLivingActual.EndingAverageOccupancy.December ?? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.December) - ZeroIfNull(EndingAverageOccupancy.December)
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
                    January = ZeroIfNull(AverageFFSFirst.January) + ZeroIfNull(AverageFFSSecond.January) + ZeroIfNull(AverageLCFirst.January) + ZeroIfNull(AverageLCSecond.January),
                    February = ZeroIfNull(AverageFFSFirst.February) + ZeroIfNull(AverageFFSSecond.February) + ZeroIfNull(AverageLCFirst.February) + ZeroIfNull(AverageLCSecond.February),
                    March = ZeroIfNull(AverageFFSFirst.March) + ZeroIfNull(AverageFFSSecond.March) + ZeroIfNull(AverageLCFirst.March) + ZeroIfNull(AverageLCSecond.March),
                    April = ZeroIfNull(AverageFFSFirst.April) + ZeroIfNull(AverageFFSSecond.April) + ZeroIfNull(AverageLCFirst.April) + ZeroIfNull(AverageLCSecond.April),
                    May = ZeroIfNull(AverageFFSFirst.May) + ZeroIfNull(AverageFFSSecond.May) + ZeroIfNull(AverageLCFirst.May) + ZeroIfNull(AverageLCSecond.May),
                    June = ZeroIfNull(AverageFFSFirst.June) + ZeroIfNull(AverageFFSSecond.June) + ZeroIfNull(AverageLCFirst.June) + ZeroIfNull(AverageLCSecond.June),
                    July = ZeroIfNull(AverageFFSFirst.July) + ZeroIfNull(AverageFFSSecond.July) + ZeroIfNull(AverageLCFirst.July) + ZeroIfNull(AverageLCSecond.July),
                    August = ZeroIfNull(AverageFFSFirst.August) + ZeroIfNull(AverageFFSSecond.August) + ZeroIfNull(AverageLCFirst.August) + ZeroIfNull(AverageLCSecond.August),
                    September = ZeroIfNull(AverageFFSFirst.September) + ZeroIfNull(AverageFFSSecond.September) + ZeroIfNull(AverageLCFirst.September) + ZeroIfNull(AverageLCSecond.September),
                    October = ZeroIfNull(AverageFFSFirst.October) + ZeroIfNull(AverageFFSSecond.October) + ZeroIfNull(AverageLCFirst.October) + ZeroIfNull(AverageLCSecond.October),
                    November = ZeroIfNull(AverageFFSFirst.November) + ZeroIfNull(AverageFFSSecond.November) + ZeroIfNull(AverageLCFirst.November) + ZeroIfNull(AverageLCSecond.November),
                    December = ZeroIfNull(AverageFFSFirst.December) + ZeroIfNull(AverageFFSSecond.December) + ZeroIfNull(AverageLCFirst.December) + ZeroIfNull(AverageLCSecond.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord EndingAveragePersonOccupancyVarianceFromBudget 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    January = AssistedLivingActual.EndingAveragePersonOccupancy.January ?? AssistedLivingActual.EndingAveragePersonOccupancy.January - ZeroIfNull(EndingAveragePersonOccupancy.January),
                    February = AssistedLivingActual.EndingAveragePersonOccupancy.February ?? AssistedLivingActual.EndingAveragePersonOccupancy.February - ZeroIfNull(EndingAveragePersonOccupancy.February),
                    March = AssistedLivingActual.EndingAveragePersonOccupancy.March ?? AssistedLivingActual.EndingAveragePersonOccupancy.March - ZeroIfNull(EndingAveragePersonOccupancy.March),
                    April = AssistedLivingActual.EndingAveragePersonOccupancy.April ?? AssistedLivingActual.EndingAveragePersonOccupancy.April - ZeroIfNull(EndingAveragePersonOccupancy.April),
                    May = AssistedLivingActual.EndingAveragePersonOccupancy.May ?? AssistedLivingActual.EndingAveragePersonOccupancy.May - ZeroIfNull(EndingAveragePersonOccupancy.May),
                    June = AssistedLivingActual.EndingAveragePersonOccupancy.June ?? AssistedLivingActual.EndingAveragePersonOccupancy.June - ZeroIfNull(EndingAveragePersonOccupancy.June),
                    July = AssistedLivingActual.EndingAveragePersonOccupancy.July ?? AssistedLivingActual.EndingAveragePersonOccupancy.July - ZeroIfNull(EndingAveragePersonOccupancy.July),
                    August = AssistedLivingActual.EndingAveragePersonOccupancy.August ?? AssistedLivingActual.EndingAveragePersonOccupancy.August - ZeroIfNull(EndingAveragePersonOccupancy.August),
                    September = AssistedLivingActual.EndingAveragePersonOccupancy.September ?? AssistedLivingActual.EndingAveragePersonOccupancy.September - ZeroIfNull(EndingAveragePersonOccupancy.September),
                    October = AssistedLivingActual.EndingAveragePersonOccupancy.October ?? AssistedLivingActual.EndingAveragePersonOccupancy.October - ZeroIfNull(EndingAveragePersonOccupancy.October),
                    November = AssistedLivingActual.EndingAveragePersonOccupancy.November ?? AssistedLivingActual.EndingAveragePersonOccupancy.November - ZeroIfNull(EndingAveragePersonOccupancy.November),
                    December = AssistedLivingActual.EndingAveragePersonOccupancy.December ?? AssistedLivingActual.EndingAveragePersonOccupancy.December - ZeroIfNull(EndingAveragePersonOccupancy.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

    }
}

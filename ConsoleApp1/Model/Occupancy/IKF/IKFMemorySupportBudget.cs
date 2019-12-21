using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFMemorySupportBudget : OccupancyRecordsContainer
    {
        public IKFMemorySupportActual MemorySupportActual { get; set; }
        public OccupancyRecord PrivateMCFirstPerson { get; set; }
        public OccupancyRecord PrivateMCSecondPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {
                if (PrivateMCFirstPerson != null && PrivateMCSecondPerson != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        January = PrivateMCFirstPerson.January ?? ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January),
                        February = PrivateMCFirstPerson.February ?? ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February),
                        March = PrivateMCFirstPerson.March ?? ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March),
                        April = PrivateMCFirstPerson.April ?? ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April),
                        May = PrivateMCFirstPerson.May ?? ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May),
                        June = PrivateMCFirstPerson.June ?? ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June),
                        July = PrivateMCFirstPerson.July ?? ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July),
                        August = PrivateMCFirstPerson.August ?? ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August),
                        September = PrivateMCFirstPerson.September ?? ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September),
                        October = PrivateMCFirstPerson.October ?? ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October),
                        November = PrivateMCFirstPerson.November ?? ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November),
                        December = PrivateMCFirstPerson.December ?? ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December)
                    };
                    record.TotalOrAverage = record.CalculateAverageValue();
                    return record;
                }
                return new OccupancyRecord();
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
                    January = ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January),
                    February = ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February),
                    March = ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March),
                    April = ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April),
                    May = ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May),
                    June = ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June),
                    July = ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July),
                    August = ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August),
                    September = ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September),
                    October = ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October),
                    November = ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November),
                    December = ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December)
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
                return record;
            }
        }

    }
}

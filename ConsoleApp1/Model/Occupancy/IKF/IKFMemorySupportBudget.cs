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
                OccupancyRecord record = new OccupancyRecord();
                record.January = MemorySupportActual.EndingAverageOccupancy.January ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.January) - ZeroIfNull(EndingAverageOccupancy.January);
                record.February = MemorySupportActual.EndingAverageOccupancy.February ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.February) - ZeroIfNull(EndingAverageOccupancy.February);
                record.March = MemorySupportActual.EndingAverageOccupancy.March ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.March) - ZeroIfNull(EndingAverageOccupancy.March);
                record.April = MemorySupportActual.EndingAverageOccupancy.April ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.April) - ZeroIfNull(EndingAverageOccupancy.April);
                record.May = MemorySupportActual.EndingAverageOccupancy.May ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.May) - ZeroIfNull(EndingAverageOccupancy.May);
                record.June = MemorySupportActual.EndingAverageOccupancy.June ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.June) - ZeroIfNull(EndingAverageOccupancy.June);
                record.July = MemorySupportActual.EndingAverageOccupancy.July ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.July) - ZeroIfNull(EndingAverageOccupancy.July);
                record.August = MemorySupportActual.EndingAverageOccupancy.August ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.August) - ZeroIfNull(EndingAverageOccupancy.August);
                record.September = MemorySupportActual.EndingAverageOccupancy.September ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.September) - ZeroIfNull(EndingAverageOccupancy.September);
                record.October = MemorySupportActual.EndingAverageOccupancy.October ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.October) - ZeroIfNull(EndingAverageOccupancy.October);
                record.November = MemorySupportActual.EndingAverageOccupancy.November ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.November) - ZeroIfNull(EndingAverageOccupancy.November);
                record.December = MemorySupportActual.EndingAverageOccupancy.December ?? ZeroIfNull(MemorySupportActual.EndingAverageOccupancy.December) - ZeroIfNull(EndingAverageOccupancy.December);
                return record;
            }
        }

        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = ZeroIfNull(PrivateMCFirstPerson.January) + ZeroIfNull(PrivateMCSecondPerson.January);
                record.February = ZeroIfNull(PrivateMCFirstPerson.February) + ZeroIfNull(PrivateMCSecondPerson.February);
                record.March = ZeroIfNull(PrivateMCFirstPerson.March) + ZeroIfNull(PrivateMCSecondPerson.March);
                record.April = ZeroIfNull(PrivateMCFirstPerson.April) + ZeroIfNull(PrivateMCSecondPerson.April);
                record.May = ZeroIfNull(PrivateMCFirstPerson.May) + ZeroIfNull(PrivateMCSecondPerson.May);
                record.June = ZeroIfNull(PrivateMCFirstPerson.June) + ZeroIfNull(PrivateMCSecondPerson.June);
                record.July = ZeroIfNull(PrivateMCFirstPerson.July) + ZeroIfNull(PrivateMCSecondPerson.July);
                record.August = ZeroIfNull(PrivateMCFirstPerson.August) + ZeroIfNull(PrivateMCSecondPerson.August);
                record.September = ZeroIfNull(PrivateMCFirstPerson.September) + ZeroIfNull(PrivateMCSecondPerson.September);
                record.October = ZeroIfNull(PrivateMCFirstPerson.October) + ZeroIfNull(PrivateMCSecondPerson.October);
                record.November = ZeroIfNull(PrivateMCFirstPerson.November) + ZeroIfNull(PrivateMCSecondPerson.November);
                record.December = ZeroIfNull(PrivateMCFirstPerson.December) + ZeroIfNull(PrivateMCSecondPerson.December);
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }
        public OccupancyRecord EndingAvgPersonOccupancyVarianceFromBudget 
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord();
                record.January = MemorySupportActual.EndingAveragePersonOccupancy.January ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.January) - ZeroIfNull(EndingAveragePersonOccupancy.January);
                record.February = MemorySupportActual.EndingAveragePersonOccupancy.February ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.February) - ZeroIfNull(EndingAveragePersonOccupancy.February);
                record.March = MemorySupportActual.EndingAveragePersonOccupancy.March ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.March) - ZeroIfNull(EndingAveragePersonOccupancy.March);
                record.April = MemorySupportActual.EndingAveragePersonOccupancy.April ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.April) - ZeroIfNull(EndingAveragePersonOccupancy.April);
                record.May = MemorySupportActual.EndingAveragePersonOccupancy.May ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.May) - ZeroIfNull(EndingAveragePersonOccupancy.May);
                record.June = MemorySupportActual.EndingAveragePersonOccupancy.June ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.June) - ZeroIfNull(EndingAveragePersonOccupancy.June);
                record.July = MemorySupportActual.EndingAveragePersonOccupancy.July ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.July) - ZeroIfNull(EndingAveragePersonOccupancy.July);
                record.August = MemorySupportActual.EndingAveragePersonOccupancy.August ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.August) - ZeroIfNull(EndingAveragePersonOccupancy.August);
                record.September = MemorySupportActual.EndingAveragePersonOccupancy.September ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.September) - ZeroIfNull(EndingAveragePersonOccupancy.September);
                record.October = MemorySupportActual.EndingAveragePersonOccupancy.October ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.October) - ZeroIfNull(EndingAveragePersonOccupancy.October);
                record.November = MemorySupportActual.EndingAveragePersonOccupancy.November ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.November) - ZeroIfNull(EndingAveragePersonOccupancy.November);
                record.December = MemorySupportActual.EndingAveragePersonOccupancy.December ?? ZeroIfNull(MemorySupportActual.EndingAveragePersonOccupancy.December) - ZeroIfNull(EndingAveragePersonOccupancy.December);
                return record;
            }
        }

    }
}

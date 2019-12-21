using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFAssistedLivingBudget : OccupancyRecordsContainer
    {
        public IKFAssistedLivingActual AssistedLivingActual { get;  set; }
        public OccupancyRecord AverageLevelOne { get; set; }
        public OccupancyRecord AverageLevelTwo { get; set; }
        public OccupancyRecord AverageLevelThree { get; set; }
        public OccupancyRecord AverageSecondPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {

                OccupancyRecord record = new OccupancyRecord
                {
                    January = ZeroIfNull(AverageLevelOne.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageLevelTwo.January),
                    February = ZeroIfNull(AverageLevelOne.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageLevelTwo.February),
                    March = ZeroIfNull(AverageLevelOne.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageLevelTwo.March),
                    April = ZeroIfNull(AverageLevelOne.April) + ZeroIfNull(AverageLevelTwo.April) + ZeroIfNull(AverageLevelTwo.April),
                    May = ZeroIfNull(AverageLevelOne.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageLevelTwo.May),
                    June = ZeroIfNull(AverageLevelOne.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageLevelTwo.June),
                    July = ZeroIfNull(AverageLevelOne.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageLevelTwo.July),
                    August = ZeroIfNull(AverageLevelOne.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageLevelTwo.August),
                    September = ZeroIfNull(AverageLevelOne.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageLevelTwo.September),
                    October = ZeroIfNull(AverageLevelOne.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageLevelTwo.October),
                    November = ZeroIfNull(AverageLevelOne.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageLevelTwo.November),
                    December = ZeroIfNull(AverageLevelOne.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageLevelTwo.December)
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
                    January = ZeroIfNull(AverageLevelOne.January) + ZeroIfNull(AverageLevelTwo.January) + ZeroIfNull(AverageLevelThree.January) + ZeroIfNull(AverageSecondPerson.January),
                    February = ZeroIfNull(AverageLevelOne.February) + ZeroIfNull(AverageLevelTwo.February) + ZeroIfNull(AverageLevelThree.February) + ZeroIfNull(AverageSecondPerson.February),
                    March = ZeroIfNull(AverageLevelOne.March) + ZeroIfNull(AverageLevelTwo.March) + ZeroIfNull(AverageLevelThree.March) + ZeroIfNull(AverageSecondPerson.March),
                    April = ZeroIfNull(AverageLevelOne.April) + ZeroIfNull(AverageLevelTwo.April) + ZeroIfNull(AverageLevelThree.April) + ZeroIfNull(AverageSecondPerson.April),
                    May = ZeroIfNull(AverageLevelOne.May) + ZeroIfNull(AverageLevelTwo.May) + ZeroIfNull(AverageLevelThree.May) + ZeroIfNull(AverageSecondPerson.May),
                    June = ZeroIfNull(AverageLevelOne.June) + ZeroIfNull(AverageLevelTwo.June) + ZeroIfNull(AverageLevelThree.June) + ZeroIfNull(AverageSecondPerson.June),
                    July = ZeroIfNull(AverageLevelOne.July) + ZeroIfNull(AverageLevelTwo.July) + ZeroIfNull(AverageLevelThree.July) + ZeroIfNull(AverageSecondPerson.July),
                    August = ZeroIfNull(AverageLevelOne.August) + ZeroIfNull(AverageLevelTwo.August) + ZeroIfNull(AverageLevelThree.August) + ZeroIfNull(AverageSecondPerson.August),
                    September = ZeroIfNull(AverageLevelOne.September) + ZeroIfNull(AverageLevelTwo.September) + ZeroIfNull(AverageLevelThree.September) + ZeroIfNull(AverageSecondPerson.September),
                    October = ZeroIfNull(AverageLevelOne.October) + ZeroIfNull(AverageLevelTwo.October) + ZeroIfNull(AverageLevelThree.October) + ZeroIfNull(AverageSecondPerson.October),
                    November = ZeroIfNull(AverageLevelOne.November) + ZeroIfNull(AverageLevelTwo.November) + ZeroIfNull(AverageLevelThree.November) + ZeroIfNull(AverageSecondPerson.November),
                    December = ZeroIfNull(AverageLevelOne.December) + ZeroIfNull(AverageLevelTwo.December) + ZeroIfNull(AverageLevelThree.December) + ZeroIfNull(AverageSecondPerson.December)
                };
                record.TotalOrAverage = record.CalculateAverageValue();
                return record;
            }
        }

        //record.January = Actual.EndingAveragePersonOccupancy.January ?? Actual.EndingAveragePersonOccupancy.January - ZeroIfNull(EndingAveragePersonOccupancy);
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

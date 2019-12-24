using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFAssistedLivingBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _endingAverageOccupancy;
        private OccupancyRecord _endingAverageOccupancyVarianceFromBudget;
        private OccupancyRecord _endingAveragePersonOccupancy;
        private OccupancyRecord _endingAveragePersonOccupancyVarianceFromBudget;

        public IKFAssistedLivingActual AssistedLivingActual { get;  set; }
        public OccupancyRecord AverageLevelOne { get; set; }
        public OccupancyRecord AverageLevelTwo { get; set; }
        public OccupancyRecord AverageLevelThree { get; set; }
        public OccupancyRecord AverageSecondPerson { get; set; }
        public OccupancyRecord EndingAverageOccupancy 
        {
            get
            {
                if (_endingAverageOccupancy == null)
                {

                    _endingAverageOccupancy = new OccupancyRecord
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
                    _endingAverageOccupancy.TotalOrAverage = _endingAverageOccupancy.CalculateAverageValue();
                }
                return _endingAverageOccupancy;
            }
        }

        public OccupancyRecord EndingAverageOccupancyVarianceFromBudget 
        { 
            get 
            {
                if (_endingAverageOccupancyVarianceFromBudget == null)
                {
                    _endingAverageOccupancyVarianceFromBudget = new OccupancyRecord
                    {
                        January = AssistedLivingActual.EndingAverageOccupancy.January.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.January) - ZeroIfNull(EndingAverageOccupancy.January) : (float?)null,
                        February = AssistedLivingActual.EndingAverageOccupancy.February.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.February) - ZeroIfNull(EndingAverageOccupancy.February) : (float?)null,
                        March = AssistedLivingActual.EndingAverageOccupancy.March.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.March) - ZeroIfNull(EndingAverageOccupancy.March) : (float?)null,
                        April = AssistedLivingActual.EndingAverageOccupancy.April.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.April) - ZeroIfNull(EndingAverageOccupancy.April) : (float?)null,
                        May = AssistedLivingActual.EndingAverageOccupancy.May.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.May) - ZeroIfNull(EndingAverageOccupancy.May) : (float?)null,
                        June = AssistedLivingActual.EndingAverageOccupancy.June.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.June) - ZeroIfNull(EndingAverageOccupancy.June) : (float?)null,
                        July = AssistedLivingActual.EndingAverageOccupancy.July.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.July) - ZeroIfNull(EndingAverageOccupancy.July) : (float?)null,
                        August = AssistedLivingActual.EndingAverageOccupancy.August.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.August) - ZeroIfNull(EndingAverageOccupancy.August) : (float?)null,
                        September = AssistedLivingActual.EndingAverageOccupancy.September.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.September) - ZeroIfNull(EndingAverageOccupancy.September) : (float?)null,
                        October = AssistedLivingActual.EndingAverageOccupancy.October.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.October) - ZeroIfNull(EndingAverageOccupancy.October) : (float?)null,
                        November = AssistedLivingActual.EndingAverageOccupancy.November.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.November) - ZeroIfNull(EndingAverageOccupancy.November) : (float?)null,
                        December = AssistedLivingActual.EndingAverageOccupancy.December.HasValue ? ZeroIfNull(AssistedLivingActual.EndingAverageOccupancy.December) - ZeroIfNull(EndingAverageOccupancy.December) : (float?)null
                    };
                }
                return _endingAverageOccupancyVarianceFromBudget;
            }
        }

        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                if (_endingAveragePersonOccupancy == null)
                {
                    _endingAveragePersonOccupancy = new OccupancyRecord
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
                    _endingAveragePersonOccupancy.TotalOrAverage = _endingAveragePersonOccupancy.CalculateAverageValue();
                }
                return _endingAveragePersonOccupancy;
            }
        }

        public OccupancyRecord EndingAveragePersonOccupancyVarianceFromBudget
        {
            get
            {
                if (_endingAveragePersonOccupancyVarianceFromBudget == null)
                {
                    _endingAveragePersonOccupancyVarianceFromBudget = new OccupancyRecord
                    {
                        January = AssistedLivingActual.EndingAveragePersonOccupancy.January.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.January - ZeroIfNull(EndingAveragePersonOccupancy.January) : (float?)null,
                        February = AssistedLivingActual.EndingAveragePersonOccupancy.February.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.February - ZeroIfNull(EndingAveragePersonOccupancy.February) : (float?)null,
                        March = AssistedLivingActual.EndingAveragePersonOccupancy.March.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.March - ZeroIfNull(EndingAveragePersonOccupancy.March) : (float?)null,
                        April = AssistedLivingActual.EndingAveragePersonOccupancy.April.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.April - ZeroIfNull(EndingAveragePersonOccupancy.April) : (float?)null,
                        May = AssistedLivingActual.EndingAveragePersonOccupancy.May.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.May - ZeroIfNull(EndingAveragePersonOccupancy.May) : (float?)null,
                        June = AssistedLivingActual.EndingAveragePersonOccupancy.June.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.June - ZeroIfNull(EndingAveragePersonOccupancy.June) : (float?)null,
                        July = AssistedLivingActual.EndingAveragePersonOccupancy.July.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.July - ZeroIfNull(EndingAveragePersonOccupancy.July) : (float?)null,
                        August = AssistedLivingActual.EndingAveragePersonOccupancy.August.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.August - ZeroIfNull(EndingAveragePersonOccupancy.August) : (float?)null,
                        September = AssistedLivingActual.EndingAveragePersonOccupancy.September.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.September - ZeroIfNull(EndingAveragePersonOccupancy.September) : (float?)null,
                        October = AssistedLivingActual.EndingAveragePersonOccupancy.October.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.October - ZeroIfNull(EndingAveragePersonOccupancy.October) : (float?)null,
                        November = AssistedLivingActual.EndingAveragePersonOccupancy.November.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.November - ZeroIfNull(EndingAveragePersonOccupancy.November) : (float?)null,
                        December = AssistedLivingActual.EndingAveragePersonOccupancy.December.HasValue ? AssistedLivingActual.EndingAveragePersonOccupancy.December - ZeroIfNull(EndingAveragePersonOccupancy.December) : (float?)null
                    };
                    _endingAveragePersonOccupancyVarianceFromBudget.TotalOrAverage = _endingAveragePersonOccupancyVarianceFromBudget.CalculateAverageValue();
                }
                return _endingAveragePersonOccupancyVarianceFromBudget;
            }
        }
    }
}

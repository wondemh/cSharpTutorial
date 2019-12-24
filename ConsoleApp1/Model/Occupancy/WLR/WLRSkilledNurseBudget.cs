using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class WLRSkilledNurseBudget :OccupancyRecordsContainer
    {
        private OccupancyRecord _averageLCFirstVarianceFromBudget;
        private OccupancyRecord _averageLCSecondVarianceFromBudget;
        private OccupancyRecord _memoryCareVarianceFromBudget;
        private OccupancyRecord _ffsDirectAdmitVarianceFromBudget;
        private OccupancyRecord _medicareVarianceFromBudget;
        private OccupancyRecord _medicaidVarianceFromBudget;
        private OccupancyRecord _totalOccupancy;
        private OccupancyRecord _totalOccupancyVarianceFromBudget;

        public WLRSkilledNurseActual SkilledNurseActual { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCFirstVarianceFromBudget
        {
            get
            {
                if (_averageLCFirstVarianceFromBudget == null)
                {
                    _averageLCFirstVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.AverageLCFirst.January.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.January) - ZeroIfNull(AverageLCFirst.January) : (float?)null,
                        February = SkilledNurseActual.AverageLCFirst.February.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.February) - ZeroIfNull(AverageLCFirst.February) : (float?)null,
                        March = SkilledNurseActual.AverageLCFirst.March.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.March) - ZeroIfNull(AverageLCFirst.March) : (float?)null,
                        April = SkilledNurseActual.AverageLCFirst.April.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.April) - ZeroIfNull(AverageLCFirst.April) : (float?)null,
                        May = SkilledNurseActual.AverageLCFirst.May.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.May) - ZeroIfNull(AverageLCFirst.May) : (float?)null,
                        June = SkilledNurseActual.AverageLCFirst.June.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.June) - ZeroIfNull(AverageLCFirst.June) : (float?)null,
                        July = SkilledNurseActual.AverageLCFirst.July.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.July) - ZeroIfNull(AverageLCFirst.July) : (float?)null,
                        August = SkilledNurseActual.AverageLCFirst.August.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.August) - ZeroIfNull(AverageLCFirst.August) : (float?)null,
                        September = SkilledNurseActual.AverageLCFirst.September.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.September) - ZeroIfNull(AverageLCFirst.September) : (float?)null,
                        October = SkilledNurseActual.AverageLCFirst.October.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.October) - ZeroIfNull(AverageLCFirst.October) : (float?)null,
                        November = SkilledNurseActual.AverageLCFirst.November.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.November) - ZeroIfNull(AverageLCFirst.November) : (float?)null,
                        December = SkilledNurseActual.AverageLCFirst.December.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCFirst.December) - ZeroIfNull(AverageLCFirst.December) : (float?)null
                    };
                    _averageLCFirstVarianceFromBudget.TotalOrAverage = _averageLCFirstVarianceFromBudget.CalculateAverageValue();
                }
                return _averageLCFirstVarianceFromBudget;
            }
        }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord AverageLCSecondVarianceFromBudget
        {
            get
            {
                if (_averageLCSecondVarianceFromBudget == null)
                {
                    _averageLCSecondVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.AverageLCSecond.January.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.January) - ZeroIfNull(AverageLCSecond.January) : (float?)null,
                        February = SkilledNurseActual.AverageLCSecond.February.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.February) - ZeroIfNull(AverageLCSecond.February) : (float?)null,
                        March = SkilledNurseActual.AverageLCSecond.March.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.March) - ZeroIfNull(AverageLCSecond.March) : (float?)null,
                        April = SkilledNurseActual.AverageLCSecond.April.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.April) - ZeroIfNull(AverageLCSecond.April) : (float?)null,
                        May = SkilledNurseActual.AverageLCSecond.May.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.May) - ZeroIfNull(AverageLCSecond.May) : (float?)null,
                        June = SkilledNurseActual.AverageLCSecond.June.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.June) - ZeroIfNull(AverageLCSecond.June) : (float?)null,
                        July = SkilledNurseActual.AverageLCSecond.July.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.July) - ZeroIfNull(AverageLCSecond.July) : (float?)null,
                        August = SkilledNurseActual.AverageLCSecond.August.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.August) - ZeroIfNull(AverageLCSecond.August) : (float?)null,
                        September = SkilledNurseActual.AverageLCSecond.September.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.September) - ZeroIfNull(AverageLCSecond.September) : (float?)null,
                        October = SkilledNurseActual.AverageLCSecond.October.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.October) - ZeroIfNull(AverageLCSecond.October) : (float?)null,
                        November = SkilledNurseActual.AverageLCSecond.November.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.November) - ZeroIfNull(AverageLCSecond.November) : (float?)null,
                        December = SkilledNurseActual.AverageLCSecond.December.HasValue ? ZeroIfNull(SkilledNurseActual.AverageLCSecond.December) - ZeroIfNull(AverageLCSecond.December) : (float?)null
                    };
                    _averageLCSecondVarianceFromBudget.TotalOrAverage = _averageLCSecondVarianceFromBudget.CalculateAverageValue();
                }
                return _averageLCSecondVarianceFromBudget;
            }
        }
        public OccupancyRecord MemoryCare { get; set; }
        public OccupancyRecord MemoryCareVarianceFromBudget
        {
            get
            {
                if (_memoryCareVarianceFromBudget == null)
                {
                    _memoryCareVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.AverageMemoryCare.January.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.January) - ZeroIfNull(MemoryCare.January) : (float?)null,
                        February = SkilledNurseActual.AverageMemoryCare.February.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.February) - ZeroIfNull(MemoryCare.February) : (float?)null,
                        March = SkilledNurseActual.AverageMemoryCare.March.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.March) - ZeroIfNull(MemoryCare.March) : (float?)null,
                        April = SkilledNurseActual.AverageMemoryCare.April.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.April) - ZeroIfNull(MemoryCare.April) : (float?)null,
                        May = SkilledNurseActual.AverageMemoryCare.May.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.May) - ZeroIfNull(MemoryCare.May) : (float?)null,
                        June = SkilledNurseActual.AverageMemoryCare.June.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.June) - ZeroIfNull(MemoryCare.June) : (float?)null,
                        July = SkilledNurseActual.AverageMemoryCare.July.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.July) - ZeroIfNull(MemoryCare.July) : (float?)null,
                        August = SkilledNurseActual.AverageMemoryCare.August.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.August) - ZeroIfNull(MemoryCare.August) : (float?)null,
                        September = SkilledNurseActual.AverageMemoryCare.September.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.September) - ZeroIfNull(MemoryCare.September) : (float?)null,
                        October = SkilledNurseActual.AverageMemoryCare.October.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.October) - ZeroIfNull(MemoryCare.October) : (float?)null,
                        November = SkilledNurseActual.AverageMemoryCare.November.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.November) - ZeroIfNull(MemoryCare.November) : (float?)null,
                        December = SkilledNurseActual.AverageMemoryCare.December.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMemoryCare.December) - ZeroIfNull(MemoryCare.December) : (float?)null
                    };
                    _memoryCareVarianceFromBudget.TotalOrAverage = _memoryCareVarianceFromBudget.CalculateAverageValue();
                }
                return _memoryCareVarianceFromBudget;
            }
        }
        public OccupancyRecord FFSDirectAdmit { get; set; }
        public OccupancyRecord FFSDirectAdmitVarianceFromBudget
        {
            get
            {
                if (_ffsDirectAdmitVarianceFromBudget == null)
                {
                    _ffsDirectAdmitVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.FFSDirectAdmit.January.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.January) - ZeroIfNull(FFSDirectAdmit.January) : (float?)null,
                        February = SkilledNurseActual.FFSDirectAdmit.February.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.February) - ZeroIfNull(FFSDirectAdmit.February) : (float?)null,
                        March = SkilledNurseActual.FFSDirectAdmit.March.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.March) - ZeroIfNull(FFSDirectAdmit.March) : (float?)null,
                        April = SkilledNurseActual.FFSDirectAdmit.April.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.April) - ZeroIfNull(FFSDirectAdmit.April) : (float?)null,
                        May = SkilledNurseActual.FFSDirectAdmit.May.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.May) - ZeroIfNull(FFSDirectAdmit.May) : (float?)null,
                        June = SkilledNurseActual.FFSDirectAdmit.June.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.June) - ZeroIfNull(FFSDirectAdmit.June) : (float?)null,
                        July = SkilledNurseActual.FFSDirectAdmit.July.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.July) - ZeroIfNull(FFSDirectAdmit.July) : (float?)null,
                        August = SkilledNurseActual.FFSDirectAdmit.August.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.August) - ZeroIfNull(FFSDirectAdmit.August) : (float?)null,
                        September = SkilledNurseActual.FFSDirectAdmit.September.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.September) - ZeroIfNull(FFSDirectAdmit.September) : (float?)null,
                        October = SkilledNurseActual.FFSDirectAdmit.October.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.October) - ZeroIfNull(FFSDirectAdmit.October) : (float?)null,
                        November = SkilledNurseActual.FFSDirectAdmit.November.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.November) - ZeroIfNull(FFSDirectAdmit.November) : (float?)null,
                        December = SkilledNurseActual.FFSDirectAdmit.December.HasValue ? ZeroIfNull(SkilledNurseActual.FFSDirectAdmit.December) - ZeroIfNull(FFSDirectAdmit.December) : (float?)null
                    };
                    _ffsDirectAdmitVarianceFromBudget.TotalOrAverage = _ffsDirectAdmitVarianceFromBudget.CalculateAverageValue();
                }
                return _ffsDirectAdmitVarianceFromBudget;
            }
        }
        public OccupancyRecord Medicare { get; set; }
        public OccupancyRecord MedicareVarianceFromBudget
        {
            get
            {
                if (_medicareVarianceFromBudget == null)
                {
                    _medicareVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.AverageMedicare.January.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.January) - ZeroIfNull(Medicare.January) : (float?)null,
                        February = SkilledNurseActual.AverageMedicare.February.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.February) - ZeroIfNull(Medicare.February) : (float?)null,
                        March = SkilledNurseActual.AverageMedicare.March.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.March) - ZeroIfNull(Medicare.March) : (float?)null,
                        April = SkilledNurseActual.AverageMedicare.April.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.April) - ZeroIfNull(Medicare.April) : (float?)null,
                        May = SkilledNurseActual.AverageMedicare.May.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.May) - ZeroIfNull(Medicare.May) : (float?)null,
                        June = SkilledNurseActual.AverageMedicare.June.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.June) - ZeroIfNull(Medicare.June) : (float?)null,
                        July = SkilledNurseActual.AverageMedicare.July.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.July) - ZeroIfNull(Medicare.July) : (float?)null,
                        August = SkilledNurseActual.AverageMedicare.August.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.August) - ZeroIfNull(Medicare.August) : (float?)null,
                        September = SkilledNurseActual.AverageMedicare.September.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.September) - ZeroIfNull(Medicare.September) : (float?)null,
                        October = SkilledNurseActual.AverageMedicare.October.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.October) - ZeroIfNull(Medicare.October) : (float?)null,
                        November = SkilledNurseActual.AverageMedicare.November.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.November) - ZeroIfNull(Medicare.November) : (float?)null,
                        December = SkilledNurseActual.AverageMedicare.December.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicare.December) - ZeroIfNull(Medicare.December) : (float?)null
                    };
                    _medicareVarianceFromBudget.TotalOrAverage = _medicareVarianceFromBudget.CalculateAverageValue();
                }
                return _medicareVarianceFromBudget;
            }
        }
        public OccupancyRecord Medicaid { get; set; }
        public OccupancyRecord MedicaidVarianceFromBudget
        {
            get
            {
                if (_medicaidVarianceFromBudget == null)
                {
                    _medicaidVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.AverageMedicaid.January.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.January) - ZeroIfNull(Medicaid.January) : (float?)null,
                        February = SkilledNurseActual.AverageMedicaid.February.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.February) - ZeroIfNull(Medicaid.February) : (float?)null,
                        March = SkilledNurseActual.AverageMedicaid.March.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.March) - ZeroIfNull(Medicaid.March) : (float?)null,
                        April = SkilledNurseActual.AverageMedicaid.April.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.April) - ZeroIfNull(Medicaid.April) : (float?)null,
                        May = SkilledNurseActual.AverageMedicaid.May.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.May) - ZeroIfNull(Medicaid.May) : (float?)null,
                        June = SkilledNurseActual.AverageMedicaid.June.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.June) - ZeroIfNull(Medicaid.June) : (float?)null,
                        July = SkilledNurseActual.AverageMedicaid.July.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.July) - ZeroIfNull(Medicaid.July) : (float?)null,
                        August = SkilledNurseActual.AverageMedicaid.August.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.August) - ZeroIfNull(Medicaid.August) : (float?)null,
                        September = SkilledNurseActual.AverageMedicaid.September.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.September) - ZeroIfNull(Medicaid.September) : (float?)null,
                        October = SkilledNurseActual.AverageMedicaid.October.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.October) - ZeroIfNull(Medicaid.October) : (float?)null,
                        November = SkilledNurseActual.AverageMedicaid.November.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.November) - ZeroIfNull(Medicaid.November) : (float?)null,
                        December = SkilledNurseActual.AverageMedicaid.December.HasValue ? ZeroIfNull(SkilledNurseActual.AverageMedicaid.December) - ZeroIfNull(Medicaid.December) : (float?)null
                    };
                    _medicaidVarianceFromBudget.TotalOrAverage = _medicaidVarianceFromBudget.CalculateAverageValue();
                }
                return _medicaidVarianceFromBudget;
            }
        }
        public OccupancyRecord TotalOccupancy
        {
            get
            {
                if (_totalOccupancy == null)
                {
                    _totalOccupancy = new OccupancyRecord
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
                    _totalOccupancy.TotalOrAverage = _totalOccupancy.CalculateAverageValue();
                }
                return _totalOccupancy;
            }
        }
        public OccupancyRecord TotalOccupancyVarianceFromBudget
        {
            get
            {
                if (_totalOccupancyVarianceFromBudget == null)
                {
                    _totalOccupancyVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.TotalAverageOccupancy.January.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.January) - ZeroIfNull(TotalOccupancy.January) : (float?)null,
                        February = SkilledNurseActual.TotalAverageOccupancy.February.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.February) - ZeroIfNull(TotalOccupancy.February) : (float?)null,
                        March = SkilledNurseActual.TotalAverageOccupancy.March.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.March) - ZeroIfNull(TotalOccupancy.March) : (float?)null,
                        April = SkilledNurseActual.TotalAverageOccupancy.April.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.April) - ZeroIfNull(TotalOccupancy.April) : (float?)null,
                        May = SkilledNurseActual.TotalAverageOccupancy.May.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.May) - ZeroIfNull(TotalOccupancy.May) : (float?)null,
                        June = SkilledNurseActual.TotalAverageOccupancy.June.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.June) - ZeroIfNull(TotalOccupancy.June) : (float?)null,
                        July = SkilledNurseActual.TotalAverageOccupancy.July.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.July) - ZeroIfNull(TotalOccupancy.July) : (float?)null,
                        August = SkilledNurseActual.TotalAverageOccupancy.August.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.August) - ZeroIfNull(TotalOccupancy.August) : (float?)null,
                        September = SkilledNurseActual.TotalAverageOccupancy.September.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.September) - ZeroIfNull(TotalOccupancy.September) : (float?)null,
                        October = SkilledNurseActual.TotalAverageOccupancy.October.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.October) - ZeroIfNull(TotalOccupancy.October) : (float?)null,
                        November = SkilledNurseActual.TotalAverageOccupancy.November.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.November) - ZeroIfNull(TotalOccupancy.November) : (float?)null,
                        December = SkilledNurseActual.TotalAverageOccupancy.December.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.December) - ZeroIfNull(TotalOccupancy.December) : (float?)null,
                        TotalOrAverage = (float)Math.Round(Divide(TotalOccupancy.TotalOrAverage, SkilledNurseActual.BedsAvailable.TotalOrAverage), 1)
                    };
                }
                return _totalOccupancyVarianceFromBudget;
            }
        }
    }
}

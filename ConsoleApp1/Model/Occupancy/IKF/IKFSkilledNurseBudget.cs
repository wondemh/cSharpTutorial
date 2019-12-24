using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IKFSkilledNurseBudget : OccupancyRecordsContainer
    {
        private OccupancyRecord _privatePayVarianceFromBudget;
        private OccupancyRecord _privateMedicaidPendingVarianceFromBudget;
        private OccupancyRecord _totalOccupancyVarianceFromBudget;
        private OccupancyRecord _medicareVarianceFromBudget;
        private OccupancyRecord _medicaidVarianceFromBudget;
        private OccupancyRecord _totalOccupancy;

        public IKFSkilledNurseActual SkilledNurseActual { get; set; }
        public OccupancyRecord PrivatePay { get; set; }
        public OccupancyRecord Medicare { get; set; }
        public OccupancyRecord Medicaid { get; set; }

        public OccupancyRecord PrivatePayVarianceFromBudget
        {
            get
            {
                if (_privatePayVarianceFromBudget == null)
                {
                    _privatePayVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.AveragePrivatePay.January.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.January) - ZeroIfNull(PrivatePay.January) : (float?)null,
                        February = SkilledNurseActual.AveragePrivatePay.February.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.February) - ZeroIfNull(PrivatePay.February) : (float?)null,
                        March = SkilledNurseActual.AveragePrivatePay.March.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.March) - ZeroIfNull(PrivatePay.March) : (float?)null,
                        April = SkilledNurseActual.AveragePrivatePay.April.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.April) - ZeroIfNull(PrivatePay.April) : (float?)null,
                        May = SkilledNurseActual.AveragePrivatePay.May.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.May) - ZeroIfNull(PrivatePay.May) : (float?)null,
                        June = SkilledNurseActual.AveragePrivatePay.June.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.June) - ZeroIfNull(PrivatePay.June) : (float?)null,
                        July = SkilledNurseActual.AveragePrivatePay.July.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.July) - ZeroIfNull(PrivatePay.July) : (float?)null,
                        August = SkilledNurseActual.AveragePrivatePay.August.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.August) - ZeroIfNull(PrivatePay.August) : (float?)null,
                        September = SkilledNurseActual.AveragePrivatePay.September.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.September) - ZeroIfNull(PrivatePay.September) : (float?)null,
                        October = SkilledNurseActual.AveragePrivatePay.October.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.October) - ZeroIfNull(PrivatePay.October) : (float?)null,
                        November = SkilledNurseActual.AveragePrivatePay.November.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.November) - ZeroIfNull(PrivatePay.November) : (float?)null,
                        December = SkilledNurseActual.AveragePrivatePay.December.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivatePay.December) - ZeroIfNull(PrivatePay.December) : (float?)null
                    };
                    _privatePayVarianceFromBudget.TotalOrAverage = _privatePayVarianceFromBudget.CalculateAverageValue();
                }
                return _privatePayVarianceFromBudget;
            }
        }
        public OccupancyRecord PrivateMedicaidPending { get; set; }

        public OccupancyRecord PrivateMedicaidPendingVarianceFromBudget 
        {
            get
            {
                if (_privateMedicaidPendingVarianceFromBudget == null)
                {
                    _privateMedicaidPendingVarianceFromBudget = new OccupancyRecord
                    {
                        January = SkilledNurseActual.AveragePrivateMedicaidPending.January.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.January) - ZeroIfNull(PrivateMedicaidPending.January) : (float?)null,
                        February = SkilledNurseActual.AveragePrivateMedicaidPending.February.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.February) - ZeroIfNull(PrivateMedicaidPending.February) : (float?)null,
                        March = SkilledNurseActual.AveragePrivateMedicaidPending.March.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.March) - ZeroIfNull(PrivateMedicaidPending.March) : (float?)null,
                        April = SkilledNurseActual.AveragePrivateMedicaidPending.April.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.April) - ZeroIfNull(PrivateMedicaidPending.April) : (float?)null,
                        May = SkilledNurseActual.AveragePrivateMedicaidPending.May.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.May) - ZeroIfNull(PrivateMedicaidPending.May) : (float?)null,
                        June = SkilledNurseActual.AveragePrivateMedicaidPending.June.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.June) - ZeroIfNull(PrivateMedicaidPending.June) : (float?)null,
                        July = SkilledNurseActual.AveragePrivateMedicaidPending.July.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.July) - ZeroIfNull(PrivateMedicaidPending.July) : (float?)null,
                        August = SkilledNurseActual.AveragePrivateMedicaidPending.August.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.August) - ZeroIfNull(PrivateMedicaidPending.August) : (float?)null,
                        September = SkilledNurseActual.AveragePrivateMedicaidPending.September.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.September) - ZeroIfNull(PrivateMedicaidPending.September) : (float?)null,
                        October = SkilledNurseActual.AveragePrivateMedicaidPending.October.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.October) - ZeroIfNull(PrivateMedicaidPending.October) : (float?)null,
                        November = SkilledNurseActual.AveragePrivateMedicaidPending.November.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.November) - ZeroIfNull(PrivateMedicaidPending.November) : (float?)null,
                        December = SkilledNurseActual.AveragePrivateMedicaidPending.December.HasValue ? ZeroIfNull(SkilledNurseActual.AveragePrivateMedicaidPending.December) - ZeroIfNull(PrivateMedicaidPending.December) : (float?)null
                    };
                    _privateMedicaidPendingVarianceFromBudget.TotalOrAverage = _privateMedicaidPendingVarianceFromBudget.CalculateAverageValue();
                }
                return _privateMedicaidPendingVarianceFromBudget;
            }
        }

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
                        December = SkilledNurseActual.TotalAverageOccupancy.December.HasValue ? ZeroIfNull(SkilledNurseActual.TotalAverageOccupancy.December) - ZeroIfNull(TotalOccupancy.December) : (float?)null
                    };
                    _totalOccupancyVarianceFromBudget.TotalOrAverage = _totalOccupancyVarianceFromBudget.CalculateAverageValue();
                }
                return _totalOccupancyVarianceFromBudget;
            }
        }
    }
}

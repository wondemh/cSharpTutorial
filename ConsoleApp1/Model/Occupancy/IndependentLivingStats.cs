using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class IndependentLivingStats
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord BeginningOccupancy { get; set; }
        public OccupancyRecord MoveIns { get; set; }
        public OccupancyRecord MoveOuts { get; set; }
        public OccupancyRecord Transfers { get; set; }
        //public OccupancyRecord EndingOccupancy { get; set; }
        public OccupancyRecord EndingOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    JanuaryValue = BeginningOccupancy.JanuaryValue + MoveIns.JanuaryValue + MoveOuts.JanuaryValue + Transfers.JanuaryValue,
                    FebruaryValue = BeginningOccupancy.FebruaryValue + MoveIns.FebruaryValue + MoveOuts.FebruaryValue + Transfers.FebruaryValue,
                    MarchValue = BeginningOccupancy.MarchValue + MoveIns.MarchValue + MoveOuts.MarchValue + Transfers.MarchValue,
                    AprilValue = BeginningOccupancy.AprilValue + MoveIns.AprilValue + MoveOuts.AprilValue + Transfers.AprilValue,
                    MayValue = BeginningOccupancy.MayValue + MoveIns.MayValue + MoveOuts.MayValue + Transfers.MayValue,
                    JuneValue = BeginningOccupancy.JuneValue + MoveIns.JuneValue + MoveOuts.JuneValue + Transfers.JuneValue,
                    JulyValue = BeginningOccupancy.JulyValue + MoveIns.JulyValue + MoveOuts.JulyValue + Transfers.JulyValue,
                    AugustValue = BeginningOccupancy.AugustValue + MoveIns.AugustValue + MoveOuts.AugustValue + Transfers.AugustValue,
                    SeptemberValue = BeginningOccupancy.SeptemberValue + MoveIns.SeptemberValue + MoveOuts.SeptemberValue + Transfers.SeptemberValue,
                    OctoberValue = BeginningOccupancy.OctoberValue + MoveIns.OctoberValue + MoveOuts.OctoberValue + Transfers.OctoberValue,
                    NovemberValue = BeginningOccupancy.NovemberValue + MoveIns.NovemberValue + MoveOuts.NovemberValue + Transfers.NovemberValue,
                    DecemberValue = BeginningOccupancy.DecemberValue + MoveIns.DecemberValue + MoveOuts.DecemberValue + Transfers.DecemberValue
                };
                record.TotalOrAverageValue = record.CalculateAverageValue();
                return record;
            }
        }

        public OccupancyRecord PercentOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    JanuaryValue = UnitsAvailable.JanuaryValue > 0 ? (float)Math.Round(EndingOccupancy.JanuaryValue / UnitsAvailable.JanuaryValue, 0) : 0,
                    FebruaryValue = UnitsAvailable.FebruaryValue > 0 ? (float)Math.Round(EndingOccupancy.FebruaryValue / UnitsAvailable.FebruaryValue, 0) : 0,
                    MarchValue = UnitsAvailable.MarchValue > 0 ? (float)Math.Round(EndingOccupancy.MarchValue / UnitsAvailable.MarchValue, 0) : 0,
                    AprilValue = UnitsAvailable.AprilValue > 0 ? (float)Math.Round(EndingOccupancy.AprilValue / UnitsAvailable.AprilValue, 0) : 0,
                    MayValue = UnitsAvailable.MayValue > 0 ? (float)Math.Round(EndingOccupancy.MayValue / UnitsAvailable.MayValue, 0) : 0,
                    JuneValue = UnitsAvailable.JuneValue > 0 ? (float)Math.Round(EndingOccupancy.JuneValue / UnitsAvailable.JuneValue, 0) : 0,
                    JulyValue = UnitsAvailable.JulyValue > 0 ? (float)Math.Round(EndingOccupancy.JulyValue / UnitsAvailable.JulyValue, 0) : 0,
                    AugustValue = UnitsAvailable.AugustValue > 0 ? (float)Math.Round(EndingOccupancy.AugustValue / UnitsAvailable.AugustValue, 0) : 0,
                    SeptemberValue = UnitsAvailable.SeptemberValue > 0 ? (float)Math.Round(EndingOccupancy.SeptemberValue / UnitsAvailable.SeptemberValue, 0) : 0,
                    OctoberValue = UnitsAvailable.OctoberValue > 0 ? (float)Math.Round(EndingOccupancy.OctoberValue / UnitsAvailable.OctoberValue, 0) : 0,
                    NovemberValue = UnitsAvailable.NovemberValue > 0 ? (float)Math.Round(EndingOccupancy.NovemberValue / UnitsAvailable.NovemberValue, 0) : 0,
                    DecemberValue = UnitsAvailable.DecemberValue > 0 ? (float)Math.Round(EndingOccupancy.DecemberValue / UnitsAvailable.DecemberValue, 0) : 0
                };
                record.TotalOrAverageValue = UnitsAvailable.TotalOrAverageValue > 0 ? (float)Math.Round(EndingOccupancy.TotalOrAverageValue / UnitsAvailable.TotalOrAverageValue, 0) : 0;
                return record;

            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    JanuaryValue = UnitsAvailable.JanuaryValue - EndingOccupancy.JanuaryValue,
                    FebruaryValue = UnitsAvailable.FebruaryValue - EndingOccupancy.FebruaryValue,
                    MarchValue = UnitsAvailable.MarchValue - EndingOccupancy.MarchValue,
                    AprilValue = UnitsAvailable.AprilValue - EndingOccupancy.AprilValue,
                    MayValue = UnitsAvailable.MayValue - EndingOccupancy.MayValue,
                    JuneValue = UnitsAvailable.JuneValue - EndingOccupancy.JuneValue,
                    JulyValue = UnitsAvailable.JulyValue - EndingOccupancy.JulyValue,
                    AugustValue = UnitsAvailable.AugustValue - EndingOccupancy.AugustValue,
                    SeptemberValue = UnitsAvailable.SeptemberValue - EndingOccupancy.SeptemberValue,
                    OctoberValue = UnitsAvailable.OctoberValue - EndingOccupancy.OctoberValue,
                    NovemberValue = UnitsAvailable.NovemberValue - EndingOccupancy.NovemberValue,
                    DecemberValue = UnitsAvailable.DecemberValue - EndingOccupancy.DecemberValue
                };
                record.TotalOrAverageValue = record.CalculateAverageValue();
                return record;
            }
        }
    }
}

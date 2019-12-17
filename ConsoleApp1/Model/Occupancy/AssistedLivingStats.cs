using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class AssistedLivingStats
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord AverageFFS { get; set; }
        public OccupancyRecord AverageLC { get; set; }
        public OccupancyRecord AverageOccupancy
        {
            get
            {
                if (AverageFFS != null && AverageLC != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        JanuaryValue = AverageFFS.JanuaryValue + AverageLC.JanuaryValue,
                        FebruaryValue = AverageFFS.FebruaryValue + AverageLC.FebruaryValue,
                        MarchValue = AverageFFS.MarchValue + AverageLC.MarchValue,
                        AprilValue = AverageFFS.AprilValue + AverageLC.AprilValue,
                        MayValue = AverageFFS.MayValue + AverageLC.MayValue,
                        JuneValue = AverageFFS.JuneValue + AverageLC.JuneValue,
                        JulyValue = AverageFFS.JulyValue + AverageLC.JulyValue,
                        AugustValue = AverageFFS.AugustValue + AverageLC.AugustValue,
                        SeptemberValue = AverageFFS.SeptemberValue + AverageLC.SeptemberValue,
                        OctoberValue = AverageFFS.OctoberValue + AverageLC.OctoberValue,
                        NovemberValue = AverageFFS.NovemberValue + AverageLC.NovemberValue,
                        DecemberValue = AverageFFS.DecemberValue + AverageLC.DecemberValue
                    };
                    record.TotalOrAverageValue = record.CalculateAverageValue();
                    return record;
                }
                return new OccupancyRecord();
            }
        }

        public OccupancyRecord PercentUnitOccupancy
        {
            get
            {
                if (UnitsAvailable != null && AverageOccupancy != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        JanuaryValue = UnitsAvailable.JanuaryValue > 0 ? (float)Math.Round(AverageOccupancy.JanuaryValue / UnitsAvailable.JanuaryValue, 0) : 0,
                        FebruaryValue = UnitsAvailable.FebruaryValue > 0 ? (float)Math.Round(AverageOccupancy.FebruaryValue / UnitsAvailable.FebruaryValue, 0) : 0,
                        MarchValue = UnitsAvailable.MarchValue > 0 ? (float)Math.Round(AverageOccupancy.MarchValue / UnitsAvailable.MarchValue, 0) : 0,
                        AprilValue = UnitsAvailable.AprilValue > 0 ? (float)Math.Round(AverageOccupancy.AprilValue / UnitsAvailable.AprilValue, 0) : 0,
                        MayValue = UnitsAvailable.MayValue > 0 ? (float)Math.Round(AverageOccupancy.MayValue / UnitsAvailable.MayValue, 0) : 0,
                        JuneValue = UnitsAvailable.JuneValue > 0 ? (float)Math.Round(AverageOccupancy.JuneValue / UnitsAvailable.JuneValue, 0) : 0,
                        JulyValue = UnitsAvailable.JulyValue > 0 ? (float)Math.Round(AverageOccupancy.JulyValue / UnitsAvailable.JulyValue, 0) : 0,
                        AugustValue = UnitsAvailable.AugustValue > 0 ? (float)Math.Round(AverageOccupancy.AugustValue / UnitsAvailable.AugustValue, 0) : 0,
                        SeptemberValue = UnitsAvailable.SeptemberValue > 0 ? (float)Math.Round(AverageOccupancy.SeptemberValue / UnitsAvailable.SeptemberValue, 0) : 0,
                        OctoberValue = UnitsAvailable.OctoberValue > 0 ? (float)Math.Round(AverageOccupancy.OctoberValue / UnitsAvailable.OctoberValue, 0) : 0,
                        NovemberValue = UnitsAvailable.NovemberValue > 0 ? (float)Math.Round(AverageOccupancy.NovemberValue / UnitsAvailable.NovemberValue, 0) : 0,
                        DecemberValue = UnitsAvailable.DecemberValue > 0 ? (float)Math.Round(AverageOccupancy.DecemberValue / UnitsAvailable.DecemberValue, 0) : 0
                    };
                    record.TotalOrAverageValue = UnitsAvailable.TotalOrAverageValue > 0 ? (float)Math.Round(AverageOccupancy.TotalOrAverageValue / UnitsAvailable.TotalOrAverageValue, 0) : 0;
                    return record;
                }
                return new OccupancyRecord();
            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                if (UnitsAvailable != null && AverageOccupancy != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        JanuaryValue = UnitsAvailable.JanuaryValue - AverageOccupancy.JanuaryValue,
                        FebruaryValue = UnitsAvailable.FebruaryValue - AverageOccupancy.FebruaryValue,
                        MarchValue = UnitsAvailable.MarchValue - AverageOccupancy.MarchValue,
                        AprilValue = UnitsAvailable.AprilValue - AverageOccupancy.AprilValue,
                        MayValue = UnitsAvailable.MayValue - AverageOccupancy.MayValue,
                        JuneValue = UnitsAvailable.JuneValue - AverageOccupancy.JuneValue,
                        JulyValue = UnitsAvailable.JulyValue - AverageOccupancy.JulyValue,
                        AugustValue = UnitsAvailable.AugustValue - AverageOccupancy.AugustValue,
                        SeptemberValue = UnitsAvailable.SeptemberValue - AverageOccupancy.SeptemberValue,
                        OctoberValue = UnitsAvailable.OctoberValue - AverageOccupancy.OctoberValue,
                        NovemberValue = UnitsAvailable.NovemberValue - AverageOccupancy.NovemberValue,
                        DecemberValue = UnitsAvailable.DecemberValue - AverageOccupancy.DecemberValue
                    };
                    record.TotalOrAverageValue = record.CalculateAverageValue();
                    return record;
                }
                return new OccupancyRecord();
            }
        }
    }
}

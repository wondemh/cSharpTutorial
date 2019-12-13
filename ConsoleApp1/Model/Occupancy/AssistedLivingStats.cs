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
                    return new OccupancyRecord
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
                }
                return null;
            }
        }

        public OccupancyRecord PercentUnitOccupancy
        {
            get
            {
                if (UnitsAvailable != null && AverageOccupancy != null)
                {
                    return new OccupancyRecord
                    {
                        JanuaryValue = UnitsAvailable.JanuaryValue > 0 ? AverageOccupancy.JanuaryValue / UnitsAvailable.JanuaryValue : 0,
                        FebruaryValue = UnitsAvailable.FebruaryValue > 0 ? AverageOccupancy.FebruaryValue / UnitsAvailable.FebruaryValue : 0,
                        MarchValue = UnitsAvailable.MarchValue > 0 ? AverageOccupancy.MarchValue / UnitsAvailable.MarchValue : 0,
                        AprilValue = UnitsAvailable.AprilValue > 0 ? AverageOccupancy.AprilValue / UnitsAvailable.AprilValue : 0,
                        MayValue = UnitsAvailable.MayValue > 0 ? AverageOccupancy.MayValue / UnitsAvailable.MayValue : 0,
                        JuneValue = UnitsAvailable.JuneValue > 0 ? AverageOccupancy.JuneValue / UnitsAvailable.JuneValue : 0,
                        JulyValue = UnitsAvailable.JulyValue > 0 ? AverageOccupancy.JulyValue / UnitsAvailable.JulyValue : 0,
                        AugustValue = UnitsAvailable.AugustValue > 0 ? AverageOccupancy.AugustValue / UnitsAvailable.AugustValue : 0,
                        SeptemberValue = UnitsAvailable.SeptemberValue > 0 ? AverageOccupancy.SeptemberValue / UnitsAvailable.SeptemberValue : 0,
                        OctoberValue = UnitsAvailable.OctoberValue > 0 ? AverageOccupancy.OctoberValue / UnitsAvailable.OctoberValue : 0,
                        NovemberValue = UnitsAvailable.NovemberValue > 0 ? AverageOccupancy.NovemberValue / UnitsAvailable.NovemberValue : 0,
                        DecemberValue = UnitsAvailable.DecemberValue > 0 ? AverageOccupancy.DecemberValue / UnitsAvailable.DecemberValue : 0
                    };
                }
                return null;
            }
        }

        public OccupancyRecord UnoccupiedUnits
        {
            get
            {
                if (UnitsAvailable != null && AverageOccupancy != null)
                {
                    return new OccupancyRecord
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
                }
                return null;
            }
        }
    }
}

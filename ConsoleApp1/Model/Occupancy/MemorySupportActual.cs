using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class MemorySupportActual
    {
        public OccupancyRecord UnitsAvailable { get; set; }
        public OccupancyRecord LicensedFor { get; set; }
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
                        JanuaryValue = PrivateMCFirstPerson.JanuaryValue + PrivateMCSecondPerson.JanuaryValue,
                        FebruaryValue = PrivateMCFirstPerson.FebruaryValue + PrivateMCSecondPerson.FebruaryValue,
                        MarchValue = PrivateMCFirstPerson.MarchValue + PrivateMCSecondPerson.MarchValue,
                        AprilValue = PrivateMCFirstPerson.AprilValue + PrivateMCSecondPerson.AprilValue,
                        MayValue = PrivateMCFirstPerson.MayValue + PrivateMCSecondPerson.MayValue,
                        JuneValue = PrivateMCFirstPerson.JuneValue + PrivateMCSecondPerson.JuneValue,
                        JulyValue = PrivateMCFirstPerson.JulyValue + PrivateMCSecondPerson.JulyValue,
                        AugustValue = PrivateMCFirstPerson.AugustValue + PrivateMCSecondPerson.AugustValue,
                        SeptemberValue = PrivateMCFirstPerson.SeptemberValue + PrivateMCSecondPerson.SeptemberValue,
                        OctoberValue = PrivateMCFirstPerson.OctoberValue + PrivateMCSecondPerson.OctoberValue,
                        NovemberValue = PrivateMCFirstPerson.NovemberValue + PrivateMCSecondPerson.NovemberValue,
                        DecemberValue = PrivateMCFirstPerson.DecemberValue + PrivateMCSecondPerson.DecemberValue
                    };
                    record.TotalOrAverageValue = record.CalculateAverageValue();
                }
                return new OccupancyRecord();
            }
        }
        public OccupancyRecord PercentAverageUnitOccupancy
        {
            get
            {
                if (EndingAverageOccupancy != null && UnitsAvailable != null)
                {
                    return new OccupancyRecord
                    {
                        JanuaryValue = UnitsAvailable.JanuaryValue > 0 ? (float)Math.Round(EndingAverageOccupancy.JanuaryValue / UnitsAvailable.JanuaryValue, 0) : 0,
                        FebruaryValue = UnitsAvailable.FebruaryValue > 0 ? (float)Math.Round(EndingAverageOccupancy.FebruaryValue / UnitsAvailable.FebruaryValue, 0) : 0,
                        MarchValue = UnitsAvailable.MarchValue > 0 ? (float)Math.Round(EndingAverageOccupancy.MarchValue / UnitsAvailable.MarchValue, 0) : 0,
                        AprilValue = UnitsAvailable.AprilValue > 0 ? (float)Math.Round(EndingAverageOccupancy.AprilValue / UnitsAvailable.AprilValue, 0) : 0,
                        MayValue = UnitsAvailable.MayValue > 0 ? (float)Math.Round(EndingAverageOccupancy.MayValue / UnitsAvailable.MayValue, 0) : 0,
                        JuneValue = UnitsAvailable.JuneValue > 0 ? (float)Math.Round(EndingAverageOccupancy.JuneValue / UnitsAvailable.JuneValue, 0) : 0,
                        JulyValue = UnitsAvailable.JulyValue > 0 ? (float)Math.Round(EndingAverageOccupancy.JulyValue / UnitsAvailable.JulyValue, 0) : 0,
                        AugustValue = UnitsAvailable.AugustValue > 0 ? (float)Math.Round(EndingAverageOccupancy.AugustValue / UnitsAvailable.AugustValue, 0) : 0,
                        SeptemberValue = UnitsAvailable.SeptemberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.SeptemberValue / UnitsAvailable.SeptemberValue, 0) : 0,
                        OctoberValue = UnitsAvailable.OctoberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.OctoberValue / UnitsAvailable.OctoberValue, 0) : 0,
                        NovemberValue = UnitsAvailable.NovemberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.NovemberValue / UnitsAvailable.NovemberValue, 0) : 0,
                        DecemberValue = UnitsAvailable.DecemberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.DecemberValue / UnitsAvailable.DecemberValue, 0) : 0,
                        TotalOrAverageValue = UnitsAvailable.TotalOrAverageValue > 0 ? (float)Math.Round(EndingAverageOccupancy.TotalOrAverageValue / UnitsAvailable.TotalOrAverageValue, 0) : 0
                    };
                }
                return null;
            }
        }

        public OccupancyRecord AverageUnoccupiedUnits
        {
            get
            {
                if (EndingAverageOccupancy != null && UnitsAvailable != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        JanuaryValue = UnitsAvailable.JanuaryValue - EndingAverageOccupancy.JanuaryValue,
                        FebruaryValue = UnitsAvailable.FebruaryValue - EndingAverageOccupancy.FebruaryValue,
                        MarchValue = UnitsAvailable.MarchValue - EndingAverageOccupancy.MarchValue,
                        AprilValue = UnitsAvailable.AprilValue - EndingAverageOccupancy.AprilValue,
                        MayValue = UnitsAvailable.MayValue - EndingAverageOccupancy.MayValue,
                        JuneValue = UnitsAvailable.JuneValue - EndingAverageOccupancy.JuneValue,
                        JulyValue = UnitsAvailable.JulyValue - EndingAverageOccupancy.JulyValue,
                        AugustValue = UnitsAvailable.AugustValue - EndingAverageOccupancy.AugustValue,
                        SeptemberValue = UnitsAvailable.SeptemberValue - EndingAverageOccupancy.SeptemberValue,
                        OctoberValue = UnitsAvailable.OctoberValue - EndingAverageOccupancy.OctoberValue,
                        NovemberValue = UnitsAvailable.NovemberValue - EndingAverageOccupancy.NovemberValue,
                        DecemberValue = UnitsAvailable.DecemberValue - EndingAverageOccupancy.DecemberValue
                    };
                    record.TotalOrAverageValue = record.CalculateAverageValue();
                }
                return new OccupancyRecord();
            }
        }

        public OccupancyRecord EndingAveragePersonOccupancy
        {
            get
            {
                if (PrivateMCFirstPerson != null && PrivateMCSecondPerson != null)
                {
                    OccupancyRecord record = new OccupancyRecord
                    {
                        JanuaryValue = PrivateMCFirstPerson.JanuaryValue + PrivateMCSecondPerson.JanuaryValue,
                        FebruaryValue = PrivateMCFirstPerson.FebruaryValue + PrivateMCSecondPerson.FebruaryValue,
                        MarchValue = PrivateMCFirstPerson.MarchValue + PrivateMCSecondPerson.MarchValue,
                        AprilValue = PrivateMCFirstPerson.AprilValue + PrivateMCSecondPerson.AprilValue,
                        MayValue = PrivateMCFirstPerson.MayValue + PrivateMCSecondPerson.MayValue,
                        JuneValue = PrivateMCFirstPerson.JuneValue + PrivateMCSecondPerson.JuneValue,
                        JulyValue = PrivateMCFirstPerson.JulyValue + PrivateMCSecondPerson.JulyValue,
                        AugustValue = PrivateMCFirstPerson.AugustValue + PrivateMCSecondPerson.AugustValue,
                        SeptemberValue = PrivateMCFirstPerson.SeptemberValue + PrivateMCSecondPerson.SeptemberValue,
                        OctoberValue = PrivateMCFirstPerson.OctoberValue + PrivateMCSecondPerson.OctoberValue,
                        NovemberValue = PrivateMCFirstPerson.NovemberValue + PrivateMCSecondPerson.NovemberValue,
                        DecemberValue = PrivateMCFirstPerson.DecemberValue + PrivateMCSecondPerson.DecemberValue
                    };
                    record.TotalOrAverageValue = record.CalculateAverageValue();
                }
                return new OccupancyRecord();
            }
        }
        public OccupancyRecord PercentLicensedOccupancy
        {
            get
            {
                if (EndingAveragePersonOccupancy != null && LicensedFor != null)
                {
                    return new OccupancyRecord
                    {
                        JanuaryValue = LicensedFor.JanuaryValue > 0 ? (float)Math.Round(EndingAverageOccupancy.JanuaryValue / LicensedFor.JanuaryValue, 0) : 0,
                        FebruaryValue = LicensedFor.FebruaryValue > 0 ? (float)Math.Round(EndingAverageOccupancy.FebruaryValue / LicensedFor.FebruaryValue, 0) : 0,
                        MarchValue = LicensedFor.MarchValue > 0 ? (float)Math.Round(EndingAverageOccupancy.MarchValue / LicensedFor.MarchValue, 0) : 0,
                        AprilValue = LicensedFor.AprilValue > 0 ? (float)Math.Round(EndingAverageOccupancy.AprilValue / LicensedFor.AprilValue, 0) : 0,
                        MayValue = LicensedFor.MayValue > 0 ? (float)Math.Round(EndingAverageOccupancy.MayValue / LicensedFor.MayValue, 0) : 0,
                        JuneValue = LicensedFor.JuneValue > 0 ? (float)Math.Round(EndingAverageOccupancy.JuneValue / LicensedFor.JuneValue, 0) : 0,
                        JulyValue = LicensedFor.JulyValue > 0 ? (float)Math.Round(EndingAverageOccupancy.JulyValue / LicensedFor.JulyValue, 0) : 0,
                        AugustValue = LicensedFor.AugustValue > 0 ? (float)Math.Round(EndingAverageOccupancy.AugustValue / LicensedFor.AugustValue, 0) : 0,
                        SeptemberValue = LicensedFor.SeptemberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.SeptemberValue / LicensedFor.SeptemberValue, 0) : 0,
                        OctoberValue = LicensedFor.OctoberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.OctoberValue / LicensedFor.OctoberValue, 0) : 0,
                        NovemberValue = LicensedFor.NovemberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.NovemberValue / LicensedFor.NovemberValue, 0) : 0,
                        DecemberValue = LicensedFor.DecemberValue > 0 ? (float)Math.Round(EndingAverageOccupancy.DecemberValue / LicensedFor.DecemberValue, 0) : 0,
                        TotalOrAverageValue = LicensedFor.TotalOrAverageValue > 0 ? (float)Math.Round(EndingAveragePersonOccupancy.TotalOrAverageValue / LicensedFor.TotalOrAverageValue, 0) : 0
                    };
                }
                return new OccupancyRecord();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class SkilledNurseStats
    {
        public OccupancyRecord BedsAvailable { get; set; }
        public OccupancyRecord AverageLCFirst { get; set; }
        public OccupancyRecord AverageLCSecond { get; set; }
        public OccupancyRecord FFSDirectAdmit { get; set; }
        public OccupancyRecord AverageMemoryCare { get; set; }
        public OccupancyRecord AverageMedicare { get; set; }
        public OccupancyRecord AverageMedicaid { get; set; }

        public OccupancyRecord TotalAverageOccupancy
        {
            get
            {
                OccupancyRecord record = new OccupancyRecord
                {
                    JanuaryValue = AverageLCFirst.JanuaryValue + AverageLCSecond.JanuaryValue + FFSDirectAdmit.JanuaryValue + AverageMemoryCare.JanuaryValue + AverageMedicare.JanuaryValue + AverageMedicaid.JanuaryValue,
                    FebruaryValue = AverageLCFirst.FebruaryValue + AverageLCSecond.FebruaryValue + FFSDirectAdmit.FebruaryValue + AverageMemoryCare.FebruaryValue + AverageMedicare.FebruaryValue + AverageMedicaid.FebruaryValue,
                    MarchValue = AverageLCFirst.MarchValue + AverageLCSecond.MarchValue + FFSDirectAdmit.MarchValue + AverageMemoryCare.MarchValue + AverageMedicare.MarchValue + AverageMedicaid.MarchValue,
                    AprilValue = AverageLCFirst.AprilValue + AverageLCSecond.AprilValue + FFSDirectAdmit.AprilValue + AverageMemoryCare.AprilValue + AverageMedicare.AprilValue + AverageMedicaid.AprilValue,
                    MayValue = AverageLCFirst.MayValue + AverageLCSecond.MayValue + FFSDirectAdmit.MayValue + AverageMemoryCare.MayValue + AverageMedicare.MayValue + AverageMedicaid.MayValue,
                    JuneValue = AverageLCFirst.JuneValue + AverageLCSecond.JuneValue + FFSDirectAdmit.JuneValue + AverageMemoryCare.JuneValue + AverageMedicare.JuneValue + AverageMedicaid.JuneValue,
                    JulyValue = AverageLCFirst.JulyValue + AverageLCSecond.JulyValue + FFSDirectAdmit.JulyValue + AverageMemoryCare.JulyValue + AverageMedicare.JulyValue + AverageMedicaid.JulyValue,
                    AugustValue = AverageLCFirst.AugustValue + AverageLCSecond.AugustValue + FFSDirectAdmit.AugustValue + AverageMemoryCare.AugustValue + AverageMedicare.AugustValue + AverageMedicaid.AugustValue,
                    SeptemberValue = AverageLCFirst.SeptemberValue + AverageLCSecond.SeptemberValue + FFSDirectAdmit.SeptemberValue + AverageMemoryCare.SeptemberValue + AverageMedicare.SeptemberValue + AverageMedicaid.SeptemberValue,
                    OctoberValue = AverageLCFirst.OctoberValue + AverageLCSecond.OctoberValue + FFSDirectAdmit.OctoberValue + AverageMemoryCare.OctoberValue + AverageMedicare.OctoberValue + AverageMedicaid.OctoberValue,
                    NovemberValue = AverageLCFirst.NovemberValue + AverageLCSecond.NovemberValue + FFSDirectAdmit.NovemberValue + AverageMemoryCare.NovemberValue + AverageMedicare.NovemberValue + AverageMedicaid.NovemberValue,
                    DecemberValue = AverageLCFirst.DecemberValue + AverageLCSecond.DecemberValue + FFSDirectAdmit.DecemberValue + AverageMemoryCare.DecemberValue + AverageMedicare.DecemberValue + AverageMedicaid.DecemberValue
                };
                record.TotalOrAverageValue = record.CalculateAverageValue();
                return record;
            }
        }

        public OccupancyRecord PercentOccupancy
        {
            get
            {

                return new OccupancyRecord
                {
                    JanuaryValue = BedsAvailable.JanuaryValue > 0 ? (float)Math.Round(TotalAverageOccupancy.JanuaryValue / BedsAvailable.JanuaryValue, 0) : 0,
                    FebruaryValue = BedsAvailable.FebruaryValue > 0 ? (float)Math.Round(TotalAverageOccupancy.FebruaryValue / BedsAvailable.FebruaryValue, 0) : 0,
                    MarchValue = BedsAvailable.MarchValue > 0 ? (float)Math.Round(TotalAverageOccupancy.MarchValue / BedsAvailable.MarchValue, 0) : 0,
                    AprilValue = BedsAvailable.AprilValue > 0 ? (float)Math.Round(TotalAverageOccupancy.AprilValue / BedsAvailable.AprilValue, 0) : 0,
                    MayValue = BedsAvailable.MayValue > 0 ? (float)Math.Round(TotalAverageOccupancy.MayValue / BedsAvailable.MayValue, 0) : 0,
                    JuneValue = BedsAvailable.JuneValue > 0 ? (float)Math.Round(TotalAverageOccupancy.JuneValue / BedsAvailable.JuneValue, 0) : 0,
                    JulyValue = BedsAvailable.JulyValue > 0 ? (float)Math.Round(TotalAverageOccupancy.JulyValue / BedsAvailable.JulyValue, 0) : 0,
                    AugustValue = BedsAvailable.AugustValue > 0 ? (float)Math.Round(TotalAverageOccupancy.AugustValue / BedsAvailable.AugustValue, 0) : 0,
                    SeptemberValue = BedsAvailable.SeptemberValue > 0 ? (float)Math.Round(TotalAverageOccupancy.SeptemberValue / BedsAvailable.SeptemberValue, 0) : 0,
                    OctoberValue = BedsAvailable.OctoberValue > 0 ? (float)Math.Round(TotalAverageOccupancy.OctoberValue / BedsAvailable.OctoberValue, 0) : 0,
                    NovemberValue = BedsAvailable.NovemberValue > 0 ? (float)Math.Round(TotalAverageOccupancy.NovemberValue / BedsAvailable.NovemberValue, 0) : 0,
                    DecemberValue = BedsAvailable.DecemberValue > 0 ? (float)Math.Round(TotalAverageOccupancy.DecemberValue / BedsAvailable.DecemberValue, 0) : 0,
                    TotalOrAverageValue = BedsAvailable.TotalOrAverageValue > 0 ? (float)Math.Round(TotalAverageOccupancy.TotalOrAverageValue / BedsAvailable.TotalOrAverageValue, 0) : 0
                };
            }
        }

    }
}

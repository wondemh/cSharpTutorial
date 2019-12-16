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
                
                    return new OccupancyRecord
                    {
                        JanuaryValue = AverageLCFirst.JanuaryValue + AverageLCSecond.JanuaryValue + FFSDirectAdmit.JanuaryValue + AverageMemoryCare.JanuaryValue + AverageMedicare.JanuaryValue + AverageMedicaid.JanuaryValue,
                        FebruaryValue = AverageLCFirst.FebruaryValue + AverageLCSecond.FebruaryValue + FFSDirectAdmit.FebruaryValue + AverageMemoryCare.FebruaryValue + AverageMedicare.FebruaryValue+ AverageMedicaid.FebruaryValue,
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
                
            }
        }
        
        public OccupancyRecord PercentOccupancy
        {
            get
            {
                
                    return new OccupancyRecord
                    {
                        JanuaryValue =  BedsAvailable.JanuaryValue > 0 ?  TotalAverageOccupancy.JanuaryValue / BedsAvailable.JanuaryValue : 0,
                        FebruaryValue = BedsAvailable.FebruaryValue > 0 ?  TotalAverageOccupancy.FebruaryValue / BedsAvailable.FebruaryValue : 0,
                        MarchValue = BedsAvailable.MarchValue > 0 ?  TotalAverageOccupancy.MarchValue / BedsAvailable.MarchValue : 0,
                        AprilValue = BedsAvailable.AprilValue > 0 ?  TotalAverageOccupancy.AprilValue / BedsAvailable.AprilValue : 0,
                        MayValue = BedsAvailable.MayValue > 0 ?  TotalAverageOccupancy.MayValue / BedsAvailable.MayValue : 0,
                        JuneValue = BedsAvailable.JuneValue > 0 ?  TotalAverageOccupancy.JuneValue / BedsAvailable.JuneValue : 0,
                        JulyValue = BedsAvailable.JulyValue > 0 ?  TotalAverageOccupancy.JulyValue / BedsAvailable.JulyValue : 0,
                        AugustValue = BedsAvailable.AugustValue > 0 ?  TotalAverageOccupancy.AugustValue / BedsAvailable.AugustValue : 0,
                        SeptemberValue = BedsAvailable.SeptemberValue > 0 ?  TotalAverageOccupancy.SeptemberValue / BedsAvailable.SeptemberValue : 0,
                        OctoberValue = BedsAvailable.OctoberValue > 0 ?  TotalAverageOccupancy.OctoberValue / BedsAvailable.OctoberValue : 0,
                        NovemberValue = BedsAvailable.NovemberValue > 0 ?  TotalAverageOccupancy.NovemberValue / BedsAvailable.NovemberValue : 0,
                        DecemberValue = BedsAvailable.DecemberValue > 0 ?  TotalAverageOccupancy.DecemberValue / BedsAvailable.DecemberValue : 0
                    };
                
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model
{
    public class OccupancyRecord
    {
        public float JanuaryValue { get; set; }
        public float FebruaryValue { get; set; }
        public float MarchValue { get; set; }
        public float AprilValue { get; set; }
        public float MayValue { get; set; }
        public float JuneValue { get; set; }
        public float JulyValue { get; set; }
        public float AugustValue { get; set; }
        public float SeptemberValue { get; set; }
        public float OctoberValue { get; set; }
        public float NovemberValue { get; set; }
        public float DecemberValue { get; set; }
        public float TotalOrAverageValue { get; set; }

        public float CalculateAverageValue()
        {
            float average = (JanuaryValue + FebruaryValue + MarchValue + AprilValue + MayValue + JuneValue + JulyValue + AugustValue + SeptemberValue +
                    OctoberValue + NovemberValue + DecemberValue) / 12;
            float roundedAverage = (float)Math.Round(average, 1);
            return roundedAverage;
        }

        public float CalculateTotalValue()
        {
            return JanuaryValue + FebruaryValue + MarchValue + AprilValue + MayValue + JuneValue + JulyValue + AugustValue + SeptemberValue +
                    OctoberValue + NovemberValue + DecemberValue;
        }

    }
}

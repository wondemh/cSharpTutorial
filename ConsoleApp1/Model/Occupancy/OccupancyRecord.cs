using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model
{
    public class OccupancyRecord
    {
        public float January { get; set; }
        public float February { get; set; }
        public float March { get; set; }
        public float April { get; set; }
        public float May { get; set; }
        public float June { get; set; }
        public float July { get; set; }
        public float August { get; set; }
        public float September { get; set; }
        public float October { get; set; }
        public float November { get; set; }
        public float December { get; set; }
        public float TotalOrAverage { get; set; }

        public float CalculateAverageValue()
        {
            float average = (January + February + March + April + May + June + July + August + September +
                    October + November + December) / 12;
            float roundedAverage = (float)Math.Round(average, 1);
            return roundedAverage;
        }

        public float CalculateTotalValue()
        {
            return January + February + March + April + May + June + July + August + September +
                    October + November + December;
        }
    }
}

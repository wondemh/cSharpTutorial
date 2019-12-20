using System;
using System.Collections.Generic;
using System.Text;

namespace ReportApp.Model.Occupancy
{
    class OccupancyRecordsContainer
    {
        public static float ZeroIfNull(float? value)
        {
            return value ?? 0;
        }

        public static float Divide(float? num, float? denom)
        {
            if (num.HasValue && denom.HasValue)
            {
                return denom.Value > 0 ? num.Value / denom.Value : 0;
            }
            return 0;
        }

        public static float Subtract(float? a, float? b)
        {
            if (a.HasValue && b.HasValue)
            {
                return a.Value - b.Value;
            }
            return 0;
        }
    }
}

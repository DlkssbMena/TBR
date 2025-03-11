using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBR
{
    public class FareCalculator
    {
        public static double CalculateFare(double drivenDistance, List<PricingBand> bands)
        {
            double total = 0.0;
            double remaining = drivenDistance;

            foreach (var band in bands)
            {
                if (remaining <= 0) break;

                if (band.Type == PricingBandType.Fixed)
                {
                    // Fixed price bands apply if any distance in the band is covered
                    if (remaining > band.Start)
                    {
                        total += band.Rate;
                        double consumed = band.End - band.Start;
                        remaining = Math.Max(remaining - consumed, 0);
                    }
                }
                else // PerMile
                {
                    double bandMiles = band.End - band.Start;
                    double applicable = double.IsPositiveInfinity(band.End)
                        ? remaining
                        : Math.Min(remaining, bandMiles);

                    total += applicable * band.Rate;
                    remaining -= applicable;
                }
            }

            return total;
        }
    }
}

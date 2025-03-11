using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBR
{
    public class FareCalculator
    {
        private readonly List<PricingBand> _bands;

        public FareCalculator(List<PricingBand> bands)
        {
            _bands = bands ?? throw new ArgumentNullException(nameof(bands));
        }

        public double CalculateFare(double drivenDistance)
        {
            double total = 0.0;
            double remaining = drivenDistance;

            foreach (var band in _bands)
            {
                if (remaining <= 0) break;

                double bandMiles = band.End - band.Start;
                double applicableMiles = (band.End == double.PositiveInfinity)
                    ? remaining
                    : Math.Min(remaining, bandMiles);

                switch (band.Type)
                {
                    case PricingBandType.Fixed:
                        if (remaining > band.Start)
                        {
                            total += band.Rate;
                            remaining -= Math.Max(bandMiles, 0);
                        }
                        break;

                    case PricingBandType.PerMile:
                        total += applicableMiles * band.Rate;
                        remaining -= applicableMiles;
                        break;
                }
            }

            return total;
        }

    }
}

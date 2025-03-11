using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBR;

namespace FareCalculator.Tests
{
    public static class TestData
    {
        public static List<PricingBand> GetDefaultPricingBands()
        {
            return new List<PricingBand>
        {
            new PricingBand { Start = 0, End = 1, Rate = 10, Type = PricingBandType.Fixed },
            new PricingBand { Start = 1, End = 6, Rate = 2, Type = PricingBandType.PerMile },
            new PricingBand { Start = 6, End = 16, Rate = 3, Type = PricingBandType.PerMile },
            new PricingBand { Start = 16, End = double.PositiveInfinity, Rate = 1, Type = PricingBandType.PerMile }
        };
        }
    }
}

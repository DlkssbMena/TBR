using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBR
{
    public class PricingBand
    {
        public double Start { get; set; }
        public double End { get; set; }
        public double Rate { get; set; }
        public PricingBandType Type { get; set; }
    }

    public enum PricingBandType { Fixed, PerMile }
}

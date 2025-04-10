﻿using System;
using System.Collections.Generic;
using TBR;
public class Program
{
    public static void Main()
    {
        
        var bands = new List<PricingBand>
        {
            new PricingBand { Start = 0, End = 1, Rate = 10, Type = PricingBandType.Fixed },
            new PricingBand { Start = 1, End = 6, Rate = 2, Type = PricingBandType.PerMile },
            new PricingBand { Start = 6, End = 16, Rate = 3, Type = PricingBandType.PerMile },
            new PricingBand { Start = 16, End = double.PositiveInfinity, Rate = 1, Type = PricingBandType.PerMile }
        };
        var fareService = new FareCalculator(bands);
        Console.WriteLine($"6 miles: £{fareService.CalculateFare(6)}");     
        Console.WriteLine($"12 miles: £{fareService.CalculateFare(12)}");   
        Console.WriteLine($"100 miles: £{fareService.CalculateFare(100)}"); 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCalculator.Tests
{
    public class FareCalculationServiceTests
    {
        [Theory]
        [InlineData(6, 20)]
        [InlineData(12, 38)]
        [InlineData(20, 54)]  
        [InlineData(0.5, 10)]
        [InlineData(30, 64)]  
        [InlineData(6.5, 21.5)]
        [InlineData(1.5, 11)]   
        [InlineData(5.75, 19.5)] 
        [InlineData(25.5, 59.5)]
        [InlineData(15.5, 47.5)] //wrong
        [InlineData(16.25, 48.25)] //wrong

        public void CalculateFareTest(double drivenDistance, double expectedFare)
        {
            
            var bands = TestData.GetDefaultPricingBands();
            var fareService = new TBR.FareCalculator(bands);

            
            double result = fareService.CalculateFare(drivenDistance);

          
            Assert.Equal(expectedFare, result);
        }
    }
}

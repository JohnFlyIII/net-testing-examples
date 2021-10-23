using System;
using Xunit;
using Devices;

namespace test
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1,1,2)]
        [InlineData(2,2,4)]
        [InlineData(4,4,8)]
        [InlineData(0,1,1)]
        [InlineData(1,0,1)]
        public void CalculatorCanAddTests(int lValue, int rValue, int expectedResult)
        {   
            // Add function should work for 1+1
            // e.g. 1 + 1 = 2
            var calculator = new Calculator();

            var result = calculator.Add(lValue, rValue);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1, 3.14)]
        [InlineData(2, 12.56)]
        public void AreaOfUnitCircle(int radius, decimal expectedResult)
        {
            // Unit circle is a circle with given radius
            var calculator = new Calculator();
            var result = calculator.AreaOfACircle(radius);
            
            Assert.Equal(expectedResult, result);
        }

        
    }
}

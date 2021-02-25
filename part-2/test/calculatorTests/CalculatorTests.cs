using System;
using Xunit;
using Devices;

namespace test
{
    public class CalculatorTests
    {
        [Fact]
        public void OnePlusOneEqualsTwo()
        {   
            // Add function should work for 1+1
            // e.g. 1 + 1 = 2
            var calculator = new Calculator();
            int lValue = 1;
            int rValue = 1;
            int expectedResult = 2;

            var result = calculator.Add(lValue, rValue);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void AreaOfUnitCircle()
        {
            // Unit circle is a circle with radius 1
            var calculator = new Calculator();
            var result = calculator.AreaOfACircle(1);

            double expectedResult = 3.14;
            Assert.Equal(expectedResult, result);
        }

        
    }
}

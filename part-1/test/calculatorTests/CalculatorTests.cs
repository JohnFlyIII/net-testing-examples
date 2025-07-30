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

        [Theory]
        [InlineData(int.MaxValue, 1, int.MinValue)]  // Overflow scenario
        [InlineData(int.MinValue, -1, int.MaxValue)] // Underflow scenario
        public void Add_WithIntegerOverflow_ProducesExpectedOverflowBehavior(int lValue, int rValue, int expectedResult)
        {
            // This test documents the current overflow behavior
            // In part-4, this could be enhanced to throw exceptions or use checked arithmetic
            var calculator = new Calculator();
            
            var result = calculator.Add(lValue, rValue);
            
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Subtract_WithZeroOperands_ReturnsZero()
        {
            // Testing identity property: 0 - 0 = 0
            var calculator = new Calculator();
            
            var result = calculator.Subtract(0, 0);
            
            Assert.Equal(0, result);
        }

        [Fact]
        public void AreaOfACircle_WithZeroRadius_ReturnsZero()
        {
            // Edge case: A circle with radius 0 has area 0
            var calculator = new Calculator();
            
            var result = calculator.AreaOfACircle(0);
            
            Assert.Equal(0, result);
        }

        [Fact]
        public void AreaOfACircle_WithNegativeRadius_ReturnsPositiveArea()
        {
            // Mathematical property: Area should be positive even with negative radius
            // Since we square the radius, -2 * -2 = 4, so area = Pi * 4
            var calculator = new Calculator();
            double radius = -2;
            
            var result = calculator.AreaOfACircle(radius);
            
            double expectedResult = Constants.Pi * 4; // 3.14 * 4 = 12.56
            Assert.Equal(expectedResult, result);
        }
    }
}

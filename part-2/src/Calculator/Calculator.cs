using System;

namespace Devices
{
    public class Calculator
    {
       public int Add(int lValue, int rValue)
       {
           return lValue + rValue;
       }

       public int Subtract(int lValue, int rValue)
       {
           return lValue - rValue;
       }

       public decimal AreaOfACircle(decimal radius)
       {
           return Decimal.Multiply(Constants.Pi, Decimal.Multiply(radius, radius)); 
       }
    }
}

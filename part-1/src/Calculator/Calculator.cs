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

       public double AreaOfACircle(double radius)
       {
           return Constants.Pi * (radius * radius);
       }
    }
}

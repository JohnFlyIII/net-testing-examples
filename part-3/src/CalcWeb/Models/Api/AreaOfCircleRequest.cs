namespace CalcWeb.Models.Api
{
    public class AreaOfCircleRequest
    {
        public readonly string Operation = "Area of a circle with given radius";
        public decimal radius {get; set;}
    }    
}
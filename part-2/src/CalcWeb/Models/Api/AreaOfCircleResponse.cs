namespace CalcWeb.Models.Api
{
    public class AreaOfCircleResponse
    {
        public readonly string Operation = "Area of a circle with given radius";
        public decimal radius {get;set;}
        public decimal area {get;set;}
    }    
}
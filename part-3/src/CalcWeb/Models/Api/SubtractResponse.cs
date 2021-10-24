namespace CalcWeb.Models.Api
{
    public class SubtractResponse
    {
        public readonly string Operation = "Subtract";
        public int lValue {get;set;}
        public int rValue {get;set;}
        public int result {get;set;}
    }    
}
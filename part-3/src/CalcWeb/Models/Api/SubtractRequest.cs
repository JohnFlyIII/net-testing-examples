namespace CalcWeb.Models.Api
{
    public class SubtractRequest
    {
        public readonly string Operation = "Subtract";
        public int lValue {get;set;}
        public int rValue {get;set;}
    }    
}
namespace CalcWeb.Models.Api
{
    public class AddResponse
    {
        public readonly string Operation = "Add";
        public int lValue { get; set; }
        public int rValue { get; set; }
        public int result { get; set; }
    }    
}
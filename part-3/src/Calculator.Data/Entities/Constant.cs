using System;
using System.ComponentModel.DataAnnotations;

namespace Calculator.Data.Entities
{
    public class Constant
    {
        [Key]
        public Guid Id { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DateTime ModifyDate { get; set; } = DateTime.MinValue;
    }
}
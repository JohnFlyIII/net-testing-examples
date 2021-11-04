using System;
using Microsoft.EntityFrameworkCore;

namespace Calculator.Data
{
    public class CalculatorDbContext : DbContext
    {
        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options)
       : base(options)
        {
        }

        public DbSet<Entities.Constant> Constants { get; set; } = null!;

    }
}

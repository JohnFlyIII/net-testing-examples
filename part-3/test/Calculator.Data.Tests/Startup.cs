using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Calculator.Data.Repositories.Interfaces;
using Calculator.Data.Repositories;
namespace Calculator.Data.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("ConfigureServices");

            var builder = new DbContextOptionsBuilder<CalculatorDbContext>();
            var options = builder.UseSqlite("DataSource=:memory;", x => { });

            services.AddScoped<DbContextOptions<CalculatorDbContext>>(_ => builder.Options);

            services.AddDbContext<CalculatorDbContext>(options => options = builder);


            services.AddScoped<IConstantsRepository, ConstantsRepository>();

            var context = new CalculatorDbContext(builder.Options);
            context.Database.EnsureCreated();
        }

      
    }
}


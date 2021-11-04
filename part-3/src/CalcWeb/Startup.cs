using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Calculator.Data.Repositories.Interfaces;
using Calculator.Data.Repositories;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Calculator.Data;

namespace CalcWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddScoped<IConstantsRepository, ConstantsRepository>();

            ConfigurePersistance(services);
        }

        private void ConfigurePersistance(IServiceCollection services)
        {
            var calculatorDbContextConnectionString = Configuration.GetConnectionString("CalculatorDb");
            Log.Information($"Using CalculatorDb connection string of : {calculatorDbContextConnectionString}");

            var persistenceProvider = Configuration["Persistence:Provider"].ToUpperInvariant();

            var calculatorDbOptionsBuilder = new DbContextOptionsBuilder<CalculatorDbContext>();

            switch (persistenceProvider)
            {
                case "POSTGRES":
                    calculatorDbOptionsBuilder.UseNpgsql(calculatorDbContextConnectionString);
                    break;
                default:
                    throw new NotImplementedException($"The persistenceProvider option: '{persistenceProvider}' is unsupported");
            }
            var calculatorDbOptions = calculatorDbOptionsBuilder.Options;

            services.AddScoped<DbContextOptions<CalculatorDbContext>>(_ => calculatorDbOptions);

            services.AddDbContext<CalculatorDbContext>(optionsBuilder => optionsBuilder = calculatorDbOptionsBuilder);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

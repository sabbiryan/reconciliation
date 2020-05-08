using System.Reflection;
using AutoMapper;
using Blazored.Modal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReconciliationApp.EntityFrameworkCore;
using ReconciliationApp.Service.IncomeOrExpenses;
using ReconciliationApp.Service.IncomeOrExpenseTypes;
using ReconciliationApp.Service.Reconciliations;
using ReconciliationApp.Web.Data;
using Sotsera.Blazor.Toaster.Core.Models;

namespace ReconciliationApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ReconciliationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //var entityFrameworkCoreAssembly = Assembly.Load($"{nameof(ReconciliationApp)}.{nameof(ReconciliationApp.EntityFrameworkCore)}");
            //var serviceAssembly = Assembly.Load($"{nameof(ReconciliationApp)}.{nameof(ReconciliationApp.Service)}");
            //services.AddAutoMapper(entityFrameworkCoreAssembly, serviceAssembly);

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBlazoredModal();
            services.AddToaster(config =>
            {
                //example customizations
                config.PositionClass = Defaults.Classes.Position.TopRight;
                config.PreventDuplicates = true;
                config.NewestOnTop = false;
            });

            services.AddScoped<IIncomeOrExpenseLogicService, IncomeOrExpenseLogicService>();
            services.AddScoped<IIncomeOrExpenseTypeLogicService, IncomeOrExpenseTypeLogicService>();
            services.AddScoped<IReconciliationLogicService, ReconciliationLogicService>();

            services.AddScoped<IncomeOrExpenseService>();
            services.AddScoped<IncomeOrExpenseTypeService>();
            services.AddScoped<ReconciliationService>();
            services.AddSingleton<WeatherForecastService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<ReconciliationDbContext>();
            //    context.Database.Migrate();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

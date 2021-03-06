﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Web.Data;

namespace Sakamoto.TCC2.CSU.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter()))
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            services.AddHttpClient();
            services.AddControllersWithViews();



            services.AddDbContext<CSUContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CSUContext")));
        }
    }
}
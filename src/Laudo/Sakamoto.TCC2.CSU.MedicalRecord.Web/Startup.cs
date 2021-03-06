using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.Bus.Configurations;
using Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.IoC;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.AutoMapper;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Context;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Mappings;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "CSU - Medical Report API");
                s.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter()))
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAutoMapper(typeof(Startup), typeof(DomainToViewModelMapping), typeof(ViewModelToDomainMapping),
                typeof(DomainToRepository));


            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CSU - Medical Report API", Version = "v1" });
            });

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            services.Configure<MessageConfigurations>(
                Configuration.GetSection(nameof(MessageConfigurations)));
            services.Configure<DatabaseSettings>(
                Configuration.GetSection(nameof(DatabaseSettings)));
            services.Register();

            services.AddControllers();
        }
    }
}
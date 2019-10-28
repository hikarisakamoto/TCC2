using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sakamoto.TCC2.CSU.Infrastructure.IoC;
using Sakamoto.TCC2.CSU.Patient.Web.Configurations;
using Swashbuckle.AspNetCore.Swagger;

namespace Sakamoto.TCC2.CSU.Patient.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

            //if (env.IsDevelopment()) builder.AddUserSecrets<Startup>();

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            //app.UseHttpsRedirection();
            //app.UseAuthentication();
            //app.UseMvc();

            //app.UseSwagger();
            //app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Equinox Project API v1.1"); });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                {
                    options.OutputFormatters.Remove(new XmlDataContractSerializerOutputFormatter());
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAutoMapperSetup();

            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "Cadastro de Saúde Unificado",
            //        Description = "CSU API Swagger surface",
            //        Contact = new Contact {Name = "Hikari Sakamoto", Email = "hikarisakamoto@gmail.com"},
            //        License = new License {Name = "MIT"}
            //    });
            //});

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            // .NET Native DI Abstraction
            services.Register();

            services.AddControllers();
        }
    }
}
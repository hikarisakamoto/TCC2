using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Patient.Application.AutoMapper;

namespace Sakamoto.TCC2.CSU.Patient.Web.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services.AddAutoMapper();

            // Registering Mappings automatically only works if the 
            // Automapper Profile classes are in ASP.NET project
            AutoMapperConfig.RegisterMappings();
        }
    }
}
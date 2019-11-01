using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.Services;

namespace Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.IoC.Application_Services
{
    internal class ApplicationService
    {
        internal static void Register(IServiceCollection services)
        {
            services.AddScoped<IMedicalReportAppService, MedicalReportAppService>();

            services.AddScoped<IMapper>(
                sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}
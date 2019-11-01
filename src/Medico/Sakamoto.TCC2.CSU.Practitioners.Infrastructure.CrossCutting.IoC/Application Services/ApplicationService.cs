using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Practitioner.Application.Interfaces;
using Sakamoto.TCC2.CSU.Practitioner.Application.Services;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.IoC.Application_Services
{
    internal static class ApplicationService
    {
        internal static void Register(IServiceCollection services)
        {
            services.AddScoped<IPractitionerAppService, PractitionerAppService>();
        }
    }
}
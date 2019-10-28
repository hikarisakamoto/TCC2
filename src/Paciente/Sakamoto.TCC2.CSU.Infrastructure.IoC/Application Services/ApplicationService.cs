using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Patient.Application.Interfaces;
using Sakamoto.TCC2.CSU.Patient.Application.Services;

namespace Sakamoto.TCC2.CSU.Infrastructure.IoC.Application_Services
{
    internal class ApplicationService
    {
        internal static void Register(IServiceCollection services)
        {
            // Application
            services.AddTransient<IPatientAppService, PatientAppService>();
        }
    }
}
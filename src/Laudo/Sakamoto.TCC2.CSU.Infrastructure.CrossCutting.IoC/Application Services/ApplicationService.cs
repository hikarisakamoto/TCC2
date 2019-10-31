using Microsoft.Extensions.DependencyInjection;

namespace Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.IoC.Application_Services
{
    internal class ApplicationService
    {
        internal static void Register(IServiceCollection services)
        {
            // Application
            //services.AddScoped<IPatientAppService, PatientAppService>();


            //services.AddScoped<IMapper>(
            //    sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}
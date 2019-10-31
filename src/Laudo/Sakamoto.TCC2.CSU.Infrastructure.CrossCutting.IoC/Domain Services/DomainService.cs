using Microsoft.Extensions.DependencyInjection;

namespace Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.IoC.Domain_Services
{
    internal class DomainService
    {
        internal static void Register(IServiceCollection services)
        {
            // Domain - Events
            //services.AddScoped<INotificationHandler<PatientHeartRateUpdatedEvent>, PatientEventHandler>();

            // Domain - Commands
            //services.AddScoped<IRequestHandler<RegisterNewPatientCommand, bool>, PatientCommandHandler>();
        }
    }
}
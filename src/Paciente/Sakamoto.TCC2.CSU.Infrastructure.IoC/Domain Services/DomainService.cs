using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Patients.Domain.CommandHandlers;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;
using Sakamoto.TCC2.CSU.Patients.Domain.EventHandlers;
using Sakamoto.TCC2.CSU.Patients.Domain.Events;

namespace Sakamoto.TCC2.CSU.Infrastructure.IoC.Domain_Services
{
    internal class DomainService
    {
        internal static void Register(IServiceCollection services)
        {
            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PatientDeactivatedEvent>, PatientEventHandler>();
            services.AddScoped<INotificationHandler<PatientRegisteredEvent>, PatientEventHandler>();
            services.AddScoped<INotificationHandler<PatientUpdatedEvent>, PatientEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPatientCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePatientCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<DeactivatePatientCommand, bool>, PatientCommandHandler>();
        }
    }
}
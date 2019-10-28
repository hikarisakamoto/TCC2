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
            services.AddScoped<INotificationHandler<PatientAddressUpdatedEvent>, PatientEventHandler>();
            services.AddScoped<INotificationHandler<PatientEmailUpdatedEvent>, PatientEventHandler>();
            services.AddScoped<INotificationHandler<PatientPhoneUpdatedEvent>, PatientEventHandler>();
            services.AddScoped<INotificationHandler<PatientPhotoUpdatedEvent>, PatientEventHandler>();
            services.AddScoped<INotificationHandler<PatientHeartRateUpdatedEvent>, PatientEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewPatientCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<DeactivatePatientCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePatientAddressCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePatientEmailCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePatientHeartRateCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePatientPhoneCommand, bool>, PatientCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePatientPhotoCommand, bool>, PatientCommandHandler>();
        }
    }
}
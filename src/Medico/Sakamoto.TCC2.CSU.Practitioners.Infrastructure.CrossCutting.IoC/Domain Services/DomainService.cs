using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Practitioners.Domain.CommandHandlers;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Commands;
using Sakamoto.TCC2.CSU.Practitioners.Domain.EventHandlers;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Events;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.IoC.Domain_Services
{
    internal class DomainService
    {
        internal static void Register(IServiceCollection services)
        {
            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<PractitionerRegisteredEvent>, PractitionerEventHandler>();
            services.AddScoped<INotificationHandler<PractitionerEmailUpdatedEvent>, PractitionerEventHandler>();
            services.AddScoped<INotificationHandler<PractitionerPhoneUpdatedEvent>, PractitionerEventHandler>();
            services.AddScoped<INotificationHandler<PractitionerDeactivatedEvent>, PractitionerEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<DeactivatePractitionerCommand, bool>, PractitionerCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewPractitionerCommand, bool>, PractitionerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePractitionerPhoneCommand, bool>, PractitionerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePractitionerEmailCommand, bool>, PractitionerCommandHandler>();
        }
    }
}
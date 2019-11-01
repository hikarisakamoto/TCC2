using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.CommandHandlers;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.EventHandlers;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Events;

namespace Sakamoto.TCC2.CSU.Infrastructure.CrossCutting.IoC.Domain_Services
{
    internal class DomainService
    {
        internal static void Register(IServiceCollection services)
        {
            // Domain - Events
            services.AddScoped<INotificationHandler<MedicalReportAddedEvent>, MedicalReportEventHandler>();
            services.AddScoped<INotificationHandler<MedicalReportWithImageAddedEvent>, MedicalReportEventHandler>();
            services.AddScoped<INotificationHandler<MedicalReportRemovedEvent>, MedicalReportEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<AddNewMedicalReportCommand, bool>, MedicalReportCommandHandler>();
            services
                .AddScoped<IRequestHandler<AddNewMedicalReportWithImageCommand, bool>, MedicalReportCommandHandler>();
            services
                .AddScoped<IRequestHandler<RemoveExistingMedicalReportByIdCommand, bool>, MedicalReportCommandHandler
                >();
        }
    }
}
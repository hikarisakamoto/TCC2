using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Notifications;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;
using Sakamoto.TCC2.CSU.Practitioners.Domain.PractitionerCommands;

namespace Sakamoto.TCC2.CSU.Practitioners.Domain.CommandHandlers
{
    public class PractitionerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewPractitionerCommand, bool>,
        IRequestHandler<UpdatePractitionerEmailCommand, bool>,
        IRequestHandler<UpdatePractitionerPhoneCommand, bool>,
        IRequestHandler<DeactivatePractitionerCommand, bool>
    {
        private readonly IMediatorHandler _bus;
        private readonly IPractitionerRepository _practitionerRepository;

        public PractitionerCommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, INotificationHandler<DomainNotification> domainNotifications, IPractitionerRepository practitionerRepository) : base(unitOfWork, bus, domainNotifications)
        {
            _bus = bus;
            _practitionerRepository = practitionerRepository;
        }

        public Task<bool> Handle(RegisterNewPractitionerCommand message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Handle(UpdatePractitionerEmailCommand message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Handle(UpdatePractitionerPhoneCommand message, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Handle(DeactivatePractitionerCommand messages, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
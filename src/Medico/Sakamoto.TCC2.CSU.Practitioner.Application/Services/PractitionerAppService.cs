using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Practitioner.Application.Interfaces;
using Sakamoto.TCC2.CSU.Practitioner.Application.ViewModels;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Commands;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.Practitioner.Application.Services
{
    public class PractitionerAppService : IPractitionerAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly IPractitionerRepository _practitionerRepository;

        public PractitionerAppService(IMediatorHandler bus, IMapper mapper,
            IPractitionerRepository practitionerRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _practitionerRepository = practitionerRepository;
        }

        public void Deactivate(DeactivatePractitionerViewModel practitionerViewModel)
        {
            var practitioner = _mapper.Map<DeactivatePractitionerCommand>(practitionerViewModel);
            _bus.SendCommand(practitioner);
        }

        public async Task<PractitionerViewModel> GetByCrm(string crm)
        {
            return _mapper.Map<PractitionerViewModel>(_practitionerRepository.GetByCrm(crm));
        }

        public async Task<PractitionerViewModel> GetById(Guid id)
        {
            return _mapper.Map<PractitionerViewModel>(_practitionerRepository.GetById(id));
        }

        public void Register(RegisterNewPractitionerViewModel practitionerViewModel)
        {
            var practitioner = _mapper.Map<RegisterNewPractitionerCommand>(practitionerViewModel);
            _bus.SendCommand(practitioner);
        }

        public void UpdateEmail(UpdatePractitionerEmailViewModel practitionerViewModel)
        {
            var practitioner = _mapper.Map<UpdatePractitionerEmailCommand>(practitionerViewModel);
            _bus.SendCommand(practitioner);
        }

        public void UpdatePhone(UpdatePractitionerPhoneViewModel practitionerViewModel)
        {
            var practitioner = _mapper.Map<UpdatePractitionerPhoneCommand>(practitionerViewModel);
            _bus.SendCommand(practitioner);
        }

        public async Task<IEnumerable<PractitionerViewModel>> GetAllPractitioners()
        {
            return _mapper.Map<IEnumerable<PractitionerViewModel>>(_practitionerRepository.GetAllPractitioners());

        }
    }
}
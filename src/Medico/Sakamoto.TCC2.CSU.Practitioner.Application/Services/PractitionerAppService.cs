using System;
using System.Threading.Tasks;
using AutoMapper;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Practitioner.Application.Interfaces;
using Sakamoto.TCC2.CSU.Practitioner.Application.ViewModels;
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
            throw new NotImplementedException();
        }

        public Task<PractitionerViewModel> GetByCrm(string crm)
        {
            throw new NotImplementedException();
        }

        public Task<PractitionerViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Register(RegisterNewPractitionerViewModel practitionerViewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmail(UpdatePractitionerEmailViewModel practitionerViewModel)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhone(UpdatePractitionerPhoneViewModel practitionerViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
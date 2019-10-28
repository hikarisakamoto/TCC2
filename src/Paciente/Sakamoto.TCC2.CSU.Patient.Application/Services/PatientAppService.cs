using System;
using System.Threading.Tasks;
using AutoMapper;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Patient.Application.Interfaces;
using Sakamoto.TCC2.CSU.Patient.Application.ViewModels;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;
using Sakamoto.TCC2.CSU.Patients.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.Patient.Application.Services
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;

        public PatientAppService(IMapper mapper, IPatientRepository patientRepository, IMediatorHandler bus)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
            _bus = bus;
        }

        public void Deactivate(DeactivatePatientViewModel patientViewModel)
        {
            var registerCommand = _mapper.Map<DeactivatePatientCommand>(patientViewModel);
            _bus.SendCommand(registerCommand);
        }

        public async Task<PatientBasicInformationViewModel> GetBasicInformationByCpf(string cpf)
        {
            return _mapper.Map<PatientBasicInformationViewModel>(_patientRepository.GetByCpf(cpf));
        }

        public async Task<PatientBasicInformationViewModel> GetBasicInformationById(Guid id)
        {
            return _mapper.Map<PatientBasicInformationViewModel>(_patientRepository.GetById(id));
        }

        public async Task<PatientViewModel> GetByCpf(string cpf)
        {
            return _mapper.Map<PatientViewModel>(_patientRepository.GetByCpf(cpf));
        }

        public async Task<PatientViewModel> GetById(Guid id)
        {
            return _mapper.Map<PatientViewModel>(_patientRepository.GetById(id));
        }

        public void Register(RegisterNewPatientViewModel patientViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewPatientCommand>(patientViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void UpdateAddress(UpdatePatientAddressViewModel patientAddressViewModel)
        {
            var registerCommand = _mapper.Map<UpdatePatientAddressCommand>(patientAddressViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void UpdateEmail(UpdatePatientEmailViewModel patientEmailViewModel)
        {
            var registerCommand = _mapper.Map<UpdatePatientEmailCommand>(patientEmailViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void UpdateHeartRate(UpdatePatientHeartRateViewModel patientHeartRateViewModel)
        {
            var registerCommand = _mapper.Map<UpdatePatientHeartRateCommand>(patientHeartRateViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void UpdatePhone(UpdatePatientPhoneViewModel patientPhoneViewModel)
        {
            var registerCommand = _mapper.Map<UpdatePatientHeartRateCommand>(patientPhoneViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void UpdatePhoto(UpdatePatientPhotoViewModel patientPhotoViewModel)
        {
            var registerCommand = _mapper.Map<UpdatePatientPhotoCommand>(patientPhotoViewModel);
            _bus.SendCommand(registerCommand);
        }
    }
}
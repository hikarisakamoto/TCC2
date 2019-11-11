using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.Services
{
    public class MedicalRecordAppService : IMedicalRecordAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly IMedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordAppService(IMediatorHandler bus, IMapper mapper,
            IMedicalRecordRepository medicalRecordRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _medicalRecordRepository = medicalRecordRepository;
        }

        public void Add(AddNewMedicalRecordViewModel medicalRecordViewModel)
        {
            var medicalReport = _mapper.Map<AddNewMedicalRecordCommand>(medicalRecordViewModel);
            _bus.SendCommand(medicalReport);
        }

        public void Add(AddNewMedicalRecordWithImageViewModel medicalRecordViewModel)
        {
            var medicalReport = _mapper.Map<AddNewMedicalReportWithImageCommand>(medicalRecordViewModel);
            _bus.SendCommand(medicalReport);
        }

        public async Task<IEnumerable<MedicalRecordViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<MedicalRecordViewModel>>(
                _medicalRecordRepository.GetAll());
        }

        public async Task<MedicalRecordViewModel> GetById(Guid id)
        {
            return _mapper.Map<MedicalRecordViewModel>(_medicalRecordRepository.GetById(id));
        }

        public async Task<IEnumerable<MedicalRecordViewModel>> GetByPatientId(Guid patientId)
        {
            return _mapper.Map<IEnumerable<MedicalRecordViewModel>>(_medicalRecordRepository.GetByPatientId(patientId));
        }

        public async Task<IEnumerable<MedicalRecordViewModel>> GetByPractitionerId(Guid practitionerId)
        {
            return _mapper.Map<IEnumerable<MedicalRecordViewModel>>(
                _medicalRecordRepository.GetByPractitionerId(practitionerId));
        }

        public async Task<IEnumerable<MedicalRecordViewModel>> GetByPractitionerIdAndPatientId(Guid practitionerId,
            Guid patientId)
        {
            return _mapper.Map<IEnumerable<MedicalRecordViewModel>>(
                _medicalRecordRepository.GetByPractitionerIdAndPatientId(practitionerId, patientId));
        }

        public void Remove(RemoveExistingMedicalRecordByIdViewModel medicalRecordViewModel)
        {
            var medicalReport = _mapper.Map<RemoveExistingMedicalRecordtByIdCommand>(medicalRecordViewModel);
            _bus.SendCommand(medicalReport);
        }
    }
}
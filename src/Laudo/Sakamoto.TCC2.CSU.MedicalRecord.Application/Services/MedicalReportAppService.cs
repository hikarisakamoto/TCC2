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
    public class MedicalReportAppService : IMedicalReportAppService
    {
        private readonly IMediatorHandler _bus;
        private readonly IMapper _mapper;
        private readonly IMedicalReportRepository _medicalReportRepository;

        public MedicalReportAppService(IMediatorHandler bus, IMapper mapper,
            IMedicalReportRepository medicalReportRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _medicalReportRepository = medicalReportRepository;
        }

        public void Add(AddNewMedicalReportViewModel medicalReportViewModel)
        {
            var medicalReport = _mapper.Map<AddNewMedicalReportCommand>(medicalReportViewModel);
            _bus.SendCommand(medicalReport);
        }

        public void Add(AddNewMedicalReportWithImageViewModel medicalReportViewModel)
        {
            var medicalReport = _mapper.Map<AddNewMedicalReportWithImageCommand>(medicalReportViewModel);
            _bus.SendCommand(medicalReport);
        }

        public async Task<MedicalReportViewModel> GetById(Guid id)
        {
            return _mapper.Map<MedicalReportViewModel>(_medicalReportRepository.GetById(id));
        }

        public async Task<IEnumerable<MedicalReportViewModel>> GetByPatientId(Guid patientId)
        {
            return _mapper.Map<IEnumerable<MedicalReportViewModel>>(_medicalReportRepository.GetByPatientId(patientId));
        }

        public async Task<IEnumerable<MedicalReportViewModel>> GetByPractitionerId(Guid practitionerId)
        {
            return _mapper.Map<IEnumerable<MedicalReportViewModel>>(
                _medicalReportRepository.GetByPractitionerId(practitionerId));
        }

        public async Task<IEnumerable<MedicalReportViewModel>> GetByPractitionerIdAndPatientId(Guid practitionerId,
            Guid patientId)
        {
            return _mapper.Map<IEnumerable<MedicalReportViewModel>>(
                _medicalReportRepository.GetByPractitionerIdAndPatientId(practitionerId, patientId));
        }

        public void Remove(RemoveExistingMedicalReportByIdViewModel medicalReportViewModel)
        {
            var medicalReport = _mapper.Map<RemoveExistingMedicalReportByIdCommand>(medicalReportViewModel);
            _bus.SendCommand(medicalReport);
        }
    }
}
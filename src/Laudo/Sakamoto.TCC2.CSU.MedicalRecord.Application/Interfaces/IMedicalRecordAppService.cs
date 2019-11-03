using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.Interfaces
{
    public interface IMedicalRecordAppService
    {
        void Add(AddNewMedicalRecordViewModel medicalRecordViewModel);
        void Add(AddNewMedicalRecordWithImageViewModel medicalRecordWithImageViewModel);
        Task<MedicalRecordViewModel> GetById(Guid id);
        Task<IEnumerable<MedicalRecordViewModel>> GetByPatientId(Guid patientId);
        Task<IEnumerable<MedicalRecordViewModel>> GetByPractitionerId(Guid practitionerId);
        Task<IEnumerable<MedicalRecordViewModel>> GetByPractitionerIdAndPatientId(Guid practitionerId, Guid patientId);
        void Remove(RemoveExistingMedicalRecordByIdViewModel medicalRecordViewModel);
    }
}
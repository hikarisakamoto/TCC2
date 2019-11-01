using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.Interfaces
{
    public interface IMedicalReportAppService
    {
        void Add(AddNewMedicalReportViewModel medicalReportViewModel);
        void Add(AddNewMedicalReportWithImageViewModel medicalReportWithImageViewModel);
        Task<MedicalReportViewModel> GetById(Guid id);
        Task<IEnumerable<MedicalReportViewModel>> GetByPatientId(Guid patientId);
        Task<IEnumerable<MedicalReportViewModel>> GetByPractitionerId(Guid practitionerId);
        Task<IEnumerable<MedicalReportViewModel>> GetByPractitionerIdAndPatientId(Guid practitionerId, Guid patientId);
        void Remove(RemoveExistingMedicalReportByIdViewModel medicalReportViewModel);
    }
}
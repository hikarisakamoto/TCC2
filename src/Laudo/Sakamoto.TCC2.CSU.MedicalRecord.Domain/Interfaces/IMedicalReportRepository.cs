using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces
{
    public interface IMedicalReportRepository : IRepository<MedicalReport>
    {
        Task<IEnumerable<MedicalReport>> GetByPatientId(Guid patientId);
        Task<IEnumerable<MedicalReport>> GetByPractitionerId(Guid practitionerId);
        Task<IEnumerable<MedicalReport>> GetByPractitionerIdAndPatientId(Guid practitionerId, Guid patientId);

        Task<MedicalReport> GetByRemovalParamaters(Guid messageMedicalReportId, Guid messagePatientId,
            Guid messagePractitionerId);
    }
}
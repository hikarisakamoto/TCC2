using System;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces
{
    public interface IMedicalReportRepository : IRepository<MedicalReport>
    {
        Task<MedicalReport> GetByRemovalParamaters(Guid messageMedicalReportId, Guid messagePatientId, Guid messagePractitionerId);
    }
}
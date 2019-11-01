using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Repositories
{
    public class MedicalReportRepository : Repository<MedicalReport>, IMedicalReportRepository
    {
        public Task<IEnumerable<MedicalReport>> GetByPatientId(Guid patientId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicalReport>> GetByPractitionerId(Guid practitionerId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MedicalReport>> GetByPractitionerIdAndPatientId(Guid practitionerId, Guid patientId)
        {
            throw new NotImplementedException();
        }

        public Task<MedicalReport> GetByRemovalParamaters(Guid messageMedicalReportId, Guid messagePatientId, Guid messagePractitionerId)
        {
            throw new NotImplementedException();
        }
    }
}
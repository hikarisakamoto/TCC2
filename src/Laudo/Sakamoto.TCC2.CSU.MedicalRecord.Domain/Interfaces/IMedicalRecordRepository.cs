using System;
using System.Collections.Generic;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces
{
    public interface IMedicalRecordRepository
    {
        void Add(Models.MedicalRecord medicalReport);
        IEnumerable<Models.MedicalRecord> GetAll();
        Models.MedicalRecord GetById(Guid id);
        IEnumerable<Models.MedicalRecord> GetByPatientId(Guid patientId);
        IEnumerable<Models.MedicalRecord> GetByPractitionerId(Guid practitionerId);
        IEnumerable<Models.MedicalRecord> GetByPractitionerIdAndPatientId(Guid practitionerId, Guid patientId);

        Models.MedicalRecord GetByRemovalParamaters(Guid medicalReportId, Guid patientId,
            Guid practitionerId);

        void Remove(Guid id);
    }
}
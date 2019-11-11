using System;
using System.Collections.Generic;
using AutoMapper;
using MongoDB.Driver;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Interfaces;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Mappings;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Repositories
{
    public class MedicalRecordRepository : IMedicalRecordRepository, IDisposable
    {
        private readonly IMongoCollection<MedicalRecords> _dbSet;
        private readonly IMapper _mapper;

        public MedicalRecordRepository(IMedicalRecordContext context, IMapper mapper,
            IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            _dbSet = context.GetMongoDatabase().GetCollection<MedicalRecords>(databaseSettings.CollectionName);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public void Add(Domain.Models.MedicalRecord medicalRecord)
        {
            var medicalReportData = _mapper.Map<MedicalRecords>(medicalRecord);
            _dbSet.InsertOneAsync(medicalReportData);
        }

        public Domain.Models.MedicalRecord GetById(Guid id)
        {
            var medicalRecord = _dbSet.Find(mr => mr.Id.Equals(id)).FirstOrDefault();

            return _mapper.Map<Domain.Models.MedicalRecord>(medicalRecord);
        }

        public IEnumerable<Domain.Models.MedicalRecord> GetByPatientId(Guid patientId)
        {
            var medicalRecords = _dbSet.Find(mr => mr.PatientId.Equals(patientId)).ToList();

            return _mapper.Map<IEnumerable<Domain.Models.MedicalRecord>>(medicalRecords);
        }

        public IEnumerable<Domain.Models.MedicalRecord> GetByPractitionerId(Guid practitionerId)
        {
            var medicalRecord = _dbSet.Find(mr => mr.PractitionerId.Equals(practitionerId)).ToList();

            return _mapper.Map<IEnumerable<Domain.Models.MedicalRecord>>(medicalRecord);
        }

        public IEnumerable<Domain.Models.MedicalRecord> GetByPractitionerIdAndPatientId(Guid practitionerId,
            Guid patientId)
        {
            var medicalRecords = _dbSet
                .Find(mr => mr.PatientId.Equals(patientId) && mr.PractitionerId.Equals(practitionerId)).ToList();
            return _mapper.Map<IEnumerable<Domain.Models.MedicalRecord>>(medicalRecords);
        }

        public Domain.Models.MedicalRecord GetByRemovalParamaters(Guid medicalReportId, Guid patientId,
            Guid practitionerId)
        {
            var medicalRecord = _dbSet.Find(mr =>
                mr.PatientId.Equals(patientId) && mr.PractitionerId.Equals(practitionerId) &&
                mr.Id.Equals(medicalReportId)).FirstOrDefault();

            return _mapper.Map<Domain.Models.MedicalRecord>(medicalRecord);
        }

        public void Remove(Guid id)
        {
            _dbSet.DeleteOne(mr => mr.Id.Equals(id));
        }
    }
}
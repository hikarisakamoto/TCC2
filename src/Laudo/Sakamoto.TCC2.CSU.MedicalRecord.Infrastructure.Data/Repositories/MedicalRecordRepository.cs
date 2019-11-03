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


        public void Add(Domain.Models.MedicalRecord medicalRecord)
        {
            var medicalReportData = _mapper.Map<MedicalRecords>(medicalRecord);
            _dbSet.InsertOneAsync(medicalReportData);
        }

        public Domain.Models.MedicalRecord GetById(Guid id)
        {
            return _mapper.Map<Domain.Models.MedicalRecord>(
                _dbSet.Find(mr => mr.Id.Equals(id.ToString())));
        }

        public IEnumerable<Domain.Models.MedicalRecord> GetByPatientId(Guid patientId)
        {
            return _mapper.Map<IEnumerable<Domain.Models.MedicalRecord>>(
                _dbSet.Find(mr => mr.PatientId.Equals(patientId)));
        }

        public IEnumerable<Domain.Models.MedicalRecord> GetByPractitionerId(Guid practitionerId)
        {
            return _mapper.Map<IEnumerable<Domain.Models.MedicalRecord>>(_dbSet.Find(mr =>
                mr.PractitionerId.Equals(practitionerId)));
        }

        public IEnumerable<Domain.Models.MedicalRecord> GetByPractitionerIdAndPatientId(Guid practitionerId,
            Guid patientId)
        {
            return _mapper.Map<IEnumerable<Domain.Models.MedicalRecord>>(_dbSet.FindAsync(mr =>
                mr.PatientId.Equals(patientId) && mr.PractitionerId.Equals(practitionerId)));
        }

        public Domain.Models.MedicalRecord GetByRemovalParamaters(Guid medicalReportId, Guid patientId,
            Guid practitionerId)
        {
            return _mapper.Map<Domain.Models.MedicalRecord>(_dbSet.Find(mr =>
                mr.PatientId.Equals(patientId) && mr.PractitionerId.Equals(practitionerId) &&
                mr.Id.Equals(medicalReportId.ToString())));
        }

        public void Remove(Guid id)
        {
            _dbSet.DeleteOne(mr => mr.Id.Equals(id.ToString()));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
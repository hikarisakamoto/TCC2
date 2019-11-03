using System;
using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models
{
    public class MedicalRecord : Entity
    {
        private MedicalRecord()
        {
        }

        public DateTime Date { get; private set; }
        public byte[] Image { get; private set; }
        public string LongDescription { get; private set; }
        public Guid PatientId { get; private set; }
        public string PatientName { get; private set; }
        public Guid PractitionerId { get; private set; }
        public string PractitionerName { get; private set; }
        public string ShortDescription { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new MedicalRecordValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public class Builder
        {
            private readonly MedicalRecord _medicalRecord;

            public Builder()
            {
                _medicalRecord = new MedicalRecord
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now
                };
            }

            public MedicalRecord Build()
            {
                return _medicalRecord;
            }

            public Builder WithImage(byte[] image)
            {
                _medicalRecord.Image = image;
                return this;
            }

            public Builder WithLongDescription(string longDescription)
            {
                _medicalRecord.LongDescription = longDescription;
                return this;
            }

            public Builder WithPatient(Patient patient)
            {
                _medicalRecord.PatientId = patient.Id;
                _medicalRecord.PatientName = patient.FullName;

                return this;
            }

            public Builder WithPractitioner(Practitioner practitioner)
            {
                _medicalRecord.PractitionerId = practitioner.Id;
                _medicalRecord.PractitionerName = practitioner.FullName;

                return this;
            }

            public Builder WithShortDescription(string shortDescription)
            {
                _medicalRecord.ShortDescription = shortDescription;
                return this;
            }
        }
    }
}
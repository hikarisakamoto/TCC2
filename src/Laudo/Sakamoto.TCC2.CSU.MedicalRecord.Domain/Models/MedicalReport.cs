using System;
using Sakamoto.TCC2.CSU.Domain.Core.Models;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Validations;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models
{
    public class MedicalReport : Entity
    {
        private MedicalReport()
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
            private readonly MedicalReport _medicalReport;

            public Builder()
            {
                _medicalReport = new MedicalReport
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now
                };
            }

            public MedicalReport Build()
            {
                return _medicalReport;
            }

            public Builder WithImage(byte[] image)
            {
                _medicalReport.Image = image;
                return this;
            }

            public Builder WithLongDescription(string longDescription)
            {
                _medicalReport.LongDescription = longDescription;
                return this;
            }

            public Builder WithPatient(Patient patient)
            {
                _medicalReport.PatientId = patient.Id;
                _medicalReport.PatientName = patient.FullName;

                return this;
            }

            public Builder WithPractitioner(Practitioner practitioner)
            {
                _medicalReport.PractitionerId = practitioner.Id;
                _medicalReport.PractitionerName = practitioner.FullName;

                return this;
            }

            public Builder WithShortDescription(string shortDescription)
            {
                _medicalReport.ShortDescription = shortDescription;
                return this;
            }
        }
    }
}
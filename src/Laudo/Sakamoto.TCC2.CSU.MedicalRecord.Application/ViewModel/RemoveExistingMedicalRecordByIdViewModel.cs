using System;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel
{
    public class RemoveExistingMedicalRecordByIdViewModel
    {
        public Guid MedicalReportId { get; set; }
        public Guid PatientId { get; set; }
        public Guid PractitionerId { get; set; }
    }
}
using System.Collections;
using System.Collections.Generic;

namespace Sakamoto.TCC2.CSU.Patient.Application.ViewModels
{
    public class PatientsViewModel
    {
        public IEnumerable<PatientBasicInformationViewModel> Patients { get; set; }
    }
}
using System;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.Patient.Application.ViewModels;

namespace Sakamoto.TCC2.CSU.Patient.Application.Interfaces
{
    public interface IPatientAppService
    {
        void Deactivate(DeactivatePatientViewModel patientViewModel);
        Task<PatientBasicInformationViewModel> GetBasicInformationByCpf(string cpf);
        Task<PatientBasicInformationViewModel> GetBasicInformationById(Guid id);
        Task<PatientViewModel> GetByCpf(string cpf);
        Task<PatientViewModel> GetById(Guid id);
        void Register(RegisterNewPatientViewModel patientViewModel);
        void UpdateAddress(UpdatePatientAddressViewModel patientAddressViewModel);
        void UpdateEmail(UpdatePatientEmailViewModel patientEmailViewModel);
        void UpdateHeartRate(UpdatePatientHeartRateViewModel patientHeartRateViewModel);
        void UpdatePhone(UpdatePatientPhoneViewModel patientPhoneViewModel);
        void UpdatePhoto(UpdatePatientPhotoViewModel patientPhotoViewModel);
    }
}
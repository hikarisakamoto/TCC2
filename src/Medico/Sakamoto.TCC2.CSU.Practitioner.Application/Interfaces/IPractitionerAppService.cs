using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakamoto.TCC2.CSU.Practitioner.Application.ViewModels;

namespace Sakamoto.TCC2.CSU.Practitioner.Application.Interfaces
{
    public interface IPractitionerAppService
    {
        void Deactivate(DeactivatePractitionerViewModel practitionerViewModel);
        Task<PractitionerViewModel> GetByCrm(string crm);
        Task<PractitionerViewModel> GetById(Guid id);
        void Register(RegisterNewPractitionerViewModel practitionerViewModel);
        void UpdateEmail(UpdatePractitionerEmailViewModel practitionerViewModel);
        void UpdatePhone(UpdatePractitionerPhoneViewModel practitionerViewModel);
        Task<IEnumerable<PractitionerViewModel>> GetAllPractitioners();
    }
}
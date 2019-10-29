using AutoMapper;
using Sakamoto.TCC2.CSU.Patient.Application.ViewModels;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patient.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Patients.Domain.Models.Patient, PatientViewModel>();

            CreateMap<Patients.Domain.Models.Patient, PatientBasicInformationViewModel>();

            CreateMap<Address, AddressViewModel>();
        }
    }
}
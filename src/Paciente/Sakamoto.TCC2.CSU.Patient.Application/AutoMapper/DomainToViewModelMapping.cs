using AutoMapper;
using Sakamoto.TCC2.CSU.Patient.Application.ViewModels;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;

namespace Sakamoto.TCC2.CSU.Patient.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Patients.Domain.Models.Patient, PatientViewModel>().ForMember(pvm => pvm.Cpf, option => option.MapFrom(p => p.Cpf.Value));

            CreateMap<Patients.Domain.Models.Patient, PatientBasicInformationViewModel>().ForMember(pvm => pvm.Cpf, option => option.MapFrom(p => p.Cpf.Value));

            CreateMap<Address, AddressViewModel>();
        }
    }
}
using AutoMapper;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Domain.Models.MedicalRecord, MedicalRecordViewModel>();
            CreateMap<Practitioner, PractitionerViewModel>();
            CreateMap<Patient, PatientViewModel>();
        }
    }
}
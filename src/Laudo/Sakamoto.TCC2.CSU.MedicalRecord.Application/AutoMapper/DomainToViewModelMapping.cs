using AutoMapper;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;
using Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Mappings;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Domain.Models.MedicalRecord, MedicalRecordViewModel>();
            CreateMap<MedicalRecords, Domain.Models.MedicalRecord>();
            CreateMap<Practitioner, PractitionerViewModel>();
            CreateMap<Patient, PatientViewModel>();
        }
    }
}
using AutoMapper;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Infrastructure.Data.Mappings
{
    public class DomainToRepository : Profile
    {
        public DomainToRepository()
        {
            CreateMap<Domain.Models.MedicalRecord, MedicalRecords>();
        }
    }
}
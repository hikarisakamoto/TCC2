using AutoMapper;
using Sakamoto.TCC2.CSU.Practitioner.Application.ViewModels;

namespace Sakamoto.TCC2.CSU.Practitioner.Application.AutoMapper
{
    public class DomainToViewModelMapping : Profile
    {
        public DomainToViewModelMapping()
        {
            CreateMap<Practitioners.Domain.Models.Practitioner, PractitionerViewModel>();
        }
    }
}
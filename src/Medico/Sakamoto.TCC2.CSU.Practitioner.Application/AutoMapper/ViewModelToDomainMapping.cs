using AutoMapper;
using Sakamoto.TCC2.CSU.Practitioner.Application.ViewModels;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Practitioner.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<RegisterNewPractitionerViewModel, RegisterNewPractitionerCommand>().ConstructUsing(p =>
                new RegisterNewPractitionerCommand(p.FullName, p.Expertise, p.Phone, p.Email, p.CRM));

            CreateMap<UpdatePractitionerEmailViewModel, UpdatePractitionerEmailCommand>()
                .ConstructUsing(p => new UpdatePractitionerEmailCommand(p.Id, p.Email));

            CreateMap<UpdatePractitionerPhoneViewModel, UpdatePractitionerPhoneCommand>()
                .ConstructUsing(p => new UpdatePractitionerPhoneCommand(p.Id, p.Phone));

            CreateMap<DeactivatePractitionerViewModel, DeactivatePractitionerCommand>()
                .ConstructUsing(p => new DeactivatePractitionerCommand(p.Id));
        }
    }
}
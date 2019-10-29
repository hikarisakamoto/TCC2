using AutoMapper;
using Sakamoto.TCC2.CSU.Patient.Application.ViewModels;
using Sakamoto.TCC2.CSU.Patients.Domain.Commands;

namespace Sakamoto.TCC2.CSU.Patient.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<RegisterNewPatientViewModel, RegisterNewPatientCommand>()
                .ConvertUsing(p =>
                    new RegisterNewPatientCommand(p.FullName, p.BirthDate, p.Gender, p.Cpf, p.Phone));

            CreateMap<DeactivatePatientViewModel, DeactivatePatientCommand>()
                .ConvertUsing(p =>
                    new DeactivatePatientCommand(p.Id, p.Cpf));

            CreateMap<UpdatePatientAddressViewModel, UpdatePatientAddressCommand>()
                .ConstructUsing(p =>
                    new UpdatePatientAddressCommand(p.Id, p.City, p.District, p.Number, p.Observation, p.PostalCode,
                        p.State, p.Street));

            CreateMap<UpdatePatientEmailViewModel, UpdatePatientEmailCommand>()
                .ConstructUsing(p =>
                    new UpdatePatientEmailCommand(p.Id, p.Email));

            CreateMap<UpdatePatientHeartRateViewModel, UpdatePatientHeartRateCommand>()
                .ConstructUsing(p =>
                    new UpdatePatientHeartRateCommand(p.Id, p.HeartRate));

            CreateMap<UpdatePatientPhoneViewModel, UpdatePatientPhoneCommand>()
                .ConstructUsing(p =>
                    new UpdatePatientPhoneCommand(p.Id, p.Phone));

            CreateMap<UpdatePatientPhotoViewModel, UpdatePatientPhotoCommand>()
                .ConstructUsing(p =>
                    new UpdatePatientPhotoCommand(p.Id, p.Photo));
        }
    }
}
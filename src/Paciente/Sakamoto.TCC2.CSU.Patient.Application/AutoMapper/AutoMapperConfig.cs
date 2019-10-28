using AutoMapper;

namespace Sakamoto.TCC2.CSU.Patient.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new DomainToViewModelMapping());
                config.AddProfile(new ViewModelToDomainMapping());
            });
        }
    }
}
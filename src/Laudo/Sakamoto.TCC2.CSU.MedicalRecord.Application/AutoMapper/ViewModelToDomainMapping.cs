using AutoMapper;
using Sakamoto.TCC2.CSU.MedicalRecord.Application.ViewModel;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Commands;
using Sakamoto.TCC2.CSU.MedicalRecord.Domain.Models;

namespace Sakamoto.TCC2.CSU.MedicalRecord.Application.AutoMapper
{
    public class ViewModelToDomainMapping : Profile
    {
        public ViewModelToDomainMapping()
        {
            CreateMap<PatientViewModel, Patient>()
                .ConstructUsing(p =>
                    new Patient(p.PatientId, p.FullName));

            CreateMap<PractitionerViewModel, Practitioner>()
                .ConstructUsing(p =>
                    new Practitioner(p.PractitionerId, p.FullName));

            CreateMap<AddNewMedicalReportViewModel, AddNewMedicalReportCommand>()
                .ConvertUsing(mr =>
                    new AddNewMedicalReportCommand(mr.LongDescription,
                        new Patient(mr.Patient.PatientId, mr.Patient.FullName),
                        new Practitioner(mr.Practitioner.PractitionerId, mr.Practitioner.FullName),
                        mr.ShortDescription));

            CreateMap<RemoveExistingMedicalReportByIdViewModel, RemoveExistingMedicalReportByIdCommand>()
                .ConstructUsing(mr =>
                    new RemoveExistingMedicalReportByIdCommand(mr.MedicalReportId, mr.PractitionerId, mr.PatientId));
        }
    }
}
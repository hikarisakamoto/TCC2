using System;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;
using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects.Enums;
using Xunit;

namespace Sakamoto.TCC2.CSU.Paciente.Tests.Model
{
    public class PatientTest
    {
        [Fact(DisplayName = "Should create a new, valid and active, patient with all attributes")]
        [Trait("Model", "Patient")]
        public void MustCreateValidActivePatientWithAllAttributes()
        {
            // Arrange
            var address = new Address.Builder()
                .InCityOf("Porto Alegre")
                .InTheState("Rio Grande do Sul")
                .WithPostalCode("91900420")
                .WithStreet("Some Place")
                .WithNumber("123")
                .InTheDistrict("Some District")
                .WithObservation("The Blue House")
                .Build();


            // Act
            var patient = new Patient.Builder(Guid.NewGuid())
                .Named("Johnny Bravo")
                .WithCpf(new CPF("58554143027"))
                .BornIn(new DateTime(1988, 09, 09))
                .WithGender(Gender.Male)
                .WithEmail("test@test.com")
                .WhichIsActive()
                .ThatLivesIn(address)
                .WithPhoto(new byte[] {0x00, 0x01, 0x02, 0x03})
                .Build();

            // Assert
            Assert.Equal("Johnny Bravo", patient.FullName);
            Assert.Equal("58554143027", patient.Cpf.Cpf);
            Assert.Equal(new DateTime(1988, 09, 09), patient.BirthDate);
            Assert.Equal(Gender.Male, patient.Gender);
            Assert.Equal("test@test.com", patient.Email);
            Assert.NotNull(patient.Address);
            Assert.True(patient.IsActive);
            Assert.NotNull(patient.Photo);
        }


        [Fact(DisplayName = "Should create a new, valid and inactive, patient with all attributes")]
        [Trait("Model", "Patient")]
        public void MustCreateValidInactivePatientWithAllAttributes()
        {
            // Arrange
            var address = new Address.Builder()
                .InCityOf("Porto Alegre")
                .InTheState("Rio Grande do Sul")
                .WithPostalCode("91900420")
                .WithStreet("Some Place")
                .WithNumber("123")
                .InTheDistrict("Some District")
                .WithObservation("The Blue House")
                .Build();


            // Act
            var patient = new Patient.Builder(Guid.NewGuid())
                .Named("Johnny Bravo")
                .WithCpf(new CPF("58554143027"))
                .BornIn(new DateTime(1988, 09, 09))
                .WithGender(Gender.Male)
                .WithEmail("test@test.com")
                .WhichIsInactive()
                .ThatLivesIn(address)
                .WithPhoto(new byte[] {0x00, 0x01, 0x02, 0x03})
                .Build();

            // Assert
            Assert.Equal("Johnny Bravo", patient.FullName);
            Assert.Equal("58554143027", patient.Cpf.Cpf);
            Assert.Equal(new DateTime(1988, 09, 09), patient.BirthDate);
            Assert.Equal(Gender.Male, patient.Gender);
            Assert.Equal("test@test.com", patient.Email);
            Assert.NotNull(patient.Address);
            Assert.False(patient.IsActive);
            Assert.NotNull(patient.Photo);
        }
    }
}
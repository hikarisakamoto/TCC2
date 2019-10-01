using Sakamoto.TCC2.CSU.Patients.Domain.ValueObjects;
using Xunit;

namespace Sakamoto.TCC2.CSU.Paciente.Tests.ValueObjects
{
    public class AddressTest
    {
        [Fact(DisplayName = "Should create a new, valid, address with all attributes")]
        [Trait("Value Object", "Address")]
        public void MustCreateValidAddress()
        {
            // Arrange
            //Act
            var address = new Address.Builder()
                .InCityOf("Porto Alegre")
                .InTheState("Rio Grande do Sul")
                .WithPostalCode("91900420")
                .WithStreet("Some Place")
                .WithNumber("123")
                .InTheDistrict("Some District")
                .WithObservation("The Blue House")
                .Build();

            // Assert
            Assert.Equal("Porto Alegre", address.City);
            Assert.Equal("Rio Grande do Sul", address.State);
            Assert.Equal("91900420", address.PostalCode);
            Assert.Equal("Some Place", address.Street);
            Assert.Equal("123", address.Number);
            Assert.Equal("Some District", address.District);
            Assert.Equal("The Blue House", address.Observation);
        }
    }
}
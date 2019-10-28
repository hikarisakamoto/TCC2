using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakamoto.TCC2.CSU.Patients.Domain.Models;

namespace Sakamoto.TCC2.CSU.Patients.Infrastructure.Data.Mappings
{
    public class PatientMap : IEntityTypeConfiguration<Patient>

    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.FullName)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.BirthDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.Gender)
                .HasColumnType("tinyint")
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(p => p.Photo)
                .HasColumnType("varbinary(max)")
                .IsRequired(false);

            builder.Ignore(p => p.ValidationResult);

            builder.OwnsOne(p => p.Cpf,
                cpf =>
                {
                    cpf.Property(c => c.Value)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CPF")
                        .HasMaxLength(11)
                        .IsRequired();

                    cpf.Ignore(p => p.ValidationResult);
                });

            builder.OwnsOne(p => p.Address,
                address =>
                {
                    address.Property(a => a.City)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("City")
                        .HasMaxLength(100);

                    address.Property(a => a.District)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("District")
                        .HasMaxLength(255);

                    address.Property(a => a.Number)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Number")
                        .HasMaxLength(10);

                    address.Property(a => a.Observation)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Observation")
                        .HasMaxLength(255);

                    address.Property(a => a.PostalCode)
                        .HasColumnType("varchar(8)")
                        .HasColumnName("PostalCode")
                        .HasMaxLength(8);

                    address.Property(a => a.State)
                        .HasColumnType("varchar(2)")
                        .HasColumnName("State")
                        .HasMaxLength(2);

                    address.Property(a => a.Street)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Street")
                        .HasMaxLength(255);

                    address.Ignore(p => p.ValidationResult);
                });
        }
    }
}
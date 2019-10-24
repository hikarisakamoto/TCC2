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

            builder.Property(p => p.Cpf.Value)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
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

            builder.Property(p => p.Address.City)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

            builder.Property(p => p.Address.District)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(p => p.Address.Number)
                .HasColumnType("varchar(10)")
                .HasMaxLength(10);

            builder.Property(p => p.Address.Observation)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);

            builder.Property(p => p.Address.PostalCode)
                .HasColumnType("varchar(8)")
                .HasMaxLength(8);

            builder.Property(p => p.Address.State)
                .HasColumnType("varchar(2)")
                .HasMaxLength(2);

            builder.Property(p => p.Address.Street)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255);
        }
    }
}
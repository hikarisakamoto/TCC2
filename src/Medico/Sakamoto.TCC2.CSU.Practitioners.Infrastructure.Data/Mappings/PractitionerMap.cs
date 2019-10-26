using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sakamoto.TCC2.CSU.Practitioners.Domain.Models;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.Data.Mappings
{
    public class PractitionerMap : IEntityTypeConfiguration<Practitioner>
    {
        public void Configure(EntityTypeBuilder<Practitioner> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.FullName)
                .HasColumnType("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.CRM)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Expertise)
                .HasColumnType("varchar(300)")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(p => p.IsActive)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(p => p.Phone)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.Ignore(p => p.ValidationResult);
        }
    }
}
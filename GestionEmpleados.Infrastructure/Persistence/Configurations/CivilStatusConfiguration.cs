using GestionEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestionEmpleados.Infrastructure.Persistence.Configurations
{
    internal class CivilStatusConfiguration : IEntityTypeConfiguration<CivilStatus>
    {
        public void Configure(EntityTypeBuilder<CivilStatus> builder)
        {
            builder.ToTable("CivilStatus");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(t => t.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre")
                .IsRequired();
        }
    }
}

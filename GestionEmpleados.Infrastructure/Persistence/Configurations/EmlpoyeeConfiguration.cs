using GestionEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Infrastructure.Persistence.Configurations
{
    public class EmlpoyeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(t=>t.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre")
                .IsRequired();
            builder.Property(t => t.ApellidoPaterno)
                .HasMaxLength(100)
                .HasColumnName("apellidoPaterno")
                .IsRequired();
            builder.Property(t => t.ApellidoMaterno)
                .HasMaxLength(100)
                .HasColumnName("apellidoMaterno")
                .IsRequired();
            builder.Property(t => t.Edad)
                .HasColumnType("int")
                .HasColumnName("edad")
                .IsRequired();
            builder.Property(t => t.FechaNacimiento)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimiento")
                .IsRequired();
            builder.Property(t => t.GeneroId)
                .HasColumnType("int")
                .HasColumnName("generoId")
                .IsRequired();
            builder.Property(t => t.EstadoCivilId)
                .HasColumnType("int")
                .HasColumnName("estadoCivilId")
                .IsRequired();
            builder.Property(t => t.Rfc)
                .HasMaxLength(100)
                .HasColumnName("rfc")
                .IsRequired();
            builder.Property(t => t.Direccion)
                .HasMaxLength(100)
                .HasColumnName("direccion")
                .IsRequired();
            builder.Property(t => t.Email)
                .HasMaxLength(100)
                .HasColumnName("email")
                .IsRequired();
            builder.Property(t => t.Telefono)
                .HasMaxLength(100)
                .HasColumnName("telefono")
                .IsRequired();
            builder.Property(t => t.Puesto)
                .HasMaxLength(100)
                .HasColumnName("puesto")
                .IsRequired();
            builder.Property(t => t.FechaAlta)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaAlta")
                .IsRequired();
            builder.Property(t => t.FechaBaja)
                .HasColumnName("fechaBaja")
                .HasColumnType("datetime");
            builder.Property(t => t.EstadoId)
                .HasColumnType("int")
                .HasColumnName("estadoId")
                .IsRequired();
            //Auditoria
            builder.Property(t => t.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("fechaCreacion")
                .HasDefaultValueSql("(getdate())");

            builder.Property(t => t.FechaModificacion)
                .HasColumnName("fechaModificacion")
                .HasColumnType("datetime");
        }
    }
}

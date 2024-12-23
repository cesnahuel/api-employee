﻿using GestionEmpleados.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEmpleados.Infrastructure.Persistence.Configurations
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Gender");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("id");

            builder.Property(t => t.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre")
                .IsRequired();
        }
    }
}

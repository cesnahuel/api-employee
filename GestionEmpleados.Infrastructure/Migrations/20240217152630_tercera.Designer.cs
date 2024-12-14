﻿// <auto-generated />
using System;
using GestionEmpleados.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionEmpleados.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240217152630_tercera")]
    partial class tercera
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionEmpleados.Domain.Entities.CivilStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("CivilStatus", (string)null);
                });

            modelBuilder.Entity("GestionEmpleados.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("apellidoMaterno");

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("apellidoPaterno");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("direccion");

                    b.Property<int>("Edad")
                        .HasColumnType("int")
                        .HasColumnName("edad");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("email");

                    b.Property<int>("EstadoCivilId")
                        .HasColumnType("int")
                        .HasColumnName("estadoCivilId");

                    b.Property<int>("EstadoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaAlta")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime>("FechaBaja")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaBaja");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("fechaCreacion")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaModificacion");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime")
                        .HasColumnName("fechaNacimiento");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int")
                        .HasColumnName("generoId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Puesto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("puesto");

                    b.Property<string>("Rfc")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("rfc");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("telefono");

                    b.HasKey("Id");

                    b.HasIndex("EstadoCivilId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("GeneroId");

                    b.ToTable("Employee", (string)null);
                });

            modelBuilder.Entity("GestionEmpleados.Domain.Entities.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Gender", (string)null);
                });

            modelBuilder.Entity("GestionEmpleados.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("GestionEmpleados.Domain.Entities.Employee", b =>
                {
                    b.HasOne("GestionEmpleados.Domain.Entities.CivilStatus", "EstadoCivil")
                        .WithMany()
                        .HasForeignKey("EstadoCivilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionEmpleados.Domain.Entities.Status", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionEmpleados.Domain.Entities.Gender", "Genero")
                        .WithMany()
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");

                    b.Navigation("EstadoCivil");

                    b.Navigation("Genero");
                });
#pragma warning restore 612, 618
        }
    }
}
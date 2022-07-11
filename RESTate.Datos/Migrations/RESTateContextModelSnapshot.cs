﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RESTate.Datos;

#nullable disable

namespace RESTate.Datos.Migrations
{
    [DbContext(typeof(RESTateContext))]
    partial class RESTateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RESTate.Datos.Entities.Contacto", b =>
                {
                    b.Property<int>("IdContacto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContacto"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("NumeroDocumento")
                        .HasColumnType("bigint");

                    b.Property<string>("Observaciones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TipoDocumento")
                        .HasColumnType("int");

                    b.HasKey("IdContacto");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.ContratoAlquiler", b =>
                {
                    b.Property<int>("IdContratoAlquiler")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContratoAlquiler"), 1L, 1);

                    b.Property<DateTime?>("FechaFinalizacionPlazo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaFirma")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaInicioPlazo")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRescision")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdContactoInquilino")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("IdContactoPropietario")
                        .HasColumnType("int");

                    b.Property<int>("IdInmueble")
                        .HasColumnType("int");

                    b.Property<double>("MontoPactadoInicial")
                        .HasColumnType("float");

                    b.Property<string>("UbicacionDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContratoAlquiler");

                    b.HasIndex("IdContactoInquilino");

                    b.HasIndex("IdContactoPropietario");

                    b.HasIndex("IdInmueble");

                    b.ToTable("ContratosAlquiler");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.Inmueble", b =>
                {
                    b.Property<int>("IdInmueble")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInmueble"), 1L, 1);

                    b.Property<int>("CantidadDeAmbientes")
                        .HasColumnType("int");

                    b.Property<int>("CantidadDeBaños")
                        .HasColumnType("int");

                    b.Property<int>("CantidadDeDormitorios")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<int>("MetrosCuadradosCubiertos")
                        .HasColumnType("int");

                    b.Property<string>("Resumen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInmueble");

                    b.ToTable("Inmuebles");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.PropietarioHistorico", b =>
                {
                    b.Property<int>("IdPropietarioHistorico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPropietarioHistorico"), 1L, 1);

                    b.Property<int>("IdContactoPropietario")
                        .HasColumnType("int");

                    b.Property<int?>("InmuebleIdInmueble")
                        .HasColumnType("int");

                    b.Property<string>("MotivoEntrada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MotivoSalida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPropietarioHistorico");

                    b.HasIndex("IdContactoPropietario");

                    b.HasIndex("InmuebleIdInmueble");

                    b.ToTable("PropietariosHistoricos");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.Reserva", b =>
                {
                    b.Property<int>("IdReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReserva"), 1L, 1);

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaLiberacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdContactoInteresado")
                        .HasColumnType("int");

                    b.Property<int>("IdInmueble")
                        .HasColumnType("int");

                    b.Property<string>("MotivoLiberacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdReserva");

                    b.HasIndex("IdContactoInteresado");

                    b.HasIndex("IdInmueble");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.Telefono", b =>
                {
                    b.Property<int>("IdTelefono")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTelefono"), 1L, 1);

                    b.Property<int>("IdContacto")
                        .HasColumnType("int");

                    b.Property<string>("NumeroTelefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTelefono");

                    b.HasIndex("IdContacto");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.ContratoAlquiler", b =>
                {
                    b.HasOne("RESTate.Datos.Entities.Contacto", "ContactoInquilino")
                        .WithMany("ContratosComoInquilino")
                        .HasForeignKey("IdContactoInquilino")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RESTate.Datos.Entities.Contacto", "ContactoPropietario")
                        .WithMany("ContratosComoPropietario")
                        .HasForeignKey("IdContactoPropietario")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RESTate.Datos.Entities.Inmueble", "Inmueble")
                        .WithMany()
                        .HasForeignKey("IdInmueble")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactoInquilino");

                    b.Navigation("ContactoPropietario");

                    b.Navigation("Inmueble");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.PropietarioHistorico", b =>
                {
                    b.HasOne("RESTate.Datos.Entities.Contacto", "Propietario")
                        .WithMany()
                        .HasForeignKey("IdContactoPropietario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RESTate.Datos.Entities.Inmueble", null)
                        .WithMany("HistorialPropietarios")
                        .HasForeignKey("InmuebleIdInmueble");

                    b.Navigation("Propietario");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.Reserva", b =>
                {
                    b.HasOne("RESTate.Datos.Entities.Contacto", "ContactoInteresado")
                        .WithMany()
                        .HasForeignKey("IdContactoInteresado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RESTate.Datos.Entities.Inmueble", "Inmueble")
                        .WithMany("HistorialReservas")
                        .HasForeignKey("IdInmueble")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactoInteresado");

                    b.Navigation("Inmueble");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.Telefono", b =>
                {
                    b.HasOne("RESTate.Datos.Entities.Contacto", "Contacto")
                        .WithMany("Telefonos")
                        .HasForeignKey("IdContacto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contacto");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.Contacto", b =>
                {
                    b.Navigation("ContratosComoInquilino");

                    b.Navigation("ContratosComoPropietario");

                    b.Navigation("Telefonos");
                });

            modelBuilder.Entity("RESTate.Datos.Entities.Inmueble", b =>
                {
                    b.Navigation("HistorialPropietarios");

                    b.Navigation("HistorialReservas");
                });
#pragma warning restore 612, 618
        }
    }
}

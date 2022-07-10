﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RESTate.Datos;

#nullable disable

namespace RESTate.Datos.Migrations
{
    [DbContext(typeof(RESTateContext))]
    [Migration("20220710202852_AgregarMetrosCuadrados")]
    partial class AgregarMetrosCuadrados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RESTate.Datos.Entities.Inmueble", b =>
                {
                    b.Property<int>("IdInmueble")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInmueble"), 1L, 1);

                    b.Property<int>("CantidadAmbientes")
                        .HasColumnType("int");

                    b.Property<int>("CantidadBaños")
                        .HasColumnType("int");

                    b.Property<int>("CantidadDormitorios")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MetrosCuadrados")
                        .HasColumnType("int");

                    b.Property<int>("MetrosCuadradosCubiertos")
                        .HasColumnType("int");

                    b.Property<string>("Resumen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInmueble");

                    b.ToTable("Inmuebles");
                });
#pragma warning restore 612, 618
        }
    }
}

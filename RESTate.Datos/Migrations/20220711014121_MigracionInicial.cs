using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTate.Datos.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contactos",
                columns: table => new
                {
                    IdContacto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDocumento = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contactos", x => x.IdContacto);
                });

            migrationBuilder.CreateTable(
                name: "Inmuebles",
                columns: table => new
                {
                    IdInmueble = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetrosCuadrados = table.Column<int>(type: "int", nullable: false),
                    MetrosCuadradosCubiertos = table.Column<int>(type: "int", nullable: false),
                    CantidadDeAmbientes = table.Column<int>(type: "int", nullable: false),
                    CantidadDeDormitorios = table.Column<int>(type: "int", nullable: false),
                    CantidadDeBaños = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmuebles", x => x.IdInmueble);
                });

            migrationBuilder.CreateTable(
                name: "Telefonos",
                columns: table => new
                {
                    IdTelefono = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdContacto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefonos", x => x.IdTelefono);
                    table.ForeignKey(
                        name: "FK_Telefonos_Contactos_IdContacto",
                        column: x => x.IdContacto,
                        principalTable: "Contactos",
                        principalColumn: "IdContacto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropietariosHistoricos",
                columns: table => new
                {
                    IdPropietarioHistorico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoEntrada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotivoSalida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdContactoPropietario = table.Column<int>(type: "int", nullable: false),
                    InmuebleIdInmueble = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropietariosHistoricos", x => x.IdPropietarioHistorico);
                    table.ForeignKey(
                        name: "FK_PropietariosHistoricos_Contactos_IdContactoPropietario",
                        column: x => x.IdContactoPropietario,
                        principalTable: "Contactos",
                        principalColumn: "IdContacto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropietariosHistoricos_Inmuebles_InmuebleIdInmueble",
                        column: x => x.InmuebleIdInmueble,
                        principalTable: "Inmuebles",
                        principalColumn: "IdInmueble");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotivoLiberacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLiberacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdInmueble = table.Column<int>(type: "int", nullable: false),
                    IdContactoInteresado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Contactos_IdContactoInteresado",
                        column: x => x.IdContactoInteresado,
                        principalTable: "Contactos",
                        principalColumn: "IdContacto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservas_Inmuebles_IdInmueble",
                        column: x => x.IdInmueble,
                        principalTable: "Inmuebles",
                        principalColumn: "IdInmueble",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropietariosHistoricos_IdContactoPropietario",
                table: "PropietariosHistoricos",
                column: "IdContactoPropietario");

            migrationBuilder.CreateIndex(
                name: "IX_PropietariosHistoricos_InmuebleIdInmueble",
                table: "PropietariosHistoricos",
                column: "InmuebleIdInmueble");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdContactoInteresado",
                table: "Reservas",
                column: "IdContactoInteresado");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdInmueble",
                table: "Reservas",
                column: "IdInmueble");

            migrationBuilder.CreateIndex(
                name: "IX_Telefonos_IdContacto",
                table: "Telefonos",
                column: "IdContacto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropietariosHistoricos");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Telefonos");

            migrationBuilder.DropTable(
                name: "Inmuebles");

            migrationBuilder.DropTable(
                name: "Contactos");
        }
    }
}

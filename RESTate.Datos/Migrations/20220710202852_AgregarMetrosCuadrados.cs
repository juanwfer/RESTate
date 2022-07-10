using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RESTate.Datos.Migrations
{
    public partial class AgregarMetrosCuadrados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetrosCuadrados",
                table: "Inmuebles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MetrosCuadradosCubiertos",
                table: "Inmuebles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetrosCuadrados",
                table: "Inmuebles");

            migrationBuilder.DropColumn(
                name: "MetrosCuadradosCubiertos",
                table: "Inmuebles");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoteriaWebScrapy.API.Migrations
{
    /// <inheritdoc />
    public partial class columnaFechaResultadoYSeedDataLoterias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaResultado",
                table: "resultadoQuiniela",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "loteria",
                columns: new[] { "IdLoteria", "NombreLoteria" },
                values: new object[,]
                {
                    { "GanaMas", "GanaMas" },
                    { "LaPrimera", "LaPrimera" },
                    { "LoteriaNacional", "LoteriaNacional" },
                    { "Pega3Mas", "Pega3Mas" },
                    { "QuinielaLeidsa", "QuinielaLeidsa" },
                    { "QuinielaReal", "QuinielaReal" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "GanaMas");

            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "LaPrimera");

            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "LoteriaNacional");

            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "Pega3Mas");

            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "QuinielaLeidsa");

            migrationBuilder.DeleteData(
                table: "loteria",
                keyColumn: "IdLoteria",
                keyValue: "QuinielaReal");

            migrationBuilder.DropColumn(
                name: "FechaResultado",
                table: "resultadoQuiniela");
        }
    }
}

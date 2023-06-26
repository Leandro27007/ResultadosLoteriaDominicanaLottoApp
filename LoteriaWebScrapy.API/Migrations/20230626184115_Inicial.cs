using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoteriaWebScrapy.API.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "loteria",
                columns: table => new
                {
                    IdLoteria = table.Column<string>(type: "TEXT", nullable: false),
                    NombreLoteria = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loteria", x => x.IdLoteria);
                });

            migrationBuilder.CreateTable(
                name: "resultadoQuiniela",
                columns: table => new
                {
                    IdResultado = table.Column<string>(type: "TEXT", nullable: false),
                    Primera = table.Column<string>(type: "TEXT", nullable: false),
                    Segunda = table.Column<string>(type: "TEXT", nullable: false),
                    Tercera = table.Column<string>(type: "TEXT", nullable: false),
                    IdLoteria = table.Column<string>(type: "TEXT", nullable: false),
                    LoteriaIdLoteria = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resultadoQuiniela", x => x.IdResultado);
                    table.ForeignKey(
                        name: "FK_resultadoQuiniela_loteria_LoteriaIdLoteria",
                        column: x => x.LoteriaIdLoteria,
                        principalTable: "loteria",
                        principalColumn: "IdLoteria");
                });

            migrationBuilder.CreateIndex(
                name: "IX_resultadoQuiniela_LoteriaIdLoteria",
                table: "resultadoQuiniela",
                column: "LoteriaIdLoteria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "resultadoQuiniela");

            migrationBuilder.DropTable(
                name: "loteria");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEROTECA_WEB_BACK.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PortaMuestra",
                columns: table => new
                {
                    IdPortaMuestra = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FechaIni = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    FechaFin = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    Columnas = table.Column<int>(type: "int", maxLength: 255, nullable: false),
                    Filas = table.Column<int>(type: "int", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortaMuestra", x => x.IdPortaMuestra);
                });

            migrationBuilder.CreateTable(
                name: "OrdenPortaMuestra",
                columns: table => new
                {
                    OrdenPortaMuestraId = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PosicionColumna = table.Column<int>(type: "int", maxLength: 2, nullable: true),
                    PosicionFila = table.Column<int>(type: "int", maxLength: 2, nullable: true),
                    Numero = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    IdPortaMuestra = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenPortaMuestra", x => x.OrdenPortaMuestraId);
                    table.ForeignKey(
                        name: "FK_OrdenPortaMuestra_PortaMuestra_IdPortaMuestra",
                        column: x => x.IdPortaMuestra,
                        principalTable: "PortaMuestra",
                        principalColumn: "IdPortaMuestra");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenPortaMuestra_IdPortaMuestra",
                table: "OrdenPortaMuestra",
                column: "IdPortaMuestra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenPortaMuestra");

            migrationBuilder.DropTable(
                name: "PortaMuestra");
        }
    }
}

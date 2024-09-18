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
                    IdPortaMuestra = table.Column<int>(type: "int", maxLength: 255, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PortaMuestra");
        }
    }
}

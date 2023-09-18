using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareControle.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class OrdemHorasTrabalhadas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "HorasTrabalhadas",
                table: "Ordens",
                type: "time",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HorasTrabalhadas",
                table: "Ordens");
        }
    }
}

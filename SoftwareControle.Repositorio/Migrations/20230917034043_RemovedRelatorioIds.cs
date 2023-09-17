using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareControle.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRelatorioIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FerramentaId",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "OrdemId",
                table: "Relatorios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Relatorios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FerramentaId",
                table: "Relatorios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrdemId",
                table: "Relatorios",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Relatorios",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareControle.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataAtualizacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Usuarios",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Ordens",
                newName: "DataAtualizacao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Ferramentas",
                newName: "DataAtualizacao");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao1",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao1",
                table: "Ordens",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao1",
                table: "Ferramentas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao1",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao1",
                table: "Ordens");

            migrationBuilder.DropColumn(
                name: "DataAtualizacao1",
                table: "Ferramentas");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Usuarios",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Ordens",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "DataAtualizacao",
                table: "Ferramentas",
                newName: "DataCriacao");
        }
    }
}

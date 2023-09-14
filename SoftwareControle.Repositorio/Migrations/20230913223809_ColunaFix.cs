using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareControle.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class ColunaFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAtualizacao1",
                table: "Usuarios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Usuarios",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Usuarios",
                type: "datetime2",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Usuarios");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataAtualizacao",
                table: "Usuarios",
                type: "datetime2",
                maxLength: 100,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtualizacao1",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);
        }
    }
}

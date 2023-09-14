using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareControle.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class SemFerramentaUsuarioTeste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ferramentas_Usuarios_UsuarioId",
                table: "Ferramentas");

            migrationBuilder.DropIndex(
                name: "IX_Ferramentas_UsuarioId",
                table: "Ferramentas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Ferramentas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "Ferramentas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Ferramentas_UsuarioId",
                table: "Ferramentas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ferramentas_Usuarios_UsuarioId",
                table: "Ferramentas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}

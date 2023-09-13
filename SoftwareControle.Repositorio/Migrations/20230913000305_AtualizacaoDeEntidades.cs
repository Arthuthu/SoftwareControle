using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoftwareControle.Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AtualizacaoDeEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adminstrador",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Cargo",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cargo",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "Adminstrador",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

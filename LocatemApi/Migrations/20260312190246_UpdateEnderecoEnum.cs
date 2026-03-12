using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocatemApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEnderecoEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoEndereco",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoEndereco",
                table: "Enderecos");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiUnicoServer.Migrations
{
    public partial class AddEstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "Taxistas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "Clientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Taxistas");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Clientes");
        }
    }
}

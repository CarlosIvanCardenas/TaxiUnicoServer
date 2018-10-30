using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiUnicoServer.Migrations
{
    public partial class AddDecimalType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kilometros",
                table: "Viajes",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Puntuacion",
                table: "Taxistas",
                type: "decimal(2, 1)",
                nullable: false,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Kilometros",
                table: "Viajes",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Puntuacion",
                table: "Taxistas",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(2, 1)");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TraficLightsRazorPages.Data.Migrations
{
    public partial class Validation_1_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "TraficLights",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Color",
                table: "TraficLights",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}

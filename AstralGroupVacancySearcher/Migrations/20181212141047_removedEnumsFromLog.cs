using Microsoft.EntityFrameworkCore.Migrations;

namespace AstralGroupVacancySearcher.Migrations
{
    public partial class removedEnumsFromLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Logs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Source",
                table: "Logs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Logs",
                nullable: false,
                defaultValue: 0);
        }
    }
}

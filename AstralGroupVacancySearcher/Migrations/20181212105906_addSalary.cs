using Microsoft.EntityFrameworkCore.Migrations;

namespace AstralGroupVacancySearcher.Migrations
{
    public partial class addSalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "response_letter_required",
                table: "Items",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "premium",
                table: "Items",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "has_test",
                table: "Items",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "archived",
                table: "Items",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AddColumn<int>(
                name: "from",
                table: "Items",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "to",
                table: "Items",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "from",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "to",
                table: "Items");

            migrationBuilder.AlterColumn<bool>(
                name: "response_letter_required",
                table: "Items",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "premium",
                table: "Items",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "has_test",
                table: "Items",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "archived",
                table: "Items",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}

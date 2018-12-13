using Microsoft.EntityFrameworkCore.Migrations;

namespace AstralGroupVacancySearcher.Migrations
{
    public partial class changeLogId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Logs_logId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Logs_ParentId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "Logs",
                newName: "Parentid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Logs",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_ParentId",
                table: "Logs",
                newName: "IX_Logs_Parentid");

            migrationBuilder.RenameColumn(
                name: "logId",
                table: "Items",
                newName: "logid");

            migrationBuilder.RenameIndex(
                name: "IX_Items_logId",
                table: "Items",
                newName: "IX_Items_logid");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Logs_logid",
                table: "Items",
                column: "logid",
                principalTable: "Logs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Logs_Parentid",
                table: "Logs",
                column: "Parentid",
                principalTable: "Logs",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Logs_logid",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Logs_Parentid",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "Parentid",
                table: "Logs",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Logs",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_Parentid",
                table: "Logs",
                newName: "IX_Logs_ParentId");

            migrationBuilder.RenameColumn(
                name: "logid",
                table: "Items",
                newName: "logId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_logid",
                table: "Items",
                newName: "IX_Items_logId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Logs_logId",
                table: "Items",
                column: "logId",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Logs_ParentId",
                table: "Logs",
                column: "ParentId",
                principalTable: "Logs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

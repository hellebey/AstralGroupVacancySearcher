using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AstralGroupVacancySearcher.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    city = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    building = table.Column<string>(nullable: true),
                    lat = table.Column<double>(nullable: true),
                    lng = table.Column<double>(nullable: true),
                    raw = table.Column<string>(nullable: true),
                    id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    alternate_url = table.Column<string>(nullable: true),
                    vacancies_url = table.Column<string>(nullable: true),
                    trusted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Source = table.Column<int>(nullable: false),
                    ParentId = table.Column<long>(nullable: true),
                    IsSuccess = table.Column<bool>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Logs_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    number = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    Contactsid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Phones_Contacts_Contactsid",
                        column: x => x.Contactsid,
                        principalTable: "Contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    premium = table.Column<bool>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    has_test = table.Column<bool>(nullable: false),
                    response_letter_required = table.Column<bool>(nullable: false),
                    typeid = table.Column<string>(nullable: true),
                    addressid = table.Column<string>(nullable: true),
                    employerid = table.Column<string>(nullable: true),
                    published_at = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    archived = table.Column<bool>(nullable: false),
                    apply_alternate_url = table.Column<string>(nullable: true),
                    url = table.Column<string>(nullable: true),
                    alternate_url = table.Column<string>(nullable: true),
                    contactsid = table.Column<int>(nullable: true),
                    logId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_Address_addressid",
                        column: x => x.addressid,
                        principalTable: "Address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Contacts_contactsid",
                        column: x => x.contactsid,
                        principalTable: "Contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Employers_employerid",
                        column: x => x.employerid,
                        principalTable: "Employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Logs_logId",
                        column: x => x.logId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Types_typeid",
                        column: x => x.typeid,
                        principalTable: "Types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_addressid",
                table: "Items",
                column: "addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_contactsid",
                table: "Items",
                column: "contactsid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_employerid",
                table: "Items",
                column: "employerid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_logId",
                table: "Items",
                column: "logId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_typeid",
                table: "Items",
                column: "typeid");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ParentId",
                table: "Logs",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_Contactsid",
                table: "Phones",
                column: "Contactsid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}

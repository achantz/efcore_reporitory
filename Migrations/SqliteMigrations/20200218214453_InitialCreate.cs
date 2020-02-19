using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations.SqliteMigrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AccountType = table.Column<string>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_account_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[] { 1, "23 KillYou Street", new DateTime(1982, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven Segal" });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[] { 2, "45 Funny Street", new DateTime(1979, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe Dirt" });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "Id", "Address", "DateOfBirth", "Name" },
                values: new object[] { 3, "56 Pickadilly Street", new DateTime(1946, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Cleese" });

            migrationBuilder.CreateIndex(
                name: "IX_account_OwnerId",
                table: "account",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}

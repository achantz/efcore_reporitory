using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    OwnerID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountID = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AccountType = table.Column<string>(nullable: false),
                    OwnerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_account_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owner",
                        principalColumn: "OwnerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "OwnerID", "Address", "DateOfBirth", "Name" },
                values: new object[] { 1L, "23 KillYou Street", new DateTime(1982, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steven Segal" });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "OwnerID", "Address", "DateOfBirth", "Name" },
                values: new object[] { 2L, "45 Funny Street", new DateTime(1979, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joe Dirt" });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "OwnerID", "Address", "DateOfBirth", "Name" },
                values: new object[] { 3L, "56 Pickadilly Street", new DateTime(1946, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Cleese" });

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
                name: "owner");
        }
    }
}

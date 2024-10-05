using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oreEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Modelclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountRole = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetBreed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetAge = table.Column<int>(type: "int", nullable: false),
                    PetDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.PetId);
                });

            migrationBuilder.CreateTable(
                name: "AccountPet",
                columns: table => new
                {
                    AccountsAccountId = table.Column<int>(type: "int", nullable: false),
                    PetsPetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPet", x => new { x.AccountsAccountId, x.PetsPetId });
                    table.ForeignKey(
                        name: "FK_AccountPet_Accounts_AccountsAccountId",
                        column: x => x.AccountsAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountPet_Pets_PetsPetId",
                        column: x => x.PetsPetId,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    ApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(type: "int", nullable: false),
                    PetID = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    ApplicationReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationExperience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationComments = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.ApplicationID);
                    table.ForeignKey(
                        name: "FK_Applications_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Pets_PetID",
                        column: x => x.PetID,
                        principalTable: "Pets",
                        principalColumn: "PetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountPet_PetsPetId",
                table: "AccountPet",
                column: "PetsPetId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_AccountId",
                table: "Applications",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PetID",
                table: "Applications",
                column: "PetID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPet");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}

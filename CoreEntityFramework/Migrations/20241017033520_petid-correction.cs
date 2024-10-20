using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oreEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class petidcorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Pets_PetID",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "PetID",
                table: "Applications",
                newName: "PetId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_PetID",
                table: "Applications",
                newName: "IX_Applications_PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Pets_PetId",
                table: "Applications",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Pets_PetId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "PetId",
                table: "Applications",
                newName: "PetID");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_PetId",
                table: "Applications",
                newName: "IX_Applications_PetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Pets_PetID",
                table: "Applications",
                column: "PetID",
                principalTable: "Pets",
                principalColumn: "PetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

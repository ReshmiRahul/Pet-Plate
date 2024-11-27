using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oreEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class FoodTruckTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountCity",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AccountState",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountCity",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AccountState",
                table: "Accounts");
        }
    }
}

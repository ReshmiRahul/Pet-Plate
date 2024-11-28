using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oreEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class updateApplications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_FoodTruck_FoodTruckId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodTruck_Location_LocationId",
                table: "FoodTruck");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_FoodTruck_FoodTruckId",
                table: "MenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Location",
                table: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTruck",
                table: "FoodTruck");

            migrationBuilder.RenameTable(
                name: "MenuItem",
                newName: "MenuItems");

            migrationBuilder.RenameTable(
                name: "Location",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "FoodTruck",
                newName: "FoodTrucks");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItem_FoodTruckId",
                table: "MenuItems",
                newName: "IX_MenuItems_FoodTruckId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodTruck_LocationId",
                table: "FoodTrucks",
                newName: "IX_FoodTrucks_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems",
                column: "MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Locations",
                table: "Locations",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTrucks",
                table: "FoodTrucks",
                column: "FoodTruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_FoodTrucks_FoodTruckId",
                table: "Applications",
                column: "FoodTruckId",
                principalTable: "FoodTrucks",
                principalColumn: "FoodTruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTrucks_Locations_LocationId",
                table: "FoodTrucks",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_FoodTrucks_FoodTruckId",
                table: "MenuItems",
                column: "FoodTruckId",
                principalTable: "FoodTrucks",
                principalColumn: "FoodTruckId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_FoodTrucks_FoodTruckId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodTrucks_Locations_LocationId",
                table: "FoodTrucks");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_FoodTrucks_FoodTruckId",
                table: "MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MenuItems",
                table: "MenuItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Locations",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodTrucks",
                table: "FoodTrucks");

            migrationBuilder.RenameTable(
                name: "MenuItems",
                newName: "MenuItem");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Location");

            migrationBuilder.RenameTable(
                name: "FoodTrucks",
                newName: "FoodTruck");

            migrationBuilder.RenameIndex(
                name: "IX_MenuItems_FoodTruckId",
                table: "MenuItem",
                newName: "IX_MenuItem_FoodTruckId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodTrucks_LocationId",
                table: "FoodTruck",
                newName: "IX_FoodTruck_LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MenuItem",
                table: "MenuItem",
                column: "MenuItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Location",
                table: "Location",
                column: "LocationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodTruck",
                table: "FoodTruck",
                column: "FoodTruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_FoodTruck_FoodTruckId",
                table: "Applications",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "FoodTruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTruck_Location_LocationId",
                table: "FoodTruck",
                column: "LocationId",
                principalTable: "Location",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_FoodTruck_FoodTruckId",
                table: "MenuItem",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "FoodTruckId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

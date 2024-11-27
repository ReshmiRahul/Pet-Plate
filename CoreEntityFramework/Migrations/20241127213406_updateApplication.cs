using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oreEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class updateApplication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodTruckId",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "FoodTruck",
                columns: table => new
                {
                    FoodTruckId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodTruck", x => x.FoodTruckId);
                    table.ForeignKey(
                        name: "FK_FoodTruck_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoodTruckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.MenuItemId);
                    table.ForeignKey(
                        name: "FK_MenuItem_FoodTruck_FoodTruckId",
                        column: x => x.FoodTruckId,
                        principalTable: "FoodTruck",
                        principalColumn: "FoodTruckId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_FoodTruckId",
                table: "Applications",
                column: "FoodTruckId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodTruck_LocationId",
                table: "FoodTruck",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_FoodTruckId",
                table: "MenuItem",
                column: "FoodTruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_FoodTruck_FoodTruckId",
                table: "Applications",
                column: "FoodTruckId",
                principalTable: "FoodTruck",
                principalColumn: "FoodTruckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_FoodTruck_FoodTruckId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "FoodTruck");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Applications_FoodTruckId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "FoodTruckId",
                table: "Applications");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedPreFilledDataFromENUMs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OldUsers");

            migrationBuilder.InsertData(
                table: "HeatingTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Electric" },
                    { 2, "Gas" },
                    { 3, "SolidFuel" },
                    { 4, "Solar" },
                    { 5, "Geothermal" }
                });

            migrationBuilder.InsertData(
                table: "LocationTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Street" },
                    { 2, "City" },
                    { 3, "CityArea" },
                    { 4, "District" },
                    { 5, "Region" }
                });

            migrationBuilder.InsertData(
                table: "PlanningTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Jacuzzi" },
                    { 2, "MultiLevel" },
                    { 3, "Terrace" },
                    { 4, "Penthouse" },
                    { 5, "WithoutFurniture" }
                });

            migrationBuilder.InsertData(
                table: "RealtyStatuses",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "Unknown" },
                    { 1, "New" },
                    { 2, "NonVerified" },
                    { 3, "Verified" },
                    { 4, "Deleted" }
                });

            migrationBuilder.InsertData(
                table: "RealtyTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Flat" },
                    { 2, "House" },
                    { 3, "Commercial" },
                    { 4, "Planning" },
                    { 5, "PlaceOnly" }
                });

            migrationBuilder.InsertData(
                table: "WallTypes",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 0, "None" },
                    { 1, "Brick" },
                    { 2, "Concrete" },
                    { 3, "Wood" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HeatingTypes",
                keyColumn: "ID",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "HeatingTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HeatingTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HeatingTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HeatingTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HeatingTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LocationTypes",
                keyColumn: "ID",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "LocationTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LocationTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LocationTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LocationTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LocationTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PlanningTypes",
                keyColumn: "ID",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "PlanningTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PlanningTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PlanningTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PlanningTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PlanningTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RealtyStatuses",
                keyColumn: "ID",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "RealtyStatuses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RealtyStatuses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RealtyStatuses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RealtyStatuses",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RealtyTypes",
                keyColumn: "ID",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "RealtyTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RealtyTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RealtyTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RealtyTypes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RealtyTypes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WallTypes",
                keyColumn: "ID",
                keyValue: 0);

            migrationBuilder.DeleteData(
                table: "WallTypes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WallTypes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WallTypes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.CreateTable(
                name: "OldUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateUpdated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OldUsers", x => x.Id);
                });
        }
    }
}

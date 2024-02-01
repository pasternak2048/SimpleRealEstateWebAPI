using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AddedRealtyInfrastructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase(
                collation: "SQL_Latin1_General_CP1_CI_AS");

            migrationBuilder.CreateTable(
                name: "HeatingTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanningTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RealtyStatuses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RealtyTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WallTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CityAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_CityAreaId",
                        column: x => x.CityAreaId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_CityId",
                        column: x => x.CityId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Locations_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_LocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realties",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RealtyTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    IsFirstFloor = table.Column<bool>(type: "bit", nullable: false),
                    IsLastFloor = table.Column<bool>(type: "bit", nullable: false),
                    FloorCount = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    RoomCount = table.Column<int>(type: "int", nullable: false),
                    BathCount = table.Column<int>(type: "int", nullable: false),
                    BuildDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RealtyStatusId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realties", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Realties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realties_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Realties_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realties_RealtyStatuses_RealtyStatusId",
                        column: x => x.RealtyStatusId,
                        principalTable: "RealtyStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realties_RealtyTypes_RealtyTypeId",
                        column: x => x.RealtyTypeId,
                        principalTable: "RealtyTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyHeatingTypes",
                columns: table => new
                {
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeatingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyHeatingTypes", x => new { x.RealtyId, x.HeatingTypeId });
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_HeatingTypes_HeatingTypeId",
                        column: x => x.HeatingTypeId,
                        principalTable: "HeatingTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyPlanningTypes",
                columns: table => new
                {
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanningTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyPlanningTypes", x => new { x.RealtyId, x.PlanningTypeId });
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_PlanningTypes_PlanningTypeId",
                        column: x => x.PlanningTypeId,
                        principalTable: "PlanningTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyWallTypes",
                columns: table => new
                {
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WallTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyWallTypes", x => new { x.RealtyId, x.WallTypeId });
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_Realties_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_WallTypes_WallTypeId",
                        column: x => x.WallTypeId,
                        principalTable: "WallTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityAreaId",
                table: "Locations",
                column: "CityAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_CityId",
                table: "Locations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_DistrictId",
                table: "Locations",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationTypeId",
                table: "Locations",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RegionId",
                table: "Locations",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_CreatedById",
                table: "Realties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_LocationId",
                table: "Realties",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_ModifiedById",
                table: "Realties",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_RealtyStatusId",
                table: "Realties",
                column: "RealtyStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Realties_RealtyTypeId",
                table: "Realties",
                column: "RealtyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_HeatingTypeId",
                table: "RealtyHeatingTypes",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_PlanningTypeId",
                table: "RealtyPlanningTypes",
                column: "PlanningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_WallTypeId",
                table: "RealtyWallTypes",
                column: "WallTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealtyHeatingTypes");

            migrationBuilder.DropTable(
                name: "RealtyPlanningTypes");

            migrationBuilder.DropTable(
                name: "RealtyWallTypes");

            migrationBuilder.DropTable(
                name: "HeatingTypes");

            migrationBuilder.DropTable(
                name: "PlanningTypes");

            migrationBuilder.DropTable(
                name: "Realties");

            migrationBuilder.DropTable(
                name: "WallTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "RealtyStatuses");

            migrationBuilder.DropTable(
                name: "RealtyTypes");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");
        }
    }
}

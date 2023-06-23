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
                name: "HeatingType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeatingType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LocationType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanningType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RealtyType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WallType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WallType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
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
                    table.PrimaryKey("PK_Location", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Location_Location_CityAreaId",
                        column: x => x.CityAreaId,
                        principalTable: "Location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Location_Location_CityId",
                        column: x => x.CityId,
                        principalTable: "Location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Location_Location_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Location_Location_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Location",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Location_LocationType_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "LocationType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realty",
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
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Realty_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realty_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Realty_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Realty_RealtyType_RealtyTypeId",
                        column: x => x.RealtyTypeId,
                        principalTable: "RealtyType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyHeatingType",
                columns: table => new
                {
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeatingTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyHeatingType", x => new { x.RealtyId, x.HeatingTypeId });
                    table.ForeignKey(
                        name: "FK_RealtyHeatingType_HeatingType_HeatingTypeId",
                        column: x => x.HeatingTypeId,
                        principalTable: "HeatingType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingType_Realty_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyPlanningType",
                columns: table => new
                {
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanningTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyPlanningType", x => new { x.RealtyId, x.PlanningTypeId });
                    table.ForeignKey(
                        name: "FK_RealtyPlanningType_PlanningType_PlanningTypeId",
                        column: x => x.PlanningTypeId,
                        principalTable: "PlanningType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningType_Realty_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealtyWallType",
                columns: table => new
                {
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WallTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyWallType", x => new { x.RealtyId, x.WallTypeId });
                    table.ForeignKey(
                        name: "FK_RealtyWallType_Realty_RealtyId",
                        column: x => x.RealtyId,
                        principalTable: "Realty",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealtyWallType_WallType_WallTypeId",
                        column: x => x.WallTypeId,
                        principalTable: "WallType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_CityAreaId",
                table: "Location",
                column: "CityAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CityId",
                table: "Location",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_DistrictId",
                table: "Location",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_LocationTypeId",
                table: "Location",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_RegionId",
                table: "Location",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_CreatedById",
                table: "Realty",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_LocationId",
                table: "Realty",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_ModifiedById",
                table: "Realty",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Realty_RealtyTypeId",
                table: "Realty",
                column: "RealtyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingType_HeatingTypeId",
                table: "RealtyHeatingType",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningType_PlanningTypeId",
                table: "RealtyPlanningType",
                column: "PlanningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallType_WallTypeId",
                table: "RealtyWallType",
                column: "WallTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealtyHeatingType");

            migrationBuilder.DropTable(
                name: "RealtyPlanningType");

            migrationBuilder.DropTable(
                name: "RealtyWallType");

            migrationBuilder.DropTable(
                name: "HeatingType");

            migrationBuilder.DropTable(
                name: "PlanningType");

            migrationBuilder.DropTable(
                name: "Realty");

            migrationBuilder.DropTable(
                name: "WallType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "RealtyType");

            migrationBuilder.DropTable(
                name: "LocationType");

            migrationBuilder.AlterDatabase(
                oldCollation: "SQL_Latin1_General_CP1_CI_AS");
        }
    }
}

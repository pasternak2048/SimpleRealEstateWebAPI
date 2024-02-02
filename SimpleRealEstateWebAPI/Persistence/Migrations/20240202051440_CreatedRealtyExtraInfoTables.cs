using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class CreatedRealtyExtraInfoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealtyHeatingTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeatingTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyHeatingTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyHeatingTypes_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanningTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyPlanningTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyPlanningTypes_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RealtyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WallTypeId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealtyWallTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealtyWallTypes_AspNetUsers_ModifiedById",
                        column: x => x.ModifiedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                name: "IX_RealtyHeatingTypes_CreatedById",
                table: "RealtyHeatingTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_HeatingTypeId",
                table: "RealtyHeatingTypes",
                column: "HeatingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_ModifiedById",
                table: "RealtyHeatingTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_RealtyId",
                table: "RealtyHeatingTypes",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_CreatedById",
                table: "RealtyPlanningTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_ModifiedById",
                table: "RealtyPlanningTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_PlanningTypeId",
                table: "RealtyPlanningTypes",
                column: "PlanningTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_RealtyId",
                table: "RealtyPlanningTypes",
                column: "RealtyId");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_CreatedById",
                table: "RealtyWallTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_ModifiedById",
                table: "RealtyWallTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_RealtyId",
                table: "RealtyWallTypes",
                column: "RealtyId");

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
        }
    }
}

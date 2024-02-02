using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class AuditableFunctionalityForRealtyProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realties_AspNetUsers_CreatedById",
                table: "Realties");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "RealtyWallTypes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "RealtyWallTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "RealtyWallTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "RealtyWallTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "RealtyPlanningTypes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "RealtyPlanningTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "RealtyPlanningTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "RealtyPlanningTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "RealtyHeatingTypes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "RealtyHeatingTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedAt",
                table: "RealtyHeatingTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ModifiedById",
                table: "RealtyHeatingTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_CreatedById",
                table: "RealtyWallTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyWallTypes_ModifiedById",
                table: "RealtyWallTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_CreatedById",
                table: "RealtyPlanningTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyPlanningTypes_ModifiedById",
                table: "RealtyPlanningTypes",
                column: "ModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_CreatedById",
                table: "RealtyHeatingTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_RealtyHeatingTypes_ModifiedById",
                table: "RealtyHeatingTypes",
                column: "ModifiedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_AspNetUsers_CreatedById",
                table: "Realties",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyHeatingTypes_AspNetUsers_CreatedById",
                table: "RealtyHeatingTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyHeatingTypes_AspNetUsers_ModifiedById",
                table: "RealtyHeatingTypes",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyPlanningTypes_AspNetUsers_CreatedById",
                table: "RealtyPlanningTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyPlanningTypes_AspNetUsers_ModifiedById",
                table: "RealtyPlanningTypes",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyWallTypes_AspNetUsers_CreatedById",
                table: "RealtyWallTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealtyWallTypes_AspNetUsers_ModifiedById",
                table: "RealtyWallTypes",
                column: "ModifiedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Realties_AspNetUsers_CreatedById",
                table: "Realties");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyHeatingTypes_AspNetUsers_CreatedById",
                table: "RealtyHeatingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyHeatingTypes_AspNetUsers_ModifiedById",
                table: "RealtyHeatingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyPlanningTypes_AspNetUsers_CreatedById",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyPlanningTypes_AspNetUsers_ModifiedById",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyWallTypes_AspNetUsers_CreatedById",
                table: "RealtyWallTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_RealtyWallTypes_AspNetUsers_ModifiedById",
                table: "RealtyWallTypes");

            migrationBuilder.DropIndex(
                name: "IX_RealtyWallTypes_CreatedById",
                table: "RealtyWallTypes");

            migrationBuilder.DropIndex(
                name: "IX_RealtyWallTypes_ModifiedById",
                table: "RealtyWallTypes");

            migrationBuilder.DropIndex(
                name: "IX_RealtyPlanningTypes_CreatedById",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropIndex(
                name: "IX_RealtyPlanningTypes_ModifiedById",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropIndex(
                name: "IX_RealtyHeatingTypes_CreatedById",
                table: "RealtyHeatingTypes");

            migrationBuilder.DropIndex(
                name: "IX_RealtyHeatingTypes_ModifiedById",
                table: "RealtyHeatingTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RealtyWallTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RealtyWallTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "RealtyWallTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "RealtyWallTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "RealtyPlanningTypes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RealtyHeatingTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "RealtyHeatingTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "RealtyHeatingTypes");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "RealtyHeatingTypes");

            migrationBuilder.AddForeignKey(
                name: "FK_Realties_AspNetUsers_CreatedById",
                table: "Realties",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

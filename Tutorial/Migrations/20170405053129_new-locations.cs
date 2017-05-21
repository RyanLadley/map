using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tutorial.Migrations
{
    public partial class newlocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Regions_RegionId1",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_RegionId1",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "RegionId1",
                table: "Locations");

            migrationBuilder.AlterColumn<long>(
                name: "RegionId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RegionId",
                table: "Locations",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Regions_RegionId",
                table: "Locations",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Regions_RegionId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_RegionId",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Locations",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "RegionId1",
                table: "Locations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_RegionId1",
                table: "Locations",
                column: "RegionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Regions_RegionId1",
                table: "Locations",
                column: "RegionId1",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

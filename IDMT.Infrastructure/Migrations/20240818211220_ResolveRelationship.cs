using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IDMT.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResolveRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionsResources_Positions_PositionId",
                table: "PositionsResources");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionsResources_Resources_ResourceId",
                table: "PositionsResources");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionsResources_PositionId",
                table: "PositionsResources",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionsResources_ResourceId",
                table: "PositionsResources",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PositionsResources_PositionId",
                table: "PositionsResources");

            migrationBuilder.DropForeignKey(
                name: "FK_PositionsResources_ResourceId",
                table: "PositionsResources");

            migrationBuilder.AddForeignKey(
                name: "FK_PositionsResources_Positions_PositionId",
                table: "PositionsResources",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PositionsResources_Resources_ResourceId",
                table: "PositionsResources",
                column: "ResourceId",
                principalTable: "Resources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

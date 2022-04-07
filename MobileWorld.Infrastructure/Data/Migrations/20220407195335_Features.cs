using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileWorld.Infrastructure.Data.Migrations
{
    public partial class Features : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_ComfortDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ExteriorDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_InteriorDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_OthersDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ProtectionDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_SafetyDetailsId",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "SafetyDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "ProtectionDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "OthersDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "InteriorDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "ExteriorDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "ComfortDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Features_ComfortDetailsId",
                table: "Features",
                column: "ComfortDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_ExteriorDetailsId",
                table: "Features",
                column: "ExteriorDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_InteriorDetailsId",
                table: "Features",
                column: "InteriorDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_OthersDetailsId",
                table: "Features",
                column: "OthersDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_ProtectionDetailsId",
                table: "Features",
                column: "ProtectionDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_SafetyDetailsId",
                table: "Features",
                column: "SafetyDetailsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Features_ComfortDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ExteriorDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_InteriorDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_OthersDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_ProtectionDetailsId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_SafetyDetailsId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "SafetyDetails");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "ProtectionDetails");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "OthersDetails");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "InteriorDetails");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "ExteriorDetails");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "ComfortDetails");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ComfortDetailsId",
                table: "Features",
                column: "ComfortDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ExteriorDetailsId",
                table: "Features",
                column: "ExteriorDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_InteriorDetailsId",
                table: "Features",
                column: "InteriorDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_OthersDetailsId",
                table: "Features",
                column: "OthersDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_ProtectionDetailsId",
                table: "Features",
                column: "ProtectionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_SafetyDetailsId",
                table: "Features",
                column: "SafetyDetailsId");
        }
    }
}

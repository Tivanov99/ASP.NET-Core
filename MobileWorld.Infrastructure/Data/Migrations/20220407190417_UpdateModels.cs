using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileWorld.Infrastructure.Data.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteAds_Ads_AdId",
                table: "FavoriteAds");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteAds_AspNetUsers_UserId",
                table: "FavoriteAds");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Features");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteAds_Ads_AdId",
                table: "FavoriteAds",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteAds_AspNetUsers_UserId",
                table: "FavoriteAds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteAds_Ads_AdId",
                table: "FavoriteAds");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteAds_AspNetUsers_UserId",
                table: "FavoriteAds");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Features",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars",
                column: "FeatureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteAds_Ads_AdId",
                table: "FavoriteAds",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteAds_AspNetUsers_UserId",
                table: "FavoriteAds",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

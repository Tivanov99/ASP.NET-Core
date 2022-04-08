using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileWorld.Infrastructure.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Cars_CarId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_EngineId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Ads_CarId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "Turbo",
                table: "Engines");

            migrationBuilder.AlterColumn<string>(
                name: "RegionName",
                table: "Regions",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Neiborhood",
                table: "Regions",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<int>(
                name: "NewtonMeter",
                table: "Engines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Engines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Mileage",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,3)");

            migrationBuilder.AddColumn<string>(
                name: "AdId",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Ads",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(6,2)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ads",
                type: "varchar(700)",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(700)",
                oldMaxLength: 700);

            migrationBuilder.CreateTable(
                name: "FavoriteAds",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AdId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteAds", x => new { x.AdId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavoriteAds_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteAds_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    SafetyDetailsId = table.Column<int>(type: "int", nullable: false),
                    ComfortDetailsId = table.Column<int>(type: "int", nullable: false),
                    OthersDetailsId = table.Column<int>(type: "int", nullable: false),
                    ExteriorDetailsId = table.Column<int>(type: "int", nullable: false),
                    ProtectionDetailsId = table.Column<int>(type: "int", nullable: false),
                    InteriorDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageData = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AdId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Ads_AdId",
                        column: x => x.AdId,
                        principalTable: "Ads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComfortDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    AutoStartStop = table.Column<bool>(type: "bit", nullable: false),
                    DvdTv = table.Column<bool>(type: "bit", nullable: false),
                    BluetoothHandsfree = table.Column<bool>(type: "bit", nullable: false),
                    SteptronicTiptronic = table.Column<bool>(type: "bit", nullable: false),
                    Usb = table.Column<bool>(type: "bit", nullable: false),
                    Airmatic = table.Column<bool>(type: "bit", nullable: false),
                    Keyless = table.Column<bool>(type: "bit", nullable: false),
                    DifferentialLock = table.Column<bool>(type: "bit", nullable: false),
                    BordPc = table.Column<bool>(type: "bit", nullable: false),
                    FastSlowShifts = table.Column<bool>(type: "bit", nullable: false),
                    LightDetector = table.Column<bool>(type: "bit", nullable: false),
                    ElMirrors = table.Column<bool>(type: "bit", nullable: false),
                    ElGlass = table.Column<bool>(type: "bit", nullable: false),
                    ElSuspension = table.Column<bool>(type: "bit", nullable: false),
                    ElSeats = table.Column<bool>(type: "bit", nullable: false),
                    Eps = table.Column<bool>(type: "bit", nullable: false),
                    Ac = table.Column<bool>(type: "bit", nullable: false),
                    Climatecontroll = table.Column<bool>(type: "bit", nullable: false),
                    MultiSteeringWheel = table.Column<bool>(type: "bit", nullable: false),
                    Navigation = table.Column<bool>(type: "bit", nullable: false),
                    SteeringWheelHeating = table.Column<bool>(type: "bit", nullable: false),
                    FrontGlassHeating = table.Column<bool>(type: "bit", nullable: false),
                    SeatsHeating = table.Column<bool>(type: "bit", nullable: false),
                    SteeringWheelAdjustment = table.Column<bool>(type: "bit", nullable: false),
                    RainSensor = table.Column<bool>(type: "bit", nullable: false),
                    PowerSteering = table.Column<bool>(type: "bit", nullable: false),
                    HeadlampWashSystem = table.Column<bool>(type: "bit", nullable: false),
                    Autopilot = table.Column<bool>(type: "bit", nullable: false),
                    Stereo = table.Column<bool>(type: "bit", nullable: false),
                    Filter = table.Column<bool>(type: "bit", nullable: false),
                    RefrigerationFrog = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComfortDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComfortDetails_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExteriorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Coupe = table.Column<bool>(type: "bit", nullable: false),
                    Sedan = table.Column<bool>(type: "bit", nullable: false),
                    LedHeadlights = table.Column<bool>(type: "bit", nullable: false),
                    XenonLights = table.Column<bool>(type: "bit", nullable: false),
                    AlloyWheels = table.Column<bool>(type: "bit", nullable: false),
                    Metallic = table.Column<bool>(type: "bit", nullable: false),
                    PanoramicSunroof = table.Column<bool>(type: "bit", nullable: false),
                    Spoilers = table.Column<bool>(type: "bit", nullable: false),
                    Shibedah = table.Column<bool>(type: "bit", nullable: false),
                    HalogenHeadlights = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExteriorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExteriorDetails_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteriorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    SuedeSaloon = table.Column<bool>(type: "bit", nullable: false),
                    LeatherSalon = table.Column<bool>(type: "bit", nullable: false),
                    Taxi = table.Column<bool>(type: "bit", nullable: false),
                    Educational = table.Column<bool>(type: "bit", nullable: false),
                    Ruler = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteriorDetails_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OthersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    AllDrive = table.Column<bool>(type: "bit", nullable: false),
                    SevenSeats = table.Column<bool>(type: "bit", nullable: false),
                    BuyBack = table.Column<bool>(type: "bit", nullable: false),
                    Exchange = table.Column<bool>(type: "bit", nullable: false),
                    AutoGas = table.Column<bool>(type: "bit", nullable: false),
                    Long = table.Column<bool>(type: "bit", nullable: false),
                    Catastrophic = table.Column<bool>(type: "bit", nullable: false),
                    Leasing = table.Column<bool>(type: "bit", nullable: false),
                    MethaneSystem = table.Column<bool>(type: "bit", nullable: false),
                    InPieces = table.Column<bool>(type: "bit", nullable: false),
                    FullyServed = table.Column<bool>(type: "bit", nullable: false),
                    Registration = table.Column<bool>(type: "bit", nullable: false),
                    Tuning = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OthersDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OthersDetails_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProtectionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Alarm = table.Column<bool>(type: "bit", nullable: false),
                    Armored = table.Column<bool>(type: "bit", nullable: false),
                    Immobilizer = table.Column<bool>(type: "bit", nullable: false),
                    Casco = table.Column<bool>(type: "bit", nullable: false),
                    CentralLocking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtectionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProtectionDetails_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    Gps = table.Column<bool>(type: "bit", nullable: false),
                    AutomaticStabilityControl = table.Column<bool>(type: "bit", nullable: false),
                    AdaptiveFrontLights = table.Column<bool>(type: "bit", nullable: false),
                    Abs = table.Column<bool>(type: "bit", nullable: false),
                    ElBreaks = table.Column<bool>(type: "bit", nullable: false),
                    Esp = table.Column<bool>(type: "bit", nullable: false),
                    TirePressure = table.Column<bool>(type: "bit", nullable: false),
                    ParkPilot = table.Column<bool>(type: "bit", nullable: false),
                    IsoFix = table.Column<bool>(type: "bit", nullable: false),
                    DynamicStabilitySystem = table.Column<bool>(type: "bit", nullable: false),
                    SlipProtectionSystem = table.Column<bool>(type: "bit", nullable: false),
                    DryBrakesSystem = table.Column<bool>(type: "bit", nullable: false),
                    Distronic = table.Column<bool>(type: "bit", nullable: false),
                    HillDescentControll = table.Column<bool>(type: "bit", nullable: false),
                    BrakeAssist = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyDetails_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Engines_CarId",
                table: "Engines",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_AdId",
                table: "Cars",
                column: "AdId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ComfortDetails_FeatureId",
                table: "ComfortDetails",
                column: "FeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExteriorDetails_FeatureId",
                table: "ExteriorDetails",
                column: "FeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteAds_UserId",
                table: "FavoriteAds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CarId",
                table: "Features",
                column: "CarId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_AdId",
                table: "Images",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_InteriorDetails_FeatureId",
                table: "InteriorDetails",
                column: "FeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OthersDetails_FeatureId",
                table: "OthersDetails",
                column: "FeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProtectionDetails_FeatureId",
                table: "ProtectionDetails",
                column: "FeatureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SafetyDetails_FeatureId",
                table: "SafetyDetails",
                column: "FeatureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Ads_AdId",
                table: "Cars",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Engines_Cars_CarId",
                table: "Engines",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Ads_AdId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Engines_Cars_CarId",
                table: "Engines");

            migrationBuilder.DropTable(
                name: "ComfortDetails");

            migrationBuilder.DropTable(
                name: "ExteriorDetails");

            migrationBuilder.DropTable(
                name: "FavoriteAds");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "InteriorDetails");

            migrationBuilder.DropTable(
                name: "OthersDetails");

            migrationBuilder.DropTable(
                name: "ProtectionDetails");

            migrationBuilder.DropTable(
                name: "SafetyDetails");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Engines_CarId",
                table: "Engines");

            migrationBuilder.DropIndex(
                name: "IX_Cars_AdId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "AdId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "RegionName",
                table: "Regions",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Neiborhood",
                table: "Regions",
                type: "nvarchar(70)",
                maxLength: 70,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(70)",
                oldMaxLength: 70,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewtonMeter",
                table: "Engines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Turbo",
                table: "Engines",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Mileage",
                table: "Cars",
                type: "decimal(6,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Ads",
                type: "decimal(6,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Ads",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Ads",
                type: "nvarchar(700)",
                maxLength: 700,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(700)",
                oldMaxLength: 700);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_EngineId",
                table: "Cars",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_CarId",
                table: "Ads",
                column: "CarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_AspNetUsers_OwnerId",
                table: "Ads",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Cars_CarId",
                table: "Ads",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Engines_EngineId",
                table: "Cars",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

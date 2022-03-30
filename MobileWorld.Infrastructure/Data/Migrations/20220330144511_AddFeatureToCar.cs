using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileWorld.Infrastructure.Data.Migrations
{
    public partial class AddFeatureToCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Turbo",
                table: "Engines");

            migrationBuilder.AlterColumn<int>(
                name: "NewtonMeter",
                table: "Engines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ComfortDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "ExteriorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "InteriorDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuedeSaloon = table.Column<bool>(type: "bit", nullable: false),
                    LeatherSalon = table.Column<bool>(type: "bit", nullable: false),
                    Taxi = table.Column<bool>(type: "bit", nullable: false),
                    Educational = table.Column<bool>(type: "bit", nullable: false),
                    Ruler = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OthersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "ProtectionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alarm = table.Column<bool>(type: "bit", nullable: false),
                    Armored = table.Column<bool>(type: "bit", nullable: false),
                    Immobilizer = table.Column<bool>(type: "bit", nullable: false),
                    Casco = table.Column<bool>(type: "bit", nullable: false),
                    CentralLocking = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtectionDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        name: "FK_Features_ComfortDetails_ComfortDetailsId",
                        column: x => x.ComfortDetailsId,
                        principalTable: "ComfortDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_ExteriorDetails_ExteriorDetailsId",
                        column: x => x.ExteriorDetailsId,
                        principalTable: "ExteriorDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_InteriorDetails_InteriorDetailsId",
                        column: x => x.InteriorDetailsId,
                        principalTable: "InteriorDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_OthersDetails_OthersDetailsId",
                        column: x => x.OthersDetailsId,
                        principalTable: "OthersDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_ProtectionDetails_ProtectionDetailsId",
                        column: x => x.ProtectionDetailsId,
                        principalTable: "ProtectionDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_SafetyDetails_SafetyDetailsId",
                        column: x => x.SafetyDetailsId,
                        principalTable: "SafetyDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars",
                column: "FeatureId",
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Features_FeatureId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "ComfortDetails");

            migrationBuilder.DropTable(
                name: "ExteriorDetails");

            migrationBuilder.DropTable(
                name: "InteriorDetails");

            migrationBuilder.DropTable(
                name: "OthersDetails");

            migrationBuilder.DropTable(
                name: "ProtectionDetails");

            migrationBuilder.DropTable(
                name: "SafetyDetails");

            migrationBuilder.DropIndex(
                name: "IX_Cars_FeatureId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "Cars");

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
        }
    }
}

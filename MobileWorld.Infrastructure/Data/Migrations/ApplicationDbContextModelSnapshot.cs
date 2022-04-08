﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobileWorld.Infrastructure.Data;

#nullable disable

namespace MobileWorld.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Ad", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(700)
                        .HasColumnType("varchar(700)");

                    b.Property<string>("OwnerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("RegionId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<int>("GearType")
                        .HasColumnType("int");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Mileage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("SeatsCount")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdId")
                        .IsUnique();

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.ComfortDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Ac")
                        .HasColumnType("bit");

                    b.Property<bool>("Airmatic")
                        .HasColumnType("bit");

                    b.Property<bool>("AutoStartStop")
                        .HasColumnType("bit");

                    b.Property<bool>("Autopilot")
                        .HasColumnType("bit");

                    b.Property<bool>("BluetoothHandsfree")
                        .HasColumnType("bit");

                    b.Property<bool>("BordPc")
                        .HasColumnType("bit");

                    b.Property<bool>("Climatecontroll")
                        .HasColumnType("bit");

                    b.Property<bool>("DifferentialLock")
                        .HasColumnType("bit");

                    b.Property<bool>("DvdTv")
                        .HasColumnType("bit");

                    b.Property<bool>("ElGlass")
                        .HasColumnType("bit");

                    b.Property<bool>("ElMirrors")
                        .HasColumnType("bit");

                    b.Property<bool>("ElSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("ElSuspension")
                        .HasColumnType("bit");

                    b.Property<bool>("Eps")
                        .HasColumnType("bit");

                    b.Property<bool>("FastSlowShifts")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<bool>("Filter")
                        .HasColumnType("bit");

                    b.Property<bool>("FrontGlassHeating")
                        .HasColumnType("bit");

                    b.Property<bool>("HeadlampWashSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("Keyless")
                        .HasColumnType("bit");

                    b.Property<bool>("LightDetector")
                        .HasColumnType("bit");

                    b.Property<bool>("MultiSteeringWheel")
                        .HasColumnType("bit");

                    b.Property<bool>("Navigation")
                        .HasColumnType("bit");

                    b.Property<bool>("PowerSteering")
                        .HasColumnType("bit");

                    b.Property<bool>("RainSensor")
                        .HasColumnType("bit");

                    b.Property<bool>("RefrigerationFrog")
                        .HasColumnType("bit");

                    b.Property<bool>("SeatsHeating")
                        .HasColumnType("bit");

                    b.Property<bool>("SteeringWheelAdjustment")
                        .HasColumnType("bit");

                    b.Property<bool>("SteeringWheelHeating")
                        .HasColumnType("bit");

                    b.Property<bool>("SteptronicTiptronic")
                        .HasColumnType("bit");

                    b.Property<bool>("Stereo")
                        .HasColumnType("bit");

                    b.Property<bool>("Usb")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("ComfortDetails");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AutoGas")
                        .HasColumnType("bit");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CubicCapacity")
                        .HasColumnType("int");

                    b.Property<int>("EcoLevel")
                        .HasColumnType("int");

                    b.Property<double>("FuelConsuption")
                        .HasColumnType("float");

                    b.Property<int>("FuelType")
                        .HasColumnType("int");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<bool>("Hybrid")
                        .HasColumnType("bit");

                    b.Property<int?>("NewtonMeter")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Engines");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.ExteriorDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AlloyWheels")
                        .HasColumnType("bit");

                    b.Property<bool>("Coupe")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<bool>("HalogenHeadlights")
                        .HasColumnType("bit");

                    b.Property<bool>("LedHeadlights")
                        .HasColumnType("bit");

                    b.Property<bool>("Metallic")
                        .HasColumnType("bit");

                    b.Property<bool>("PanoramicSunroof")
                        .HasColumnType("bit");

                    b.Property<bool>("Sedan")
                        .HasColumnType("bit");

                    b.Property<bool>("Shibedah")
                        .HasColumnType("bit");

                    b.Property<bool>("Spoilers")
                        .HasColumnType("bit");

                    b.Property<bool>("XenonLights")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("ExteriorDetails");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.FavoriteAd", b =>
                {
                    b.Property<string>("AdId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AdId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FavoriteAds");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("Features");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AdId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.InteriorDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Educational")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<bool>("LeatherSalon")
                        .HasColumnType("bit");

                    b.Property<bool>("Ruler")
                        .HasColumnType("bit");

                    b.Property<bool>("SuedeSaloon")
                        .HasColumnType("bit");

                    b.Property<bool>("Taxi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("InteriorDetails");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.OthersDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AllDrive")
                        .HasColumnType("bit");

                    b.Property<bool>("AutoGas")
                        .HasColumnType("bit");

                    b.Property<bool>("BuyBack")
                        .HasColumnType("bit");

                    b.Property<bool>("Catastrophic")
                        .HasColumnType("bit");

                    b.Property<bool>("Exchange")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<bool>("FullyServed")
                        .HasColumnType("bit");

                    b.Property<bool>("InPieces")
                        .HasColumnType("bit");

                    b.Property<bool>("Leasing")
                        .HasColumnType("bit");

                    b.Property<bool>("Long")
                        .HasColumnType("bit");

                    b.Property<bool>("MethaneSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("Registration")
                        .HasColumnType("bit");

                    b.Property<bool>("SevenSeats")
                        .HasColumnType("bit");

                    b.Property<bool>("Tuning")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("OthersDetails");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.ProtectionDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Alarm")
                        .HasColumnType("bit");

                    b.Property<bool>("Armored")
                        .HasColumnType("bit");

                    b.Property<bool>("Casco")
                        .HasColumnType("bit");

                    b.Property<bool>("CentralLocking")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<bool>("Immobilizer")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("ProtectionDetails");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Neiborhood")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("RegionName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("TownId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.SafetyDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Abs")
                        .HasColumnType("bit");

                    b.Property<bool>("AdaptiveFrontLights")
                        .HasColumnType("bit");

                    b.Property<bool>("AutomaticStabilityControl")
                        .HasColumnType("bit");

                    b.Property<bool>("BrakeAssist")
                        .HasColumnType("bit");

                    b.Property<bool>("Distronic")
                        .HasColumnType("bit");

                    b.Property<bool>("DryBrakesSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("DynamicStabilitySystem")
                        .HasColumnType("bit");

                    b.Property<bool>("ElBreaks")
                        .HasColumnType("bit");

                    b.Property<bool>("Esp")
                        .HasColumnType("bit");

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<bool>("Gps")
                        .HasColumnType("bit");

                    b.Property<bool>("HillDescentControll")
                        .HasColumnType("bit");

                    b.Property<bool>("IsoFix")
                        .HasColumnType("bit");

                    b.Property<bool>("ParkPilot")
                        .HasColumnType("bit");

                    b.Property<bool>("SlipProtectionSystem")
                        .HasColumnType("bit");

                    b.Property<bool>("TirePressure")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId")
                        .IsUnique();

                    b.ToTable("SafetyDetails");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int?>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Ad", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", "Owner")
                        .WithMany("Ads")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Car", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Ad", "Ad")
                        .WithOne("Car")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.Car", "AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.ComfortDetail", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Feature", "Feature")
                        .WithOne("ComfortDetails")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.ComfortDetail", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Engine", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Car", "Car")
                        .WithOne("Engine")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.Engine", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.ExteriorDetail", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Feature", "Feature")
                        .WithOne("ExteriorDetails")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.ExteriorDetail", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.FavoriteAd", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Ad", "Ad")
                        .WithMany("Fans")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", "User")
                        .WithMany("FavoriteAds")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Feature", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Car", "Car")
                        .WithOne("Feature")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.Feature", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Image", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Ad", "Ad")
                        .WithMany("Images")
                        .HasForeignKey("AdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ad");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.InteriorDetail", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Feature", "Feature")
                        .WithOne("InteriorDetails")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.InteriorDetail", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.OthersDetail", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Feature", "Feature")
                        .WithOne("OthersDetails")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.OthersDetail", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.ProtectionDetail", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Feature", "Feature")
                        .WithOne("ProtectionDetails")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.ProtectionDetail", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Region", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Town", "Town")
                        .WithMany()
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Town");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.SafetyDetail", b =>
                {
                    b.HasOne("MobileWorld.Infrastructure.Data.Models.Feature", "Feature")
                        .WithOne("SafetyDetails")
                        .HasForeignKey("MobileWorld.Infrastructure.Data.Models.SafetyDetail", "FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Identity.ApplicationUser", b =>
                {
                    b.Navigation("Ads");

                    b.Navigation("FavoriteAds");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Ad", b =>
                {
                    b.Navigation("Car")
                        .IsRequired();

                    b.Navigation("Fans");

                    b.Navigation("Images");
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Car", b =>
                {
                    b.Navigation("Engine")
                        .IsRequired();

                    b.Navigation("Feature")
                        .IsRequired();
                });

            modelBuilder.Entity("MobileWorld.Infrastructure.Data.Models.Feature", b =>
                {
                    b.Navigation("ComfortDetails")
                        .IsRequired();

                    b.Navigation("ExteriorDetails")
                        .IsRequired();

                    b.Navigation("InteriorDetails")
                        .IsRequired();

                    b.Navigation("OthersDetails")
                        .IsRequired();

                    b.Navigation("ProtectionDetails")
                        .IsRequired();

                    b.Navigation("SafetyDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

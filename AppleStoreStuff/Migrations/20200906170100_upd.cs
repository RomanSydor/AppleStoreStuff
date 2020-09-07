using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppleStoreStuff.Migrations
{
    public partial class upd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirPodses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirPodsModel = table.Column<string>(nullable: true),
                    WirelessCharging = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmountOfProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirPodses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppleWatches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AppleWatchModel = table.Column<string>(nullable: true),
                    ScreenSize = table.Column<int>(nullable: false),
                    Cellular = table.Column<string>(nullable: true),
                    Gps = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    HousingMaterial = table.Column<string>(nullable: true),
                    StrapType = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmountOfProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppleWatches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IPadModel = table.Column<string>(nullable: true),
                    TypeOfModel = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ScreenType = table.Column<string>(nullable: true),
                    ScreenSize = table.Column<float>(nullable: false),
                    Processor = table.Column<string>(nullable: true),
                    Ram = table.Column<int>(nullable: false),
                    MainCamera = table.Column<string>(nullable: true),
                    FrontCamera = table.Column<int>(nullable: false),
                    YearOfProduction = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmountOfProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IPhones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IPhoneModel = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    ScreenType = table.Column<string>(nullable: true),
                    ScreenSize = table.Column<float>(nullable: false),
                    UhdRecording = table.Column<string>(nullable: true),
                    BatteryCapacity = table.Column<int>(nullable: false),
                    Processor = table.Column<string>(nullable: true),
                    Ram = table.Column<int>(nullable: false),
                    MainCamera = table.Column<string>(nullable: true),
                    FrontCamera = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmountOfProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IPhones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Macs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MacModel = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    ScreenSize = table.Column<float>(nullable: false),
                    Processor = table.Column<string>(nullable: true),
                    KernelsAmount = table.Column<int>(nullable: false),
                    Ram = table.Column<int>(nullable: false),
                    SsdCapacity = table.Column<string>(nullable: true),
                    DriveCapacity = table.Column<string>(nullable: true),
                    VideoCard = table.Column<string>(nullable: true),
                    YearOfProduction = table.Column<int>(nullable: false),
                    Color = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AmountOfProduct = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Macs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    BoughtProds = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirPodses");

            migrationBuilder.DropTable(
                name: "AppleWatches");

            migrationBuilder.DropTable(
                name: "IPads");

            migrationBuilder.DropTable(
                name: "IPhones");

            migrationBuilder.DropTable(
                name: "Macs");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class initialmigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "adress",
                table: "Patrons",
                newName: "Telephone");

            migrationBuilder.RenameColumn(
                name: "TelephoneNumber",
                table: "Patrons",
                newName: "HomeLibrary");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patrons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Patrons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Patrons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Patrons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HomeLibraryBranchId",
                table: "Patrons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibraryCardId",
                table: "Patrons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OverdueFees",
                table: "Patrons",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Patrons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "LibraryBranchDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfPatrons = table.Column<int>(type: "int", nullable: false),
                    NumberOfAssets = table.Column<int>(type: "int", nullable: false),
                    TotalAssetValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryBranchDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibraryCardDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryCardDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagDtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagDtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Video",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    duree = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    director = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Video", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<int>(type: "int", nullable: false),
                    CloseTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.id);
                    table.ForeignKey(
                        name: "FK_BranchHours_LibraryBranchDtos_BranchId",
                        column: x => x.BranchId,
                        principalTable: "LibraryBranchDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LibraryAssetDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false),
                    locationId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    deweyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryAssetDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryAssetDto_LibraryBranchDtos_locationId",
                        column: x => x.locationId,
                        principalTable: "LibraryBranchDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LibraryAssetDto_StatusDtos_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusDtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryAssetId = table.Column<int>(type: "int", nullable: true),
                    LibraryCardId = table.Column<int>(type: "int", nullable: true),
                    CheckedOutSince = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedOutUntil = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutDto_LibraryAssetDto_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssetDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutDto_LibraryCardDto_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCardDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistoryDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibraryAssetId = table.Column<int>(type: "int", nullable: true),
                    LibraryCardId = table.Column<int>(type: "int", nullable: true),
                    CheckedOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistoryDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistoryDto_LibraryAssetDto_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssetDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutHistoryDto_LibraryCardDto_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCardDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoldDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoldPlaced = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LibraryAssetId = table.Column<int>(type: "int", nullable: true),
                    LibraryCardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoldDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoldDto_LibraryAssetDto_LibraryAssetId",
                        column: x => x.LibraryAssetId,
                        principalTable: "LibraryAssetDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoldDto_LibraryCardDto_LibraryCardId",
                        column: x => x.LibraryCardId,
                        principalTable: "LibraryCardDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_HomeLibraryBranchId",
                table: "Patrons",
                column: "HomeLibraryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_BranchId",
                table: "BranchHours",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDto_LibraryAssetId",
                table: "CheckoutDto",
                column: "LibraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutDto_LibraryCardId",
                table: "CheckoutDto",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistoryDto_LibraryAssetId",
                table: "CheckoutHistoryDto",
                column: "LibraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistoryDto_LibraryCardId",
                table: "CheckoutHistoryDto",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldDto_LibraryAssetId",
                table: "HoldDto",
                column: "LibraryAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldDto_LibraryCardId",
                table: "HoldDto",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssetDto_locationId",
                table: "LibraryAssetDto",
                column: "locationId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryAssetDto_StatusId",
                table: "LibraryAssetDto",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryBranchDtos_HomeLibraryBranchId",
                table: "Patrons",
                column: "HomeLibraryBranchId",
                principalTable: "LibraryBranchDtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibraryCardDto_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId",
                principalTable: "LibraryCardDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryBranchDtos_HomeLibraryBranchId",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibraryCardDto_LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckoutDto");

            migrationBuilder.DropTable(
                name: "CheckoutHistoryDto");

            migrationBuilder.DropTable(
                name: "HoldDto");

            migrationBuilder.DropTable(
                name: "TagDtos");

            migrationBuilder.DropTable(
                name: "Video");

            migrationBuilder.DropTable(
                name: "LibraryAssetDto");

            migrationBuilder.DropTable(
                name: "LibraryCardDto");

            migrationBuilder.DropTable(
                name: "LibraryBranchDtos");

            migrationBuilder.DropTable(
                name: "StatusDtos");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_HomeLibraryBranchId",
                table: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "HomeLibraryBranchId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "OverdueFees",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Patrons");

            migrationBuilder.RenameColumn(
                name: "Telephone",
                table: "Patrons",
                newName: "adress");

            migrationBuilder.RenameColumn(
                name: "HomeLibrary",
                table: "Patrons",
                newName: "TelephoneNumber");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmazonService.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmazonOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BarcodeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    BuyingPrice = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderChannel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketPlace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmazonOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ASIN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ASINCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASIN", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SKIN",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SKINCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SKIN", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AmazonOrders");

            migrationBuilder.DropTable(
                name: "ASIN");

            migrationBuilder.DropTable(
                name: "SKIN");
        }
    }
}

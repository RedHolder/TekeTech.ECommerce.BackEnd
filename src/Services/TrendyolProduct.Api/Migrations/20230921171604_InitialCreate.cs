using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrendyolProduct.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTerritory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductSizes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShipmentTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductFeatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductChannel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastCheckDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductURL",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrendyolProductURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductURL", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ProductURL");
        }
    }
}

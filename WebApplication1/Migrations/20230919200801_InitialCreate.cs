using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrendyolProductModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FinalBrandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalTerritoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalSizes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalStock = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalShippingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinalFeatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductChannel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendyolProductModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrendyolProductModel");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations.CatalogDbMigration
{
    public partial class InitDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoParsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsStart = table.Column<bool>(type: "bit", nullable: false),
                    IsQueue = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    IsStartUpdate = table.Column<bool>(type: "bit", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompletionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoParsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationParsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComparatorLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationParsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationParsers_InfoParsers_ParserId",
                        column: x => x.ParserId,
                        principalTable: "InfoParsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "URLs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasBeenProcessed = table.Column<bool>(type: "bit", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    ElapsedMilliseconds = table.Column<int>(type: "int", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_URLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_URLs_InfoParsers_ParserId",
                        column: x => x.ParserId,
                        principalTable: "InfoParsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldConfigurations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfigurationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringParse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldConfigurations_ConfigurationParsers_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "ConfigurationParsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParseValuesProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price10 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityProductOffice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityProductStock = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    InfoURLId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParseValuesProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParseValuesProduct_URLs_InfoURLId",
                        column: x => x.InfoURLId,
                        principalTable: "URLs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TextProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(38,18)", precision: 38, scale: 18, nullable: false),
                    Availability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailabilityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Compatibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthWidthHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalogProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resource = table.Column<double>(type: "float", nullable: false),
                    TypeProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeEquipment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginallyProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeriesProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceFrom5 = table.Column<decimal>(type: "decimal(38,18)", precision: 38, scale: 18, nullable: false),
                    PriceFrom10 = table.Column<decimal>(type: "decimal(38,18)", precision: 38, scale: 18, nullable: false),
                    CodeTN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrinterCompatibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartridgeCompatibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityPackage = table.Column<int>(type: "int", nullable: false),
                    TrademarkAndPN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ParseValuesProduct_TextProductId",
                        column: x => x.TextProductId,
                        principalTable: "ParseValuesProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationParsers_ParserId",
                table: "ConfigurationParsers",
                column: "ParserId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldConfigurations_ConfigurationId",
                table: "FieldConfigurations",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ParseValuesProduct_InfoURLId",
                table: "ParseValuesProduct",
                column: "InfoURLId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TextProductId",
                table: "Product",
                column: "TextProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_URLs_ParserId",
                table: "URLs",
                column: "ParserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FieldConfigurations");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "ConfigurationParsers");

            migrationBuilder.DropTable(
                name: "ParseValuesProduct");

            migrationBuilder.DropTable(
                name: "URLs");

            migrationBuilder.DropTable(
                name: "InfoParsers");
        }
    }
}

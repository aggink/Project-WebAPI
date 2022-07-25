using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Company.Data.Migrations.ParserDbMigration
{
    public partial class UpdateParser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkParser_PropertyParserId",
                table: "WorkParser",
                column: "PropertyParserId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkParser_PropertyParser_PropertyParserId",
                table: "WorkParser",
                column: "PropertyParserId",
                principalTable: "PropertyParser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkParser_PropertyParser_PropertyParserId",
                table: "WorkParser");

            migrationBuilder.DropIndex(
                name: "IX_WorkParser_PropertyParserId",
                table: "WorkParser");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inivohacks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeys_Add : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TrackingCodes_ProductID",
                table: "TrackingCodes",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingCodes_Products_ProductID",
                table: "TrackingCodes",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingCodes_Products_ProductID",
                table: "TrackingCodes");

            migrationBuilder.DropIndex(
                name: "IX_TrackingCodes_ProductID",
                table: "TrackingCodes");
        }
    }
}

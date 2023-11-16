using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inivohacks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class certificate_foreign_Keys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Products_ProductID",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackingCodes_Products_ProductID",
                table: "TrackingCodes");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Products_ProductID",
                table: "Certificates",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingCodes_Products_ProductID",
                table: "TrackingCodes",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certificates_Products_ProductID",
                table: "Certificates");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackingCodes_Products_ProductID",
                table: "TrackingCodes");

            migrationBuilder.AddForeignKey(
                name: "FK_Certificates_Products_ProductID",
                table: "Certificates",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingCodes_Products_ProductID",
                table: "TrackingCodes",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

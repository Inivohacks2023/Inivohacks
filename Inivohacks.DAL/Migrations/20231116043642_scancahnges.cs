using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inivohacks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class scancahnges : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "TrackingCodeCreatedTimeStamp",
                table: "TrackingCodes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Scans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Scans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Scans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Batch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ManufacturedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OriginalBatchid = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatchItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatchItem", x => x.Id);
                });

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

            migrationBuilder.DropTable(
                name: "Batch");

            migrationBuilder.DropTable(
                name: "BatchItem");

            migrationBuilder.DropColumn(
                name: "TrackingCodeCreatedTimeStamp",
                table: "TrackingCodes");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Scans");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Scans");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Scans");

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

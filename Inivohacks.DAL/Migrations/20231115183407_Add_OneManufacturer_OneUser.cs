using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inivohacks.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_OneManufacturer_OneUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufacturerID", "Address", "Name", "NotifyEmail", "NotifySMS" },
                values: new object[] { 1, "308 Negro Aroya Lane, Alberquerqe, New Mexico", "Walter White Pharmaceuticals", "walter.white@example.com", "+1 1234567890" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "FirstName", "LastName", "LoginDisabled", "ManufacturerID", "Password", "Username" },
                values: new object[] { 1, "Jesse", "Pinkman", false, 1, "123", "jesse" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufacturerID",
                keyValue: 1);
        }
    }
}

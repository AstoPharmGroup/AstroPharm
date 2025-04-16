using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroPharm.Data.Migrations
{
    /// <inheritdoc />
    public partial class isRevoke : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "RefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 1L,
                column: "IsRevoked",
                value: false);

            migrationBuilder.UpdateData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 2L,
                column: "IsRevoked",
                value: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "admin@example.com", "Admin", "User" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Email", "FirstName" },
                values: new object[] { "superadmin@example.com", "SuperAdmin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "RefreshTokens");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "ali.courier@example.com", "Ali", "Smith" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Email", "FirstName" },
                values: new object[] { "admin@example.com", "Admin" });
        }
    }
}

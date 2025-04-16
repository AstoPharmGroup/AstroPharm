using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AstroPharm.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoLatitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branch_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Catalogs",
                columns: new[] { "Id", "CatalogName", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "Pain Relief", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Antibiotics", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedAt", "LanguageName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "English", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbek", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "Id", "CreatedAt", "LoLatitude", "Longitude", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.299500000000002, 69.240099999999998, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.781700000000001, 64.428600000000003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "CreatedAt", "PaymentDate", "PaymentMethod", "PaymentStatus", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 23.48m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 12.50m, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LanguageId", "LastName", "Password", "PhoneNumber", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", "John", 1L, "Doe", "hashedpassword1", "+998901234567", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "ali.courier@example.com", "Ali", 2L, "Smith", "hashedpassword2", "+998901234568", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@example.com", "Admin", 1L, "User", "hashedpassword3", "+998901234569", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "BranchName", "CreatedAt", "LocationId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, "Tashkent Central", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Bukhara Main", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CatalogId", "CategoryName", "CreatedAt", "Description", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, "Analgesics", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pain relief medications", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, "Penicillin", new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antibiotic medications", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CreatedAt", "OrderDate", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 23L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 12L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L }
                });

            migrationBuilder.InsertData(
                table: "RefreshTokens",
                columns: new[] { "Id", "CreatedAt", "ExpiryDate", "Token", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "token123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "token456", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "ExpiredDate", "Image", "MedicationName", "Price", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pain reliever", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "paracetamol.jpg", "Paracetamol", 5.99m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antibiotic", new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "amoxicillin.jpg", "Amoxicillin", 12.50m, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Banners",
                columns: new[] { "Id", "CategoryId", "CategoryId1", "CreatedAt", "Description", "Image", "MedicationId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, 1L, null, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "20% off analgesics", "pain_sale.jpg", 1L, "Pain Relief Sale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, 2L, null, new DateTime(2025, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buy 2, get 1 free", "antibiotic_promo.jpg", 2L, "Antibiotic Promo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "Count", "CreatedAt", "MedicationId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, 2, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, 1, new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "CreatedAt", "Discount", "MedicationId", "OrderId", "PaymentId", "Quantity", "TotalAmount", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 1L, 1L, 1L, 2L, 11.98m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2L, new DateTime(2025, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0m, 2L, 2L, 2L, 1L, 12.50m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "WishLists",
                columns: new[] { "Id", "CreatedAt", "MedicationId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, new DateTime(2025, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branch_LocationId",
                table: "Branch",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branch");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DeleteData(
                table: "Banners",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Banners",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "RefreshTokens",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "WishLists",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Payments",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Catalogs",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}

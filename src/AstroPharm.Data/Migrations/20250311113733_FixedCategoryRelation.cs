using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AstroPharm.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Banners_Categories_CategoryId1",
                table: "Banners");

            migrationBuilder.DropIndex(
                name: "IX_Banners_CategoryId1",
                table: "Banners");

            migrationBuilder.DropColumn(
                name: "CategoryId1",
                table: "Banners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId1",
                table: "Banners",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Banners_CategoryId1",
                table: "Banners",
                column: "CategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Banners_Categories_CategoryId1",
                table: "Banners",
                column: "CategoryId1",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}

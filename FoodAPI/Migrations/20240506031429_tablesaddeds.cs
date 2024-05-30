using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablesaddeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_reviews_ResturantID",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_dishes_ResturantID",
                table: "dishes");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_ResturantID",
                table: "reviews",
                column: "ResturantID");

            migrationBuilder.CreateIndex(
                name: "IX_dishes_ResturantID",
                table: "dishes",
                column: "ResturantID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_reviews_ResturantID",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_dishes_ResturantID",
                table: "dishes");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_ResturantID",
                table: "reviews",
                column: "ResturantID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_dishes_ResturantID",
                table: "dishes",
                column: "ResturantID",
                unique: true);
        }
    }
}

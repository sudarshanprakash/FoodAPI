using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class trungfixanddriver10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_resturants_UserId",
                table: "resturants");

            migrationBuilder.CreateIndex(
                name: "IX_resturants_UserId",
                table: "resturants",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_resturants_UserId",
                table: "resturants");

            migrationBuilder.CreateIndex(
                name: "IX_resturants_UserId",
                table: "resturants",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");
        }
    }
}

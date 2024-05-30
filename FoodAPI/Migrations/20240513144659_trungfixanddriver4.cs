using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class trungfixanddriver4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants");

            migrationBuilder.DropIndex(
                name: "IX_resturants_UserId",
                table: "resturants");

            migrationBuilder.CreateIndex(
                name: "IX_resturants_UserId",
                table: "resturants",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants");

            migrationBuilder.DropIndex(
                name: "IX_resturants_UserId",
                table: "resturants");

            migrationBuilder.CreateIndex(
                name: "IX_resturants_UserId",
                table: "resturants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

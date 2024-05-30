using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class trungfixanddriver5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants");

            migrationBuilder.AddForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants");

            migrationBuilder.AddForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants",
                column: "UserId",
                principalTable: "users",
                principalColumn: "userID");
        }
    }
}

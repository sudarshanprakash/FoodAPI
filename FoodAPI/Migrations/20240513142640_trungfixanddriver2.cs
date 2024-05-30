using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class trungfixanddriver2 : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "resturants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_resturants_UserId",
                table: "resturants",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "resturants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                principalColumn: "userID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

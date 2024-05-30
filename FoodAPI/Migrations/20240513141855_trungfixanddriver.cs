using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class trungfixanddriver : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "resturants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "averageReview",
                table: "resturants",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "resturants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDispatched",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 1,
                columns: new[] { "UserId", "averageReview" },
                values: new object[] { 1, 3.0 });

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 2,
                columns: new[] { "UserId", "averageReview" },
                values: new object[] { 2, 3.0 });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resturants_users_UserId",
                table: "resturants");

            migrationBuilder.DropIndex(
                name: "IX_resturants_UserId",
                table: "resturants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "resturants");

            migrationBuilder.DropColumn(
                name: "isDispatched",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "resturants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "averageReview",
                table: "resturants",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 1,
                column: "averageReview",
                value: 3);

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 2,
                column: "averageReview",
                value: 3);
        }
    }
}

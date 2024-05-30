using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class priceaddedonordereddish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "orderedDishes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "dishes",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "dishes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 1,
                column: "price",
                value: 6.0);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 2,
                column: "price",
                value: 8.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "price",
                table: "orderedDishes");

            migrationBuilder.AlterColumn<float>(
                name: "price",
                table: "dishes",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "imageUrl",
                table: "dishes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 1,
                column: "price",
                value: 6f);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 2,
                column: "price",
                value: 8f);
        }
    }
}

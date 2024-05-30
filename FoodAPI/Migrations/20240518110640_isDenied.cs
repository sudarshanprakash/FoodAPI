using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class isDenied : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isDenied",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<double>(
                name: "price",
                table: "dishes",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

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
                name: "isDenied",
                table: "orders");

            migrationBuilder.AlterColumn<decimal>(
                name: "price",
                table: "dishes",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 1,
                column: "price",
                value: 6m);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 2,
                column: "price",
                value: 8m);
        }
    }
}

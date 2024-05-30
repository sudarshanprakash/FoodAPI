using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class delivery : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isEngaged",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "driverId",
                table: "orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDelivered",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isReady",
                table: "orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 1,
                column: "Description",
                value: "indian cusine");

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 2,
                column: "Description",
                value: "fast foods");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userID",
                keyValue: 1,
                column: "isEngaged",
                value: false);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userID",
                keyValue: 2,
                column: "isEngaged",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isEngaged",
                table: "users");

            migrationBuilder.DropColumn(
                name: "driverId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "isDelivered",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "isReady",
                table: "orders");

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "resturants",
                keyColumn: "resturantId",
                keyValue: 2,
                column: "Description",
                value: null);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class trungfixanddriver11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderedDishes_orders_orderId",
                table: "orderedDishes");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "orderedDishes",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderedDishes_orderId",
                table: "orderedDishes",
                newName: "IX_orderedDishes_OrderId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "subscriptionExpirationDate",
                table: "users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "subscreatedat",
                table: "users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<float>(
                name: "balance",
                table: "users",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "orderedDishes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userID",
                keyValue: 1,
                columns: new[] { "subscreatedat", "subscriptionExpirationDate" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userID",
                keyValue: 2,
                columns: new[] { "subscreatedat", "subscriptionExpirationDate" },
                values: new object[] { null, null });

            migrationBuilder.CreateIndex(
                name: "IX_orders_driverId",
                table: "orders",
                column: "driverId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderedDishes_orders_OrderId",
                table: "orderedDishes",
                column: "OrderId",
                principalTable: "orders",
                principalColumn: "orderId",
                onDelete: ReferentialAction.NoAction    );

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_driverId",
                table: "orders",
                column: "driverId",
                principalTable: "users",
                principalColumn: "userID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderedDishes_orders_OrderId",
                table: "orderedDishes");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_driverId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_driverId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "orderedDishes",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_orderedDishes_OrderId",
                table: "orderedDishes",
                newName: "IX_orderedDishes_orderId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "subscriptionExpirationDate",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "subscreatedat",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "balance",
                table: "users",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "orderId",
                table: "orderedDishes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userID",
                keyValue: 1,
                columns: new[] { "subscreatedat", "subscriptionExpirationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "userID",
                keyValue: 2,
                columns: new[] { "subscreatedat", "subscriptionExpirationDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.AddForeignKey(
                name: "FK_orderedDishes_orders_orderId",
                table: "orderedDishes",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "orderId");
        }
    }
}

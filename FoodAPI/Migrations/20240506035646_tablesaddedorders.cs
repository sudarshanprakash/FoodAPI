using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablesaddedorders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_Order_orderId",
                table: "dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_users_UserID",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserID",
                table: "orders",
                newName: "IX_orders_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_dishes_orders_orderId",
                table: "dishes",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_users_UserID",
                table: "orders",
                column: "UserID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_orders_orderId",
                table: "dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_users_UserID",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "Order");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UserID",
                table: "Order",
                newName: "IX_Order_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_dishes_Order_orderId",
                table: "dishes",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_users_UserID",
                table: "Order",
                column: "UserID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

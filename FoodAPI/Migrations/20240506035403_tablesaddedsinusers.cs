using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablesaddedsinusers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isProcessed = table.Column<bool>(type: "bit", nullable: false),
                    isDone = table.Column<bool>(type: "bit", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalPrice = table.Column<float>(type: "real", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Order_users_UserID",
                        column: x => x.UserID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 1,
                column: "orderId",
                value: null);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 2,
                column: "orderId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserID",
                table: "reviews",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_dishes_orderId",
                table: "dishes",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_dishes_Order_orderId",
                table: "dishes",
                column: "orderId",
                principalTable: "Order",
                principalColumn: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_UserID",
                table: "reviews",
                column: "UserID",
                principalTable: "users",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_Order_orderId",
                table: "dishes");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_UserID",
                table: "reviews");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropIndex(
                name: "IX_reviews_UserID",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_dishes_orderId",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "dishes");
        }
    }
}

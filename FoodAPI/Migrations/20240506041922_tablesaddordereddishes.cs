using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablesaddordereddishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dishes_orders_orderId",
                table: "dishes");

            migrationBuilder.DropIndex(
                name: "IX_dishes_orderId",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "orderId",
                table: "dishes");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "dishes");

            migrationBuilder.AddColumn<int>(
                name: "ResturantId",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "orderedDishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dishId = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderedDishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderedDishes_dishes_dishId",
                        column: x => x.dishId,
                        principalTable: "dishes",
                        principalColumn: "dishId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderedDishes_orders_orderId",
                        column: x => x.orderId,
                        principalTable: "orders",
                        principalColumn: "orderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_ResturantId",
                table: "orders",
                column: "ResturantId");

            migrationBuilder.CreateIndex(
                name: "IX_orderedDishes_dishId",
                table: "orderedDishes",
                column: "dishId");

            migrationBuilder.CreateIndex(
                name: "IX_orderedDishes_orderId",
                table: "orderedDishes",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_resturants_ResturantId",
                table: "orders",
                column: "ResturantId",
                principalTable: "resturants",
                principalColumn: "resturantId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_resturants_ResturantId",
                table: "orders");

            migrationBuilder.DropTable(
                name: "orderedDishes");

            migrationBuilder.DropIndex(
                name: "IX_orders_ResturantId",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "ResturantId",
                table: "orders");

            migrationBuilder.AddColumn<int>(
                name: "orderId",
                table: "dishes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 1,
                columns: new[] { "orderId", "quantity" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "dishes",
                keyColumn: "dishId",
                keyValue: 2,
                columns: new[] { "orderId", "quantity" },
                values: new object[] { null, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_dishes_orderId",
                table: "dishes",
                column: "orderId");

            migrationBuilder.AddForeignKey(
                name: "FK_dishes_orders_orderId",
                table: "dishes",
                column: "orderId",
                principalTable: "orders",
                principalColumn: "orderId");
        }
    }
}

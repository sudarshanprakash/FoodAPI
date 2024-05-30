using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class tablesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "resturants",
                columns: table => new
                {
                    resturantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    resturantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    postcode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    averageReview = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resturants", x => x.resturantId);
                });

            migrationBuilder.CreateTable(
                name: "dishes",
                columns: table => new
                {
                    dishId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    ResturantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dishes", x => x.dishId);
                    table.ForeignKey(
                        name: "FK_dishes_resturants_ResturantID",
                        column: x => x.ResturantID,
                        principalTable: "resturants",
                        principalColumn: "resturantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    reviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reviewContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    star = table.Column<int>(type: "int", nullable: false),
                    ResturantID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.reviewId);
                    table.ForeignKey(
                        name: "FK_reviews_resturants_ResturantID",
                        column: x => x.ResturantID,
                        principalTable: "resturants",
                        principalColumn: "resturantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "resturants",
                columns: new[] { "resturantId", "address", "averageReview", "category", "imageUrl", "phone", "postcode", "resturantName" },
                values: new object[,]
                {
                    { 1, "Berry, NSW", 3, "Indian", "image goes here", "08615151", "2541", "Indika" },
                    { 2, "Wollongong, NSW", 3, "American", "image goes here", "04156171", "2541", "KFC" }
                });

            migrationBuilder.InsertData(
                table: "dishes",
                columns: new[] { "dishId", "ResturantID", "imageUrl", "name", "price", "quantity" },
                values: new object[,]
                {
                    { 1, 1, "image url goes here", "Butter chicken", 6f, 0 },
                    { 2, 2, "image url goes here", "Fried Chicken", 8f, 0 }
                });

            migrationBuilder.InsertData(
                table: "reviews",
                columns: new[] { "reviewId", "ResturantID", "UserID", "reviewContent", "star" },
                values: new object[,]
                {
                    { 1, 1, 1, "very good", 5 },
                    { 2, 2, 2, "good", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_dishes_ResturantID",
                table: "dishes",
                column: "ResturantID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_ResturantID",
                table: "reviews",
                column: "ResturantID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dishes");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "resturants");
        }
    }
}

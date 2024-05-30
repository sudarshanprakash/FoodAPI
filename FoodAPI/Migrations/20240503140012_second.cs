using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAPI.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdat",
                table: "users",
                newName: "subscreatedat");

            migrationBuilder.AddColumn<bool>(
                name: "hasSubscription",
                table: "users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "userID", "address", "balance", "cardNumber", "email", "hasSubscription", "password", "phoneNumber", "postcode", "role", "subscreatedat", "subscriptionExpirationDate", "username" },
                values: new object[,]
                {
                    { 1, "Wollongong", 50f, "1235333", "trung@gmil.com", false, "trung@123", "62662622", "2500", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trung doan" },
                    { 2, "Wollongong", 50f, "1555333", "spk@gmil.com", false, "spk@123", "071116616", "2500", "User", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudarshan Khadka" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "userID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "hasSubscription",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "subscreatedat",
                table: "users",
                newName: "createdat");
        }
    }
}

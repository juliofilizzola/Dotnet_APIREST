using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekShopping.API.Migrations
{
    /// <inheritdoc />
    public partial class Seed_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "code", "created_at", "name" },
                values: new object[] { 1L, "XAS123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TEC" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "category",
                keyColumn: "id",
                keyValue: 1L);
        }
    }
}

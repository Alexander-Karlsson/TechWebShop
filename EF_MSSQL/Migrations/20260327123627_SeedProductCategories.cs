using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), "Think different. Think iPhone.", "iPhone" },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), "Do more. Much more.", "Mac" },
                    { new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012"), "Sound that moves with you.", "AirPods" },
                    { new Guid("d4e5f6a7-b8c9-0123-defa-234567890123"), "Thin. Powerful. Endless.", "iPad" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-0123-defa-234567890123"));
        }
    }
}

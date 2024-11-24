using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c052ffb4-245b-4c3c-8390-f1bd806828e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1980d60-8c25-4a75-a6a3-4981a270986e", "AQAAAAIAAYagAAAAEK6f02jEqi0mc4+x9D+FyGgS9PiagHNq5I5pqUL2phrgq+GYYpsJ3UKiBEykVOVzXg==", "93d0abf9-33a7-45c6-a22e-f0711f068e62" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c052ffb4-245b-4c3c-8390-f1bd806828e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9a807f9-766c-4fcf-a44e-6a1f895bfdf6", "AQAAAAIAAYagAAAAEB8FufCGU86Te+9o7x49T2RWPvCzrP7qk8dPgwASB1zR4HN/4roIt/5JNW/SkD0kag==", "76793afb-b30a-404f-8356-a864fa64f70a" });
        }
    }
}

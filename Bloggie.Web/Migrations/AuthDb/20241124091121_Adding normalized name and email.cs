using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class Addingnormalizednameandemail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c052ffb4-245b-4c3c-8390-f1bd806828e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81bda475-eafc-441c-a149-6bbf106c4624", "AQAAAAIAAYagAAAAEMDMO1bUM7D27x6q+jFeoZF8FOj8hgdZga/fYIdx9nHf7qQq/6oEWa/cqhP9xPIQwg==", "10cd252c-6369-48d3-bd9d-119dbd2078bd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c052ffb4-245b-4c3c-8390-f1bd806828e2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e1980d60-8c25-4a75-a6a3-4981a270986e", "AQAAAAIAAYagAAAAEK6f02jEqi0mc4+x9D+FyGgS9PiagHNq5I5pqUL2phrgq+GYYpsJ3UKiBEykVOVzXg==", "93d0abf9-33a7-45c6-a22e-f0711f068e62" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class addroles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e975f07-9bdc-4242-9623-ca33eea745fc", null, "Admin", "ADMIN" },
                    { "239a1f31-4ef5-418e-bc18-fb8544e37b52", null, "Editor", "EDITOR" },
                    { "bf0c34fd-3ac0-4f07-80e1-12d12bc2f6ae", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e975f07-9bdc-4242-9623-ca33eea745fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "239a1f31-4ef5-418e-bc18-fb8544e37b52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf0c34fd-3ac0-4f07-80e1-12d12bc2f6ae");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace BusFinderAppWeb.Migrations
{
    public partial class adminadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Login", "password" },
                values: new object[] { 2, "admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

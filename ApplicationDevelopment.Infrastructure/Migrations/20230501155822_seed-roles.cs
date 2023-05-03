using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.Infrastructure.Migrations
{
    public partial class seedroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin", "bedee48c-511d-4923-8d5f-3f390313c440", "Admin", "ADMIN" },
                    { "customer", "7bfc5bfb-b405-429a-9621-a6288a1edfa9", "Customer", "CUSTOMER" },
                    { "staff", "0ddee847-e183-4dda-9a19-41e51b74691a", "Staff", "STAFF" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "staff");
        }
    }
}

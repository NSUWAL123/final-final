using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.Infrastructure.Migrations
{
    public partial class adminseedlatest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("c69b082b-ecde-469c-8aaf-27695a52f250"), "admin-user-id" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "e91255dd-e46d-4e1c-a10c-8e4b2c4d8b64");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer",
                column: "ConcurrencyStamp",
                value: "d12c32c7-ef0f-4bdb-934e-c55400071f69");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "staff",
                column: "ConcurrencyStamp",
                value: "2bc1301e-4bb0-432d-be03-8692a37a275a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6badb627-5481-4ac0-8ae7-94eea7d70edf", "AQAAAAEAACcQAAAAEGb/MJcqr0rmAt2csyQZAxrMezKrzRz4nRGaD8JgBimyEiWO6LuGS1o+P/mZVDLa+A==", "6e2c2a0c-8b67-435f-be8d-62d7ad748cba" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("c69b082b-ecde-469c-8aaf-27695a52f250"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "744e96c1-4138-492b-a675-5802756fcd53");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer",
                column: "ConcurrencyStamp",
                value: "bc56d47b-60d5-48ba-bba1-6f15b0183673");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "staff",
                column: "ConcurrencyStamp",
                value: "ca0d479e-f356-4d31-a7ad-078e5838856c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30de0423-7489-42a5-b286-e48adee82b45", "AQAAAAEAACcQAAAAEFaD22YcTtGeYqWhjcAm0oqd7RpdDgB4yB3/kAsYTgCYEMKcycNwXEFZoY0lqjmoUQ==", "288ea358-78d4-4e31-a406-620a63450542" });
        }
    }
}

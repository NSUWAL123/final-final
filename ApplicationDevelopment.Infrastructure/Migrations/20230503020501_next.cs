using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.Infrastructure.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("c69b082b-ecde-469c-8aaf-27695a52f250"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin", "admin-user-id" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id");

            migrationBuilder.AddColumn<string>(
                name: "CarImage",
                table: "Car",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "463696f6-d31d-4d0a-9bb7-a177c694ba21");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer",
                column: "ConcurrencyStamp",
                value: "5c60f140-c0fc-4d2c-bc32-a441f75539a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "staff",
                column: "ConcurrencyStamp",
                value: "d0b788b5-aadb-4eb1-9a9e-717a3f68da62");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "65908038-d81f-4aa6-81d4-54364852184c", 0, "ab598bb4-a3cf-4592-9b66-f5e0cbcbbf38", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEL8GOL1bBt71BDqzHTIiJhoj9KP3bu8nhV1HqScG7ErMx1CDtKry2hxBUFc7YQ17sw==", null, false, "5268694b-1beb-476a-8887-5e14e974ffb7", false, "admin" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("16892db2-0911-426c-9a0f-6d184a028c1b"), "65908038-d81f-4aa6-81d4-54364852184c" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin", "65908038-d81f-4aa6-81d4-54364852184c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("16892db2-0911-426c-9a0f-6d184a028c1b"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "admin", "65908038-d81f-4aa6-81d4-54364852184c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "65908038-d81f-4aa6-81d4-54364852184c");

            migrationBuilder.DropColumn(
                name: "CarImage",
                table: "Car");

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin-user-id", 0, "6badb627-5481-4ac0-8ae7-94eea7d70edf", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEGb/MJcqr0rmAt2csyQZAxrMezKrzRz4nRGaD8JgBimyEiWO6LuGS1o+P/mZVDLa+A==", null, false, "6e2c2a0c-8b67-435f-be8d-62d7ad748cba", false, "admin" });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UserId" },
                values: new object[] { new Guid("c69b082b-ecde-469c-8aaf-27695a52f250"), "admin-user-id" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "admin", "admin-user-id" });
        }
    }
}

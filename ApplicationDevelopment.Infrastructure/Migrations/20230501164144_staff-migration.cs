using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.Infrastructure.Migrations
{
    public partial class staffmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Staff",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "a23949df-4822-4a56-8b56-707b02cd3810");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer",
                column: "ConcurrencyStamp",
                value: "57f24100-1132-4ed8-bfc6-a1c825f47eeb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "staff",
                column: "ConcurrencyStamp",
                value: "280d066e-8518-4d21-a035-31fdc74cedd6");

            migrationBuilder.CreateIndex(
                name: "IX_Staff_AddressId",
                table: "Staff",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Address_AddressId",
                table: "Staff",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Address_AddressId",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_AddressId",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Staff");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "bfc32b1b-931a-46d6-a017-8791c086304c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "customer",
                column: "ConcurrencyStamp",
                value: "09636643-3014-4474-b516-f7a8d28dc7e7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "staff",
                column: "ConcurrencyStamp",
                value: "7ffe9fb2-980b-4759-8cf6-ec5d8ed99355");
        }
    }
}

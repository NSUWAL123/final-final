using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.Infrastructure.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "CarRequest");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "CarRequest",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CarRequest",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CarRequest_CarId",
                table: "CarRequest",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarRequest_UserId",
                table: "CarRequest",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarRequest_AspNetUsers_UserId",
                table: "CarRequest",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarRequest_Car_CarId",
                table: "CarRequest",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarRequest_AspNetUsers_UserId",
                table: "CarRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_CarRequest_Car_CarId",
                table: "CarRequest");

            migrationBuilder.DropIndex(
                name: "IX_CarRequest_CarId",
                table: "CarRequest");

            migrationBuilder.DropIndex(
                name: "IX_CarRequest_UserId",
                table: "CarRequest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CarRequest");

            migrationBuilder.AlterColumn<Guid>(
                name: "StaffId",
                table: "CarRequest",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "CarRequest",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

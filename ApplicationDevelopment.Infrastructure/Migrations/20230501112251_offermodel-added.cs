using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.Infrastructure.Migrations
{
    public partial class offermodeladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "CarRequest",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMedium",
                table: "CarRequest",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_DamageRequest_CarRequestId",
                table: "DamageRequest",
                column: "CarRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_DamageRequest_CarRequest_CarRequestId",
                table: "DamageRequest",
                column: "CarRequestId",
                principalTable: "CarRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DamageRequest_CarRequest_CarRequestId",
                table: "DamageRequest");

            migrationBuilder.DropIndex(
                name: "IX_DamageRequest_CarRequestId",
                table: "DamageRequest");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "CarRequest",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMedium",
                table: "CarRequest",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}

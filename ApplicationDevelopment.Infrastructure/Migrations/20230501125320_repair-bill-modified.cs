using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationDevelopment.Infrastructure.Migrations
{
    public partial class repairbillmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "repairCost",
                table: "RepairBill",
                newName: "RepairCost");

            migrationBuilder.RenameColumn(
                name: "isPaid",
                table: "RepairBill",
                newName: "IsPaid");

            migrationBuilder.RenameColumn(
                name: "damageRequestId",
                table: "RepairBill",
                newName: "DamageRequestId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "RepairBill",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepairCost",
                table: "RepairBill",
                newName: "repairCost");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "RepairBill",
                newName: "isPaid");

            migrationBuilder.RenameColumn(
                name: "DamageRequestId",
                table: "RepairBill",
                newName: "damageRequestId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RepairBill",
                newName: "id");
        }
    }
}

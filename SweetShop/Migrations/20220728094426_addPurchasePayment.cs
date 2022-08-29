using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetShop.Migrations
{
    public partial class addPurchasePayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PurchasePayment",
                table: "Purchases",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasePayment",
                table: "Purchases");
        }
    }
}

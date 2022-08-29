using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetShop.Migrations
{
    public partial class deleteCartProductItemId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartProductItemId",
                table: "CartsProducts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartProductItemId",
                table: "CartsProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetShop.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "CartsProducts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CartsProducts_AccountId",
                table: "CartsProducts",
                column: "AccountId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartsProducts_Accounts_AccountId",
                table: "CartsProducts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartsProducts_Accounts_AccountId",
                table: "CartsProducts");

            migrationBuilder.DropIndex(
                name: "IX_CartsProducts_AccountId",
                table: "CartsProducts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "CartsProducts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetShop.Migrations
{
    public partial class V : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_Products_ProductId",
                table: "PurchaseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItem_Purchases_PurchaseId",
                table: "PurchaseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseItem",
                table: "PurchaseItem");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItem_ProductId",
                table: "PurchaseItem");

            migrationBuilder.RenameTable(
                name: "PurchaseItem",
                newName: "PurchaseItems");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItem_PurchaseId",
                table: "PurchaseItems",
                newName: "IX_PurchaseItems_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseItems",
                table: "PurchaseItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Products_ProductId",
                table: "PurchaseItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItems_Purchases_PurchaseId",
                table: "PurchaseItems",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Products_ProductId",
                table: "PurchaseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseItems_Purchases_PurchaseId",
                table: "PurchaseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseItems",
                table: "PurchaseItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseItems_ProductId",
                table: "PurchaseItems");

            migrationBuilder.RenameTable(
                name: "PurchaseItems",
                newName: "PurchaseItem");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseItems_PurchaseId",
                table: "PurchaseItem",
                newName: "IX_PurchaseItem_PurchaseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseItem",
                table: "PurchaseItem",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseItem_ProductId",
                table: "PurchaseItem",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_Products_ProductId",
                table: "PurchaseItem",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseItem_Purchases_PurchaseId",
                table: "PurchaseItem",
                column: "PurchaseId",
                principalTable: "Purchases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

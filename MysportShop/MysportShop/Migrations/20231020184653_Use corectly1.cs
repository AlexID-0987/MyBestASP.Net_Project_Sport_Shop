using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class Usecorectly1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_BuyProductId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_BuyProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SummaOnsetProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BuyProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Orders",
                newName: "QuantityProduct");

            migrationBuilder.AddColumn<int>(
                name: "NumberProduct",
                table: "Orders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberProduct",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "QuantityProduct",
                table: "Orders",
                newName: "Number");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SummaOnsetProduct",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Products",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BuyProductId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BuyProductId",
                table: "Orders",
                column: "BuyProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_BuyProductId",
                table: "Orders",
                column: "BuyProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

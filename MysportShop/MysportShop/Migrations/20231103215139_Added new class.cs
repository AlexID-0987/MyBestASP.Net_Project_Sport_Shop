using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class Addednewclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_myOrders_MyOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SummaOnsetProduct",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyOrderId",
                table: "Products",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyOrderId",
                table: "Products",
                column: "MyOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_myOrders_MyOrderId",
                table: "Products",
                column: "MyOrderId",
                principalTable: "myOrders",
                principalColumn: "MyOrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

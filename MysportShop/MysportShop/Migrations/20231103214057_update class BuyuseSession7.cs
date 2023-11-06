using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class updateclassBuyuseSession7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_MyProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyProductId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProductId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyProductId",
                table: "Products",
                column: "MyProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_MyProductId",
                table: "Products",
                column: "MyProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

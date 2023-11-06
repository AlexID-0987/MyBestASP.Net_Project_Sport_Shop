using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class updateclassBuyuseSession797 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyOrderId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProductId",
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

            migrationBuilder.CreateTable(
                name: "myOrders",
                columns: table => new
                {
                    MyOrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_myOrders", x => x.MyOrderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyOrderId",
                table: "Products",
                column: "MyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MyProductId",
                table: "Products",
                column: "MyProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_myOrders_MyOrderId",
                table: "Products",
                column: "MyOrderId",
                principalTable: "myOrders",
                principalColumn: "MyOrderId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_MyProductId",
                table: "Products",
                column: "MyProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_myOrders_MyOrderId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_MyProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "myOrders");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyOrderId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MyProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyOrderId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MyProductId",
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
    }
}

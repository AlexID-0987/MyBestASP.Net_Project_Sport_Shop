using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class addedid88 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyProduct");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "BuyProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyOrderId = table.Column<int>(nullable: true),
                    MyProductOneId = table.Column<int>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    SummaOnsetProduct = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyProduct_myOrders_MyOrderId",
                        column: x => x.MyOrderId,
                        principalTable: "myOrders",
                        principalColumn: "MyOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BuyProduct_Products_MyProductOneId",
                        column: x => x.MyProductOneId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyProduct_MyOrderId",
                table: "BuyProduct",
                column: "MyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyProduct_MyProductOneId",
                table: "BuyProduct",
                column: "MyProductOneId");
        }
    }
}

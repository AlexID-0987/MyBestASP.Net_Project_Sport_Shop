using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class Myord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyProduct");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "myOrders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "myOrders");

            migrationBuilder.CreateTable(
                name: "BuyProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyOrderId = table.Column<int>(nullable: true),
                    MyProductId = table.Column<int>(nullable: true),
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
                        name: "FK_BuyProduct_Products_MyProductId",
                        column: x => x.MyProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyProduct_MyOrderId",
                table: "BuyProduct",
                column: "MyOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyProduct_MyProductId",
                table: "BuyProduct",
                column: "MyProductId");
        }
    }
}

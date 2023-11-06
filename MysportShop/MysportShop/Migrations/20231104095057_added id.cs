using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class addedid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(nullable: false),
                    SummaOnsetProduct = table.Column<decimal>(nullable: false),
                    MyProductOneId = table.Column<int>(nullable: true),
                    MyOrderId = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyProduct");
        }
    }
}

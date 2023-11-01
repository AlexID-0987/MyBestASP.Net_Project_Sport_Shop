using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class MyclassSes55 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "saveSessionDatas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "saveSessionDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuyProductId = table.Column<int>(nullable: true),
                    MyOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saveSessionDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_saveSessionDatas_Products_BuyProductId",
                        column: x => x.BuyProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_saveSessionDatas_myOrders_MyOrderId",
                        column: x => x.MyOrderId,
                        principalTable: "myOrders",
                        principalColumn: "MyOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_saveSessionDatas_BuyProductId",
                table: "saveSessionDatas",
                column: "BuyProductId");

            migrationBuilder.CreateIndex(
                name: "IX_saveSessionDatas_MyOrderId",
                table: "saveSessionDatas",
                column: "MyOrderId");
        }
    }
}

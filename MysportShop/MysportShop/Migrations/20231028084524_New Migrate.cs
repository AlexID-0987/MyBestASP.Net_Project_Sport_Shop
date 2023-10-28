using Microsoft.EntityFrameworkCore.Migrations;

namespace MysportShop.Migrations
{
    public partial class NewMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FirstOrders",
                table: "FirstOrders");

            migrationBuilder.RenameTable(
                name: "FirstOrders",
                newName: "myOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_myOrders",
                table: "myOrders",
                column: "MyOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_myOrders",
                table: "myOrders");

            migrationBuilder.RenameTable(
                name: "myOrders",
                newName: "FirstOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FirstOrders",
                table: "FirstOrders",
                column: "MyOrderId");
        }
    }
}

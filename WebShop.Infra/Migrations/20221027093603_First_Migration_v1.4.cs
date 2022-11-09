using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Infra.Migrations
{
    public partial class First_Migration_v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImgUrl", "Name", "Price", "ProductCategory", "Provider" },
                values: new object[,]
                {
                    { 1, "Delicious avocado", "assets/imgs/shop/product-9-1.jpg", "Avocado", 34.6m, "Vegetables", "Amazon" },
                    { 2, "Delicious nuts", "assets/imgs/shop/product-3-1.jpg", "Nuts", 4.9m, "Snack", "Amazon" },
                    { 3, "Delicious Stake", "assets/imgs/shop/product-2-1.jpg", "Stake Meat", 64.6m, "Meats", "MeatMarket" },
                    { 4, "Delicious Water", "assets/imgs/shop/product-1-1.jpg", "Bottle of water", 0.6m, "All", "Fuentsanta" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

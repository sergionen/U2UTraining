using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Infra.Migrations
{
    public partial class First_Migration_v17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "ReviewScore",
                type: "decimal(8,3)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "ReviewScore",
                columns: new[] { "Id", "ProductId", "Score" },
                values: new object[,]
                {
                    { 1, 1, 3m },
                    { 2, 2, 3.1m },
                    { 3, 2, 5m },
                    { 4, 2, 1m },
                    { 5, 3, 3m },
                    { 6, 3, 0.9m },
                    { 7, 3, 3.7m },
                    { 12, 4, 5m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ReviewScore",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.AlterColumn<decimal>(
                name: "Score",
                table: "ReviewScore",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,3)");
        }
    }
}

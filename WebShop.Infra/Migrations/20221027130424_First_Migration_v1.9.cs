using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShop.Infra.Migrations
{
    public partial class First_Migration_v19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewScore_Products_ProductId",
                table: "ReviewScore");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewScore",
                table: "ReviewScore");

            migrationBuilder.RenameTable(
                name: "ReviewScore",
                newName: "ReviewScores");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewScore_ProductId",
                table: "ReviewScores",
                newName: "IX_ReviewScores_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewScores",
                table: "ReviewScores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewScores_Products_ProductId",
                table: "ReviewScores",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReviewScores_Products_ProductId",
                table: "ReviewScores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReviewScores",
                table: "ReviewScores");

            migrationBuilder.RenameTable(
                name: "ReviewScores",
                newName: "ReviewScore");

            migrationBuilder.RenameIndex(
                name: "IX_ReviewScores_ProductId",
                table: "ReviewScore",
                newName: "IX_ReviewScore_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReviewScore",
                table: "ReviewScore",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReviewScore_Products_ProductId",
                table: "ReviewScore",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

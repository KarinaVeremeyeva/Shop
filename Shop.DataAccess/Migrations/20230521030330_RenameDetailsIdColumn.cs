using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameDetailsIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Details_DetailId",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "DetailId",
                table: "ProductDetails",
                newName: "DetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_DetailId",
                table: "ProductDetails",
                newName: "IX_ProductDetails_DetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Details_DetailId",
                table: "ProductDetails",
                column: "DetailId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Details_DetailIdNew",
                table: "ProductDetails");

            migrationBuilder.RenameColumn(
                name: "DetailIdNew",
                table: "ProductDetails",
                newName: "DetailId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductDetails_DetailIdNew",
                table: "ProductDetails",
                newName: "IX_ProductDetails_DetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Details_DetailId",
                table: "ProductDetails",
                column: "DetailId",
                principalTable: "Details",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

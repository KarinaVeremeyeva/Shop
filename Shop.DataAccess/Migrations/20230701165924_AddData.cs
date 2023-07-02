using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                column: "PhotoUrl",
                value: "https://img.5element.by/import/images/ut/goods/good_955608f1-247a-11ed-bb95-0050560120e8/sm-m325fzkgcau-chernyy-128gb-telefon-gsm-samsung-galaxy-m32-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                column: "PhotoUrl",
                value: "https://img.5element.by/import/images/ut/goods/good_1772e206-c950-11ed-bb90-005056012464/redmi-note-12-6gb-128gb-nfc-onyx-gray-ru-telefon-gsm-xiaomi-1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                column: "PhotoUrl",
                value: "https://img.5element.by/import/images/ut/goods/good_b5813643-828d-11ed-bb97-0050560120e8/-1.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                column: "PhotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                column: "PhotoUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                column: "PhotoUrl",
                value: null);
        }
    }
}

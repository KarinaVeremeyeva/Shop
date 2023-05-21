using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { new Guid("027ab076-461c-4f42-a09b-e052b818aa57"), "New category", "Parent Category", null });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), "Filter 2", 0 },
                    { new Guid("6dbc33b7-8938-495d-b573-0b36dced335e"), "Filter 8", 2 },
                    { new Guid("751d6ee6-ad02-4452-a626-e6b7f625f421"), "Filter 10", 2 },
                    { new Guid("955dd108-63c3-4d6c-83da-f23991091ece"), "Filter 7", 1 },
                    { new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"), "Filter 4", 1 },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), "Filter 5", 1 },
                    { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), "Filter 1", 0 },
                    { new Guid("f5c54777-d731-4e88-be25-9f653575ea5c"), "Filter 9", 2 },
                    { new Guid("fa47c781-8881-4e88-b508-6c401678fbf5"), "Filter 3", 0 },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), "Filter 6", 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"), "Child 3 category", "Child 3", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") },
                    { new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"), "Child 1 category", "Child 1", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") },
                    { new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"), "Child 2 category", "Child 2", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PhotoUrl", "Price" },
                values: new object[,]
                {
                    { new Guid("b06cc374-2161-474b-bd67-469ab1e757bf"), new Guid("027ab076-461c-4f42-a09b-e052b818aa57"), "This is a description for product 3.", "Product 3", null, 800m },
                    { new Guid("15fbac63-871c-4eb5-bcaa-900179d7d8e4"), new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"), "This is a description for product 4.", "Product 4", null, 30m },
                    { new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"), "This is a description for product 2.", "Product 2", null, 99m },
                    { new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"), "This is a description for product 1.", "Product 1", null, 100m },
                    { new Guid("d09d2c8d-87e7-465b-9364-b409233a8607"), new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"), "This is a description for product 5.", "Product 5", null, 50m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("6dbc33b7-8938-495d-b573-0b36dced335e"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("751d6ee6-ad02-4452-a626-e6b7f625f421"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("955dd108-63c3-4d6c-83da-f23991091ece"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("f5c54777-d731-4e88-be25-9f653575ea5c"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("fa47c781-8881-4e88-b508-6c401678fbf5"));

            migrationBuilder.DeleteData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15fbac63-871c-4eb5-bcaa-900179d7d8e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b06cc374-2161-474b-bd67-469ab1e757bf"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d09d2c8d-87e7-465b-9364-b409233a8607"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("027ab076-461c-4f42-a09b-e052b818aa57"));
        }
    }
}

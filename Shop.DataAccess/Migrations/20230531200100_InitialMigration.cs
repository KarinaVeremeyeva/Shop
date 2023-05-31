using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => new { x.ProductId, x.DetailId });
                    table.ForeignKey(
                        name: "FK_ProductDetails_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("027ab076-461c-4f42-a09b-e052b818aa57"), "Smartphones and Gadgets category", "Smartphones and Gadgets", null },
                    { new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db"), "Laptops and computers category", "Laptops and computers", null },
                    { new Guid("af784f4c-e8cb-458a-b313-e94619358052"), "TVs category", "TVs", null }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), "Color", 0 },
                    { new Guid("6dbc33b7-8938-495d-b573-0b36dced335e"), "Noise Control", 2 },
                    { new Guid("751d6ee6-ad02-4452-a626-e6b7f625f421"), "Memory Card Support", 2 },
                    { new Guid("955dd108-63c3-4d6c-83da-f23991091ece"), "Battery", 1 },
                    { new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"), "Memory", 1 },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), "Display", 1 },
                    { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), "Brand", 0 },
                    { new Guid("f5c54777-d731-4e88-be25-9f653575ea5c"), "Smart Alarm", 2 },
                    { new Guid("fa47c781-8881-4e88-b508-6c401678fbf5"), "Manufacturer", 0 },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), "Camera", 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("11f80fdb-6ee8-4005-86d6-b59b46ff6930"), "OLED TVs category", "OLED TVs", new Guid("af784f4c-e8cb-458a-b313-e94619358052") },
                    { new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53"), "Laptops and computer equipment category", "Laptops and computer equipment", new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db") },
                    { new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354"), "Input Devices and Storage category", "Input Devices and Storage", new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db") },
                    { new Guid("74345c29-4005-470d-96a3-a77996a84686"), "LED TVs category", "LED TVs", new Guid("af784f4c-e8cb-458a-b313-e94619358052") },
                    { new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"), "Gadgets category", "Gadgets", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") },
                    { new Guid("875a71eb-231b-4f34-a628-330dc5968ee0"), "Tablets category", "Tablets", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") },
                    { new Guid("9758d768-a2d5-40fb-9f13-0eba41770a82"), "Smart TVs category", "Smart TVs", new Guid("af784f4c-e8cb-458a-b313-e94619358052") },
                    { new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"), "Smartphones and Accessories category", "Smartphones and Accessories", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") },
                    { new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"), "Headphones category", "Headphones", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") },
                    { new Guid("17365631-3b8f-4d6d-a499-c94b88531435"), "Earbuds category", "Earbuds", new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66") },
                    { new Guid("24cc7c5f-7b14-4044-82fd-bfa882a7ee95"), "Laptop Computers category", "Laptop Computers", new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53") },
                    { new Guid("30d6b5bd-900b-4d97-b39c-befc21b4cc4a"), "Smart Watch category", "Smart Watches", new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404") },
                    { new Guid("38f67f27-92be-4983-a8b3-bd557f36e60e"), "Bluetooth Headphones category", "Bluetooth Headphones", new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66") },
                    { new Guid("4022a623-2ccc-43bb-8fc6-f737875ea741"), "Over-Ear Headphones category", "Over-Ear Headphones", new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66") },
                    { new Guid("6aafe0c5-2673-49d4-97ba-6381bf43ffdc"), "Keyboards category", "Keyboards", new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354") },
                    { new Guid("6feb32fe-afc3-4d51-90a9-5acf19b7a0da"), "Computer Mice category", "Computer Mice", new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354") },
                    { new Guid("71edade5-f485-421a-9783-cc63dce769dd"), "Fitness Trackers category", "Fitness Trackers", new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404") },
                    { new Guid("8dec42a2-1b3b-4ebc-8816-bfb907c0840c"), "HDDs and SSDs category", "HDDs and SSDs", new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354") },
                    { new Guid("d1553817-fcde-4c22-87df-b54e27e9d5c9"), "Desktop Computers category", "Desktop Computers", new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53") },
                    { new Guid("d4490f24-d752-458f-b324-a604e79b2f2e"), "Smartphone Accessories category", "Accessories", new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c") },
                    { new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "Smartphones category", "Smartphones", new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c") },
                    { new Guid("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"), "Cases and Covers category", "Cases and Covers", new Guid("d4490f24-d752-458f-b324-a604e79b2f2e") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PhotoUrl", "Price" },
                values: new object[,]
                {
                    { new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "This is a description for Samsung Galaxy M32", "Samsung Galaxy M32", null, 300m },
                    { new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "This is a description for Xiaomi Redmi Note 12", "Xiaomi Redmi Note 12", null, 300m },
                    { new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "This is a description for Apple iPhone 13.", "Apple iPhone 13", null, 900m },
                    { new Guid("b06cc374-2161-474b-bd67-469ab1e757bf"), new Guid("38f67f27-92be-4983-a8b3-bd557f36e60e"), "This is a description for JBL Tune 510BT Black.", "JBL Tune 510BT Black", null, 60m },
                    { new Guid("d09d2c8d-87e7-465b-9364-b409233a8607"), new Guid("71edade5-f485-421a-9783-cc63dce769dd"), "This is a description for Redmi Smart Band 2.", "Xiaomi Redmi Smart Band 2", null, 30m }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "DetailId", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "Black" },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "6.4" },
                    { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "Samsung" },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "64" },
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "Black" },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "6.67" },
                    { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "Xiaomi" },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "50" },
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "Midnight" },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "6.1" },
                    { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "Apple" },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "12" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PhotoUrl", "Price" },
                values: new object[] { new Guid("15fbac63-871c-4eb5-bcaa-900179d7d8e4"), new Guid("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"), "This is a description for phone case.", "UGREEN Clear iPhone 12 Case", null, 30m });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_DetailId",
                table: "ProductDetails",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

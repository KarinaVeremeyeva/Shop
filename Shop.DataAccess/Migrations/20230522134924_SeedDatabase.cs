using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shop.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8") });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("027ab076-461c-4f42-a09b-e052b818aa57"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Smartphones and Gadgets category", "Smartphones and Gadgets" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Gadgets category", "Gadgets" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Smartphones and Accessories category", "Smartphones and Accessories" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Headphones category", "Headphones" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db"), "Laptops and computers category", "Laptops and computers", null },
                    { new Guid("17365631-3b8f-4d6d-a499-c94b88531435"), "Earbuds category", "Earbuds", new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66") },
                    { new Guid("30d6b5bd-900b-4d97-b39c-befc21b4cc4a"), "Smart Watch category", "Smart Watches", new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404") },
                    { new Guid("38f67f27-92be-4983-a8b3-bd557f36e60e"), "Bluetooth Headphones category", "Bluetooth Headphones", new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66") },
                    { new Guid("4022a623-2ccc-43bb-8fc6-f737875ea741"), "Over-Ear Headphones category", "Over-Ear Headphones", new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66") },
                    { new Guid("71edade5-f485-421a-9783-cc63dce769dd"), "Fitness Trackers category", "Fitness Trackers", new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404") },
                    { new Guid("875a71eb-231b-4f34-a628-330dc5968ee0"), "Tablets category", "Tablets", new Guid("027ab076-461c-4f42-a09b-e052b818aa57") },
                    { new Guid("af784f4c-e8cb-458a-b313-e94619358052"), "TVs category", "TVs", null },
                    { new Guid("d4490f24-d752-458f-b324-a604e79b2f2e"), "Smartphone Accessories category", "Accessories", new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c") },
                    { new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "Smartphones category", "Smartphones", new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c") }
                });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                column: "Name",
                value: "Color");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("6dbc33b7-8938-495d-b573-0b36dced335e"),
                column: "Name",
                value: "Noise Control");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("751d6ee6-ad02-4452-a626-e6b7f625f421"),
                column: "Name",
                value: "Memory Card Support");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("955dd108-63c3-4d6c-83da-f23991091ece"),
                column: "Name",
                value: "Battery");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"),
                column: "Name",
                value: "Memory");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                column: "Name",
                value: "Display");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                column: "Name",
                value: "Brand");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("f5c54777-d731-4e88-be25-9f653575ea5c"),
                column: "Name",
                value: "Smart Alarm");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("fa47c781-8881-4e88-b508-6c401678fbf5"),
                column: "Name",
                value: "Manufacturer");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                column: "Name",
                value: "Camera");

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8") },
                column: "Value",
                value: "Apple");

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "DetailId", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "Black" },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "6.4" },
                    { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "Samsung" },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"), "64" },
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "Midnight" },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "6.1" },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "12" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15fbac63-871c-4eb5-bcaa-900179d7d8e4"),
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"), "This is a description for phone case.", "UGREEN Clear iPhone 12 Case" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "This is a description for Samsung Galaxy M32", "Samsung Galaxy M32", 300m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "This is a description for Apple iPhone 13.", "Apple iPhone 13", 900m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b06cc374-2161-474b-bd67-469ab1e757bf"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("38f67f27-92be-4983-a8b3-bd557f36e60e"), "This is a description for JBL Tune 510BT Black.", "JBL Tune 510BT Black", 60m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d09d2c8d-87e7-465b-9364-b409233a8607"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("71edade5-f485-421a-9783-cc63dce769dd"), "This is a description for Redmi Smart Band 2.", "Xiaomi Redmi Smart Band 2", 30m });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("11f80fdb-6ee8-4005-86d6-b59b46ff6930"), "OLED TVs category", "OLED TVs", new Guid("af784f4c-e8cb-458a-b313-e94619358052") },
                    { new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53"), "Laptops and computer equipment category", "Laptops and computer equipment", new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db") },
                    { new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354"), "Input Devices and Storage category", "Input Devices and Storage", new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db") },
                    { new Guid("74345c29-4005-470d-96a3-a77996a84686"), "LED TVs category", "LED TVs", new Guid("af784f4c-e8cb-458a-b313-e94619358052") },
                    { new Guid("9758d768-a2d5-40fb-9f13-0eba41770a82"), "Smart TVs category", "Smart TVs", new Guid("af784f4c-e8cb-458a-b313-e94619358052") },
                    { new Guid("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"), "Cases and Covers category", "Cases and Covers", new Guid("d4490f24-d752-458f-b324-a604e79b2f2e") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "PhotoUrl", "Price" },
                values: new object[] { new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"), "This is a description for Xiaomi Redmi Note 12", "Xiaomi Redmi Note 12", null, 300m });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("24cc7c5f-7b14-4044-82fd-bfa882a7ee95"), "Laptop Computers category", "Laptop Computers", new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53") },
                    { new Guid("6aafe0c5-2673-49d4-97ba-6381bf43ffdc"), "Keyboards category", "Keyboards", new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354") },
                    { new Guid("6feb32fe-afc3-4d51-90a9-5acf19b7a0da"), "Computer Mice category", "Computer Mice", new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354") },
                    { new Guid("8dec42a2-1b3b-4ebc-8816-bfb907c0840c"), "HDDs and SSDs category", "HDDs and SSDs", new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354") },
                    { new Guid("d1553817-fcde-4c22-87df-b54e27e9d5c9"), "Desktop Computers category", "Desktop Computers", new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53") }
                });

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "DetailId", "ProductId", "Value" },
                values: new object[,]
                {
                    { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "Black" },
                    { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "6.67" },
                    { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "Xiaomi" },
                    { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"), "50" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11f80fdb-6ee8-4005-86d6-b59b46ff6930"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("17365631-3b8f-4d6d-a499-c94b88531435"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("24cc7c5f-7b14-4044-82fd-bfa882a7ee95"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("30d6b5bd-900b-4d97-b39c-befc21b4cc4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("38f67f27-92be-4983-a8b3-bd557f36e60e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4022a623-2ccc-43bb-8fc6-f737875ea741"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6aafe0c5-2673-49d4-97ba-6381bf43ffdc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6feb32fe-afc3-4d51-90a9-5acf19b7a0da"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("71edade5-f485-421a-9783-cc63dce769dd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74345c29-4005-470d-96a3-a77996a84686"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("875a71eb-231b-4f34-a628-330dc5968ee0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8dec42a2-1b3b-4ebc-8816-bfb907c0840c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9758d768-a2d5-40fb-9f13-0eba41770a82"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d1553817-fcde-4c22-87df-b54e27e9d5c9"));

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8") });

            migrationBuilder.DeleteData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("405fc23c-aa11-47f2-828e-f721ceeceb53"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("41c5ec09-6a3c-4375-867f-7952dc9df354"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("af784f4c-e8cb-458a-b313-e94619358052"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d4490f24-d752-458f-b324-a604e79b2f2e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("07b9ad0f-6847-46dd-9609-8ccf7da201db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e05ab76b-f53b-41c8-aac1-e8062ae75f54"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("027ab076-461c-4f42-a09b-e052b818aa57"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "New category", "Parent Category" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Child 3 category", "Child 3" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Child 1 category", "Child 1" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Child 2 category", "Child 2" });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                column: "Name",
                value: "Filter 2");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("6dbc33b7-8938-495d-b573-0b36dced335e"),
                column: "Name",
                value: "Filter 8");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("751d6ee6-ad02-4452-a626-e6b7f625f421"),
                column: "Name",
                value: "Filter 10");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("955dd108-63c3-4d6c-83da-f23991091ece"),
                column: "Name",
                value: "Filter 7");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"),
                column: "Name",
                value: "Filter 4");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                column: "Name",
                value: "Filter 5");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                column: "Name",
                value: "Filter 1");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("f5c54777-d731-4e88-be25-9f653575ea5c"),
                column: "Name",
                value: "Filter 9");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("fa47c781-8881-4e88-b508-6c401678fbf5"),
                column: "Name",
                value: "Filter 3");

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: new Guid("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                column: "Name",
                value: "Filter 6");

            migrationBuilder.UpdateData(
                table: "ProductDetails",
                keyColumns: new[] { "DetailId", "ProductId" },
                keyValues: new object[] { new Guid("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8") },
                column: "Value",
                value: "blue");

            migrationBuilder.InsertData(
                table: "ProductDetails",
                columns: new[] { "DetailId", "ProductId", "Value" },
                values: new object[] { new Guid("b1f3413e-8556-401f-8ffe-ba221b9d5e58"), new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"), "test" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("15fbac63-871c-4eb5-bcaa-900179d7d8e4"),
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"), "This is a description for product 4.", "Product 4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("a71fe02a-a524-49ee-9f26-d156c0b62d6c"), "This is a description for product 2.", "Product 2", 99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("c11cdea5-b146-421b-ad27-bfe07dcb6a66"), "This is a description for product 1.", "Product 1", 100m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b06cc374-2161-474b-bd67-469ab1e757bf"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("027ab076-461c-4f42-a09b-e052b818aa57"), "This is a description for product 3.", "Product 3", 800m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d09d2c8d-87e7-465b-9364-b409233a8607"),
                columns: new[] { "CategoryId", "Description", "Name", "Price" },
                values: new object[] { new Guid("7bf9425a-1c6e-4078-817f-1c49b4909404"), "This is a description for product 5.", "Product 5", 50m });
        }
    }
}

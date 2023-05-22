using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57"),
                    Name = "Smartphones and Gadgets",
                    Description = "Smartphones and Gadgets category",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = Guid.Parse("a71fe02a-a524-49ee-9f26-d156c0b62d6c"),
                    Name = "Smartphones and Accessories",
                    Description = "Smartphones and Accessories category",
                    ParentCategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")
                },
                new Category
                {
                    Id = Guid.Parse("d4490f24-d752-458f-b324-a604e79b2f2e"),
                    Name = "Accessories",
                    Description = "Smartphone Accessories category",
                    ParentCategoryId = Guid.Parse("a71fe02a-a524-49ee-9f26-d156c0b62d6c")
                },
                new Category
                {
                    Id = Guid.Parse("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d"),
                    Name = "Cases and Covers",
                    Description = "Cases and Covers category",
                    ParentCategoryId = Guid.Parse("d4490f24-d752-458f-b324-a604e79b2f2e")
                },
                new Category
                {
                    Id = Guid.Parse("e05ab76b-f53b-41c8-aac1-e8062ae75f54"),
                    Name = "Smartphones",
                    Description = "Smartphones category",
                    ParentCategoryId = Guid.Parse("a71fe02a-a524-49ee-9f26-d156c0b62d6c")
                },
                new Category
                {
                    Id = Guid.Parse("875a71eb-231b-4f34-a628-330dc5968ee0"),
                    Name = "Tablets",
                    Description = "Tablets category",
                    ParentCategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")
                },
                new Category
                {
                    Id = Guid.Parse("c11cdea5-b146-421b-ad27-bfe07dcb6a66"),
                    Name = "Headphones",
                    Description = "Headphones category",
                    ParentCategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")
                },
                new Category
                {
                    Id = Guid.Parse("38f67f27-92be-4983-a8b3-bd557f36e60e"),
                    Name = "Bluetooth Headphones",
                    Description = "Bluetooth Headphones category",
                    ParentCategoryId = Guid.Parse("c11cdea5-b146-421b-ad27-bfe07dcb6a66")
                },
                new Category
                {
                    Id = Guid.Parse("17365631-3b8f-4d6d-a499-c94b88531435"),
                    Name = "Earbuds",
                    Description = "Earbuds category",
                    ParentCategoryId = Guid.Parse("c11cdea5-b146-421b-ad27-bfe07dcb6a66")
                },
                new Category
                {
                    Id = Guid.Parse("4022a623-2ccc-43bb-8fc6-f737875ea741"),
                    Name = "Over-Ear Headphones",
                    Description = "Over-Ear Headphones category",
                    ParentCategoryId = Guid.Parse("c11cdea5-b146-421b-ad27-bfe07dcb6a66")
                },
                new Category
                {
                    Id = Guid.Parse("7bf9425a-1c6e-4078-817f-1c49b4909404"),
                    Name = "Gadgets",
                    Description = "Gadgets category",
                    ParentCategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")
                },
                new Category
                {
                    Id = Guid.Parse("30d6b5bd-900b-4d97-b39c-befc21b4cc4a"),
                    Name = "Smart Watches",
                    Description = "Smart Watch category",
                    ParentCategoryId = Guid.Parse("7bf9425a-1c6e-4078-817f-1c49b4909404")
                },
                new Category
                {
                    Id = Guid.Parse("71edade5-f485-421a-9783-cc63dce769dd"),
                    Name = "Fitness Trackers",
                    Description = "Fitness Trackers category",
                    ParentCategoryId = Guid.Parse("7bf9425a-1c6e-4078-817f-1c49b4909404")
                },

                new Category
                {
                    Id = Guid.Parse("af784f4c-e8cb-458a-b313-e94619358052"),
                    Name = "TVs",
                    Description = "TVs category",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = Guid.Parse("74345c29-4005-470d-96a3-a77996a84686"),
                    Name = "LED TVs",
                    Description = "LED TVs category",
                    ParentCategoryId = Guid.Parse("af784f4c-e8cb-458a-b313-e94619358052")
                },
                new Category
                {
                    Id = Guid.Parse("11f80fdb-6ee8-4005-86d6-b59b46ff6930"),
                    Name = "OLED TVs",
                    Description = "OLED TVs category",
                    ParentCategoryId = Guid.Parse("af784f4c-e8cb-458a-b313-e94619358052")
                },
                new Category
                {
                    Id = Guid.Parse("9758d768-a2d5-40fb-9f13-0eba41770a82"),
                    Name = "Smart TVs",
                    Description = "Smart TVs category",
                    ParentCategoryId = Guid.Parse("af784f4c-e8cb-458a-b313-e94619358052")
                },

                new Category
                {
                    Id = Guid.Parse("07b9ad0f-6847-46dd-9609-8ccf7da201db"),
                    Name = "Laptops and computers",
                    Description = "Laptops and computers category",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = Guid.Parse("405fc23c-aa11-47f2-828e-f721ceeceb53"),
                    Name = "Laptops and computer equipment",
                    Description = "Laptops and computer equipment category",
                    ParentCategoryId = Guid.Parse("07b9ad0f-6847-46dd-9609-8ccf7da201db")
                },
                new Category
                {
                    Id = Guid.Parse("24cc7c5f-7b14-4044-82fd-bfa882a7ee95"),
                    Name = "Laptop Computers",
                    Description = "Laptop Computers category",
                    ParentCategoryId = Guid.Parse("405fc23c-aa11-47f2-828e-f721ceeceb53")
                },
                new Category
                {
                    Id = Guid.Parse("d1553817-fcde-4c22-87df-b54e27e9d5c9"),
                    Name = "Desktop Computers",
                    Description = "Desktop Computers category",
                    ParentCategoryId = Guid.Parse("405fc23c-aa11-47f2-828e-f721ceeceb53")
                },
                new Category
                {
                    Id = Guid.Parse("41c5ec09-6a3c-4375-867f-7952dc9df354"),
                    Name = "Input Devices and Storage",
                    Description = "Input Devices and Storage category",
                    ParentCategoryId = Guid.Parse("07b9ad0f-6847-46dd-9609-8ccf7da201db")
                },
                new Category
                {
                    Id = Guid.Parse("6aafe0c5-2673-49d4-97ba-6381bf43ffdc"),
                    Name = "Keyboards",
                    Description = "Keyboards category",
                    ParentCategoryId = Guid.Parse("41c5ec09-6a3c-4375-867f-7952dc9df354")
                },
                new Category
                {
                    Id = Guid.Parse("6feb32fe-afc3-4d51-90a9-5acf19b7a0da"),
                    Name = "Computer Mice",
                    Description = "Computer Mice category",
                    ParentCategoryId = Guid.Parse("41c5ec09-6a3c-4375-867f-7952dc9df354")
                },
                new Category
                {
                    Id = Guid.Parse("8dec42a2-1b3b-4ebc-8816-bfb907c0840c"),
                    Name = "HDDs and SSDs",
                    Description = "HDDs and SSDs category",
                    ParentCategoryId = Guid.Parse("41c5ec09-6a3c-4375-867f-7952dc9df354")
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                    Name = "Apple iPhone 13",
                    Description = "This is a description for Apple iPhone 13.",
                    Price = 900,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("e05ab76b-f53b-41c8-aac1-e8062ae75f54")
                },
                new Product
                {
                    Id = Guid.Parse("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                    Name = "Samsung Galaxy M32",
                    Description = "This is a description for Samsung Galaxy M32",
                    Price = 300,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("e05ab76b-f53b-41c8-aac1-e8062ae75f54")
                },
                new Product
                {
                    Id = Guid.Parse("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                    Name = "Xiaomi Redmi Note 12",
                    Description = "This is a description for Xiaomi Redmi Note 12",
                    Price = 300,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("e05ab76b-f53b-41c8-aac1-e8062ae75f54")
                },
                new Product
                {
                    Id = Guid.Parse("15fbac63-871c-4eb5-bcaa-900179d7d8e4"),
                    Name = "UGREEN Clear iPhone 12 Case",
                    Description = "This is a description for phone case.",
                    Price = 30,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("c4bf3a5e-5aec-417d-9a4b-efc71fe6956d")
                },
                new Product
                {
                    Id = Guid.Parse("b06cc374-2161-474b-bd67-469ab1e757bf"),
                    Name = "JBL Tune 510BT Black",
                    Description = "This is a description for JBL Tune 510BT Black.",
                    Price = 60,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("38f67f27-92be-4983-a8b3-bd557f36e60e")
                },
                new Product
                {
                    Id = Guid.Parse("d09d2c8d-87e7-465b-9364-b409233a8607"),
                    Name = "Xiaomi Redmi Smart Band 2",
                    Description = "This is a description for Redmi Smart Band 2.",
                    Price = 30,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("71edade5-f485-421a-9783-cc63dce769dd")
                }
            );

            modelBuilder.Entity<Detail>().HasData(
                new Detail
                {
                    Id = Guid.Parse("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                    Name = "Brand",
                    Type = DetailType.String
                },
                new Detail
                {
                    Id = Guid.Parse("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                    Name = "Color",
                    Type = DetailType.String
                },
                new Detail
                {
                    Id = Guid.Parse("fa47c781-8881-4e88-b508-6c401678fbf5"),
                    Name = "Manufacturer",
                    Type = DetailType.String
                },
                new Detail
                {
                    Id = Guid.Parse("b1f3413e-8556-401f-8ffe-ba221b9d5e58"),
                    Name = "Memory",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                    Name = "Display",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                    Name = "Camera",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("955dd108-63c3-4d6c-83da-f23991091ece"),
                    Name = "Battery",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("6dbc33b7-8938-495d-b573-0b36dced335e"),
                    Name = "Noise Control",
                    Type = DetailType.Boolean
                },
                new Detail
                {
                    Id = Guid.Parse("f5c54777-d731-4e88-be25-9f653575ea5c"),
                    Name = "Smart Alarm",
                    Type = DetailType.Boolean
                },
                new Detail
                {
                    Id = Guid.Parse("751d6ee6-ad02-4452-a626-e6b7f625f421"),
                    Name = "Memory Card Support",
                    Type = DetailType.Boolean
                }
            );

            modelBuilder.Entity<ProductDetail>().HasData(
                new ProductDetail
                {
                    ProductId = Guid.Parse("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                    DetailsId = Guid.Parse("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                    Value = "Apple"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                    DetailsId = Guid.Parse("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                    Value = "6.1"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                    DetailsId = Guid.Parse("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                    Value = "Midnight"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                    DetailsId = Guid.Parse("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                    Value = "12"
                },

                new ProductDetail
                {
                    ProductId = Guid.Parse("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                    DetailsId = Guid.Parse("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                    Value = "Samsung"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                    DetailsId = Guid.Parse("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                    Value = "6.4"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                    DetailsId = Guid.Parse("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                    Value = "Black"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                    DetailsId = Guid.Parse("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                    Value = "64"
                },

                new ProductDetail
                {
                    ProductId = Guid.Parse("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                    DetailsId = Guid.Parse("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                    Value = "Xiaomi"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                    DetailsId = Guid.Parse("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                    Value = "6.67"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                    DetailsId = Guid.Parse("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                    Value = "Black"
                },
                new ProductDetail
                {
                    ProductId = Guid.Parse("7cda37ad-0d0a-4685-8104-3f435f5eeaf6"),
                    DetailsId = Guid.Parse("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                    Value = "50"
                }
            );
        }
    }
}

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
                    Name = "Parent Category",
                    Description = "New category",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = Guid.Parse("a71fe02a-a524-49ee-9f26-d156c0b62d6c"),
                    Name = "Child 1",
                    Description = "Child 1 category",
                    ParentCategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")
                },
                new Category
                {
                    Id = Guid.Parse("c11cdea5-b146-421b-ad27-bfe07dcb6a66"),
                    Name = "Child 2",
                    Description = "Child 2 category",
                    ParentCategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")
                },
                new Category
                {
                    Id = Guid.Parse("7bf9425a-1c6e-4078-817f-1c49b4909404"),
                    Name = "Child 3",
                    Description = "Child 3 category",
                    ParentCategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.Parse("86ca08b6-3b59-4046-9c3f-260f0631ceb8"),
                    Name = "Product 1",
                    Description = "This is a description for product 1.",
                    Price = 100,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("c11cdea5-b146-421b-ad27-bfe07dcb6a66")
                },
                new Product
                {
                    Id = Guid.Parse("75ac7087-0031-4895-8a7c-60e87b96a5d7"),
                    Name = "Product 2",
                    Description = "This is a description for product 2.",
                    Price = 99,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("a71fe02a-a524-49ee-9f26-d156c0b62d6c")

                },
                new Product
                {
                    Id = Guid.Parse("b06cc374-2161-474b-bd67-469ab1e757bf"),
                    Name = "Product 3",
                    Description = "This is a description for product 3.",
                    Price = 800,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("027ab076-461c-4f42-a09b-e052b818aa57")

                },
                new Product
                {
                    Id = Guid.Parse("15fbac63-871c-4eb5-bcaa-900179d7d8e4"),
                    Name = "Product 4",
                    Description = "This is a description for product 4.",
                    Price = 30,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("7bf9425a-1c6e-4078-817f-1c49b4909404")
                },
                new Product
                {
                    Id = Guid.Parse("d09d2c8d-87e7-465b-9364-b409233a8607"),
                    Name = "Product 5",
                    Description = "This is a description for product 5.",
                    Price = 50,
                    PhotoUrl = null,
                    CategoryId = Guid.Parse("7bf9425a-1c6e-4078-817f-1c49b4909404")
                }
            );

            modelBuilder.Entity<Detail>().HasData(
                new Detail
                {
                    Id = Guid.Parse("f3f27ab2-e1f8-4ba4-a4f2-2e5b97bb769b"),
                    Name = "Filter 1",
                    Type = DetailType.String
                },
                new Detail
                {
                    Id = Guid.Parse("0d517bcf-374b-4095-9e7c-4187bd814e27"),
                    Name = "Filter 2",
                    Type = DetailType.String
                },
                new Detail
                {
                    Id = Guid.Parse("fa47c781-8881-4e88-b508-6c401678fbf5"),
                    Name = "Filter 3",
                    Type = DetailType.String
                },
                new Detail
                {
                    Id = Guid.Parse("b1f3413e-8556-401f-8ffe-ba221b9d5e58"),
                    Name = "Filter 4",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("c621e56a-5546-49f1-bb69-fd97c9a00fe1"),
                    Name = "Filter 5",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("fdfa2737-bf8f-4fb8-9477-bfa52cbd198c"),
                    Name = "Filter 6",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("955dd108-63c3-4d6c-83da-f23991091ece"),
                    Name = "Filter 7",
                    Type = DetailType.Number
                },
                new Detail
                {
                    Id = Guid.Parse("6dbc33b7-8938-495d-b573-0b36dced335e"),
                    Name = "Filter 8",
                    Type = DetailType.Boolean
                },
                new Detail
                {
                    Id = Guid.Parse("f5c54777-d731-4e88-be25-9f653575ea5c"),
                    Name = "Filter 9",
                    Type = DetailType.Boolean
                },
                new Detail
                {
                    Id = Guid.Parse("751d6ee6-ad02-4452-a626-e6b7f625f421"),
                    Name = "Filter 10",
                    Type = DetailType.Boolean
                }
            );
        }
    }
}

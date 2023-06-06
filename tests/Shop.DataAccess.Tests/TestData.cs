using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Tests
{
    public static class TestData
    {
        public static Category GetTestCategory(Guid id)
        {
            return GetTestCategories().First(x => x.Id == id);
        }

        public static IEnumerable<Category> GetTestCategories()
        {
            var categories = new List<Category>()
            {
                new Category
                {
                    Id = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                    Name = "Category 1",
                    Description = "Description 1",
                    ChildCategories = {
                        new Category
                        {
                            Id = Guid.Parse("e77a4e6e-a0f0-4b1c-988e-adeb182a059c"),
                            Name = "Child 1",
                            Description = "Description 2",
                            ParentCategoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                            ChildCategories = {
                                new Category
                                {
                                    Id = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37"),
                                    Name = "Child 1.1",
                                    Description = "Description 3",
                                    ParentCategoryId = Guid.Parse("e77a4e6e-a0f0-4b1c-988e-adeb182a059c")
                                }
                            }
                        },
                        new Category
                        {
                            Id = Guid.Parse("0865d2ff-5602-40df-9466-26b2fef9785e"),
                            Name = "Child 2",
                            Description = "Description 4",
                            ParentCategoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6")
                        },
                    }
                }
            };

            return categories;
        }

        public static Product GetTestProduct(Guid id)
        {
            return GetTestProducts().First(x => x.Id == id);
        }

        public static IEnumerable<Product> GetTestProducts()
        {
            var products = new List<Product>()
            {
                new Product
                {
                    Id = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a"),
                    Name = "Product 1",
                    Price = 1000,
                    Category = new Category
                    {
                        Id = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                        Name = "Category 1",
                        Description = "Description 1",
                    },
                    CategoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                },
                new Product
                {
                    Id = Guid.Parse("d5a5e423-f829-48a8-a7e6-0e6446618e27"),
                    Name = "Product 2",
                    Price = 2000,
                    Category = new Category
                    {
                        Id = Guid.Parse("d1ca19e4-ec09-4810-9929-718d2f2d3a6b"),
                        Name = "Category 2",
                        Description = "Description 2",
                    },
                    CategoryId = Guid.Parse("d1ca19e4-ec09-4810-9929-718d2f2d3a6b"),
                }
            };

            return products;
        }

        public static CartItem GetTestCartItem(Guid cartItemId)
        {
            return GetTestCartItems().First(x => x.Id == cartItemId);
        }

        public static IEnumerable<CartItem> GetTestCartItems()
        {
            var cartItems = new List<CartItem>
            {
                new CartItem
                {
                    Id = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39"),
                    Quantity = 2,
                    UserEmail = "test@email",
                    Product = new Product
                    {
                        Id = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37"),
                        Name = "Test product 1",
                        Price = 100
                    },
                    ProductId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37"),
                },
                new CartItem
                {
                    Id = Guid.Parse("61790063-dfdf-4c04-ba9b-fa58ef92d045"),
                    Quantity = 1,
                    UserEmail = "test@email",
                    Product = new Product
                    {
                        Id = Guid.Parse("3e7bde91-bed9-4e6e-bd23-c917abc80bea"),
                        Name = "Test product 2",
                        Price = 200
                    },
                    ProductId = Guid.Parse("3e7bde91-bed9-4e6e-bd23-c917abc80bea"),
                }
            };

            return cartItems;
        }
    }
}

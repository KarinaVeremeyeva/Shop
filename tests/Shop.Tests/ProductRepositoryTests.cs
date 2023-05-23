using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private TestShopContext Context { get; set; }

        private ProductRepository ProductRepository { get; set; }

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "TestShopDb")
                .Options;

            Context = new TestShopContext(contextOptions);
            ProductRepository = new ProductRepository(Context);
        }

        [Test]
        public void GetById_GetProductById_ReturnsProduct()
        {
            // arrange
            var product = new Product
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
            };
            Context.Products.Add(product);
            Context.SaveChanges();

            // act
            var expected = product.Id;
            var actual = ProductRepository.GetById(product.Id)?.Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_GetAllProducts_ReturnsAllProducts()
        {
            // arrange
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

            Context.Products.AddRange(products);
            Context.SaveChanges();

            // act
            var expected = Context.Products.First().Id;
            var actual = ProductRepository.GetAll().First().Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_AddProduct_ProductWasAdded()
        {
            // arrange
            var product = new Product
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
            };

            ProductRepository.Add(product);

            // act
            var expected = product.Id;
            var actual = Context.Products.Where(p => p.Id == product.Id).First().Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Update_UpdateProduct_ProductWasUpdated()
        {
            // arrange
            var product = new Product
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
            };
            Context.Products.Add(product);
            Context.SaveChanges();

            var productToUpdate = Context.Products.First(p => p.Id == product.Id);
            productToUpdate.Name = "Updated Product";
            ProductRepository.Update(productToUpdate);

            // act
            var expected = product.Name;
            var actual = Context.Products.Where(p => p.Id == product.Id).First().Name;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Remove_RemoveProduct_ProductWasRemoved()
        {
            // arrange
            var product = new Product
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
            };
            Context.Products.Add(product);
            Context.SaveChanges();
            ProductRepository.Remove(product.Id);

            // act
            Product? expected = null;
            var actual = Context.Products.FirstOrDefault(p => p.Id == product.Id);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [TearDown]
        public void CleanUp()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}

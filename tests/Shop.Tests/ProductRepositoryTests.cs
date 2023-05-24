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
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

            Context.Products.Add(product);
            Context.SaveChanges();

            // act
            var expected = product.Id;
            var actual = ProductRepository.GetById(product.Id)?.Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetById_PassNotExistingProductId_ReturnsNull()
        {
            // arrange
            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // act
            Product? expected = null;
            var actual = ProductRepository.GetById(productId);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_GetAllProducts_ReturnsAllProducts()
        {
            // arrange
            var products = TestData.GetTestProducts();

            Context.Products.AddRange(products);
            Context.SaveChanges();

            // act
            var expected = Context.Products.First().Id;
            var actual = ProductRepository.GetAll().First().Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetProductsByCategoryIds_PassExistingCategoryIds_ReturnsProducts()
        {
            // arrange
            var products = TestData.GetTestProducts();
            var categoryIds = new List<Guid>
            {
                Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                Guid.Parse("d1ca19e4-ec09-4810-9929-718d2f2d3a6b")
            };

            Context.Products.AddRange(products);
            Context.SaveChanges();

            // act
            var actual = ProductRepository.GetProductsByCategoryIds(categoryIds);

            // assert
            Assert.That(actual.Count(), Is.EqualTo(2));
            Assert.That(actual.First(), Is.EqualTo(products.First()));
        }

        [Test]
        public void GetProductsByCategoryIds_PassNotExistingCategoryIds_ReturnsEmptyList()
        {
            // arrange
            var products = TestData.GetTestProducts();
            var categoryIds = new List<Guid>
            {
                Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Guid.Parse("00000000-0000-0000-0000-000000000001")
            };

            Context.Products.AddRange(products);
            Context.SaveChanges();

            // act
            var actual = ProductRepository.GetProductsByCategoryIds(categoryIds);

            // assert
            Assert.That(actual, Is.EqualTo(new List<Product>()));
        }

        [Test]
        public void GetProductsByCategoryIds_PassNullCategoryIds_ReturnsEmptyList()
        {
            // arrange
            var products = TestData.GetTestProducts();
            var categoryIds = new List<Guid>();

            Context.Products.AddRange(products);
            Context.SaveChanges();

            // act
            var actual = ProductRepository.GetProductsByCategoryIds(categoryIds);

            // assert
            Assert.That(actual, Is.EqualTo(new List<Product>()));
        }

        [Test]
        public void Add_AddProduct_ProductWasAdded()
        {
            // arrange
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

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
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

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
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

            Context.Products.Add(product);
            Context.SaveChanges();
            ProductRepository.Remove(product.Id);

            // act
            Product? expected = null;
            var actual = Context.Products.FirstOrDefault(p => p.Id == product.Id);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Remove_RemoveNotExistingProduct_ProductWasNotRemoved()
        {
            // arrange
            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            ProductRepository.Remove(productId);

            // act
            Product? expected = null;
            var actual = Context.Products.FirstOrDefault(p => p.Id == productId);

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

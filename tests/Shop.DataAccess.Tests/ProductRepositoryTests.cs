using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.DataAccess.Tests
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
        public async Task GetByIdAsync_GetProductById_ReturnsProduct()
        {
            // arrange
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

            Context.Products.Add(product);
            Context.SaveChanges();

            var expected = product.Id;

            // act
            var actual = await ProductRepository.GetByIdAsync(product.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetByIdAsync_PassNotExistingProductId_ReturnsNull()
        {
            // arrange
            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // act
            var actual = await ProductRepository.GetByIdAsync(productId);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task GetAllAsync_GetAllProducts_ReturnsAllProducts()
        {
            // arrange
            var products = TestData.GetTestProducts();

            Context.Products.AddRange(products);
            Context.SaveChanges();

            var expected = Context.Products;

            // act
            var actual = await ProductRepository.GetAllAsync();

            // assert
            Assert.That(actual.First().Id, Is.EqualTo(expected.First().Id));
        }

        [Test]
        public async Task GetProductsByCategoryIdsAsync_PassExistingCategoryIds_ReturnsProducts()
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
            var actual = await ProductRepository.GetProductsByCategoryIdsAsync(categoryIds);

            // assert
            Assert.That(actual.Count(), Is.EqualTo(2));
            Assert.That(actual.First(), Is.EqualTo(products.First()));
        }

        [Test]
        public async Task GetProductsByCategoryIdsAsync_PassNotExistingCategoryIds_ReturnsEmptyList()
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
            var actual = await ProductRepository.GetProductsByCategoryIdsAsync(categoryIds);

            // assert
            Assert.That(actual, Is.EqualTo(new List<Product>()));
        }

        [Test]
        public async Task GetProductsByCategoryIdsAsync_PassNullCategoryIds_ReturnsEmptyList()
        {
            // arrange
            var products = TestData.GetTestProducts();
            var categoryIds = new List<Guid>();

            Context.Products.AddRange(products);
            Context.SaveChanges();

            // act
            var actual = await ProductRepository.GetProductsByCategoryIdsAsync(categoryIds);

            // assert
            Assert.That(actual, Is.EqualTo(new List<Product>()));
        }

        [Test]
        public async Task AddAsync_AddProduct_ProductWasAdded()
        {
            // arrange
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

            await ProductRepository.AddAsync(product);

            var expected = product.Id;

            // act
            var actual = Context.Products.First(p => p.Id == product.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public async Task UpdateAsync_UpdateProduct_ProductWasUpdated()
        {
            // arrange
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

            Context.Products.Add(product);
            Context.SaveChanges();

            var productToUpdate = Context.Products.First(p => p.Id == product.Id);
            productToUpdate.Name = "Updated Product";
            await ProductRepository.UpdateAsync(productToUpdate);

            var expected = product;

            // act
            var actual = Context.Products.First(p => p.Id == product.Id);

            // assert
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        [Test]
        public async Task RemoveAsync_RemoveProduct_ProductWasRemoved()
        {
            // arrange
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var product = TestData.GetTestProduct(productId);

            Context.Products.Add(product);
            Context.SaveChanges();
            await ProductRepository.RemoveAsync(product.Id);

            // act
            var actual = Context.Products.FirstOrDefault(p => p.Id == product.Id);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task RemoveAsync_RemoveNotExistingProduct_ProductWasNotRemoved()
        {
            // arrange
            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            await ProductRepository.RemoveAsync(productId);

            // act
            var actual = Context.Products.FirstOrDefault(p => p.Id == productId);

            // assert
            Assert.That(actual, Is.Null);
        }

        [TearDown]
        public void CleanUp()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}

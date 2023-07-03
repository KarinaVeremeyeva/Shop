using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repositories;

namespace Shop.DataAccess.Tests
{
    [TestFixture]
    public class CategoryRepositoryTests
    {
        private TestShopContext Context { get; set; }

        private CategoryRepository CategoryRepository { get; set; }

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "TestShopDb")
                .Options;

            Context = new TestShopContext(contextOptions);
            CategoryRepository = new CategoryRepository(Context);
        }

        [Test]
        public async Task GetByIdAsync_GetCategoryById_ReturnsCategory()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            Context.Categories.Add(category);
            Context.SaveChanges();

            var expected = category.Id;

            // act
            var actual = await CategoryRepository.GetByIdAsync(category.Id);
            
            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetByIdAsync_PassNotExistingCategoryId_ReturnsNull()
        {
            // arrange
            var categoryId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // act
            var actual = await CategoryRepository.GetByIdAsync(categoryId);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task GetByIdAsync_GetChildCategoryById_ReturnsCategory()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);
            var childCategoryId = category.ChildCategories.First().Id;

            Context.Categories.Add(category);
            Context.SaveChanges();

            var expected = category.ChildCategories.First();

            // act
            var actual = await CategoryRepository.GetByIdAsync(childCategoryId);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected.Id));
        }

        [Test]
        public async Task GetByIdAsync_GetGrandChildCategoryById_ReturnsCategory()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);
            var grandChildCategoryId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");

            Context.Categories.Add(category);
            Context.SaveChanges();

            var expected = grandChildCategoryId;

            // act
            var actual = await CategoryRepository.GetByIdAsync(grandChildCategoryId);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetAllAsync_GetAllCategories_ReturnsAllCategories()
        {
            // arrange
            var categories = TestData.GetTestCategories();

            Context.Categories.AddRange(categories);
            Context.SaveChanges();

            var expected = Context.Categories;

            // act
            var actual = await CategoryRepository.GetAllAsync();

            // assert
            Assert.That(actual.First().Id, Is.EqualTo(expected.First().Id));
        }

        [Test]
        public async Task AddAsync_AddCategory_CategoryWasSaved()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            await CategoryRepository.AddAsync(category);

            var expected = category.Id;

            // act
            var actual = Context.Categories.First(c => c.Id == category.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public async Task UpdateAsync_UpdateCategory_CategoryWasUpdated()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            Context.Categories.Add(category);
            Context.SaveChanges();

            var categoryToUpdate = Context.Categories.First(c => c.Id == category.Id);
            categoryToUpdate.Name = "Updated Category";
            await CategoryRepository.UpdateAsync(categoryToUpdate);
            var expected = category;

            // act
            var actual = Context.Categories.First(c => c.Id == category.Id);

            // assert
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
        }

        [Test]
        public async Task RemoveAsync_RemoveCategory_CategoryWasRemoveed()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            Context.Categories.Add(category);
            Context.SaveChanges();
            await CategoryRepository.RemoveAsync(category.Id);

            // act
            var actual = Context.Categories.FirstOrDefault(c => c.Id == category.Id);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task RemoveAsync_RemoveNotExistingCategory_CategoryWasNotRemoved()
        {
            // arrange
            var categoryId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            await CategoryRepository.RemoveAsync(categoryId);

            // act
            var actual = Context.Categories.FirstOrDefault(c => c.Id == categoryId);

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
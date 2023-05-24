using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.Tests
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
        public void GetById_GetCategoryById_ReturnsCategory()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            Context.Categories.Add(category);
            Context.SaveChanges();

            // act
            var expected = category.Id;
            var actual = CategoryRepository.GetById(category.Id)?.Id;
            
            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetById_PassNotExistingCategoryId_ReturnsNull()
        {
            // arrange
            var categoryId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // act
            Category? expected = null;
            var actual = CategoryRepository.GetById(categoryId);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetById_GetChildCategoryById_ReturnsCategory()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);
            var childCategoryId = category.ChildCategories.First().Id;

            Context.Categories.Add(category);
            Context.SaveChanges();

            // act
            var expected = category.ChildCategories.First().Id;
            var actual = CategoryRepository.GetById(childCategoryId)?.Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetById_GetGrandChildCategoryById_ReturnsCategory()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);
            var grandChildCategoryId = category
                .ChildCategories.First()
                .ChildCategories.First().Id;

            Context.Categories.Add(category);
            Context.SaveChanges();

            // act
            var expected = grandChildCategoryId;
            var actual = CategoryRepository.GetById(grandChildCategoryId)?.Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_GetAllCategories_ReturnsAllCategories()
        {
            // arrange
            var categories = TestData.GetTestCategories();

            Context.Categories.AddRange(categories);
            Context.SaveChanges();

            // act
            var expected = Context.Categories.First().Id;
            var actual = CategoryRepository.GetAll().First().Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Add_AddCategory_CategoryWasSaved()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            CategoryRepository.Add(category);

            // act
            var expected = category.Id;
            var actual = Context.Categories.Where(c => c.Id == category.Id).First().Id;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Update_UpdateCategory_CategoryWasUpdated()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            Context.Categories.Add(category);
            Context.SaveChanges();

            var categoryToUpdate = Context.Categories.First(c => c.Id == category.Id);
            categoryToUpdate.Name = "Updated Category";
            CategoryRepository.Update(categoryToUpdate);

            // act
            var expected = category.Name;
            var actual = Context.Categories.Where(c => c.Id == category.Id).First().Name;

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Remove_RemoveCategory_CategoryWasRemoveed()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            Context.Categories.Add(category);
            Context.SaveChanges();
            CategoryRepository.Remove(category.Id);

            // act
            Category? expected = null;
            var actual = Context.Categories.FirstOrDefault(c => c.Id == category.Id);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Remove_RemoveNotExistingCategory_CategoryWasNotRemoved()
        {
            var categoryId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            CategoryRepository.Remove(categoryId);

            // act
            Category? expected = null;
            var actual = Context.Categories.FirstOrDefault(c => c.Id == categoryId);

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
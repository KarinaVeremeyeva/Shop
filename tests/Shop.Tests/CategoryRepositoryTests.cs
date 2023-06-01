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

            var expected = category.Id;

            // act
            var actual = CategoryRepository.GetById(category.Id);
            
            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public void GetById_PassNotExistingCategoryId_ReturnsNull()
        {
            // arrange
            var categoryId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // act
            var actual = CategoryRepository.GetById(categoryId);

            // assert
            Assert.That(actual, Is.Null);
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

            var expected = category.ChildCategories.First();

            // act
            var actual = CategoryRepository.GetById(childCategoryId);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected.Id));
        }

        [Test]
        public void GetById_GetGrandChildCategoryById_ReturnsCategory()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);
            var grandChildCategoryId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");

            Context.Categories.Add(category);
            Context.SaveChanges();

            var expected = grandChildCategoryId;

            // act
            var actual = CategoryRepository.GetById(grandChildCategoryId);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_GetAllCategories_ReturnsAllCategories()
        {
            // arrange
            var categories = TestData.GetTestCategories();

            Context.Categories.AddRange(categories);
            Context.SaveChanges();

            var expected = Context.Categories;

            // act
            var actual = CategoryRepository.GetAll();

            // assert
            Assert.That(actual.First().Id, Is.EqualTo(expected.First().Id));
        }

        [Test]
        public void Add_AddCategory_CategoryWasSaved()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var category = TestData.GetTestCategory(categoryId);

            CategoryRepository.Add(category);

            var expected = category.Id;

            // act
            var actual = Context.Categories.First(c => c.Id == category.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
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
            var expected = category;

            // act
            var actual = Context.Categories.First(c => c.Id == category.Id);

            // assert
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
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
            var actual = Context.Categories.FirstOrDefault(c => c.Id == category.Id);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Remove_RemoveNotExistingCategory_CategoryWasNotRemoved()
        {
            // arrange
            var categoryId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            CategoryRepository.Remove(categoryId);

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
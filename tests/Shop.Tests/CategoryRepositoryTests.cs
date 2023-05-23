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
            var category = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Category",
                Description = "Description 1",
                ParentCategoryId = null
            };
            Context.Categories.Add(category);
            Context.SaveChanges();

            // act
            var expected = category.Id;
            var actual = CategoryRepository.GetById(category.Id)?.Id;
            
            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetAll_GetAllCategories_ReturnsAllCategories()
        {
            // arrange
            var categories = new List<Category>()
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "category 1",
                    Description = "Description 1",
                    ParentCategoryId = null
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "category 2",
                    Description = "Description 2",
                    ParentCategoryId = null
                }
            };

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
            var category = new Category()
            {
                Id = Guid.Parse("45fd40b8-146d-4a5b-a3a3-6366fc74d37e"),
                Name = "Category 1",
                Description = "Description 1",
            };
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
            var category = new Category()
            {
                Id = Guid.Parse("45fd40b8-146d-4a5b-a3a3-6366fc74d37e"),
                Name = "Category 1",
                Description = "Description 1",
            };
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
            var category = new Category()
            {
                Id = Guid.Parse("45fd40b8-146d-4a5b-a3a3-6366fc74d37e"),
                Name = "Category 1",
                Description = "Description 1",
            };
            Context.Categories.Add(category);
            Context.SaveChanges();
            CategoryRepository.Remove(category.Id);

            // act
            Category? expected = null;
            var actual = Context.Categories.FirstOrDefault(c => c.Id == category.Id);

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
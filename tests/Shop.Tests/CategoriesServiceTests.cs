using AutoMapper;
using Moq;
using Shop.BLL;
using Shop.BLL.Services;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.Tests
{
    [TestFixture]
    public class CategoriesServiceTests
    {
        private static IMapper _mapper;

        [OneTimeSetUp]
        public void Initialize()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new BusinessLogicProfile());
            });
            var mapper = mappingConfig.CreateMapper();
            _mapper = mapper;
        }

        [Test]
        public void GetCategories_GetAllCategories_ReturnsCtaegories()
        {
            // arrange
            var testCategories = GetTestCategories();

            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository
                .Setup(x => x.GetAll())
                .Returns(testCategories);

            var service = new CategoriesService(mockRepository.Object, _mapper);
            
            // act
            var actual = service.GetCategories().First();
            
            // assert
            Assert.That(actual.Id, Is.EqualTo(testCategories.First().Id));
        }

        [Test]
        public void GetCategoryAndChildrenIds_GetCategoryIds_ReturnsCategoryIds()
        {
            // arrange
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var testCategories = GetTestCategories();
            var category = GetTestCategory();

            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository
                .Setup(x => x.GetById(categoryId))
                .Returns(category);

            var service = new CategoriesService(mockRepository.Object, _mapper);

            var ids = category.ChildCategories.Select(x => x.Id);
            var expected = ids.Concat(new List<Guid> { categoryId });     

            // act
            var actual = service.GetCategoryAndChildrenIds(categoryId);

            // assert
            Assert.That(actual.First(), Is.EqualTo(expected.First()));
        }

        [Test]
        public void GetCategoryAndChildrenIds_PassNotExistingCategoryId_ReturnsArgumentException()
        {
            // arrange
            var categoryId = Guid.Parse("2f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Throws(new ArgumentException("Entity was not found"));
            var service = new CategoriesService(mockRepository.Object, _mapper);

            // act and assert
            Assert.Throws<ArgumentException>(
                () => service.GetCategoryAndChildrenIds(categoryId),
                "Entity was not found");
        }

        private Category GetTestCategory()
        {
            var category = new Category
            {
                Id = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                Name = "Category 1",
                Description = "Description 1",
                ChildCategories = {
                        new Category
                        {
                            Id = Guid.Parse("0865d2ff-5602-40df-9466-26b2fef9785e"),
                            Name = "Child 1",
                            Description = "Description 2",
                            ParentCategoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6")
                        },
                        new Category
                        {
                            Id = Guid.Parse("e77a4e6e-a0f0-4b1c-988e-adeb182a059c"),
                            Name = "Child 2",
                            Description = "Description 3",
                            ParentCategoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                            ChildCategories = {
                                new Category
                                {
                                    Id = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37"),
                                    Name = "Child 2.1",
                                    Description = "Description 4",
                                }
                            }
                        }
                    }
            };

            return category;
        }

        private IEnumerable<Category> GetTestCategories()
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
                            Id = Guid.Parse("0865d2ff-5602-40df-9466-26b2fef9785e"),
                            Name = "Child 1",
                            Description = "Description 2",
                            ParentCategoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6")
                        },
                        new Category
                        {
                            Id = Guid.Parse("e77a4e6e-a0f0-4b1c-988e-adeb182a059c"),
                            Name = "Child 2",
                            Description = "Description 3",
                            ParentCategoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6"),
                            ChildCategories = {
                                new Category
                                {
                                    Id = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37"),
                                    Name = "Child 2.1",
                                    Description = "Description 4",
                                }
                            }
                        }
                    }
                }
            };

            return categories;
        }
    }
}

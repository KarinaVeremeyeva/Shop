using AutoMapper;
using Moq;
using Shop.BLL;
using Shop.BLL.Services;
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
            var testCategories = TestData.GetTestCategories();

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
            var category = TestData.GetTestCategory(categoryId);

            var mockRepository = new Mock<ICategoryRepository>();
            mockRepository
                .Setup(x => x.GetById(categoryId))
                .Returns(category);
            var service = new CategoriesService(mockRepository.Object, _mapper);

            var expected = new List<Guid>
            {
                Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37"),
                Guid.Parse("e77a4e6e-a0f0-4b1c-988e-adeb182a059c"),
                Guid.Parse("0865d2ff-5602-40df-9466-26b2fef9785e"),
                categoryId
            };

            // act
            var actual = service.GetCategoryAndChildrenIds(categoryId);

            // assert
            Assert.That(actual.Count(), Is.EqualTo(expected.Count()));
            Assert.That(actual.First(), Is.EqualTo(expected.First()));
        }

        [Test]
        public void GetCategoryAndChildrenIds_PassNotExistingCategoryId_ReturnsEmptyList()
        {
            // arrange
            var categoryId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var mockRepository = new Mock<ICategoryRepository>();
            
            var service = new CategoriesService(mockRepository.Object, _mapper);
            
            // act 
            var actual = service.GetCategoryAndChildrenIds(categoryId);

            // assert
            Assert.That(actual.Count(), Is.EqualTo(0));
        }
    }
}

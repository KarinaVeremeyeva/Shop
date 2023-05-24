using AutoMapper;
using Moq;
using Shop.BLL;
using Shop.BLL.Services;
using Shop.DataAccess.Repositories;

namespace Shop.Tests
{
    [TestFixture]
    public class ProductsServiceTests
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
        public void GetProduct_GetProductById_ReturnsProduct()
        {
            // ararnge
            var productId = Guid.Parse("ee83d6ba-c84b-4a60-99d8-76a9833ca11a");
            var testProduct = TestData.GetTestProduct(productId);

            var mockRepository = new Mock<IProductRepository>();
            mockRepository
                .Setup(x => x.GetById(productId))
                .Returns(testProduct);

            var mockService = new Mock<ICategoriesService>();

            var service = new ProductsService(mockService.Object, mockRepository.Object, _mapper);

            // act
            var actual = service.GetProduct(productId)?.Id;

            // assert
            Assert.That(actual, Is.EqualTo(testProduct?.Id));
        }

        [Test]
        public void GetProductByCategoryId_GetProducts_ReturnsSelectedProducts()
        {
            // arrange
            var testProducts = TestData.GetTestProducts();
            var categoryId = Guid.Parse("4f9702de-cefd-4bac-93ec-0a4b5cb77ca6");
            var mockRepository = new Mock<IProductRepository>();
            mockRepository.Setup(x => x.GetProductsByCategoryIds(It.IsAny<IEnumerable<Guid>>()))
                .Returns(testProducts);

            var categoryIds = new List<Guid>
            {
                categoryId,
                Guid.Parse("d1ca19e4-ec09-4810-9929-718d2f2d3a6b")
            };

            var mockService = new Mock<ICategoriesService>();
            mockService
                .Setup(x => x.GetCategoryAndChildrenIds(It.IsAny<Guid>()))
                .Returns(categoryIds);

            // act
            var service = new ProductsService(mockService.Object, mockRepository.Object, _mapper);
            var actual = service.GetProductByCategoryId(categoryId);
            
            // asssert
            Assert.That(actual.Count(), Is.EqualTo(testProducts.Count()));
            Assert.That(actual.First().Id, Is.EqualTo(testProducts.First().Id));

        }
    }
}

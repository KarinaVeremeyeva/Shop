using AutoMapper;
using Moq;
using Shop.BLL.Services;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;
using System.Linq.Expressions;

namespace Shop.BLL.Tests
{
    [TestFixture]
    public class CartItemsServiceTests
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
        public async Task AddToCartAsync_AddProductToCart_CartItemAdded()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(new List<CartItem>());
            mockCartRepository.Setup(x => x.AddAsync(It.IsAny<CartItem>()));

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Product());

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            await service.AddToCartAsync(productId, email);

            // assert
            mockCartRepository.Verify(x => x.AddAsync(It.Is<CartItem>(cartItem => cartItem.Quantity == 1)));
        }
        [Test]
        public async Task AddToCartAsync_AddProductToCart_QuantityShouldIncrease()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems().Take(1);

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(testCartItems);
            mockCartRepository.Setup(x => x.UpdateAsync(It.IsAny<CartItem>()));

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .Setup(x => x.GetByIdAsync(It.IsAny<Guid>()))
                .ReturnsAsync(new Product());

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            await service.AddToCartAsync(productId, email);

            // assert
            mockCartRepository.Verify(x => x.UpdateAsync(It.Is<CartItem>(cartItem => cartItem.Quantity == 3)));
        }

        [Test]
        public void AddToCartAsync_PassNotExistingProductId_ThrowsException()
        {
            // arrange
            var mockCartRepository = new Mock<ICartItemsRepository>();
            var mockProductRepository = new Mock<IProductRepository>();
            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var email = "test@email";

            // act and assert
            Assert.That(() => service.AddToCartAsync(productId, email),
                Throws.Exception
                    .TypeOf<ArgumentException>()
                    .With.Property("Message").EqualTo($"Product {productId} doesn't exist."));
        }

        [Test]
        public async Task RemoveFromCardAsync_RemoveProductFromCard_ProductRemovedFromCart()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems().Take(1);

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(testCartItems);
            mockCartRepository.Setup(x => x.RemoveAsync(It.IsAny<Guid>()));

            var mockProductRepository = new Mock<IProductRepository>();
            
            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            await service.RemoveFromCardAsync(productId, email);

            // assert
            mockCartRepository.Verify(x => x.RemoveAsync(It.IsAny<Guid>()));
        }

        [Test]
        public async Task RemoveFromCardAsync_PassNotExistingProductId_Returns()
        {
            // arrange
            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var email = "test@email";

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(new List<CartItem>());
            mockCartRepository.Setup(x => x.RemoveAsync(It.IsAny<Guid>()));

            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            await service.RemoveFromCardAsync(productId, email);

            // assert
            mockCartRepository.Verify(x => x.RemoveAsync(It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public async Task ReduceProductCountAsync_HasItemWithQuantity2_ProductQuantityDecreased()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems().Take(1);

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(testCartItems);
            mockCartRepository.Setup(x => x.UpdateAsync(It.IsAny<CartItem>()));

            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            await service.ReduceProductCountAsync(productId, email);

            // assert
            mockCartRepository.Verify(x => x.UpdateAsync(It.Is<CartItem>(cartItem => cartItem.Quantity == 1)));
        }

        [Test]
        public async Task GetCartItemsAsync_GetAllCartItems_ReturnsCartItemList()
        {
            // arrange
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(testCartItems);
            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);
            
            // act
            var actual = await service.GetCartItemsAsync(email);

            // assert
            Assert.That(actual.Count(), Is.EqualTo(testCartItems.Count()));
            Assert.That(actual.First().Id, Is.EqualTo(testCartItems.First().Id));
        }

        [Test]
        public async Task GetTotalPriceAsync_GetCartItemsTotalPrice_ReturnsTotalPrice()
        {
            // arrange
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(testCartItems);
            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            var expected = 400;

            // act
            var actual = await service.GetTotalPriceAsync(email);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        public async Task GetTotalCountAsync_GetCartItemsTotalCount_ReturnsTotalCount()
        {
            // arrange
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetWhereAsync(It.IsAny<Expression<Func<CartItem, bool>>>()))
                .ReturnsAsync(testCartItems);
            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            var expected = 2;

            // act
            var actual = await service.GetTotalCountAsync(email);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

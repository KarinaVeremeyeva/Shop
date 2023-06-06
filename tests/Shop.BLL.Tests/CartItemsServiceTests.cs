using AutoMapper;
using Moq;
using Shop.BLL.Services;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

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
        public void AddToCart_AddProductToCart_CartItemAdded()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(new List<CartItem>());
            mockCartRepository.Setup(x => x.Add(It.IsAny<CartItem>()));

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(new Product());

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            service.AddToCart(productId, email);

            // assert
            mockCartRepository.Verify(x => x.Add(It.Is<CartItem>(cartItem => cartItem.Quantity == 1)));
        }
        [Test]
        public void AddToCart_AddProductToCart_QuantityShouldIncrease()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(testCartItems);
            mockCartRepository.Setup(x => x.Update(It.IsAny<CartItem>()));

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(new Product());

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            service.AddToCart(productId, email);

            // assert
            mockCartRepository.Verify(x => x.Update(It.Is<CartItem>(cartItem => cartItem.Quantity == 3)));
        }

        [Test]
        public void AddToCart_PassNotExistingProductId_ThrowsException()
        {
            // arrange
            var mockCartRepository = new Mock<ICartItemsRepository>();
            var mockProductRepository = new Mock<IProductRepository>();
            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var email = "test@email";

            // act and assert
            Assert.That(() => service.AddToCart(productId, email),
                Throws.Exception
                    .TypeOf<ArgumentException>()
                    .With.Property("Message").EqualTo($"Product {productId} doesn't exist."));
        }

        [Test]
        public void RemoveFromCard_RemoveProductFromCard_ProductRemovedFromCart()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(testCartItems);
            mockCartRepository.Setup(x => x.Remove(It.IsAny<Guid>()));

            var mockProductRepository = new Mock<IProductRepository>();
            
            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            service.RemoveFromCard(productId, email);

            // assert
            mockCartRepository.Verify(x => x.Remove(It.IsAny<Guid>()));
        }

        [Test]
        public void RemoveFromCard_PassNotExistingProductId_Returns()
        {
            // arrange
            var productId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            var email = "test@email";

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(new List<CartItem>());
            mockCartRepository.Setup(x => x.Remove(It.IsAny<Guid>()));

            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            service.RemoveFromCard(productId, email);

            // assert
            mockCartRepository.Verify(x => x.Remove(It.IsAny<Guid>()), Times.Never);
        }

        [Test]
        public void ReduceProductCount_HasItemWithQuantity2_ProductQuantityDecreased()
        {
            // arrange
            var productId = Guid.Parse("a79fd279-390d-4416-ba08-c3239bf7ed37");
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(testCartItems);
            mockCartRepository.Setup(x => x.Update(It.IsAny<CartItem>()));

            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            // act
            service.ReduceProductCount(productId, email);

            // assert
            mockCartRepository.Verify(x => x.Update(It.Is<CartItem>(cartItem => cartItem.Quantity == 1)));
        }

        [Test]
        public void GetCartItems_GetAllCartItems_ReturnsCartItemList()
        {
            // arrange
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(testCartItems);
            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);
            
            // act
            var actual = service.GetCartItems(email);

            // assert
            Assert.That(actual.Count(), Is.EqualTo(testCartItems.Count()));
            Assert.That(actual.First().Id, Is.EqualTo(testCartItems.First().Id));
        }

        [Test]
        public void GetTotalPrice_GetCartItemsTotalPrice_ReturnsTotalPrice()
        {
            // arrange
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(testCartItems);
            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            var expected = 400;

            // act
            var actual = service.GetTotalPrice(email);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        public void GetTotalCount_GetCartItemsTotalCount_ReturnsTotalCount()
        {
            // arrange
            var email = "test@email";
            var testCartItems = TestData.GetTestCartItems();

            var mockCartRepository = new Mock<ICartItemsRepository>();
            mockCartRepository
                .Setup(x => x.GetAll())
                .Returns(testCartItems);
            var mockProductRepository = new Mock<IProductRepository>();

            var service = new CartItemsService(mockCartRepository.Object, mockProductRepository.Object, _mapper);

            var expected = 2;

            // act
            var actual = service.GetTotalCount(email);

            // assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

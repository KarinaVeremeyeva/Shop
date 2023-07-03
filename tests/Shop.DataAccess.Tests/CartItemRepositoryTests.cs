using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repositories;

namespace Shop.DataAccess.Tests
{
    [TestFixture]
    public class CartItemRepositoryTests
    {
        private TestShopContext Context { get; set; }

        private CartItemRepository CartItemRepository { get; set; }

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<ShopContext>()
                .UseInMemoryDatabase(databaseName: "TestShopDb")
                .Options;

            Context = new TestShopContext(contextOptions);
            CartItemRepository = new CartItemRepository(Context);
        }

        [Test]
        public async Task GetByIdAsync_GetCartItemById_ReturnsCartItem()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            Context.ShoppingCartItems.Add(cartItem);
            Context.SaveChanges();

            var expected = cartItem.Id;

            // act
            var actual = await CartItemRepository.GetByIdAsync(cartItem.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public async Task GetByIdAsync_PassNotExistingCartItemId_ReturnsNull()
        {
            // arrange
            var cartItemId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // act
            var actual = await CartItemRepository.GetByIdAsync(cartItemId);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task GetAllAsync_GetAllCartItems_ReturnsAllCartItems()
        {
            // arrange
            var cartItems = TestData.GetTestCartItems();

            Context.ShoppingCartItems.AddRange(cartItems);
            Context.SaveChanges();

            var expected = Context.ShoppingCartItems;

            // act
            var actual = await CartItemRepository.GetAllAsync();

            // assert
            Assert.That(actual.First().Id, Is.EqualTo(expected.First().Id));
        }

        [Test]
        public async Task AddAsync_AddCartItem_CartItemWasAdded()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            await CartItemRepository.AddAsync(cartItem);
            var expected = cartItem.Id;

            // act
            var actual = Context.ShoppingCartItems.First(c => c.Id == cartItem.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public async Task UpdateAsync_UpdateCartItem_CartItemWasUpdated()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            Context.ShoppingCartItems.Add(cartItem);
            Context.SaveChanges();

            var cartItemToUpdate = Context.ShoppingCartItems.FirstOrDefault(c => c.Id == cartItem.Id);
            cartItemToUpdate.Quantity = 2;
            await CartItemRepository.UpdateAsync(cartItemToUpdate);

            var expected = cartItem;

            // act
            var actual = Context.ShoppingCartItems.First(c => c.Id == cartItem.Id);

            // assert
            Assert.That(actual.Quantity, Is.EqualTo(expected.Quantity));
        }

        [Test]
        public async Task RemoveAsync_RemoveCartItem_CartItemWasRemoved()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            Context.ShoppingCartItems.Add(cartItem);
            Context.SaveChanges();
            await CartItemRepository.RemoveAsync(cartItem.Id);

            // act
            var actual = Context.ShoppingCartItems.FirstOrDefault(c => c.Id == cartItem.Id);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task RemoveAsync_RemoveNotExistingCartItem_CartItemWasRemoved()
        {
            // arrange
            var cartItemId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            await CartItemRepository.RemoveAsync(cartItemId);

            // act
            var actual = Context.ShoppingCartItems.FirstOrDefault(c => c.Id == cartItemId);

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

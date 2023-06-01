using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;
using Shop.DataAccess.Repositories;

namespace Shop.Tests
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
        public void GetById_GetCartItemById_ReturnsCartItem()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            Context.ShoppingCartItems.Add(cartItem);
            Context.SaveChanges();

            var expected = cartItem.Id;

            // act
            var actual = CartItemRepository.GetById(cartItem.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public void GetById_PassNotExistingCartItemId_ReturnsNull()
        {
            // arrange
            var cartItemId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // act
            var actual = CartItemRepository.GetById(cartItemId);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void GetAll_GetAllCartItems_ReturnsAllCartItems()
        {
            // arrange
            var cartItems = TestData.GetTestCartItems();

            Context.ShoppingCartItems.AddRange(cartItems);
            Context.SaveChanges();

            var expected = Context.ShoppingCartItems;

            // act
            var actual = CartItemRepository.GetAll();

            // assert
            Assert.That(actual.First().Id, Is.EqualTo(expected.First().Id));
        }

        [Test]
        public void Add_AddCartItem_CartItemWasAdded()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            CartItemRepository.Add(cartItem);
            var expected = cartItem.Id;

            // act
            var actual = Context.ShoppingCartItems.First(c => c.Id == cartItem.Id);

            // assert
            Assert.That(actual.Id, Is.EqualTo(expected));
        }

        [Test]
        public void Update_UpdateCartItem_CartItemWasUpdated()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            Context.ShoppingCartItems.Add(cartItem);
            Context.SaveChanges();

            var cartItemToUpdate = Context.ShoppingCartItems.FirstOrDefault(c => c.Id == cartItem.Id);
            cartItemToUpdate.Quantity = 2;
            CartItemRepository.Update(cartItemToUpdate);

            var expected = cartItem;

            // act
            var actual = Context.ShoppingCartItems.First(c => c.Id == cartItem.Id);

            // assert
            Assert.That(actual.Quantity, Is.EqualTo(expected.Quantity));
        }

        [Test]
        public void Remove_RemoveCartItem_CartItemWasRemoved()
        {
            // arrange
            var cartItemId = Guid.Parse("d787bb8f-bc03-4e54-baed-dc70d17e3f39");
            var cartItem = TestData.GetTestCartItem(cartItemId);

            Context.ShoppingCartItems.Add(cartItem);
            Context.SaveChanges();
            CartItemRepository.Remove(cartItem.Id);

            // act
            var actual = Context.ShoppingCartItems.FirstOrDefault(c => c.Id == cartItem.Id);

            // assert
            Assert.That(actual, Is.Null);
        }

        [Test]
        public void Remove_RemoveNotExistingCartItem_CartItemWasRemoved()
        {
            // arrange
            var cartItemId = Guid.Parse("00000000-0000-0000-0000-000000000000");
            CartItemRepository.Remove(cartItemId);

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

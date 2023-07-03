using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class CartItemsService : ICartItemsService
    {
        private readonly ICartItemsRepository _cartItemsRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CartItemsService(
            ICartItemsRepository cartItemsRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _cartItemsRepository = cartItemsRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CartItemModel> AddToCartAsync(Guid productId, string email)
        {
            var checkProductId = await _productRepository.GetByIdAsync(productId)
                ?? throw new ArgumentException($"Product {productId} doesn't exist.");

            var cartItems = await _cartItemsRepository
                .GetWhereAsync(c => c.UserEmail == email && c.ProductId == productId);
            var cartItem = cartItems.SingleOrDefault();

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    UserEmail = email,
                    ProductId = productId,
                    Quantity = 1
                };

                var addedCartItem = await _cartItemsRepository.AddAsync(cartItem);
                var cartItemModel = _mapper.Map<CartItemModel>(addedCartItem);

                return cartItemModel;
            }
            else
            {
                cartItem.Quantity++;

                var updatedCartItem = await _cartItemsRepository.UpdateAsync(cartItem);
                var cartItemModel = _mapper.Map<CartItemModel>(updatedCartItem);

                return cartItemModel;
            }
        }

        public async Task RemoveFromCardAsync(Guid productId, string email)
        {
            var cartItems = await _cartItemsRepository
                .GetWhereAsync(c => c.UserEmail == email && c.ProductId == productId);
            var cartItem = cartItems.SingleOrDefault();

            if (cartItem == null)
            {
                return;
            }

            await _cartItemsRepository.RemoveAsync(cartItem.Id);
        }

        public async Task ReduceProductCountAsync(Guid productId, string email)
        {
            var cartItems = await _cartItemsRepository
                .GetWhereAsync(c => c.UserEmail == email && c.ProductId == productId);
            var cartItem = cartItems.SingleOrDefault();

            if (cartItem == null)
            {
                return;
            }

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                await _cartItemsRepository.UpdateAsync(cartItem);
            }
            else
            {
                await _cartItemsRepository.RemoveAsync(cartItem.Id);
            }
        }

        public async Task<List<CartItemModel>> GetCartItemsAsync(string email)
        {
            var cartItems = await _cartItemsRepository.GetWhereAsync(c => c.UserEmail == email);

            return _mapper.Map<List<CartItemModel>>(cartItems);
        }

        public async Task<decimal> GetTotalPriceAsync(string email)
        {
            var cartItems = await _cartItemsRepository.GetWhereAsync(c => c.UserEmail == email);
            var totalPrice = cartItems
                .Select(c => c.Quantity * c.Product.Price)
                .Sum();

            return totalPrice;
        }

        public async Task<int> GetTotalCountAsync(string email)
        {
            var cartItems = await _cartItemsRepository.GetWhereAsync(c => c.UserEmail == email);
            var totalCount = cartItems
                .Select(c => c.Quantity)
                .Sum();

            return totalCount;
        }
    }
}

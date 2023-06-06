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

        public CartItemModel AddToCart(Guid productId, string email)
        {
            var checkProductId = _productRepository.GetById(productId)
                ?? throw new ArgumentException($"Product {productId} doesn't exist.");

            var cartItem = _cartItemsRepository.GetAll()
                .SingleOrDefault(c => c.UserEmail == email && c.ProductId == productId);
            
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    UserEmail = email,
                    ProductId = productId,
                    Quantity = 1
                };

                var addedCartItem = _cartItemsRepository.Add(cartItem);
                var cartItemModel = _mapper.Map<CartItemModel>(addedCartItem);

                return cartItemModel;
            }
            else
            {
                cartItem.Quantity++;

                var updatedCartItem = _cartItemsRepository.Update(cartItem);
                var cartItemModel = _mapper.Map<CartItemModel>(updatedCartItem);

                return cartItemModel;
            }
        }

        public void RemoveFromCard(Guid productId, string email)
        {
            var cartItem = _cartItemsRepository.GetAll()
                .SingleOrDefault(c => c.UserEmail == email && c.ProductId == productId);

            if (cartItem == null)
            {
                return;
            }

            _cartItemsRepository.Remove(cartItem.Id);
        }

        public void ReduceProductCount(Guid productId, string email)
        {
            var cartItem = _cartItemsRepository.GetAll()
                .SingleOrDefault(c => c.UserEmail == email && c.ProductId == productId);

            if (cartItem == null)
            {
                return;
            }

            if (cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
                _cartItemsRepository.Update(cartItem);
            }
            else
            {
                _cartItemsRepository.Remove(cartItem.Id);
            }
        }

        public List<CartItemModel> GetCartItems(string email)
        {
            var cartItems = _cartItemsRepository.GetAll()
                .Where(c => c.UserEmail == email);

            return _mapper.Map<List<CartItemModel>>(cartItems);
        }

        public decimal GetTotalPrice(string email)
        {
            var totalPrice = _cartItemsRepository.GetAll()
                .Where(c => c.UserEmail == email)
                .Select(c => c.Quantity * c.Product.Price)
                .Sum();

            return totalPrice;
        }

        public int GetTotalCount(string email)
        {
            var totalCount = _cartItemsRepository.GetAll()
                .Where(c => c.UserEmail == email)
                .Select(c => c.Quantity)
                .Sum();

            return totalCount;
        }
    }
}

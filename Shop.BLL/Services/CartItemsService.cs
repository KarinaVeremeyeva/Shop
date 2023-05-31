﻿using AutoMapper;
using Shop.BLL.Models;
using Shop.DataAccess.Entities;
using Shop.DataAccess.Repositories;

namespace Shop.BLL.Services
{
    public class CartItemsService : ICartItemsService
    {
        private ICartItemsRepository _cartItemsRepository;
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public CartItemsService(
            ICartItemsRepository cartItemsRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _cartItemsRepository = cartItemsRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public void AddToCart(Guid productId, string email)
        {
            var cartItem = _cartItemsRepository.GetAll()
                .SingleOrDefault(c => c.UserEmail == email && c.ProductId == productId);
            
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    UserEmail = email,
                    ProductId = productId,
                    Product = _productRepository.GetById(productId),
                    Quantity = 1
                };

                _cartItemsRepository.Add(cartItem);
            }
            else
            {
                cartItem.Quantity++;
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
            cartItem.Quantity--;
        }

        public List<CartItemModel> GetCartItems(string email)
        {
            var cartItems = _cartItemsRepository.GetAll()
                .Where(c => c.UserEmail == email);

            return _mapper.Map<List<CartItemModel>>(cartItems);
        }

        public decimal GetTotalPrice(string email)
        {
            decimal totalPrice = 0;
            totalPrice = _cartItemsRepository.GetAll()
                .Where(c => c.UserEmail == email)
                .Select(c => c.Quantity * c.Product.Price).Sum();

            return totalPrice;
        }

        public int GetTotalCount(string email)
        {
            var totalCount = 0;
            totalCount = _cartItemsRepository.GetAll()
                .Where(c => c.UserEmail == email)
                .Select(c => c.Quantity).Sum();

            return totalCount;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Services;
using Shop.DataAccess.Entities;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartItemsService _cartItemsService;
        private IMapper _mapper;

        public CartController(
            ICartItemsService cartItemsService,
            IMapper mapper)
        {
            _cartItemsService = cartItemsService;
            _mapper = mapper;
        }

        [HttpPost("{productId}")]
        public IActionResult AddToCart(Guid productId)
        {
            var email = ParseToken();
            _cartItemsService.AddToCart(productId, email);

            return Ok();
        }

        [HttpDelete("{productId}")]
        public IActionResult RemoveFromCart(Guid productId)
        {
            var email = ParseToken();
            _cartItemsService.RemoveFromCard(productId, email);

            return Ok();
        }

        [HttpGet]
        public IEnumerable<CartItemDto> GetCartItems()
        {
            var email = ParseToken();
            var items = _cartItemsService.GetCartItems(email);

            return _mapper.Map<List<CartItemDto>>(items);
        }

        private string ParseToken()
        {
            var email = "user1@gmail.com";
            return email;
        }
    }
}

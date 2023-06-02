using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Services;

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
            var updatedCartItem = _cartItemsService.AddToCart(productId, email);
            var cartItemDto = _mapper.Map<CartItemDto>(updatedCartItem);

            return Ok(cartItemDto);
        }

        [HttpDelete("{productId}")]
        public IActionResult RemoveFromCart(Guid productId)
        {
            var email = ParseToken();
            _cartItemsService.RemoveFromCard(productId, email);

            return Ok();
        }

        [HttpPut("{productId}/reduce")]
        public IActionResult ReduceProductCount(Guid productId)
        {
            var email = ParseToken();
            _cartItemsService.ReduceProductCount(productId, email);

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

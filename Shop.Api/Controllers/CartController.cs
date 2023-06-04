using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Services;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartItemsService _cartItemsService;
        private IIdentityApiService _identityApiService;
        private IMapper _mapper;

        public CartController(
            ICartItemsService cartItemsService,
            IIdentityApiService identityApiService,
            IMapper mapper)
        {
            _cartItemsService = cartItemsService;
            _mapper = mapper;
            _identityApiService = identityApiService;
        }

        [HttpPost("{productId}")]
        public async Task<IActionResult> AddToCartAsync(Guid productId)
        {
            var email = await ParseTokenAsync();
            var updatedCartItem = _cartItemsService.AddToCart(productId, email);
            var cartItemDto = _mapper.Map<CartItemDto>(updatedCartItem);

            return Ok(cartItemDto);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromCartAsync(Guid productId)
        {
            var email = await ParseTokenAsync();
            _cartItemsService.RemoveFromCard(productId, email);

            return Ok();
        }

        [HttpPut("{productId}/reduce")]
        public async Task<IActionResult> ReduceProductCountAsync(Guid productId)
        {
            var email = await ParseTokenAsync();
            _cartItemsService.ReduceProductCount(productId, email);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<CartItemDto>> GetCartItemsAsync()
        {
            var email = await ParseTokenAsync();
            var items = _cartItemsService.GetCartItems(email);

            return _mapper.Map<List<CartItemDto>>(items);
        }

        private async Task<string> ParseTokenAsync()
        {
            Request.Cookies.TryGetValue("Access-Token", out var token);
            //var email = "user1@gmail.com";
            var userData = await _identityApiService.GetUserData(token);
            var email = userData.Email;
            
            return email;
        }
    }
}

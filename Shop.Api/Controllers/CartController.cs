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
        private const string Authorization = "Authorization";

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
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);

            var updatedCartItem = _cartItemsService.AddToCart(productId, userData.Email);
            var cartItemDto = _mapper.Map<CartItemDto>(updatedCartItem);

            return Ok(cartItemDto);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> RemoveFromCartAsync(Guid productId)
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);

            _cartItemsService.RemoveFromCard(productId, userData.Email);

            return Ok();
        }

        [HttpPut("{productId}/reduce")]
        public async Task<IActionResult> ReduceProductCountAsync(Guid productId)
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);

            _cartItemsService.ReduceProductCount(productId, userData.Email);

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<CartItemDto>> GetCartItemsAsync()
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);

            var items = _cartItemsService.GetCartItems(userData.Email);

            return _mapper.Map<List<CartItemDto>>(items);
        }

        [HttpGet("user-data")]
        public async Task<UserDataDto> GetAllUserData()
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);

            var result = new UserDataDto
            {
                Email = userData.Email,
                Role = userData.Role,
                TotalProductsCount = _cartItemsService.GetTotalCount(userData.Email),
                TotalProductsPrice = _cartItemsService.GetTotalPrice(userData.Role),
            };

            return result;
        }
    }
}

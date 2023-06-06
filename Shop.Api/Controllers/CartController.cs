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
        private readonly ICartItemsService _cartItemsService;
        private readonly IIdentityApiService _identityApiService;
        private readonly IMapper _mapper;
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
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartItemDto))]
        public async Task<IActionResult> AddToCartAsync(Guid productId)
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);
            if (userData == null)
            {
                return Unauthorized();
            }

            var updatedCartItem = _cartItemsService.AddToCart(productId, userData.Email);
            var cartItemDto = _mapper.Map<CartItemDto>(updatedCartItem);

            return Ok(cartItemDto);
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveFromCartAsync(Guid productId)
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);
            if (userData == null)
            {
                return Unauthorized();
            }

            _cartItemsService.RemoveFromCard(productId, userData.Email);

            return Ok();
        }

        [HttpPut("{productId}/reduce")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReduceProductCountAsync(Guid productId)
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);
            if (userData == null)
            {
                return Unauthorized();
            }

            _cartItemsService.ReduceProductCount(productId, userData.Email);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CartItemDto>))]
        public async Task<IActionResult> GetCartItemsAsync()
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);
            if (userData == null)
            {
                return Unauthorized();
            }

            var items = _cartItemsService.GetCartItems(userData.Email);

            return Ok(_mapper.Map<List<CartItemDto>>(items));
        }

        [HttpGet("user-data")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDataDto))]
        public async Task<IActionResult> GetAllUserData()
        {
            Request.Headers.TryGetValue(Authorization, out var token);
            var userData = await _identityApiService.GetUserData(token);
            if (userData == null)
            {
                return Unauthorized();
            }

            var result = new UserDataDto
            {
                Email = userData.Email,
                Role = userData.Role,
                TotalProductsCount = _cartItemsService.GetTotalCount(userData.Email),
                TotalProductsPrice = _cartItemsService.GetTotalPrice(userData.Role),
            };

            return Ok(result);
        }
    }
}

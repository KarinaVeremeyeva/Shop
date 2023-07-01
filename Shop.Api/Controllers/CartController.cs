using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.DTOs;
using Shop.BLL.Services;
using System.Security.Claims;

namespace Shop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartItemsService _cartItemsService;
        private readonly IMapper _mapper;

        public CartController(
            ICartItemsService cartItemsService,
            IMapper mapper)
        {
            _cartItemsService = cartItemsService;
            _mapper = mapper;
        }

        [HttpPost("{productId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UsersOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CartItemDto))]
        public async Task<IActionResult> AddToCartAsync(Guid productId)
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            var updatedCartItem = await _cartItemsService.AddToCartAsync(productId, email);
            var cartItemDto = _mapper.Map<CartItemDto>(updatedCartItem);

            return Ok(cartItemDto);
        }

        [HttpDelete("{productId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UsersOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveFromCartAsync(Guid productId)
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            await _cartItemsService.RemoveFromCardAsync(productId, email);

            return Ok();
        }

        [HttpPut("{productId}/reduce")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UsersOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReduceProductCountAsync(Guid productId)
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            await _cartItemsService.ReduceProductCountAsync(productId, email);

            return Ok();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UsersOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CartItemDto>))]
        public async Task<IActionResult> GetCartItemsAsync()
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            var items = await _cartItemsService.GetCartItemsAsync(email);
            var result = _mapper.Map<List<CartItemDto>>(items);
            
            return Ok(result);
        }

        [HttpGet("user-data")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDataDto))]
        public async Task<IActionResult> GetAllUserDataAsync()
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;
            var role = User.Claims.First(type => type.Type == ClaimTypes.Role).Value;

            var result = new UserDataDto
            {
                Email = email,
                Role = role,
                TotalProductsCount = await _cartItemsService.GetTotalCountAsync(email),
                TotalProductsPrice = await _cartItemsService.GetTotalPriceAsync(email),
            };

            return Ok(result);
        }
    }
}

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
        public IActionResult AddToCart(Guid productId)
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            var updatedCartItem = _cartItemsService.AddToCart(productId, email);
            var cartItemDto = _mapper.Map<CartItemDto>(updatedCartItem);

            return Ok(cartItemDto);
        }

        [HttpDelete("{productId}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UsersOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult RemoveFromCart(Guid productId)
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            _cartItemsService.RemoveFromCard(productId, email);

            return Ok();
        }

        [HttpPut("{productId}/reduce")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UsersOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult ReduceProductCount(Guid productId)
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            _cartItemsService.ReduceProductCount(productId, email);

            return Ok();
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "UsersOnly")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CartItemDto>))]
        public IActionResult GetCartItems()
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;

            var items = _cartItemsService.GetCartItems(email);

            return Ok(_mapper.Map<List<CartItemDto>>(items));
        }

        [HttpGet("user-data")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDataDto))]
        public IActionResult GetAllUserData()
        {
            var email = User.Claims.First(type => type.Type == ClaimTypes.Email).Value;
            var role = User.Claims.First(type => type.Type == ClaimTypes.Role).Value;

            var result = new UserDataDto
            {
                Email = email,
                Role = role,
                TotalProductsCount = _cartItemsService.GetTotalCount(email),
                TotalProductsPrice = _cartItemsService.GetTotalPrice(email),
            };

            return Ok(result);
        }
    }
}

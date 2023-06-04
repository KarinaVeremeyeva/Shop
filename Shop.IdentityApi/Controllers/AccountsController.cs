using Microsoft.AspNetCore.Mvc;
using Shop.IdentityApi.Models;
using Shop.IdentityApi.Services;
using System.Net.Http.Headers;

namespace Shop.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccoutService _accoutService;
        private readonly IJwtTokenService _tokenService;

        public AccountsController(IAccoutService userService, IJwtTokenService jwtTokenService)
        {
            _accoutService = userService;
            _tokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginModel loginModel)
        {
            var result = await _accoutService.LoginAsync(loginModel);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            var token = _tokenService.CreateToken(loginModel.Username);
            Response.Headers.Add("Authorization", token);

            Response.Cookies.Append("Access-Token", token, new CookieOptions { HttpOnly = true, SameSite = SameSiteMode.Lax });

            return Ok();
        }

        [HttpGet("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _accoutService.LogoutAsync();

            return Ok();
        }

        [HttpGet("validate")]
        public async Task<UserDataModel> GetUserData()
        {
            Request.Cookies.TryGetValue("Access-Token", out var token);

            var isTokenValid = _tokenService.ValidateToken(token);
            if (!isTokenValid)
            {
                return null;
            }

            var user = await _accoutService.GetUserData(token);
            
            return user;
        }
    }
}

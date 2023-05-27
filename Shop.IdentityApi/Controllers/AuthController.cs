using Microsoft.AspNetCore.Mvc;
using Shop.IdentityApi.Services;

namespace Shop.IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IJwtTokenService _tokenService;
        
        public AuthController(IJwtTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("token")]
        public string GetToken(string email)
        {
            var token = _tokenService.CreateToken(email);

            return token;
        }
    }
}

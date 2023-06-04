using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.IdentityApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.IdentityApi.Services
{
    public class JwtTokenService : IJwtTokenService
    {
        private readonly JwtTokenSettings _settings;

        public JwtTokenService(IOptions<JwtTokenSettings> options)
        {
            _settings = options.Value;
        }

        public string CreateToken(string email)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email)
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var token = new JwtSecurityToken(
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(1)),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var validationParameters = new TokenValidationParameters()
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidIssuer = _settings.ValidIssuer,
                ValidAudience = _settings.ValidAudience,
                IssuerSigningKey = authSigningKey,
                ValidateLifetime = true
            };

            try
            {
                tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);

                return validatedToken.ValidTo >= DateTime.UtcNow;
            }
            catch
            {
                return false;
            }
        }
    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Shop.BLL.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Shop.Api
{
    public class TokenHandler : AuthenticationHandler<TokenHandler.TokenHandlerOptions>
    {
        private readonly IIdentityApiService _identityApiService;
        private const string Authorization = "Authorization";

        public TokenHandler(
            IOptionsMonitor<TokenHandlerOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IIdentityApiService identityApiService)
            : base(options, logger, encoder, clock)
        {
            _identityApiService = identityApiService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var result = Request.Headers.TryGetValue(Authorization, out var token);

            if (!result)
            {
                return AuthenticateResult.Fail("Token is null");
            }

            var userData = await _identityApiService.GetUserDataAsync(token);
            if (userData == null)
            {
                return AuthenticateResult.Fail("Unauthorized");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, userData.Email),
                new Claim(ClaimTypes.Role, userData.Role)
            };
            var identity = new ClaimsIdentity(claims, nameof(TokenHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), this.Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }

        public class TokenHandlerOptions : AuthenticationSchemeOptions
        {

        }
    }
}

using Microsoft.AspNetCore.Identity;
using Shop.IdentityApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Shop.IdentityApi.Services
{
    public class AccountService : IAccoutService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(LoginModel loginModel)
        {
            var result = await _signInManager.PasswordSignInAsync(
                loginModel.Username, loginModel.Password, isPersistent: true, lockoutOnFailure: false);

            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDataModel> GetUserDataAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var email = jwtSecurityToken.Claims.First(c => c.Type == ClaimTypes.Email).Value;
            
            var user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.SingleOrDefault();

            var userModel = new UserDataModel { Email = email, Role = role };

            return userModel;
        }
    }
}

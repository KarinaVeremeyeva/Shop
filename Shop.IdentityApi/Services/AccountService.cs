using Microsoft.AspNetCore.Identity;
using Shop.IdentityApi.Models;

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
    }
}

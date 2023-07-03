using Microsoft.AspNetCore.Identity;
using Shop.IdentityApi.Models;

namespace Shop.IdentityApi.Services
{
    public interface IAccoutService
    {
        Task<SignInResult> LoginAsync(LoginModel loginModel);

        Task LogoutAsync();

        Task<UserDataModel> GetUserDataAsync(string token);
    }
}

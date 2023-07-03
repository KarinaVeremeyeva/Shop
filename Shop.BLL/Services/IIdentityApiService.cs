using Shop.IdentityApi.Models;

namespace Shop.BLL.Services
{
    public interface IIdentityApiService
    {
        Task<UserDataModel?> GetUserDataAsync(string token);
    }
}

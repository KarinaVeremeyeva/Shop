using Shop.IdentityApi.Models;

namespace Shop.BLL.Services
{
    public interface IIdentityApiService
    {
        Task<UserDataModel?> GetUserData(string token);
    }
}

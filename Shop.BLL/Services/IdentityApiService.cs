using Shop.IdentityApi.Models;
using System.Net.Http.Json;

namespace Shop.BLL.Services
{
    public class IdentityApiService : IIdentityApiService
    {
        private readonly HttpClient _httpClient;
        private const string UserPath = "api/Accounts";

        public IdentityApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDataModel> GetUserData(string token)
        {
            UserDataModel user = null;
            var response = await _httpClient.GetAsync($"{UserPath}/validate");
            
            if (response.IsSuccessStatusCode && response.Content != null)
            {
                user = await response.Content.ReadFromJsonAsync<UserDataModel>();
            }

            return user;
        }
    }
}

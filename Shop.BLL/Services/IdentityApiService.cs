using Shop.IdentityApi.Models;
using System.Net.Http.Json;

namespace Shop.BLL.Services
{
    public class IdentityApiService : IIdentityApiService
    {
        private readonly HttpClient _httpClient;
        private const string UserPath = "api/Accounts";
        private const string Authorization = "Authorization";

        public IdentityApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserDataModel> GetUserData(string token)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, $"{UserPath}/validate"))
            {
                request.Headers.Add(Authorization, token);
                
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var user = await response.Content.ReadFromJsonAsync<UserDataModel>();

                return user;
            }
        }
    }
}

namespace Shop.IdentityApi.Services
{
    public interface IJwtTokenService
    {
        string CreateToken(string email);

        bool ValidateToken(string token);
    }
}

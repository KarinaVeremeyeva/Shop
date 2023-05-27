namespace Shop.IdentityApi.Services
{
    public interface IJwtTokenService
    {
        public string CreateToken(string email);
    }
}

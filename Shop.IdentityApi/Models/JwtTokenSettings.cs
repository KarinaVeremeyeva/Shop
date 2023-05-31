namespace Shop.IdentityApi.Models
{
    public class JwtTokenSettings
    {
        public string ValidAudience { get; set; }

        public string ValidIssuer { get; set; }

        public string SecretKey { get; set; }
    }
}

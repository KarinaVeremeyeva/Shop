namespace Shop.Api.DTOs
{
    public class UserDataDto
    {
        public string Email { get; set; }

        public string Role { get; set; }

        public int TotalProductsCount { get; set; }

        public decimal TotalProductsPrice { get; set; }
    }
}

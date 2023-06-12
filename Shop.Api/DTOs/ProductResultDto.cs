namespace Shop.Api.DTOs
{
    public class ProductResultDto
    {
        public List<ProductDto> Products { get; set; }

        public int TotalCount { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}

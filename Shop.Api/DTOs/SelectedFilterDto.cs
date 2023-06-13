namespace Shop.Api.DTOs
{
    public class SelectedFilterDto
    {
        public Guid DetailId { get; set; }

        public List<string> Values { get; set; }
    }
}

using Shop.DataAccess.Entities;

namespace Shop.Api.DTOs
{
    public class FilterDto
    {
        public Guid DetailId { get; set; }

        public string Name { get; set; }

        public DetailType Type { get; set; }

        public List<string> Values { get; set; }
    }
}
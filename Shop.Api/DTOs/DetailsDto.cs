using Shop.DataAccess.Entities;

namespace Shop.Api.DTOs
{
    public class DetailsDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DetailType Type { get; set; }
    }
}
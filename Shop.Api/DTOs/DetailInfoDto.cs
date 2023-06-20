using Shop.DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace Shop.Api.DTOs
{
    public class DetailInfoDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name should not be empty.")]
        public string Name { get; set; }

        [RequiredEnumField(ErrorMessage = "Detail type is required.")]
        public DetailType Type { get; set; }
    }
}

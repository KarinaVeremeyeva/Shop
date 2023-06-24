using Shop.Api.DTOs;

namespace Shop.Api.Validators
{
    public class DetailValidator : IValidator<DetailInfoDto>
    {
        public string Validate(DetailInfoDto entity)
        {
            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(entity.Name))
            {
                validationErrors.Add("Name should not be empty");
            }

            var type = entity.Type.GetType();
            if (!type.IsEnum || !Enum.IsDefined(type, entity.Type))
            {
                validationErrors.Add("Detail type is required");
            }

            return string.Join(", ", validationErrors);
        }
    }
}

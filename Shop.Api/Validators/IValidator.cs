namespace Shop.Api.Validators
{
    public interface IValidator<TEntityModel>
    {
        Task<string> ValidateAsync(TEntityModel entity);
    }
}

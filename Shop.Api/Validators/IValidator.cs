namespace Shop.Api.Validators
{
    public interface IValidator<TEntityModel>
    {
        string Validate(TEntityModel entity);
    }
}

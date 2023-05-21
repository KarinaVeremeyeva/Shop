namespace Shop.BLL.Services
{
    public interface ICategoriesService
    {
        IEnumerable<Guid> GetCategoryAndChildrenIds(Guid categoryId);
    }
}

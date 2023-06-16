using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IDetailsService
    {
        IEnumerable<FilterModel> GetFiltersByCategoryId(Guid categoryId);

        DetailModel AddDetail(DetailModel detail);

        void RemoveDetail(Guid id);

        DetailModel UpdateDetail(DetailModel detail);

        List<DetailModel> GetDetails();
    }
}

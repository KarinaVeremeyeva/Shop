using Shop.BLL.Models;

namespace Shop.BLL.Services
{
    public interface IDetailsService
    {
        DetailModel AddDetail(DetailModel detail);

        void RemoveDetail(Guid id);

        DetailModel UpdateDetail(DetailModel detail);

        List<DetailModel> GetDetails();

        bool ValidateProductDetails(List<ProductDetailModel> productDetails);
    }
}

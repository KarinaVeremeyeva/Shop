using Shop.DataAccess.Entities;

namespace Shop.BLL.Models
{
    public class FilterModel
    {
        public Guid DetailId { get; set; }

        public string Name { get; set; }

        public DetailType Type { get; set; }

        public List<string> Values { get; set; }
    }
}

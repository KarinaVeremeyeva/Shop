using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess.Repositories
{
    public class DetailRepository : Repository<Detail>, IDetailRepository
    {
        public DetailRepository(ShopContext dbContext)
            : base(dbContext)
        {
        }

        public override IEnumerable<Detail> GetAll()
        {
            var details = _context.Details
                .Include(d => d.ProductDetails)
                .ToList();

            return details;
        }

        public override Detail GetById(Guid id)
        {
            var detail = _context.Details
                .Include(d => d.ProductDetails)
                .SingleOrDefault(d => d.Id == id);

            return detail;
        }
    }
}

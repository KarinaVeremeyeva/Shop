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

        public override async Task<IEnumerable<Detail>> GetAllAsync()
        {
            var details = await _context.Details.ToListAsync();

            return details;
        }

        public override async Task<Detail?> GetByIdAsync(Guid id)
        {
            var detail = await _context.Details.SingleOrDefaultAsync(d => d.Id == id);

            return detail;
        }
    }
}

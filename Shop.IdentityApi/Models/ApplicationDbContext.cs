using Microsoft.EntityFrameworkCore;

namespace Shop.IdentityApi.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}

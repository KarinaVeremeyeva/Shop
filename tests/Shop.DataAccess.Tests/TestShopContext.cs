using Microsoft.EntityFrameworkCore;

namespace Shop.DataAccess.Tests
{
    public class TestShopContext : ShopContext
    {
        public TestShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}

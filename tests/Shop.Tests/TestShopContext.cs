using Microsoft.EntityFrameworkCore;
using Shop.DataAccess;

namespace Shop.Tests
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

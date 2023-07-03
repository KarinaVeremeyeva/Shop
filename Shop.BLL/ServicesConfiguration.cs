using Microsoft.Extensions.DependencyInjection;
using Shop.DataAccess.Repositories;

namespace Shop.BLL
{
    public static class ServicesConfiguration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICartItemsRepository, CartItemRepository>();
            services.AddScoped<IDetailRepository, DetailRepository>();
        }
    }
}

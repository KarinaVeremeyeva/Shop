using Shop.DataAccess;
using Shop.BLL.Services;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Repositories;
using Shop.BLL;
using Shop.Api;

internal class Program
{
    private const string Name = "AllowAnyOrigin";

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<ShopContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<ICategoriesService, CategoriesService>();
        builder.Services.AddScoped<IProductsService, ProductsService>();

        builder.Services.AddAutoMapper(typeof(BusinessLogicProfile), typeof(MappingProfile));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(Name,
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(Name);

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
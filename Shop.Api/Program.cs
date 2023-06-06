using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shop.Api;
using Shop.BLL;
using Shop.BLL.Services;
using Shop.DataAccess;
using Shop.DataAccess.Repositories;
using System.Net.Http.Headers;

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
        builder.Services.AddScoped<ICartItemsRepository, CartItemRepository>();
        builder.Services.AddScoped<ICategoriesService, CategoriesService>();
        builder.Services.AddScoped<IProductsService, ProductsService>();
        builder.Services.AddScoped<ICartItemsService, CartItemsService>();
        builder.Services.AddHttpClient<IIdentityApiService, IdentityApiService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7017/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        });

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
        builder.Services.AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

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
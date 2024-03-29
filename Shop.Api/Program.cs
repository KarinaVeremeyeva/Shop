using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shop.Api;
using Shop.Api.DTOs;
using Shop.Api.Validators;
using Shop.BLL;
using Shop.BLL.Models;
using Shop.BLL.Services;
using Shop.DataAccess;
using System.Net.Http.Headers;

internal class Program
{
    private const string CorsPolicyName = "AllowAnyOrigin";
    private const string UsersPolicyName = "UsersOnly";
    private const string AdminsPolicyName = "AdminsOnly";

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        var identityString = builder.Configuration.GetValue<string>("IdentityBaseAddress");

        builder.Services.AddDbContext<ShopContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        builder.Services.AddRepositories();
        builder.Services.AddScoped<ICategoriesService, CategoriesService>();
        builder.Services.AddScoped<IProductsService, ProductsService>();
        builder.Services.AddScoped<ICartItemsService, CartItemsService>();
        builder.Services.AddScoped<IDetailsService, DetailsService>();
        builder.Services.AddHttpClient<IIdentityApiService, IdentityApiService>(client =>
        {
            client.BaseAddress = new Uri(identityString);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        });
        builder.Services.AddScoped<IValidator<ProductModel>, ProductValidator>();
        builder.Services.AddScoped<IValidator<DetailInfoDto>, DetailValidator>();
        builder.Services.AddScoped<IValidator<CategoryInfoDto>, CategoryValidator>();

        builder.Services.AddAutoMapper(typeof(BusinessLogicProfile), typeof(MappingProfile));

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName,
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        builder.Services.AddControllers();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddScheme<TokenHandler.TokenHandlerOptions, TokenHandler>(JwtBearerDefaults.AuthenticationScheme, _=> { });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(UsersPolicyName, policy =>
            {
                policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                policy.RequireRole("User");
            });
            options.AddPolicy(AdminsPolicyName, policy =>
            {
                policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                policy.RequireRole("Admin");
            });
        });

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

        app.UseCors(CorsPolicyName);

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
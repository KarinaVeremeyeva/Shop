using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shop.IdentityApi.Models;
using Shop.IdentityApi.Services;
using System.Text;

const string Name = "AllowAnyOrigin";

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
var tokenSettings = builder.Configuration.GetSection("JwtTokenSettings");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = tokenSettings.GetValue<string>("ValidIssuer"),
            ValidateAudience = true,
            ValidAudience = tokenSettings.GetValue<string>("ValidAudience"),
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.GetValue<string>("SecretKey"))),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true
        };
    });

builder.Services.Configure<JwtTokenSettings>(tokenSettings);
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IAccoutService, AccountService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(Name,
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Authorization"));
});
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(Name);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

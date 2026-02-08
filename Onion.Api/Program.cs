using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Onion.Application.Services.CacheService;
using Onion.Application.Services.CategoryServise;
using Onion.Application.Services.PaginationService;
using Onion.Application.Services.ProductServices;
using Onion.Application.Services.Tokenservice;
using Onion.Application.Services.UserServices;
using Onion.Domain.Models;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Data;
using Onion.Infrastructure.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// DbContext & Identity
builder.Services.AddDbContext<ProductDbContext>(x =>
    x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, Role>(x => x.SignIn.RequireConfirmedAccount = false)
    .AddRoles<Role>()
    .AddEntityFrameworkStores<ProductDbContext>();

// JWT Bearer
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JwtSettings:SecretKey yapılandırılmamış.");
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ClockSkew = TimeSpan.Zero
    };
});

// Redis distributed cache
var redisConnection = builder.Configuration.GetConnectionString("Redis");
if (!string.IsNullOrEmpty(redisConnection))
{
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = redisConnection;
    });
}
else
{
    builder.Services.AddDistributedMemoryCache(); // Redis yoksa memory cache (geliştirme için)
}

// Application services
builder.Services.AddTransient<ICacheService, CacheService>();
builder.Services.AddTransient<IPaginationService, PaginationService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

// Repositories (ProductService için)
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();

// Swagger + JWT Bearer tanımı
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ürün Katalog API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT token almak için /api/auth/login ile giriş yapın, dönen token'ı buraya 'Bearer {token}' şeklinde girin."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ürün Katalog API v1"));
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

// Kök adrese gidildiğinde Swagger'a yönlendir (Development'ta)
if (app.Environment.IsDevelopment())
    app.MapGet("/", () => Results.Redirect("/swagger")).ExcludeFromDescription();

app.Run();

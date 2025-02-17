using Microsoft.EntityFrameworkCore;
using Onion.Domain.Models;
using Onion.Infrastructure.Data;
using Onion.Application.Services.UserServices;
using Onion.Application.Services.CartItemService;
using Onion.Application.Services.CartServices;
using Onion.Application.Services.CategoryServise;
using Onion.Application.Services.OrderItemService;
using Onion.Application.Services.OrderService;
using Onion.Application.Services.ProductServices;
using Onion.Application.Services.ReturnItemService;
using Onion.Application.Services.ReturnServices;
using Onion.Domain.Repositories;
using Onion.Infrastructure.Repositories;
using Onion.Application.Mapper;
using Onion.UIWebApp.UIMapper;
using Onion.Application.Services.ContentCategoryService;
using Onion.Application.Services.NewsService;
using Onion.Application.Services.BlogPostService;
using Onion.Application.Services.FAQService;
using Onion.Application.Services.ComplaintService;
using Onion.Application.Services.BidService;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.WebHost.UseSentry(o =>
{
    o.Dsn = "https://cf11df667b867d25b4f4eaab560c8f7f@o4508788474839040.ingest.us.sentry.io/4508788476674048";
    // When configuring for the first time, to see what the SDK is doing:
    o.Debug = true;
    // Set TracesSampleRate to 1.0 to capture 100%
    // of transactions for tracing.
    // We recommend adjusting this value in production
    o.TracesSampleRate = 1.0;

});

builder.Services.AddDbContext<ProductDbContext>(x => x.UseSqlServer());
builder.Services.AddIdentity<User, Role>(x => x.SignIn.RequireConfirmedAccount = false).AddRoles<Role>().AddEntityFrameworkStores<ProductDbContext>();

//builder.Services.AddAutoMapper(typeof(ProductMapper), typeof(UIMapper));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<ICartItemService, CartItemService>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<ICategoryService,CategoryService>();
builder.Services.AddTransient<IOrderItemService,OrderItemService>();
builder.Services.AddTransient<IOrderService,OrderService>();
builder.Services.AddTransient<IProductService,ProductService>();
builder.Services.AddTransient<IReturnItemService,ReturnItemService>();
builder.Services.AddTransient<IReturnService,ReturnService>();
builder.Services.AddTransient<IContentCategoryService, ContentCategoryService>();
builder.Services.AddTransient<IBlogPostService, BlogPostService>();
builder.Services.AddTransient<INewsService, NewsService>();
builder.Services.AddTransient<IFAQService, FAQService>();
builder.Services.AddTransient<IComplaintService, ComplaintService>();
builder.Services.AddTransient<IBidService, BidService>();


builder.Services.AddTransient<ICartItemRepository,CartItemRepository>();
builder.Services.AddTransient<ICartRepository,CartRepository>();
builder.Services.AddTransient<ICategoryRepository,CategoryRepository>();
builder.Services.AddTransient<IOrderItemRepository,OrderItemRepository>();
builder.Services.AddTransient<IOrderRepository,OrderRepository>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<IReturnItemRepository,ReturnItemRepository>();
builder.Services.AddTransient<IReturnRepository, ReturnRepository>();
builder.Services.AddTransient<IContentCategoryRepository, ContentCategoryRepository>();
builder.Services.AddTransient<IBlogPostRepository, BlogPostRepository>();
builder.Services.AddTransient<INewsRepository, NewsRepository>();
builder.Services.AddTransient<IFAQRepository, FAQRepository>();
builder.Services.AddTransient<IComplaintRepository, ComplaintRepository>();
builder.Services.AddTransient<IBidRepository, BidRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

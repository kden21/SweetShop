using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SweetShop.DAL;
using SweetShop.DAL.Interfaces;
using SweetShop.DAL.Repositories;
using SweetShop.Domain.Entities;
using SweetShop.Service.Implementations;
using SweetShop.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SweetShopContext>(option => option.UseNpgsql(connection, b => b.MigrationsAssembly("SweetShop")));//AddDbContext<SweetShopContext>(option => option.UseNpgsql(connection, b => b.MigrationsAssembly("SweetShop")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<SweetShopContext>();
builder.Services.AddControllersWithViews();




builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<CartProductsRepository>();
builder.Services.AddScoped<CartProductsService>();

builder.Services.AddScoped<CartProductsItemRepository>();
builder.Services.AddScoped<CartProductsItemService>();

builder.Services.AddScoped<IdentityOptions>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(options =>
    {
        options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
    });

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//גûגמה מבתוךעמג
//app.MapGet("/", (SweetShopContext db) => db.Products.ToList());

app.Run();

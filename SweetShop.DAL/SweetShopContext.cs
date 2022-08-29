using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SweetShop.Domain;
using SweetShop.Domain.Entities;

namespace SweetShop.DAL
{
    public class SweetShopContext : DbContext
    {
        public DbSet<Product>? Products { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<CartProductItem> CartProductItems { get; set; } = null!;
        public DbSet<CartProducts> CartsProducts { get; set; } = null!;
        //public DbSet<IdentityUser> IdentityUsers { get; set; } = null!;
        public SweetShopContext(DbContextOptions<SweetShopContext> options): base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

        }
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, Name = "Молоко", Price = 22.5M, Weight = 0.2},
                    new Product { Id = 2, Name = "Хлеб", Price = 33.5M, Weight = 20 }
            );
        }*/
        
        
    }
}
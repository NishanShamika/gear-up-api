using Microsoft.EntityFrameworkCore;
using gear_up_api.Models;

namespace gear_up_api.Context
{
    public class GearUpDbContext : DbContext
    {
        public GearUpDbContext(DbContextOptions<GearUpDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.Carts)
        //        .WithOne(c => c.User)
        //        .HasForeignKey(c => c.UserId);

        //    modelBuilder.Entity<Cart>()
        //        .HasOne(c => c.Order)
        //        .WithOne(o => o.Cart)
        //        .HasForeignKey<Cart>(c => c.OrderId);

        //    modelBuilder.Entity<CartItem>()
        //        .HasOne(ci => ci.Cart)
        //        .WithMany(c => c.CartItems)
        //        .HasForeignKey(ci => ci.CartId);

        //    modelBuilder.Entity<CartItem>()
        //        .HasOne(ci => ci.Product)
        //        .WithMany()
        //        .HasForeignKey(ci => ci.ProductId);

        //    //Seed Products
        //    //modelBuilder.Entity<Product>().HasData(
        //    //    new Product { Id = 1, Name = "Product1" },
        //    //    new Product { Id = 2, Name = "Product2" },
        //    //    new Product { Id = 3, Name = "Product3" },
        //    //    new Product { Id = 15, Name = "Product15" }
        //    //);
        //}
    }
}


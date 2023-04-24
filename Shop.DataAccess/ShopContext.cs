using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Entities;

namespace Shop.DataAccess
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Details> Details { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductDetails> ProductDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ShopDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity => 
                {
                    entity.HasKey(x => x.Id);
                    entity.HasOne(x => x.ParentCategory)
                        .WithMany(x => x.ChildCategories)
                        .HasForeignKey(x => x.ParentCategoryId)
                        .IsRequired(false)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Product>()
                .HasMany(x => x.Details)
                .WithMany(x => x.Products)
                .UsingEntity<ProductDetails>(
                    j => j
                        .HasOne(x => x.Detail)
                        .WithMany(x => x.ProductDetails)
                        .HasForeignKey(x => x.DetailsId),
                    j => j
                        .HasOne(x => x.Product)
                        .WithMany(x => x.ProductDetails)
                        .HasForeignKey(x => x.ProductId),
                    j => 
                    {
                        j.HasKey(x => new { x.ProductId, x. DetailsId });
                    });

            base.OnModelCreating(modelBuilder);
        }
    }
}
using System.Net.NetworkInformation;
using System.Reflection;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CalshoesDbContext : DbContext
    {
        public CalshoesDbContext(DbContextOptions<CalshoesDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Product>(entity => {
                entity.HasKey(p => p.Id);
                entity.HasIndex(p => p.Id).IsUnique();
                entity.Property(p => p.Id).IsRequired();
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

                entity.HasMany(p => p.ProductImages)
                    .WithOne(pi => pi.Product)
                    .HasForeignKey(pi => pi.ProductId);
                entity.HasMany(p => p.ProductVariants)
                    .WithOne(pi => pi.Product)
                    .HasForeignKey(pi => pi.ProductId);
            });

            modelBuilder.Entity<ProductBrand>(entity => {
                entity.HasKey(pb => pb.Id);
                entity.HasIndex(pb => pb.Id);
                entity.Property(pb => pb.Id).IsRequired();
                entity.Property(pb => pb.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(pb => pb.Product)
                    .WithOne(p => p.ProductBrand)
                    .HasForeignKey(p => p.ProductBrandId);
            });

            modelBuilder.Entity<ProductCategory>(entity => {
                entity.HasKey(pc => pc.Id);
                entity.Property(pc => pc.Id).IsRequired();
                entity.HasIndex(pc => pc.Id).IsUnique();
                entity.Property(pc => pc.Name).IsRequired().HasMaxLength(100);

                entity.HasMany(pc => pc.Product)
                    .WithOne(p => p.ProductCategory)
                    .HasForeignKey(p => p.ProductCategoryId);
            });

            modelBuilder.Entity<ProductImage>(entity => {
                entity.HasKey(pi => pi.Id);
                entity.Property(pi => pi.Id).IsRequired();
                entity.HasIndex(pi => pi.Id).IsUnique();
                entity.Property(pi => pi.ImageUrl).IsRequired();
            });

            modelBuilder.Entity<ProductVariant>(entity => {
                entity.HasKey(pv => pv.Id);
                entity.Property(pv => pv.Id).IsRequired();
                entity.HasIndex(pv => pv.Id).IsUnique();
                entity.Property(pv => pv.Size).IsRequired().HasColumnType("decimal(2,2)");
                entity.Property(pv => pv.StockQuantity).IsRequired();
            });
            
            // overcomes SQLite's limitations in supporting decimal data types
            if (Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    var properties = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));

                    foreach (var property in properties)
                    {
                        modelBuilder.Entity(entityType.Name).Property(property.Name).HasConversion<double>();
                    }
                }
            }

        }

    }
}
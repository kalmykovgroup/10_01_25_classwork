using BlazorApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка Category
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Настройка Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);


            // Seed Categories
            // Определение фиксированных GUID для консистентности
            var electronicsCategoryId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var groceriesCategoryId = Guid.Parse("22222222-2222-2222-2222-222222222222");

            var supplier_1_Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
            var supplier_2_Id = Guid.Parse("44444444-4444-4444-4444-444444444444");
              

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    Id = supplier_1_Id,
                    Name = "Поставщик электроники"
                },
                new Supplier
                {
                    Id = supplier_2_Id,
                    Name = "Поставщик продуктов"
                }
            ); 


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = electronicsCategoryId,
                    Name = "Электроника"
                },
                new Category
                {
                    Id = groceriesCategoryId,
                    Name = "Продукты"
                }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Смартфон",
                    CategoryId = electronicsCategoryId,
                    SupplierId = supplier_1_Id,
                    Count = 7,
                    CostPrice = 699.99M,
                    Price = 1699.99M
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Ноутбук",
                    CategoryId = electronicsCategoryId,
                    SupplierId = supplier_1_Id,
                    Count = 5,
                    CostPrice = 999.99M,
                    Price = 1999.99M,
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Хлеб",
                    CategoryId = groceriesCategoryId,
                    SupplierId = supplier_2_Id,
                    Count = 50,
                    CostPrice = 2.49M,
                    Price = 3.49M,
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Молоко",
                    CategoryId = groceriesCategoryId,
                    SupplierId = supplier_2_Id,
                    Count = 20,
                    CostPrice = 1.89M,
                    Price = 5.89M,
                }
            );

             
        }
    }
}

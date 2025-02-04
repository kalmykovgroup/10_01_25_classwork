using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models._Category;

namespace Test.Data.Configurations._Category
{


    /// <summary>
    /// Конфигурация сущности Category через Fluent API.
    /// </summary>
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // 1) Имя таблицы
            builder.ToTable("categories");

            // 2) Первичный ключ
            builder.HasKey(c => c.Id);

            // Предполагаем, что Guid генерируется в приложении
            builder.Property(c => c.Id)
                   .ValueGeneratedNever();

            // 3) Настройка полей (столбцов)
            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(100);

            builder.Property(c => c.ParentId)
                   .HasColumnName("parent_id");

            // 4) Самореференция (Self-reference):
            // "одна категория" -> "многие подкатегории (SubCategories)"
            // Если нужно при удалении родителя не удалять подкатегории, используйте Restrict.
            builder.HasOne(c => c.ParentCategory)
                   .WithMany(pc => pc.SubCategories)
                   .HasForeignKey(c => c.ParentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // 5) Связь Category -> Products (One-to-Many)
            // В Product, скорее всего, есть поле CategoryId.
            builder.HasMany(c => c.Products)
                   .WithOne(p => p.Category!)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}

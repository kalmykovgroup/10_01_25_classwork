using Kalmykov_mag.Entities._Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kalmykov_mag.Entities._Storage
{
    /// <summary>
    /// Категория файла для определения типа сущности в TPH.
    /// </summary>
    public enum FileCategory
    {
        GeneralFile,   // Общий тип файлов (например, если нет явного типа)
        ProductFile,   // Файлы, связанные с продуктами
        OrderFile,     // Файлы, связанные с заказами
        ReviewFile     // Файлы, связанные с отзывами
    }

    /// <summary>
    /// Типа сущности TPH.
    /// Это подход, при котором несколько классов иерархии наследования сопоставляются с одной таблицей в базе данных
    /// Базовая сущность для хранения данных о файлах.
    /// Используется для управления файлами, связанными с продуктами, заказами, отзывами и другими сущностями.
    /// </summary>
    [Table("file_storage")]
    public abstract class FileStorage : AuditableEntity
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Дискриминатор для определения категории файла.
        /// Например, общий файл, файл продукта или заказа.
        /// </summary>
        [Column("file_category")]
        public FileCategory FileCategory { get; protected set; }

        /// <summary>
        /// Имя файла (например, "image.png").
        /// Используется для отображения или управления файлом.
        /// </summary>
        [Required]
        [MaxLength(255)]
        [Column("file_name")]
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Путь к файлу на сервере или в облачном хранилище.
        /// Указывает местоположение файла.
        /// </summary>
        [Required]
        [MaxLength(2048)]
        [Column("file_path")]
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// MIME-тип файла (например, "image/png", "application/pdf").
        /// Используется для определения типа содержимого файла.
        /// </summary>
        [Required]
        [MaxLength(100)]
        [Column("file_type")]
        public string FileType { get; set; } = string.Empty;

        /// <summary>
        /// Размер файла в байтах.
        /// Используется для отображения или анализа объёма данных.
        /// </summary>
        [Column("file_size")]
        public long FileSize { get; set; }

        /// <summary>
        /// Признак основного файла для сущности.
        /// Например, основное изображение для продукта.
        /// </summary>
        [Column("is_primary")]
        public bool IsPrimary { get; set; } = false;

        /// <summary>
        /// Дата и время загрузки файла.
        /// Используется для отслеживания времени добавления файла.
        /// </summary>
        [Column("uploaded_at")]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Настройка сущности FileStorage.
        /// Определяет дискриминатор TPH и дополнительные ограничения.
        /// </summary>
        public static void ConfigureEntity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileStorage>(entity =>
            {
                // Настройка TPH для дискриминатора FileCategory
                entity.HasDiscriminator<FileCategory>(t => t.FileCategory)
                    .HasValue<FileStorage>(FileCategory.GeneralFile)
                    .HasValue<ProductFile>(FileCategory.ProductFile)
                    .HasValue<OrderFile>(FileCategory.OrderFile)
                    .HasValue<ReviewFile>(FileCategory.ReviewFile);
            });
        }
    }

}

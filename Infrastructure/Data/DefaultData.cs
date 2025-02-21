using Domain.Entities.AddressesSpace;
using Domain.Entities.AddressesSpace.Heirs;
using Domain.Entities.BrandSpace;
using Domain.Entities.CategorySpace;
using Domain.Entities.IntermediateSpace;
using Domain.Entities.ProductSpace;
using Domain.Entities.SupplierSpace;
using Domain.Entities.TranslationSpace;
using Domain.Entities.TranslationsSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Domain.Entities.UserSpace;
using Domain.Entities.UserSpace.UserTypes;
using Domain.Models.LoyaltyProgramSpace.Discount;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class DefaultData
    {


        public DefaultData(ModelBuilder modelBuilder)
        {
            // 1. Языки
            modelBuilder.Entity<Language>().HasData(
                new Language { Code = "en", Name = "English" },
                new Language { Code = "ru", Name = "Русский" }
            );

            // 2. Генерация базовых пользователей, адресов, поставщиков, категорий, брендов и пр.

            // Генерируем фиксированные идентификаторы для админа, клиентов, сотрудников и поставщиков
            Guid adminId = Guid.NewGuid();
            Guid customer1Id = Guid.NewGuid();
            Guid customer2Id = Guid.NewGuid();
            Guid employee1Id = Guid.NewGuid();

            Guid supplier1Id = Guid.NewGuid();
            Guid supplier2Id = Guid.NewGuid();
            Guid supplier3Id = Guid.NewGuid();

            // Адреса пользователей
            modelBuilder.Entity<UserAddress>().HasData(
                new UserAddress { Id = Guid.NewGuid(), UserId = customer1Id, Street = "ул. Ленина, д. 10", City = "Москва", PostalCode = "101000", Country = "Россия", IsPrimary = true, CreatedByUserId = adminId },
                new UserAddress { Id = Guid.NewGuid(), UserId = customer2Id, Street = "ул. Советская, д. 15", City = "Санкт-Петербург", PostalCode = "190000", Country = "Россия", IsPrimary = true, CreatedByUserId = adminId },
                new UserAddress { Id = Guid.NewGuid(), UserId = customer2Id, Street = "ул. Центральная, д. 20", City = "Новосибирск", PostalCode = "630000", Country = "Россия", IsPrimary = false, CreatedByUserId = adminId },
                new UserAddress { Id = Guid.NewGuid(), UserId = customer2Id, Street = "ул. Пушкина, д. 25", City = "Екатеринбург", PostalCode = "620000", Country = "Россия", IsPrimary = false, CreatedByUserId = adminId }
            );

            // Адреса поставщиков
            modelBuilder.Entity<SupplierAddress>().HasData(
                new SupplierAddress { Id = Guid.NewGuid(), SupplierId = supplier2Id, Street = "МКАД, 19-й километр, вл20с1", City = "Москва", PostalCode = "101000", Country = "Россия", IsPrimary = true, CreatedByUserId = adminId },
                new SupplierAddress { Id = Guid.NewGuid(), SupplierId = supplier3Id, Street = "ул. Калинина, д. 5", City = "Санкт-Петербург", PostalCode = "190000", Country = "Россия", IsPrimary = true, CreatedByUserId = adminId },
                new SupplierAddress { Id = Guid.NewGuid(), SupplierId = supplier3Id, Street = "ул. Жукова, д. 8", City = "Новосибирск", PostalCode = "630000", Country = "Россия", IsPrimary = false, CreatedByUserId = adminId },
                new SupplierAddress { Id = Guid.NewGuid(), SupplierId = supplier3Id, Street = "ул. Тверская, д. 40", City = "Екатеринбург", PostalCode = "620000", Country = "Россия", IsPrimary = false, CreatedByUserId = adminId }
            );

            // Поставщики
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = supplier1Id, Name = "Default Supplier", CreatedByUserId = adminId },
                new Supplier { Id = supplier2Id, Name = "Южные ворота", CreatedByUserId = adminId },
                new Supplier { Id = supplier3Id, Name = "РМС", CreatedByUserId = adminId }
            );

            // WishList (обычно для пользователя, но для примера создадим несколько)
            Guid wishList1Id = Guid.NewGuid();
            Guid wishList2Id = Guid.NewGuid();
            Guid wishList3Id = Guid.NewGuid();
            Guid wishList4Id = Guid.NewGuid();

            WishList[] wishLists =
            {
            new WishList { Id = wishList1Id },
            new WishList { Id = wishList2Id },
            new WishList { Id = wishList3Id },
            new WishList { Id = wishList4Id },
        };
            modelBuilder.Entity<WishList>().HasData(wishLists);

            // Пользователи
            User[] users = new[]
            {
                new User
                {
                    Id = adminId,
                    UserType = UserType.Admin,
                    PhoneNumber = "+79260128187",
                    FirstName = "Иван",
                    LastName = "Калмыков",
                    Patronymic = "Алексеевич",
                    DateOfBirth = new DateTime(1996, 10, 17),
                    Email = "admin@kalmykov-group.ru",
                    PasswordHash = "hashed_password_1",
                    IsActive = true,
                    AddressType = AddressType.User,
                    CreatedByUserId = adminId,
                    WishListId = wishList1Id
                },
                new User
                {
                    Id = employee1Id,
                    UserType = UserType.Employee,
                    PhoneNumber = "+1122334455",
                    FirstName = "Дмитрий",
                    LastName = "Сидоров",
                    Patronymic = "Алексеевич",
                    DateOfBirth = new DateTime(1988, 7, 30),
                    Email = "dmitry.sidorov@example.com",
                    PasswordHash = "hashed_password_3",
                    IsActive = true,
                    AddressType = AddressType.Supplier,
                    CreatedByUserId = adminId,
                    WishListId = wishList2Id
                },
                new User
                {
                    Id = customer1Id,
                    UserType = UserType.Customer,
                    PhoneNumber = "+1987654321",
                    FirstName = "Анна",
                    LastName = "Смирнова",
                    Patronymic = "Игоревна",
                    DateOfBirth = new DateTime(1995, 10, 22),
                    Email = "anna.smirnova@example.com",
                    PasswordHash = "hashed_password_2",
                    IsActive = true,
                    AddressType = AddressType.User,
                    CreatedByUserId = adminId,
                    WishListId = wishList3Id
                },
                new User
                {
                    Id = customer2Id,  
                    UserType = UserType.Customer,
                    PhoneNumber = "+79260128187",
                    FirstName = "Иван",
                    LastName = "Калмыков",
                    Patronymic = "Алексеевич",
                    DateOfBirth = new DateTime(1996, 10, 17),
                    Email = "customer2@kalmykov-group.ru",
                    PasswordHash = "hashed_password_1123",
                    IsActive = true,
                    AddressType = AddressType.User,
                    CreatedByUserId = adminId,
                    WishListId = wishList4Id
                },
            };
            modelBuilder.Entity<User>().HasData(users);

            var rootCategoryId = Guid.NewGuid();

            // Основная категория "Телефоны"
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = rootCategoryId, ParentCategoryId = null, Level = 0, CreatedByUserId = adminId }
            );
            AddTranslations(modelBuilder, rootCategoryId, "Телефоны", "Phones", adminId);

            // Основные категории
            var smartphonesId = Guid.NewGuid();
            var buttonPhonesId = Guid.NewGuid();
            var accessoriesId = Guid.NewGuid();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = smartphonesId, ParentCategoryId = rootCategoryId, Level = 1, CreatedByUserId = adminId },
                new Category { Id = buttonPhonesId, ParentCategoryId = rootCategoryId, Level = 1, CreatedByUserId = adminId },
                new Category { Id = accessoriesId, ParentCategoryId = rootCategoryId, Level = 1, CreatedByUserId = adminId }
            );

            AddTranslations(modelBuilder, smartphonesId, "Смартфоны", "Smartphones", adminId);
            AddTranslations(modelBuilder, buttonPhonesId, "Кнопочные телефоны", "Button Phones", adminId);
            AddTranslations(modelBuilder, accessoriesId, "Аксессуары", "Accessories", adminId);

            // Подкатегории смартфонов
            AddCategoryWithTranslations(modelBuilder, "Флагманы", "Flagships", smartphonesId, 2, adminId);
            AddCategoryWithTranslations(modelBuilder, "Средний сегмент", "Mid-range", smartphonesId, 2, adminId);
            AddCategoryWithTranslations(modelBuilder, "Бюджетные модели", "Budget models", smartphonesId, 2, adminId);
            AddCategoryWithTranslations(modelBuilder, "Игровые смартфоны", "Gaming smartphones", smartphonesId, 2, adminId);
            AddCategoryWithTranslations(modelBuilder, "Компактные смартфоны", "Compact smartphones", smartphonesId, 2, adminId);

            // Подкатегории кнопочных телефонов
            AddCategoryWithTranslations(modelBuilder, "Классические", "Classic", buttonPhonesId, 2, adminId);
            AddCategoryWithTranslations(modelBuilder, "Телефоны для пожилых", "Phones for elderly", buttonPhonesId, 2, adminId);
            AddCategoryWithTranslations(modelBuilder, "Защищенные кнопочные телефоны", "Rugged button phones", buttonPhonesId, 2, adminId);

            // Подкатегории аксессуаров
            var casesId = Guid.NewGuid();
            var screenProtectorsId = Guid.NewGuid();
            var chargersId = Guid.NewGuid();
            var cablesId = Guid.NewGuid();
            var headphonesId = Guid.NewGuid();

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = casesId, ParentCategoryId = accessoriesId, Level = 2, CreatedByUserId = adminId},
                new Category { Id = screenProtectorsId, ParentCategoryId = accessoriesId, Level = 2, CreatedByUserId = adminId },
                new Category { Id = chargersId, ParentCategoryId = accessoriesId, Level = 2, CreatedByUserId = adminId },
                new Category { Id = cablesId, ParentCategoryId = accessoriesId, Level = 2, CreatedByUserId = adminId },
                new Category { Id = headphonesId, ParentCategoryId = accessoriesId, Level = 2, CreatedByUserId = adminId }
            );

            AddTranslations(modelBuilder, casesId, "Чехлы", "Cases", adminId);
            AddTranslations(modelBuilder, screenProtectorsId, "Защитные стекла и пленки", "Screen protectors", adminId);
            AddTranslations(modelBuilder, chargersId, "Зарядные устройства", "Chargers", adminId);
            AddTranslations(modelBuilder, cablesId, "Кабели и адаптеры", "Cables & Adapters", adminId);
            AddTranslations(modelBuilder, headphonesId, "Наушники и гарнитуры", "Headphones & Headsets", adminId);

            // Подкатегории чехлов
            AddCategoryWithTranslations(modelBuilder, "Силиконовые", "Silicone", casesId, 3, adminId);
            AddCategoryWithTranslations(modelBuilder, "Кожаные", "Leather", casesId, 3, adminId);
            AddCategoryWithTranslations(modelBuilder, "Противоударные", "Shockproof", casesId, 3, adminId);
            AddCategoryWithTranslations(modelBuilder, "Книжки", "Book-style", casesId, 3, adminId);
            AddCategoryWithTranslations(modelBuilder, "С прозрачной крышкой", "Transparent cover", casesId, 3, adminId);

            // Подкатегории зарядных устройств
            AddCategoryWithTranslations(modelBuilder, "Беспроводные", "Wireless", chargersId, 3, adminId);
            AddCategoryWithTranslations(modelBuilder, "Сетевые", "Wired", chargersId, 3, adminId);
            AddCategoryWithTranslations(modelBuilder, "Автомобильные", "Car chargers", chargersId, 3, adminId);
            AddCategoryWithTranslations(modelBuilder, "Магнитные", "Magnetic", chargersId, 3, adminId);

             
            var brand1Id = Guid.NewGuid();
            var brand2Id = Guid.NewGuid();
            var brand3Id = Guid.NewGuid();
            var brand4Id = Guid.NewGuid();
            var brand5Id = Guid.NewGuid();
            modelBuilder.Entity<Brand>().HasData(
                new Brand { Id = brand1Id, Name = "Sony", CreatedByUserId = adminId },
                new Brand { Id = brand2Id, Name = "Samsung", CreatedByUserId = adminId },
                new Brand { Id = brand3Id, Name = "Nike", CreatedByUserId = adminId },
                new Brand { Id = brand4Id, Name = "Adidas", CreatedByUserId = adminId },
                new Brand { Id = brand5Id, Name = "Apple", CreatedByUserId = adminId }
            );

            // Продукты
            // Создадим 10 000 продуктов, для каждого:
            // - Генерируем уникальный ProductId
            // - Создаем две записи в ProductTranslation (ru и en)
            // - Создаем WishList для продукта и связь через WishListProduct

            var productsList = new List<Product>();
            var productTranslationsList = new List<ProductTranslation>();
            var wishListsList = new List<WishList>();
            var wishListProductsList = new List<WishListProduct>();


            Random random = new Random();

            for (int i = 1; i <= 1000; i++)
            {
                Guid productId = Guid.NewGuid();
                Guid productWishListId = Guid.NewGuid();

                decimal number = 10 + random.Next(0, 200000); // Исходное число
                decimal minPercent = 10m; // Минимальный процент
                decimal maxPercent = 50m; // Максимальный процент

                decimal randomPercent = random.Next((int)minPercent, (int)maxPercent + 1); // Генерация числа от 10 до 50
                decimal newNumber = number + (number * randomPercent / 100); // Прибавление процента


                // Продукт: рандомная цена, случайное распределение по категориям и брендам
                var product = new Product
                {
                    Id = productId,
                    CategoryId = (i % 2 == 0) ? smartphonesId : buttonPhonesId,
                    BrandId = (i % 5 == 0) ? brand5Id : (i % 4 == 0) ? brand4Id : (i % 3 == 0) ? brand3Id : (i % 2 == 0) ? brand2Id : brand1Id,
                    Price = 1000 + i,
                    OriginalPrice = newNumber,
                    CreatedByUserId = adminId,
                    SupplierId = (i % 3 == 0) ? supplier3Id : (i % 2 == 0) ? supplier2Id : supplier1Id
                };
                productsList.Add(product);

                // Переводы для продукта
                productTranslationsList.Add(new ProductTranslation
                {
                    EntityId = productId,
                    LanguageId = "ru",
                    Name = $"Продукт {i}",
                    CreatedByUserId = adminId
                });
                productTranslationsList.Add(new ProductTranslation
                {
                    EntityId = productId,
                    LanguageId = "en",
                    Name = $"Product {i}",
                    CreatedByUserId = adminId
                });

                // WishList для продукта (если требуется для каждого продукта)
                wishListsList.Add(new WishList
                {
                    Id = productWishListId
                });

                // Связь продукта с его WishList
                wishListProductsList.Add(new WishListProduct
                {
                    ProductId = productId,
                    WishListId = productWishListId
                });
            }

            modelBuilder.Entity<Product>().HasData(productsList);
            modelBuilder.Entity<ProductTranslation>().HasData(productTranslationsList);
            modelBuilder.Entity<WishList>().HasData(wishListsList);
            modelBuilder.Entity<WishListProduct>().HasData(wishListProductsList);

            // Скидки и связи скидок, если необходимо – можно добавить аналогично
        }

        private void AddCategoryWithTranslations(ModelBuilder modelBuilder, string ruName, string enName, Guid parentId, int level, Guid createdByUserId)
        {
            var categoryId = Guid.NewGuid();
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = categoryId, ParentCategoryId = parentId, Level = level, CreatedByUserId = createdByUserId }
            );
            AddTranslations(modelBuilder, categoryId, ruName, enName, createdByUserId);
        }

        private void AddTranslations(ModelBuilder modelBuilder, Guid categoryId, string ruName, string enName, Guid createdByUserId)
        {
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation {  EntityId = categoryId, LanguageId = "ru", Name = ruName, CreatedByUserId = createdByUserId },
                new CategoryTranslation { EntityId = categoryId, LanguageId = "en", Name = enName, CreatedByUserId = createdByUserId }
            );
        }
    }
}

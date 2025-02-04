using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Test.Data.Configurations._Category;
using Test.Data.Configurations._LoyaltyProgram;
using Test.Data.Configurations._LoyaltyProgram.Bundle;
using Test.Data.Configurations._LoyaltyProgram.Discount;
using Test.Data.Configurations._LoyaltyProgram.Loyalty;
using Test.Data.Configurations._Order;
using Test.Data.Configurations._Product;
using Test.Data.Configurations._User;
using Test.Models._Category;
using Test.Models._Discounts.Bundle;
using Test.Models._Discounts.Loyalty;
using Test.Models._LoyaltyProgram;
using Test.Models._LoyaltyProgram.Discount;
using Test.Models._Order;
using Test.Models._Product;
using Test.Models._User;

namespace Test.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<DiscountRule> DiscountRules => Set<DiscountRule>();
        public DbSet<DiscountCondition> DiscountConditions => Set<DiscountCondition>();
        public DbSet<DiscountBundle> DiscountBundles => Set<DiscountBundle>();
        public DbSet<BundleItem> BundleItems => Set<BundleItem>();
        public DbSet<Coupon> Coupons => Set<Coupon>();
        public DbSet<LoyaltyProgram> LoyaltyPrograms => Set<LoyaltyProgram>();
        public DbSet<LoyaltyTier> LoyaltyTiers => Set<LoyaltyTier>();
        public DbSet<UserLoyalty> UserLoyaltyRecords => Set<UserLoyalty>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<DiscountUsage> DiscountUsages => Set<DiscountUsage>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
      : base(options)
        {
        }

        #region GUIDs для фиктивных данных
        // Пользователи
        private static readonly Guid userAliceId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        private static readonly Guid userBobId = Guid.Parse("22222222-2222-2222-2222-222222222222");

        // Категории
        private static readonly Guid categoryPhonesId = Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
        private static readonly Guid categoryLaptopsId = Guid.Parse("bbbbbbb2-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

        // Товары
        private static readonly Guid productIphoneId = Guid.Parse("ccccccc3-cccc-cccc-cccc-cccccccccccc");
        private static readonly Guid productLaptopId = Guid.Parse("ddddddd4-dddd-dddd-dddd-dddddddddddd");

        // Скидочные правила
        private static readonly Guid discountRulePercentageId = Guid.Parse("99999991-9999-9999-9999-999999999991");
        private static readonly Guid discountRuleFixedId = Guid.Parse("99999992-9999-9999-9999-999999999992");
        private static readonly Guid discountRuleCategoryId = Guid.Parse("99999993-9999-9999-9999-999999999993");
        private static readonly Guid discountRuleBundleId = Guid.Parse("99999994-9999-9999-9999-999999999994");
        private static readonly Guid discountRuleLoyaltyId = Guid.Parse("99999995-9999-9999-9999-999999999995");
        private static readonly Guid discountRuleFreeShippingId = Guid.Parse("99999996-9999-9999-9999-999999999996");
        private static readonly Guid discountRuleBuyXGetYId = Guid.Parse("99999997-9999-9999-9999-999999999997");
 
        // Условия скидки
        private static readonly Guid discountConditionCartTotalId = Guid.Parse("88888881-8888-8888-8888-888888888881");
        private static readonly Guid discountConditionCategoryId = Guid.Parse("88888882-8888-8888-8888-888888888882");

        // Бандлы
        private static readonly Guid discountBundleId = Guid.Parse("77777771-7777-7777-7777-777777777771");
        private static readonly Guid bundleItemIphoneId = Guid.Parse("77777772-7777-7777-7777-777777777772");
        private static readonly Guid bundleItemLaptopId = Guid.Parse("77777773-7777-7777-7777-777777777773");

        // Купон
        private static readonly Guid couponSummerId = Guid.Parse("66666666-6666-6666-6666-666666666666");

        // Программа лояльности
        private static readonly Guid loyaltyProgramId = Guid.Parse("55555551-5555-5555-5555-555555555551");
        private static readonly Guid loyaltyTierBronzeId = Guid.Parse("55555552-5555-5555-5555-555555555552");
        private static readonly Guid loyaltyTierSilverId = Guid.Parse("55555553-5555-5555-5555-555555555553");
        private static readonly Guid userLoyaltyAliceId = Guid.Parse("55555554-5555-5555-5555-555555555554");

        // Заказы, позиции, использования скидок
        private static readonly Guid order1Id = Guid.Parse("33333331-3333-3333-3333-333333333331");
        private static readonly Guid orderItem1Id = Guid.Parse("33333332-3333-3333-3333-333333333332");
        private static readonly Guid discountUsage1Id = Guid.Parse("44444441-4444-4444-4444-444444444441");

        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiscountConditionConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountRuleConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountUsageConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());

            modelBuilder.ApplyConfiguration(new LoyaltyProgramConfiguration());
            modelBuilder.ApplyConfiguration(new LoyaltyTierConfiguration());
            modelBuilder.ApplyConfiguration(new UserLoyaltyConfiguration());

            modelBuilder.ApplyConfiguration(new DiscountBundleConfiguration());
            modelBuilder.ApplyConfiguration(new BundleItemConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());


            base.OnModelCreating(modelBuilder);
            #region User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = userAliceId,
                    Email = "alice@example.com",
                    CreatedAt = new DateTime(2025, 1, 1),
                    UpdatedAt = null
                },
                new User
                {
                    Id = userBobId,
                    Email = "bob@example.com",
                    CreatedAt = new DateTime(2025, 1, 2),
                    UpdatedAt = null
                }
            );
            #endregion

            #region Category
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = categoryPhonesId,
                    Name = "Phones",
                    ParentId = null
                },
                new Category
                {
                    Id = categoryLaptopsId,
                    Name = "Laptops",
                    ParentId = null
                }
            );
            #endregion

            #region Product
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = productIphoneId,
                    Name = "iPhone 14",
                    CategoryId = categoryPhonesId,
                    Price = 800m,
                    CreatedAt = new DateTime(2025, 1, 3),
                    UpdatedAt = null
                },
                new Product
                {
                    Id = productLaptopId,
                    Name = "Gaming Laptop",
                    CategoryId = categoryLaptopsId,
                    Price = 1500m,
                    CreatedAt = new DateTime(2025, 1, 4),
                    UpdatedAt = null
                }
            );
            #endregion

            #region DiscountRules (3 разных типа скидок)
            modelBuilder.Entity<DiscountRule>().HasData(
                // 1) Процентная скидка
                new DiscountRule
                {
                    Id = discountRulePercentageId,
                    Name = "10% off for orders over 5000",
                    DiscountRuleType = DiscountRuleType.Percentage,
                    Value = 10m,                   // 10%
                    StartDate = null,
                    EndDate = null,
                    MinOrderAmount = 5000m,
                    MaxUsageCount = 0,
                    CurrentUsageCount = 0,
                    IsStackable = false,
                    Priority = 1,
                    Description = "Процентная скидка",
                    CreatedAt = new DateTime(2025, 1, 5),
                    UpdatedAt = null
                },
                // 2) Фиксированная скидка
                new DiscountRule
                {
                    Id = discountRuleFixedId,
                    Name = "Fixed 500 off over 10000",
                    DiscountRuleType = DiscountRuleType.FixedAmount,
                    Value = 500m,                  // 500 ед.
                    StartDate = null,
                    EndDate = null,
                    MinOrderAmount = 10000m,
                    MaxUsageCount = 0,
                    CurrentUsageCount = 0,
                    IsStackable = false,
                    Priority = 2,
                    Description = "Фиксированная скидка 500 руб. при сумме заказа от 10000",
                    CreatedAt = new DateTime(2025, 1, 6),
                    UpdatedAt = null
                },
                // 3) Скидка на категорию
                new DiscountRule
                {
                    Id = discountRuleCategoryId,
                    Name = "15% off category X",
                    DiscountRuleType = DiscountRuleType.CategorySpecific,
                    Value = 15m,                   // 15% скидка
                    StartDate = null,
                    EndDate = null,
                    MinOrderAmount = 0m,
                    MaxUsageCount = 0,
                    CurrentUsageCount = 0,
                    IsStackable = false,
                    Priority = 3,
                    Description = "Скидка 15% на товары из определённой категории (условия в DiscountCondition)",
                    CreatedAt = new DateTime(2025, 1, 7),
                    UpdatedAt = null
                },
                // 4) Бандл-скидка
                new DiscountRule
                {
                    Id = discountRuleBundleId,
                    Name = "Bundle discount: Phone + Laptop",
                    DiscountRuleType = DiscountRuleType.Bundle,
                    Value = 300m,                  // Скидка 300 при покупке набора
                    StartDate = null,
                    EndDate = null,
                    MinOrderAmount = 0m,
                    MaxUsageCount = 0,
                    CurrentUsageCount = 0,
                    IsStackable = false,
                    Priority = 4,
                    Description = "Скидка 300 руб. при покупке 2 товаров в бандле (iPhone + Laptop)",
                    CreatedAt = new DateTime(2025, 1, 8),
                    UpdatedAt = null
                },
                // 5) Скидка по бонусным баллам
                new DiscountRule
                {
                    Id = discountRuleLoyaltyId,
                    Name = "Loyalty points usage",
                    DiscountRuleType = DiscountRuleType.LoyaltyPoints,
                    Value = 1m,                   // 1 балл = 1 рубль
                    StartDate = null,
                    EndDate = null,
                    MinOrderAmount = 0m,
                    MaxUsageCount = 0,
                    CurrentUsageCount = 0,
                    IsStackable = false,
                    Priority = 5,
                    Description = "Скидка, основанная на списании бонусных баллов",
                    CreatedAt = new DateTime(2025, 1, 9),
                    UpdatedAt = null
                },
                // 6) Бесплатная доставка
                new DiscountRule
                {
                    Id = discountRuleFreeShippingId,
                    Name = "Free shipping over 2000",
                    DiscountRuleType = DiscountRuleType.FreeShipping,
                    Value = 0m,
                    StartDate = null,
                    EndDate = null,
                    MinOrderAmount = 2000m,
                    MaxUsageCount = 0,
                    CurrentUsageCount = 0,
                    IsStackable = false,
                    Priority = 6,
                    Description = "Бесплатная доставка при заказе от 2000",
                    CreatedAt = new DateTime(2025, 1, 10),
                    UpdatedAt = null
                },
                // 7) Акция "Купи X, получи Y бесплатно"
                new DiscountRule
                {
                    Id = discountRuleBuyXGetYId,
                    Name = "Buy X, get Y free",
                    DiscountRuleType = DiscountRuleType.BuyXGetY,
                    Value = 0m,   // здесь логика зависит от условий
                    StartDate = null,
                    EndDate = null,
                    MinOrderAmount = 0m,
                    MaxUsageCount = 0,
                    CurrentUsageCount = 0,
                    IsStackable = false,
                    Priority = 7,
                    Description = "Купи 3 товара, получи 1 бесплатно (пример)",
                    CreatedAt = new DateTime(2025, 1, 11),
                    UpdatedAt = null
                }
            );
            #endregion

            #region DiscountConditions (демо: cart_total + category)
            // Например: условие, что CartTotal >= 2000 (для наглядности)
            // и условие, что категория = Phones (MinQuantity=1)
            modelBuilder.Entity<DiscountCondition>().HasData(
                new DiscountCondition
                {
                    Id = discountConditionCartTotalId,
                    DiscountRuleId = discountRulePercentageId, // Привязываем к 10% скидке
                    Operator = ConditionOperator.And,
                    ConditionType = ConditionType.CartTotal,
                    Threshold = 2000m,   // Применим скидку только если корзина >= 2000
                    Comparison = ">=",
                    // Остальные поля null
                },
                new DiscountCondition
                {
                    Id = discountConditionCategoryId,
                    DiscountRuleId = discountRulePercentageId,
                    Operator = ConditionOperator.And,
                    ConditionType = ConditionType.Category,
                    CategoryId = categoryPhonesId,
                    MinQuantity = 1,
                    // Остальные поля null
                }
            );
            #endregion

            #region DiscountBundle
            modelBuilder.Entity<DiscountBundle>().HasData(
                new DiscountBundle
                {
                    Id = discountBundleId,
                    DiscountRuleId = discountRuleBundleId,
                    BundleName = "Phone + Laptop Bundle"
                }
            );
            #endregion

            #region BundleItem (два товара в бандле)
            modelBuilder.Entity<BundleItem>().HasData(
                new BundleItem
                {
                    Id = bundleItemIphoneId,
                    DiscountBundleId = discountBundleId,
                    ProductId = productIphoneId,
                    Quantity = 1
                },
                new BundleItem
                {
                    Id = bundleItemLaptopId,
                    DiscountBundleId = discountBundleId,
                    ProductId = productLaptopId,
                    Quantity = 1
                }
            );
            #endregion

            #region Coupon
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = couponSummerId,
                    Code = "SUMMER2025",
                    ExpirationDate = new DateTime(2025, 12, 31),
                    MaxUses = 100,
                    CurrentUses = 0,
                    IsSingleUsePerUser = false,
                    DiscountRuleId = discountRulePercentageId,
                    CreatedAt = new DateTime(2025, 1, 6),
                    UpdatedAt = null
                }
            );
            #endregion

            #region LoyaltyProgram
            modelBuilder.Entity<LoyaltyProgram>().HasData(
                new LoyaltyProgram
                {
                    Id = loyaltyProgramId,
                    Name = "VIP Program",
                    DefaultPointsPerDollar = 1,     // 1 балл за $1 по умолчанию
                    PointsToCurrencyRatio = 0.01m  // 1 балл = 0.01$
                }
            );
            #endregion

            #region LoyaltyTier (Bronze, Silver)
            modelBuilder.Entity<LoyaltyTier>().HasData(
                new LoyaltyTier
                {
                    Id = loyaltyTierBronzeId,
                    LoyaltyProgramId = loyaltyProgramId,
                    TierName = "Bronze",
                    MinPoints = 0,
                    DiscountPercentage = 0,      // нет авт. скидки
                    PointsMultiplier = 1.0m    // базовый множитель
                },
                new LoyaltyTier
                {
                    Id = loyaltyTierSilverId,
                    LoyaltyProgramId = loyaltyProgramId,
                    TierName = "Silver",
                    MinPoints = 1000,
                    DiscountPercentage = 5,      // 5% авт. скидка
                    PointsMultiplier = 1.5m    // полтора балла за 1$
                }
            );
            #endregion

            #region UserLoyalty
            // Связываем Алису с программой VIP, на уровне Bronze
            modelBuilder.Entity<UserLoyalty>().HasData(
                new UserLoyalty
                {
                    Id = userLoyaltyAliceId,
                    UserId = userAliceId,
                    LoyaltyProgramId = loyaltyProgramId,
                    CurrentTierId = loyaltyTierBronzeId,
                    TotalPoints = 500,   // Накопила 500 баллов
                    Active = true,
                    CreatedAt = new DateTime(2025, 1, 10),
                    UpdatedAt = null
                }
            );
            #endregion

            #region Orders (демо-заказ)
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = order1Id,
                    UserId = userAliceId,  // заказ оформлен Алисой
                    TotalAmount = 1200m,        // к примеру
                    CreatedAt = new DateTime(2025, 1, 11),
                    UpdatedAt = null
                }
            );
            #endregion

            #region OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = orderItem1Id,
                    OrderId = order1Id,
                    ProductId = productIphoneId,
                    Quantity = 1,
                    PriceAtMoment = 800m
                }
            );
            #endregion

            #region DiscountUsage
            // Предположим, Алиса применила скидку (DiscountRulePercentageId) к заказу order1
            modelBuilder.Entity<DiscountUsage>().HasData(
                new DiscountUsage
                {
                    Id = discountUsage1Id,
                    DiscountRuleId = discountRulePercentageId,
                    UserId = userAliceId,
                    OrderId = order1Id,
                    UsageDate = new DateTime(2025, 1, 11),
                    AppliedAmount = 80m // 10% от 800
                }
            );
            #endregion
        }
    }
}

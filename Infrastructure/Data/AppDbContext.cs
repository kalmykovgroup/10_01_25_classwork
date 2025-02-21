using Domain.Entities.ProductSpace;
using Domain.Entities.OrderSpace;
using Infrastructure.Data.ConfigurationsEntity.ProductSpace;
using Domain.Entities.AddressesSpace;
using Domain.Entities.UserSpace;
using Domain.Entities.CategorySpace;
using Domain.Entities.Common;
using Domain.Entities.IntermediateSpace;
using Domain.Entities.StatusesSpace;
using Domain.Entities.TranslationsSpace;
using Domain.Entities.TranslationsSpace.TranslationEntities;
using Microsoft.EntityFrameworkCore; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Infrastructure.Data.ConfigurationsEntity.UserSpace;
using Infrastructure.Data.ConfigurationsEntity;
using Infrastructure.Data.ConfigurationsEntity.AddressesSpace;
using Infrastructure.Data.ConfigurationsEntity.CategorySpace;
using Infrastructure.Data.ConfigurationsEntity.IntermediateSpaceConf;
using Infrastructure.Data.ConfigurationsEntity.OrderSpace;
using Infrastructure.Data.ConfigurationsEntity.StatusesSpace;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.CategorySpace;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.StatusesSpace;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.UserSpace;
using Domain.Entities.UserSpace.UserTypes;
using Infrastructure.Data.ConfigurationsEntity.UserSpace.UserTypes;
using Domain.Entities.AnalyticsSpace;
using Infrastructure.Data.ConfigurationsEntity.BrandSpaceConf;
using Infrastructure.Data.ConfigurationsEntity.InventorySpaceConf;
using Infrastructure.Data.ConfigurationsEntity.LoyaltyProgramSpace.Bundle;
using Infrastructure.Data.ConfigurationsEntity.LoyaltyProgramSpace.CouponSpace;
using Infrastructure.Data.ConfigurationsEntity.LoyaltyProgramSpace.Discount;
using Infrastructure.Data.ConfigurationsEntity.LoyaltyProgramSpace.Loyalty;
using Infrastructure.Data.ConfigurationsEntity.NotificationsSpaceConf;
using Infrastructure.Data.ConfigurationsEntity.StorageSpace.Heirs;
using Infrastructure.Data.ConfigurationsEntity.StorageSpace;
using Infrastructure.Data.ConfigurationsEntity.SupplierSpaceConf;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.BrandSpaceConf;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.LoyaltyProgramSpaceConf.Bundle;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.LoyaltyProgramSpaceConf.Discount;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.LoyaltyProgramSpaceConf.Loyalty;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.NotificationSpaceConf;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.ProductSpace;
using Infrastructure.Data.ConfigurationsEntity.AddressesSpace.Heirs;
using Infrastructure.Data.ConfigurationsEntity.PaymentSpace;
using Infrastructure.Data.ConfigurationsEntity.StatusesSpace.Heirs;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.OrderSpaceConf;
using Domain.Models.LoyaltyProgramSpace.Discount;
using Infrastructure.Data.ConfigurationsEntity.TranslationSpace;
using Domain.Entities.TranslationSpace;
using Application.Common.Interfaces;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext, IUnitOfWork
    {
        private readonly ChangeLogInterceptor _changeLogInterceptor = new();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_changeLogInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
         

        public DbSet<Product> Products { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        public DbSet<WishListProduct> WishListProducts { get; set; }
        public DbSet<PhoneVerificationCode> PhoneVerificationCodes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        //Нужно для middleware, через эту запись можно получить перевод для любой сущности
        public DbSet<Language> Languages { get; set; }

        public DbSet<ProductTranslation> ProductTranslations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            #region AddressesSpace 
            //heirs
            new SupplierAddressConf(modelBuilder);
            new UserAddressConf(modelBuilder); 

            new AddressConfig(modelBuilder);

            #endregion


            #region AnalyticsSpace

            new CustomerPreferenceConf(modelBuilder);
            new SalesReportConf(modelBuilder);
            new SalesReportItemConf(modelBuilder);

            new ViewHistoryConf(modelBuilder);
            new VisitorActionConf(modelBuilder);
            new VisitorSessionConf(modelBuilder);


            #endregion

            #region BrandSpaceConf

            new BrandConf(modelBuilder);

            #endregion


            #region CategorySpace

            new CategoryConfig(modelBuilder);

            #endregion


            #region Common

            new HistoryConf(modelBuilder);

            #endregion


            #region IntermediateSpaceConf

            new CustomerPreferenceBrandConf(modelBuilder);
            new CustomerPreferenceCategoryConf(modelBuilder);
            new OrderCouponConf(modelBuilder);

            new ProductDiscountConf(modelBuilder);

            new ProductTagConf(modelBuilder);
            new RolePermissionConf(modelBuilder);
            new SupplierBrandConf(modelBuilder);

            new UserPermissionConf(modelBuilder);
            new UserRoleConf(modelBuilder);

            modelBuilder.ApplyConfiguration(new WishListProductConf());
                 

            #endregion

            #region InventorySpaceConf

            new ProductStockConf(modelBuilder);
            new SupplyProductConf(modelBuilder);
            new SupplyConf(modelBuilder);
            new WarehouseConf(modelBuilder);

            #endregion

            #region LoyaltyProgramSpace

            //Bundle

            new BundleItemConf(modelBuilder);
            new DiscountBundleConf(modelBuilder);

            //Coupon

            new CouponConf(modelBuilder);
            new CouponUsageConf(modelBuilder);

            //Discount

            new DiscountConditionConf(modelBuilder);
            new DiscountRuleConf(modelBuilder);
            new DiscountUsageConf(modelBuilder);

            //Loyalty

            new CustomerLoyaltyConf(modelBuilder);
            new LoyaltyBonusConf(modelBuilder);
            new LoyaltyProgramConf(modelBuilder);
            new LoyaltyTierConf(modelBuilder);

            #endregion


            #region NotificationsSpaceConf

            new NotificationConf(modelBuilder);

            #endregion

            #region OrderSpace

            new OrderConf(modelBuilder);
            new OrderHistoryConf(modelBuilder);
            new OrderItemConf(modelBuilder);

            new ShippingDetailsConf(modelBuilder);
            new ShippingMethodConf(modelBuilder);

            #endregion

            #region PaymentSpace


            new CurrencyConf(modelBuilder);
            new PaymentCardConf(modelBuilder);
            new PaymentDetailsConf(modelBuilder);

            new PaymentMethodConf(modelBuilder);
            new PaymentTransactionConf(modelBuilder);
            new PaymentTypeConf(modelBuilder);

            new ReceiptConf(modelBuilder);

            #endregion

            #region ProductSpace

            new ProductAttributeConf(modelBuilder);
            new ProductConf(modelBuilder);
            new ProductVariantConf(modelBuilder);

            new ProductWaitConf(modelBuilder);
            new ReviewConf(modelBuilder);
            new TagConf(modelBuilder);

            modelBuilder.ApplyConfiguration(new WishListConf());
           
            #endregion

            #region StatusesSpace

            new OrderStatusConfig(modelBuilder); 
            new ShippingStatusConfig(modelBuilder);
            new StatusConfig(modelBuilder);

            #endregion



            #region StorageSpace

            //Heirs
            new OrderFileConf(modelBuilder);
            new ProductFileConf(modelBuilder);
            new ReviewFileConf(modelBuilder);

            new FileStorageConf(modelBuilder);

            #endregion


            #region StorageSpace

            new SupplierConf(modelBuilder);

            #endregion
 

            #region Translations

            new LanguageConf(modelBuilder);

            new BrandTranslationConf(modelBuilder);

            new CategoryTranslationConf(modelBuilder);

            new DiscountBundleTranslationConf(modelBuilder);
            new DiscountRuleTranslationConf(modelBuilder);
            new LoyaltyProgramTranslationConf(modelBuilder);
            new LoyaltyTierTranslationConf(modelBuilder);

            new NotificationTranslationConf(modelBuilder);

            new ShippingMethodTranslationConf(modelBuilder);

            new ProductAttributeTranslationConf(modelBuilder);
            new ProductTranslationConf(modelBuilder);
            new ProductVariantTranslationConf(modelBuilder);
              
            new StatusTranslationConfig(modelBuilder);

            new CustomerGroupTranslationConfig(modelBuilder);
            new PermissionTranslationConfig(modelBuilder);
            new RoleTranslationConfig(modelBuilder);

            #endregion

            #region UserSpace

            //UserTypes         
                new EmployeeConf(modelBuilder);
                new CustomerConf(modelBuilder);
                new AdminConf(modelBuilder);

            new CustomerGroupConf(modelBuilder);         
            new PermissionConf(modelBuilder); 

            new PhoneVerificationCodeConf(modelBuilder);
            new RoleConf(modelBuilder);
            new UserConf(modelBuilder);

            #endregion

            new DefaultData(modelBuilder);

        }
         
  

        public async Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            var transaction = await Database.BeginTransactionAsync(cancellationToken);
            return new EfTransaction(transaction);
        }

        public override int SaveChanges()
        {
            ConvertDateTimeToUtc();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ConvertDateTimeToUtc();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void ConvertDateTimeToUtc()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                foreach (var property in entry.Properties)
                {
                    if (property.Metadata.ClrType == typeof(DateTime) || property.Metadata.ClrType == typeof(DateTime?))
                    {
                        if (property.CurrentValue is DateTime dt && dt.Kind != DateTimeKind.Utc)
                        {
                            // 🔹 Переводим в UTC правильно
                            property.CurrentValue = dt.ToUniversalTime();

                            // ✅ Выводим после изменения
                            Console.WriteLine($"\n\nProperty: {property.Metadata.Name}, Value (converted): {property.CurrentValue}, Kind: {((DateTime)property.CurrentValue).Kind}\n\n");
                        }
                    }
                }
            }
        }

    }
}

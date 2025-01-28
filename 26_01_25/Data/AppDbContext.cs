using Microsoft.EntityFrameworkCore;
using Kalmykov_mag.Entities._Auth;
using Kalmykov_mag.Entities._Order;
using Kalmykov_mag.Entities._Product;
using Kalmykov_mag.Entities._Category;
using Kalmykov_mag.Entities._Discounts;
using Kalmykov_mag.Entities._Inventory;
using Kalmykov_mag.Entities._Notifications;
using Kalmykov_mag.Entities._Subscriptions;
using Kalmykov_mag.Entities._Statuses;
using Kalmykov_mag.Entities._Storage;
using Kalmykov_mag.Entities._Analytics;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Translations; 
using Kalmykov_mag.Entities._Intermediate;
using Kalmykov_mag.Entities._Translations.TranslationEntities;
using Kalmykov_mag.Entities._Other;
using Kalmykov_mag.Entities._Addresses;

namespace Kalmykov_mag.Data
{
    public class AppDbContext : DbContext
    { 

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        #region Addresses

        ///<summary>
        ///TPH(Table Per Hierarchy)(Одна общая таблица)
        /// CustomerAddress, EmployeeAddress, SupplierAddress, WarehouseAddress
        /// </summary> 
        public DbSet<Address> Addresses { get; set; } 

        #endregion

        #region Analytics

        public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<CustomerPreference> CustomerPreferences { get; set; }

        public DbSet<SalesReport> SalesReports { get; set; }

        public DbSet<SalesReportItem> SalesReportItems { get; set; }

        public DbSet<ViewHistory> ViewHistories { get; set; }

        public DbSet<VisitorAction> VisitorActions { get; set; }

        public DbSet<VisitorSession> VisitorSessions { get; set; }

        public DbSet<WishList> WishListCollection { get; set; }
        #endregion

        #region Auth


        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Role> Roles { get; set; }

        ///<summary>
        /// TPH(Table Per Hierarchy)(Одна общая таблица)
        /// Employee, Customer 
        /// </summary>  
        public DbSet<User> Users { get; set; }

        #endregion

        #region Category

        public DbSet<Category> Categories { get; set; }

        #endregion
         

        #region Brand

        public DbSet<Brand> Brands { get; set; }

        public DbSet<SupplierBrand> SupplierBrands { get; set; }

        #endregion

           

        #region Discounts
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CustomerGroupDiscount> CustomerGroupDiscounts { get; set; }
        public DbSet<DiscountRule> DiscountRules { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<LoyaltyPoints> LoyaltyPointsCollection { get; set; }
        public DbSet<OrderCoupon> OrderCoupons { get; set; }
        public DbSet<DiscountRuleAction> DiscountRuleActions { get; set; }
        #endregion

        #region Intermediate

        public DbSet<CustomerPreferenceCategory> CustomerPreferenceCategories { get; set; }
        public DbSet<CustomerPreferenceBrand> CustomerPreferenceBrands { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Inventory
        public DbSet<ProductStock> ProductStocks { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        #endregion

        #region Notifications
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<NotificationTranslation> NotificationTranslations { get; set; }
        #endregion

        #region Order
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentDetails> PaymentDetailsCollection { get; set; }
        public DbSet<ShippingDetails> ShippingDetailsCollection { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }
        public DbSet<OrderAppliedDiscount> OrderAppliedDiscounts { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ShippingMethod> ShippingMethods { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAttribute> ProductAttributes { get; set; } 
        
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductWait> ProductWaitlists { get; set; }
        #endregion

        #region Statuses
        public DbSet<Status> BaseStatuses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<ShippingStatus> ShippingStatuses { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        #endregion

        #region Storage
        public DbSet<FileStorage> FileStorages { get; set; }

        public DbSet<ProductFile> ProductFiles { get; set; }
        public DbSet<OrderFile> OrderFiles { get; set; }
        public DbSet<ReviewFile> ReviewFiles { get; set; }
        #endregion

        #region Subscriptions
        public DbSet<NewsletterSubscription> NewsletterSubscriptions { get; set; }
        #endregion

        #region Supplier
        public DbSet<Supplier> Suppliers { get; set; }
        #endregion

        #region Translations
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<DiscountTranslation> DiscountTranslations { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }
        public DbSet<SupplierTranslation> SupplierTranslations { get; set; }
        public DbSet<BrandTranslation> BrandTranslations { get; set; }
        public DbSet<ProductAttributeTranslation> ProductAttributeTranslations { get; set; }
        public DbSet<StatusTranslation> BaseStatusTranslations { get; set; }
        #endregion

  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Настройка AuditableEntity для всех наследников (цикл)
            AuditableEntity.ConfigureEntity(modelBuilder);

            #region Addresses

            //TPH (Один общий класс)
            //Объединяет: CustomerAddress, EmployeeAddress, SupplierAddress, WarehouseAddress
            Address.ConfigureEntity(modelBuilder);

            #endregion

            #region Analytics

            // CustomerGroup
            CustomerGroup.ConfigureEntity(modelBuilder);

            CustomerPreference.ConfigureEntity(modelBuilder);

            // SalesReport
            SalesReport.ConfigureEntity(modelBuilder);

            // SalesReportItem
            SalesReportItem.ConfigureEntity(modelBuilder);

            // Настройка ViewHistory 
            ViewHistory.ConfigureEntity(modelBuilder);

            // VisitorAction
            VisitorAction.ConfigureEntity(modelBuilder);

            // VisitorSession
            VisitorSession.ConfigureEntity(modelBuilder);

            // WishList 
            WishList.ConfigureEntity(modelBuilder);

            #endregion

            #region Auth

            //TPH (Общая таблица для Employee, Customer)
            User.ConfigureEntity(modelBuilder);

            Employee.ConfigureEntity(modelBuilder);
            Customer.ConfigureEntity(modelBuilder);

            Permission.ConfigureEntity(modelBuilder);
            
            Role.ConfigureEntity(modelBuilder);

            #endregion

            #region Category

            Category.ConfigureEntity(modelBuilder);
      

            #endregion

            #region Common
             
            AuditableEntity.ConfigureEntity(modelBuilder);

            //SeoTranslatableEntity настраивать не нужно!
            //TranslatableEntity настройка циклическая, стоит самая первая.

            #endregion

            #region Discounts

            Coupon.ConfigureEntity(modelBuilder);
             
            CustomerGroupDiscount.ConfigureEntity(modelBuilder);

            // TPC создает отдельную таблицу для каждого конкретного (не абстрактного) класса
            Discount.ConfigureEntity(modelBuilder);
             
            DiscountRule.ConfigureEntity(modelBuilder);

            DiscountRuleAction.ConfigureEntity(modelBuilder);

            LoyaltyPoints.ConfigureEntity(modelBuilder);

            ProductDiscount.ConfigureEntity(modelBuilder);

            OrderCoupon.ConfigureEntity(modelBuilder);


            #endregion

            #region Intermediate

            //CustomerPreferenceBrand
            CustomerPreferenceBrand.ConfigureEntity(modelBuilder);

            //CustomerPreferenceCategory
            CustomerPreferenceCategory.ConfigureEntity(modelBuilder);

            //ProductTag
            ProductTag.ConfigureEntity(modelBuilder);

            //RolePermission
            RolePermission.ConfigureEntity(modelBuilder);

            //SupplierBrand
            SupplierBrand.ConfigureEntity(modelBuilder);

            //UserPermission
            UserPermission.ConfigureEntity(modelBuilder);

            //UserRole
            UserRole.ConfigureEntity(modelBuilder); 

            #endregion

            #region Inventory

            // ProductStock
            ProductStock.ConfigureEntity(modelBuilder);

            // Warehouse 
            Warehouse.ConfigureEntity(modelBuilder);

            #endregion

            #region Notifications

            Notification.ConfigureEntity(modelBuilder); 

            #endregion

         
            #region Order


            // Для OrderAppliedDiscount
            OrderAppliedDiscount.ConfigureEntity(modelBuilder); 

            // Для OrderHistory
            OrderHistory.ConfigureEntity(modelBuilder);
          
            // Для Order
            Order.ConfigureEntity(modelBuilder);

            // OrderItem
            OrderItem.ConfigureEntity(modelBuilder);

            // PaymentDetails
            PaymentDetails.ConfigureEntity(modelBuilder);

            // PaymentMethod
            PaymentMethod.ConfigureEntity(modelBuilder);

            // Receipt
            Receipt.ConfigureEntity(modelBuilder);

            // ShippingDetails
            ShippingDetails.ConfigureEntity(modelBuilder);

            // ShippingMethod
            ShippingMethod.ConfigureEntity(modelBuilder);

            #endregion


            #region Other

            // Brand
            Brand.ConfigureEntity(modelBuilder);

            // Supplier
            Supplier.ConfigureEntity(modelBuilder);

            #endregion

            #region Product

            // Product
            Product.ConfigureEntity(modelBuilder);

            // ProductAttribute
            ProductAttribute.ConfigureEntity(modelBuilder);

            // ProductVariant
            ProductVariant.ConfigureEntity(modelBuilder);

            // ProductWait
            ProductWait.ConfigureEntity(modelBuilder);

            //Review
            Review.ConfigureEntity(modelBuilder);

            //Tag
            Tag.ConfigureEntity(modelBuilder);


            #endregion

            #region Statuses

            // Status TPH.(Одна общая таблица)
            Status.ConfigureEntity(modelBuilder);

            // OrderStatus
            OrderStatus.ConfigureEntity(modelBuilder);

            // PaymentStatus
            PaymentStatus.ConfigureEntity(modelBuilder);

            // ShippingStatus
            ShippingStatus.ConfigureEntity(modelBuilder);

            #endregion

            #region Storage

            // FileStorage
            FileStorage.ConfigureEntity(modelBuilder);

            // ProductFile
            ProductFile.ConfigureEntity(modelBuilder);

            // OrderFile
            OrderFile.ConfigureEntity(modelBuilder);

            // ReviewFile
            ReviewFile.ConfigureEntity(modelBuilder);




            #endregion

            #region Subscriptions

            // NewsletterSubscription
            NewsletterSubscription.ConfigureEntity(modelBuilder);


            #endregion 


            #region Translations

            BrandTranslation.ConfigureEntity(modelBuilder);
            CategoryTranslation.ConfigureEntity(modelBuilder);
            CustomerGroupTranslation.ConfigureEntity(modelBuilder);
            DiscountTranslation.ConfigureEntity(modelBuilder);
            NotificationTranslation.ConfigureEntity(modelBuilder);
            PermissionTranslation.ConfigureEntity(modelBuilder);
            ProductAttributeTranslation.ConfigureEntity(modelBuilder);
            ProductTranslation.ConfigureEntity(modelBuilder);
            ProductVariantTranslation.ConfigureEntity(modelBuilder);
            RoleTranslation.ConfigureEntity(modelBuilder);
            StatusTranslation.ConfigureEntity(modelBuilder);
            SupplierTranslation.ConfigureEntity(modelBuilder);

            #endregion
             

        }


    }
}

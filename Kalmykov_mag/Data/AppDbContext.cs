using Microsoft.EntityFrameworkCore; 
using Kalmykov_mag.Entities._Addresses;
using Kalmykov_mag.Entities._Auth;
using System.Data;
using Kalmykov_mag.Entities._Common;
using Kalmykov_mag.Entities._Translations.TranslationEntities;
using Kalmykov_mag.Entities._Statuses;
using System.Reflection;
using Kalmykov_mag.Entities._Translations;
using Kalmykov_mag.Entities._Intermediate;

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

        #region Statuses

        public DbSet<Status> Statuses { get; set; }
        
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

        #region _Intermediate

        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        #endregion

        #region Translations
        //  public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        //  public DbSet<DiscountTranslation> DiscountTranslations { get; set; }
        //  public DbSet<ProductTranslation> ProductTranslations { get; set; }
        //  public DbSet<SupplierTranslation> SupplierTranslations { get; set; }
        // public DbSet<BrandTranslation> BrandTranslations { get; set; }
        //  public DbSet<ProductAttributeTranslation> ProductAttributeTranslations { get; set; }
        public DbSet<PermissionTranslation> PermissionTranslations { get; set; }
           public DbSet<RoleTranslation> RoleTranslations { get; set; }
           public DbSet<StatusTranslation> StatusTranslations { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Настройка AuditableEntity для всех наследников (цикл) 
            AuditableEntity.ConfigureEntity(modelBuilder, this); // Передаем контекст

            #region Addresses

            //TPH (Один общий класс)
            //Объединяет: CustomerAddress, EmployeeAddress, SupplierAddress, WarehouseAddress
            Address.ConfigureEntity(modelBuilder);

            #endregion

            #region Auth

            //TPH (Общая таблица для Employee, Customer)
            User.ConfigureEntity(modelBuilder);
            Employee.ConfigureEntity(modelBuilder);
            Customer.ConfigureEntity(modelBuilder);

            Permission.ConfigureEntity(modelBuilder);
            Role.ConfigureEntity(modelBuilder);

            #endregion

            #region _Intermediate

            RolePermission.ConfigureEntity(modelBuilder);
            UserPermission.ConfigureEntity(modelBuilder);
            UserRole.ConfigureEntity(modelBuilder);

            #endregion

            #region Statuses

            //TPH (Один общий класс)
            //Объединяет: OrderStatus, PaymentStatus, ShippingStatus
            Status.ConfigureEntity(modelBuilder);

            #endregion

            #region Translations

            //Вызываю все классы переводчики
            
            var translationBaseType = typeof(Translation<>);
            var translationTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    t.IsClass &&
                    !t.IsAbstract &&
                    t.BaseType != null &&
                    t.BaseType.IsGenericType &&
                    t.BaseType.GetGenericTypeDefinition() == translationBaseType
                );
             

            foreach (var type in translationTypes)
            {              
                var method = type.GetMethod("ConfigureEntity", BindingFlags.Public | BindingFlags.Static);

                method?.Invoke(null, new object[] { modelBuilder });

                Console.WriteLine($"Вызов метода ConfigureEntity для {type.Name}");
            } 

            #endregion

        }

        // Метод для фильтра NULL
        private static string GetNullFilter(string columnName, DbContext context)
        {
            var provider = context.Database.ProviderName;
            return provider switch
            {
                var p when p.Contains("SqlServer") => $"[{columnName}] IS NOT NULL",
                var p when p.Contains("MySql") => $"`{columnName}` IS NOT NULL",
                var p when p.Contains("PostgreSql") => $"\"{columnName}\" IS NOT NULL",
                _ => ""
            };
        }


    }
}

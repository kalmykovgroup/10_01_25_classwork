 
/*using Kalmykov_mag.Entities._Analytics;
using Kalmykov_mag.Entities._Discounts;
using Kalmykov_mag.Entities._Notifications;
using Kalmykov_mag.Entities._Order;
using Kalmykov_mag.Entities._Product;*/
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations; 
using Microsoft.EntityFrameworkCore;
using Kalmykov_mag.Entities._Addresses;
using Kalmykov_mag.Entities._Order;

namespace Kalmykov_mag.Entities._Auth
{
    /// <summary>
    /// Клиент интернет-магазина (наследник пользователя)
    /// </summary>
    [Table("users")]
    public class Customer : User
    {
        /// <summary>
        /// Конструктор, устанавливающий тип пользователя как Customer
        /// </summary>
        public Customer()
        {
            UserType = UserType.Customer;
        }

         /// <summary>
        /// Идентификатор группы клиента (например, VIP, Regular)
        /// </summary>
        [Column("customer_group_id")]
        public Guid CustomerGroupId { get; set; }

        /// <summary>
        /// Группа клиента
        /// </summary>
        public virtual CustomerGroup CustomerGroup { get; set; } = null!;

        /// <summary>
        /// Идентификатор предпочтений клиента
        /// </summary>
 /*       [Column("customer_preference_id")]
        public Guid? CustomerPreferenceId { get; set; }

        /// <summary>
        /// Предпочтения клиента
        /// </summary>
        public virtual CustomerPreference? CustomerPreference { get; set; }

        /// <summary>
        /// Бонусные баллы лояльности клиента
        /// </summary>
        public virtual ICollection<LoyaltyPoints> LoyaltyPoints { get; set; } = new List<LoyaltyPoints>();

        /// <summary>
        /// Список методов оплаты клиента
        /// </summary>
        public virtual ICollection<PaymentMethod> PaymentMethods { get; set; } = new List<PaymentMethod>();*/

        /// <summary>
        /// Список адресов клиента
        /// </summary>
        public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

       /// <summary>
        /// Список заказов клиента
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        /*   /// <summary>
          /// Список продуктов, которые клиент ожидает
          /// </summary>
          public virtual ICollection<ProductWait> ProductWaitCollection { get; set; } = new List<ProductWait>();

          /// <summary>
          /// История просмотров клиента
          /// </summary>
          public virtual ICollection<ViewHistory> ViewHistory { get; set; } = new List<ViewHistory>();

          /// <summary>
          /// Уведомления клиента
          /// </summary>
          public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

          /// <summary>
          /// Список желаний клиента
          /// </summary>
          public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();*/


        /// <summary>
        /// Настройка сущности Customer
        /// </summary>
        public static new void ConfigureEntity(ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Customer>(entity =>
            {
             // Связь с группой клиентов
                entity.HasOne(c => c.CustomerGroup)
                    .WithMany(cg => cg.Customers)
                    .HasForeignKey(c => c.CustomerGroupId)
                    .OnDelete(DeleteBehavior.Restrict);


                /*     // Настройка связи с CustomerPreference (один-к-одному) Связь с предпочтениями клиента
                  entity.HasOne(c => c.CustomerPreference)
                      .WithOne(cp => cp.Customer) // Навигационное свойство в CustomerPreference
                      .HasForeignKey<CustomerPreference>(cp => cp.CustomerId) // Внешний ключ в CustomerPreference
                      .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление


                  // Связь с бонусными баллами
                  entity.HasMany(c => c.LoyaltyPoints)
                      .WithOne(lp => lp.Customer)
                      .HasForeignKey(lp => lp.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                  // Связь с методами оплаты
                  entity.HasMany(c => c.PaymentMethods)
                      .WithOne(pm => pm.Customer)
                      .HasForeignKey(pm => pm.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);*/

                entity.HasMany(c => c.Addresses)
                .WithOne()
                .HasForeignKey(a => new { a.EntityId, a.AddressType }) // Внешние ключи в Address
                .HasPrincipalKey(c => new { c.Id, c.AddressType }) // Основные ключи в Customer
                .OnDelete(DeleteBehavior.Cascade); // Каскадное удаление

               // Связь с заказами
                entity.HasMany(c => c.Orders)
                    .WithOne(o => o.Customer)
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                /*   // Связь с продуктами в списке ожидания
                  entity.HasMany(c => c.ProductWaitCollection)
                      .WithOne(w => w.Customer)
                      .HasForeignKey(w => w.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                  // Связь с историей просмотров
                  entity.HasMany(c => c.ViewHistory)
                      .WithOne(vh => vh.Customer)
                      .HasForeignKey(vh => vh.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                  // Связь с уведомлениями
                  entity.HasMany(c => c.Notifications)
                      .WithOne(n => n.Customer)
                      .HasForeignKey(n => n.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);

                  // Связь с списками желаний
                  entity.HasMany(c => c.WishLists)
                      .WithOne(w => w.Customer)
                      .HasForeignKey(w => w.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);*/
            });
        }
    }
}
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models._Discounts.Loyalty
{ 
    /// <summary>
    /// Программа лояльности, в рамках которой пользователи могут накапливать баллы и повышать уровни.
    /// </summary>
    public class LoyaltyProgram
    {
        /// <summary>
        /// Уникальный идентификатор программы лояльности.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название программы (например "Программа постоянного клиента").
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Количество баллов, которое начисляется по умолчанию за 1 условную денежную единицу.
        /// </summary>
        public int? DefaultPointsPerDollar { get; set; }

        /// <summary>
        /// Коэффициент конвертации баллов в валюту (1 балл = X единиц валюты).
        /// </summary>
        public decimal? PointsToCurrencyRatio { get; set; }

        /// <summary>
        /// Навигационное свойство на уровни лояльности (LoyaltyTier).
        /// </summary>
        public virtual ICollection<LoyaltyTier> LoyaltyTiers { get; set; }
            = new List<LoyaltyTier>();

        /// <summary>
        /// Навигационное свойство на записи, связывающие пользователей с этой программой (UserLoyalty).
        /// </summary>
        public virtual ICollection<UserLoyalty> UserLoyaltyRecords { get; set; }
            = new List<UserLoyalty>();
    }

}

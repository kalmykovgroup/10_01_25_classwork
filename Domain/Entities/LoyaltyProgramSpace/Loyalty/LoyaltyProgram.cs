

using Domain.Entities.Common;
using Domain.Entities.LoyaltyProgramSpace.Loyalty;
using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Loyalty;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.LoyaltyProgramSpace.Loyalty
{ 
    /// <summary>
    /// Программа лояльности, в рамках которой пользователи могут накапливать баллы и повышать уровни.
    /// </summary>
    public class LoyaltyProgram : SeoTranslatableEntity<LoyaltyProgramTranslation, LoyaltyProgram>
    {
        /// <summary>
        /// Уникальный идентификатор программы лояльности.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название программы (например "Программа постоянного клиента").
        /// </summary>
        [NotMapped]
        public string Name => GetTranslation(t => t.Name);

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
        /// Навигационное свойство на записи, связывающие пользователей с этой программой (CustomerLoyalty).
        /// </summary>
        public virtual ICollection<CustomerLoyalty> UserLoyaltyRecords { get; set; }
            = new List<CustomerLoyalty>();

        /// <summary>
        /// Список временных бонусов, связанных с программой лояльности.
        /// </summary>
        public virtual ICollection<LoyaltyBonus> LoyaltyBonuses { get; set; }
            = new List<LoyaltyBonus>();
    }

}

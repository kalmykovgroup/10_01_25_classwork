

using Domain.Entities.Common;
using Domain.Entities.TranslationSpace.TranslationEntities.LoyaltyProgramSpace.Loyalty;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.LoyaltyProgramSpace.Loyalty
{ 

    /// <summary>
    /// Уровень в программе лояльности (например, Bronze, Silver, Gold).
    /// </summary>
    public class LoyaltyTier : TranslatableEntity<LoyaltyTierTranslation, LoyaltyTier>
    {
        /// <summary>
        /// Уникальный идентификатор уровня лояльности.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ссылка на программу лояльности, к которой относится данный уровень.
        /// </summary>
        public Guid LoyaltyProgramId { get; set; }

        /// <summary>
        /// Название уровня (например, "Gold").
        /// </summary>
        [NotMapped]
        public string TierName => GetTranslation(t => t.TierName);

        /// <summary>
        /// Минимальное количество баллов, начиная с которого пользователь попадает на этот уровень.
        /// </summary>
        public int? MinPoints { get; set; }

        /// <summary>
        /// Процент скидки, который даёт данный уровень (например, 5%).
        /// </summary>
        public decimal? DiscountPercentage { get; set; }

        /// <summary>
        /// Множитель баллов (например, x2 для Gold), когда пользователь получает больше баллов за покупку.
        /// </summary>
        public decimal? PointsMultiplier { get; set; }

        /// <summary>
        /// Навигационное свойство: программа лояльности, к которой относится уровень.
        /// </summary>
        public virtual LoyaltyProgram? LoyaltyProgram { get; set; }

        /// <summary>
        /// Навигационное свойство: записи пользователей, у которых текущий уровень = этот уровень.
        /// </summary>
        public virtual ICollection<CustomerLoyalty> UserLoyaltyRecords { get; set; }
            = new List<CustomerLoyalty>();
    }

}

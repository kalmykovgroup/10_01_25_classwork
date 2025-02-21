using Domain.Entities.Common;
using Domain.Entities.TranslationsSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.Common
{
    public class SeoTranslatableEntityConf<TTranslationEntity, TEntity> : TranslatableEntityConf<TTranslationEntity, TEntity>
       where TTranslationEntity : Translation<TEntity>
       where TEntity : TranslatableEntity<TTranslationEntity, TEntity>
    {
        /// <summary>
        /// Это класс не требуется, так как в SeoTranslatableEntity нет полей, а есть методы получения этих полей
        /// например: public string Name => GetTranslation(t => t.Name);
        /// Этот класс существует чтобы не ломать структуру.
        /// ProductEntity -> SeoTranslatableEntity -> TranslatableEntity
        /// ProductConf -> SeoTranslatableEntityConf -> TranslatableEntityConf
        /// Если убрать SeoTranslatableEntityConf, то можно запутаться или даже подумать что допущена ошибка.   
        /// </summary>
        /// <param name="modelBuilder"></param>
        public SeoTranslatableEntityConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
        }
    }
}

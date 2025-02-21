using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities.TranslationsSpace;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Domain.Entities.CategorySpace;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace.TranslationEntities.CategorySpace
{
    public class CategoryTranslationConf : SeoTranslationConf<CategoryTranslation, Category>
    {
        public CategoryTranslationConf(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<CategoryTranslation>(entity =>
            {
 
                entity.Property(c => c.Name).HasColumnName("name").IsRequired().HasMaxLength(255);
                entity.Property(c => c.Description).HasColumnName("description").IsRequired(false).HasMaxLength(1000);
            });
        }

      
    }
}

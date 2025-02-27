﻿using Domain.Entities.CategorySpace;
using Domain.Entities.TranslationsSpace;
using Infrastructure.Data.ConfigurationsEntity.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.CategorySpace
{
    public class CategoryConfig : SeoTranslatableEntityConf<CategoryTranslation, Category>
    {
        public CategoryConfig(ModelBuilder modelBuilder) : base(modelBuilder)
        {
            modelBuilder.Entity<Category>(entity => {

                entity.ToTable("categories");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id).HasColumnName("id");

                entity.Property(c => c.ParentCategoryId).IsRequired(false).HasColumnName("parent_category_id");

                entity.Property(c => c.IsActive).HasColumnName("is_active").HasDefaultValue(true);

                entity.Property(c => c.ImageUrl).HasColumnName("image_url").HasMaxLength(2048);

                entity.Property(c => c.Level).HasColumnName("level").IsRequired();

                entity.Property(c => c.FullPath).HasColumnName("full_path").HasMaxLength(1000);

                // Настройка связи с родительской категорией
                entity.HasOne(e => e.ParentCategory)
                    .WithMany(e => e.SubCategories)
                    .HasForeignKey(e => e.ParentCategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
                  
                 
                entity.HasIndex(e => e.FullPath).HasDatabaseName("IX_Category_FullPath");

            });
        }   
    }
}

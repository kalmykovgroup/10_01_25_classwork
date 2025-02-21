using Domain.Entities.TranslationSpace;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.TranslationSpace
{
    public class LanguageConf
    {
        public LanguageConf(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("languages");

                entity.HasKey(l => l.Code); // Делаем `Code` первичным ключом

                entity
                    .Property(l => l.Code)
                    .HasColumnName("code")
                    .HasColumnType("varchar(10)"); // Делаем `Code` строковым

                entity.Property(l => l.Name)
                     .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsRequired();
            });
        }
    }
}

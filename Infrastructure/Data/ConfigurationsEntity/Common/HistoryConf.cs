using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.ConfigurationsEntity.Common
{
    public class HistoryConf
    {
        public HistoryConf(ModelBuilder modelBuilder) {

            modelBuilder.Entity<History>(entity =>
            {
                entity.ToTable("histories");

                entity.HasKey(cl => cl.Id);

                entity.Property(cl => cl.TableName)
                    .HasColumnName("table_name")
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(cl => cl.RecordId)
                    .HasColumnName("record_id")
                    .HasColumnType("text")
                    .IsRequired();

                entity.Property(cl => cl.ChangeType)
                    .HasColumnName("change_type")
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(cl => cl.ChangeDate)
                    .HasColumnName("change_date")
                    .IsRequired();

                entity.Property(cl => cl.OldData)
                    .HasColumnName("old_data")
                    .HasColumnType("jsonb") // если PostgreSQL, иначе "nvarchar(max)" для MSSQL
                    .IsRequired(false);

                entity.Property(cl => cl.NewData)
                    .HasColumnName("new_data")
                    .HasColumnType("jsonb")
                    .IsRequired(false);

                entity.Property(cl => cl.UserId)
                    .HasColumnName("user_id")
                    .IsRequired(false);
            });
        }
    }
}

using Ivan1.Database.Helpers;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ivan1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ivan1.Database.Configurations
{
    public class DisciplineConfigurations : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";
        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder
                .HasKey(p => p.DisciplineID)
                .HasName($"pk_{TableName}_discipline_id");
            //автогенерация первичного ключа (Целочисленный)
            builder.Property(p => p.DisciplineID)
                .ValueGeneratedOnAdd();

            //расписываем названия колонок в бд и их обязательгность и тд и тп
            builder.Property(p => p.DisciplineID)
                .HasColumnName("discipline_id")
                .HasComment("Идентефикатор записи группы");

            builder.Property(p => p.DisciplineName)
                .IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);
            builder.ToTable(TableName);

        }
    }
}

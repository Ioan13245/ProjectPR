using Ivan1.Database.Helpers;
using Ivan1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ivan1.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .HasKey(p => p.GroupId)
                .HasName($"pk_{TableName}_group_id");
            //автогенерация первичного ключа (Целочисленный)
            builder.Property(p => p.GroupId)
                .ValueGeneratedOnAdd();

            //расписываем названия колонок в бд и их обязательгность и тд и тп
            builder.Property(p => p.GroupId)
                .HasColumnName("group_id")
                .HasComment("Идентефикатор записи группы");

            builder.Property(p => p.GroupName)
                .IsRequired()
                .HasColumnName("c_group_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.DisciplineID)
                .IsRequired()
                .HasColumnName("c_group_id");

            builder.ToTable(TableName)
                .HasOne(p => p.Discipline)
                .WithMany()
                .HasForeignKey(p => p.DisciplineID)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_discipline_id");

            builder.Navigation(p => p.Discipline)
                .AutoInclude();
        }
    }
}

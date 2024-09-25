using Ivan1.Database.Helpers;
using Ivan1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Ivan1.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //первичный ключ
            builder
                .HasKey(p => p.StudentId)
                .HasName($"pk_{TableName}_student_id");
            //автогенерация первичного ключа (Целочисленный)
            builder.Property(p => p.StudentId)
                .ValueGeneratedOnAdd();

            //расписываем названия колонок в бд и их обязательгность и тд и тп
            builder.Property(p => p.StudentId)
                .HasColumnName("student_id")
                .HasComment("Идентефикатор записи студента");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("c_student_first_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("c_student_last_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("c_student_middle_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100);

            builder.ToTable(TableName)
                .HasOne(p => p.Group)
                .WithMany()
                .HasForeignKey(p => p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable(TableName)
                .HasIndex(p => p.GroupId, $"idx_{TableName}_fk_f_group_id");

            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}

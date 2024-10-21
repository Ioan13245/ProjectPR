using Ivan1.Database.Configurations;
using Ivan1.Database.Configurations;
using Ivan1.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivan1.Database
{
    public class StudentDbContext : DbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfigurations());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}

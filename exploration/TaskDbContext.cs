using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tasks.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Category)
                .HasMaxLength(50)
                .HasDefaultValue("Allgemein");

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.Priority)
                .HasDefaultValue(1);

            modelBuilder.Entity<TaskItem>()
                .Property(t => t.DueDate)
                .IsRequired(false);
        }
    }
}

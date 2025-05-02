using Microsoft.EntityFrameworkCore;
using System;
using TaskManager.Models;

namespace TaskManager.Services
{
    public class TaskDbContext : DbContext
    {
        public DbSet<TaskItem> Tasks { get; set; }

        // Konfiguriere die Datenbankverbindung
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // SQLite-Datenbankdatei im aktuellen Verzeichnis
            optionsBuilder.UseSqlite("Data Source=tasks.db");
        }

        // Konfiguriere das Datenmodell
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
        }
    }
}

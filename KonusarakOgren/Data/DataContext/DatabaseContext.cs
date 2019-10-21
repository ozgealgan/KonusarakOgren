using KonusarakOgren.Data.Entities;
using KonusarakOgren.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace KonusarakOgren.Data.DataContext
{
    public class DatabaseContext : DbContext
    {
        private static bool _created = false;
        public DatabaseContext()
        {
            if (!_created)
            {
                _created = true;
                //Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "./Data/Database/database.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBuilder.UseSqlite(connection);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>()
                        .HasMany(q => q.Options)
                        .WithOne(o => o.Question)
                        .IsRequired();

            modelBuilder.Entity<Exam>()
                        .HasMany(e => e.Questions)
                        .WithOne(q => q.Exam)
                        .IsRequired();
        }

    }
}


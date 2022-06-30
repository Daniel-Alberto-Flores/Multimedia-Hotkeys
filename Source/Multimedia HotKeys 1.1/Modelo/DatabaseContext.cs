using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "FileName=" + System.Environment.CurrentDirectory + "\\Database.db",
                sqliteOptionsAction: op =>
                {
                    op.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName
                        );
                });            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>().ToTable("Configurations");
            modelBuilder.Entity<Configuration>(entity =>
            {
                entity.HasKey(e => e.Id);
            });
            modelBuilder.Entity<HotKey>().ToTable("Hotkeys");
            modelBuilder.Entity<HotKey>(entity =>
            {
                entity.HasKey(e => e.Name);
            });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<HotKey> HotKeys { get; set; }
    }
}

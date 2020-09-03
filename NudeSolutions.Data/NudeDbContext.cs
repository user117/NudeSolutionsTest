using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NudeSolutions.Shared;
namespace NudeSolutions.Data
{
    public class NudeDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=C:/Temp/nude.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>();
        }
    }
}
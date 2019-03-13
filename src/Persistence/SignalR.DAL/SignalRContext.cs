using System;
using SignalR.Entities;
using Microsoft.EntityFrameworkCore;

namespace SignalR.DAL
{
    public class SignalRContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DBPrueba");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryID);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductID);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasMaxLength(80)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductName)
                .HasMaxLength(200)
                .IsRequired();

        }
    }
}
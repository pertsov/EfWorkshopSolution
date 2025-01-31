using CompanyApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Entity configurations can be moved to separate classes if preferred
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                entity.HasMany(e => e.Orders).WithOne(o => o.Customer).HasForeignKey(o => o.CustomerId);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.HasMany(o => o.OrderItems).WithOne(oi => oi.Order).HasForeignKey(oi => oi.OrderId);
                entity.Property(o => o.TotalAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.OrderItemId);
                entity.HasOne(oi => oi.Product).WithMany().HasForeignKey(oi => oi.ProductId);
                entity.Property(oi => oi.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Price).HasColumnType("decimal(18, 2)");
            });
        }
    }
}

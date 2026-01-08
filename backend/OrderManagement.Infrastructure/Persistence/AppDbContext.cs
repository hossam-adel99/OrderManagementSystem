using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Order
            modelBuilder.Entity<Order>(builder =>
            {
                builder.HasKey(o => o.Id);
                builder.Ignore(o => o.Total);
            });

            // Product
            modelBuilder.Entity<Product>(builder =>
            {
                builder.HasKey(p => p.Id);

                builder.OwnsOne(p => p.Price, money =>
                {
                    money.Property(m => m.Amount)
                         .HasPrecision(18, 2);
                });
            });

            // OrderItem
            modelBuilder.Entity<OrderItem>(builder =>
            {
                builder.HasKey(oi => new { oi.OrderId, oi.ProductId });

                builder.HasOne(oi => oi.Order)
                       .WithMany(o => o.Items)
                       .HasForeignKey(oi => oi.OrderId);

                builder.HasOne(oi => oi.Product)
                       .WithMany(p => p.OrderItems)
                       .HasForeignKey(oi => oi.ProductId);

                builder.OwnsOne(oi => oi.UnitPrice, money =>
                {
                    money.Property(m => m.Amount)
                         .HasPrecision(18, 2);
                });
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}

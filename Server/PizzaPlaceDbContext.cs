using Microsoft.EntityFrameworkCore;
using PizzaPlace.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaPlace.Server
{
    public class PizzaPlaceDbContext: DbContext
    {
        public PizzaPlaceDbContext(DbContextOptions<PizzaPlaceDbContext> options):base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PizzaOrder> PizzaOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pizzaEntity = modelBuilder.Entity<Pizza>();
            pizzaEntity.HasKey(pizza => pizza.Id);
            pizzaEntity.Property(pizza => pizza.Price).HasColumnType("DECIMAL(10,2)");
            pizzaEntity.Property(pizza => pizza.Name).HasMaxLength(20);

            var customerEntity = modelBuilder.Entity<Customer>();
            customerEntity.HasOne(customer => customer.Order)
                .WithOne(order => order.Customer)
                .HasForeignKey<Order>(order => order.CustomerId);
            customerEntity.Property(customer => customer.Name).HasMaxLength(20);
            customerEntity.Property(customer => customer.Street).HasMaxLength(200);
            customerEntity.Property(customer => customer.City).HasMaxLength(200);


            var orderEntity = modelBuilder.Entity<Order>();
            orderEntity.HasMany(order => order.PizzaOrders)
                .WithOne(pizzaOrder => pizzaOrder.Order);
            orderEntity.Property(order => order.TotalPrice).HasColumnType("DECIMAL(10,2)");
            pizzaEntity.HasMany(pizza => pizza.PizzaOrders)
                .WithOne(pizzaOrder => pizzaOrder.Pizza);
        }
    }
}

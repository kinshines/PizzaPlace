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
            Database.EnsureCreated();
        }

        public DbSet<Pizza> Pizzas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var pizzaEntity = modelBuilder.Entity<Pizza>();
            pizzaEntity.HasKey(pizza => pizza.Id);
            pizzaEntity.Property(pizza => pizza.Price).HasColumnType("DECIMAL(10,2)");
            pizzaEntity.Property(pizza => pizza.Name).HasMaxLength(20);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;

namespace BTS.Test.DataContext
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Shopping> Shoppings { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SHOPPING_CONNECTION_STRING") ?? throw new Exception("No connection string setup"));
            }
        }
    }
}

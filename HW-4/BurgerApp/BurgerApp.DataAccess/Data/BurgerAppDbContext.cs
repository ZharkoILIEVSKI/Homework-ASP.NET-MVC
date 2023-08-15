using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Data
{
    public class BurgerAppDbContext : DbContext
    {
        public BurgerAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Order> Orders{ get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Burger> Burgers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BurgerApp;Trusted_Connection=True;MultipleActiveResultSets=true");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.BurgerId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.Id);

            modelBuilder.Entity<Burger>()
                .HasMany(x => x.BurgerOrders)
                .WithOne(x => x.Burger)
                .HasForeignKey(x => x.BurgerId);

            modelBuilder.Entity<Burger>()
                    .HasData(
                            new Burger
                            {
                                Id = 1,
                                Name = "Hamburger",
                                Price = 200,
                                IsVegetarian = false,
                                IsVegan = false,
                                HasFries = true,
                            },

                            new Burger
                            {
                                Id = 2,
                                Name = "CheeseBurger",
                                Price = 220,
                                IsVegetarian = false,
                                IsVegan = false,
                                HasFries = true,
                            },

                            new Burger
                            {
                                Id = 3,
                                Name = "ChickenBurger",
                                Price = 240,
                                IsVegetarian = false,
                                IsVegan = false,
                                HasFries = true,
                            }
                            );

            modelBuilder.Entity<Order>()
                .HasData(
                            new Order
                            {
                                Id = 1,
                                FullName = "Bojan Bojanovski",
                                Address = "Praska 22",
                                IsDelivered = false,
                                OrderLocation = "BurgerStore N'1",
                            },
                            new Order
                            {
                                Id = 2,
                                FullName = "Svetle Svetlanosvka",
                                Address = "Alzirska 33",
                                IsDelivered = false,
                                OrderLocation = "BurgerStore N'2",
                            }
                );
        }

        


    }
}

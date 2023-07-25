using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess
{
    public class StaticDb
    {
        public static int BurgerId { get; set; }
        public static int OrderId { get; set; }
        public static int UserId { get; set; }
        public static List<Burger> Burgers { get; set; }
        public static List<Order> Orders { get; set; }
        public static List<User> Users { get; set; }
        public StaticDb()
        {
            BurgerId = 3;
            OrderId = 2;
            UserId = 2;

            Burgers = new List<Burger>
            {
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
                },
            };

            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    FullName = "Bojan Bojanovski",
                    Address = "Praska 22",
                    IsDelivered = false,
                    BurgerOrder = new List<BurgerOrder>
                    {
                        new BurgerOrder
                        {
                            Burger = Burgers[0],
                            BurgerId = Burgers[0].Id,
                            OrderId = Orders[0].Id,
                        },
                    },
                    OrderLocation = "BurgerStore N'1",
                },
                new Order
                {
                    Id=2,
                    FullName = "Svetle Svetlanosvka",
                    Address = "Alzirska 33",
                    IsDelivered = false,
                    BurgerOrder= new List<BurgerOrder> 
                    {
                        new BurgerOrder
                        {
                            Burger = Burgers[1],
                            BurgerId = Burgers[1].Id,
                            OrderId = Orders[1].Id
                        },
                    },
                     OrderLocation = "BurgerStore N'2",
                },
            };

            Users = new List<User>
            {
                new User
                {
                    Id = 1,
                    FullName = "Bojan Bojanovski",
                    Address = "Praska 22",
                    Orders = new List<Order> {}
                },
                new User
                {
                    Id = 2,
                    FullName = "Svetle Svetlanovska",
                    Address = "Alzirska 33",
                    Orders = new List<Order> {}
                }
            };
            
        }

        


    }
}

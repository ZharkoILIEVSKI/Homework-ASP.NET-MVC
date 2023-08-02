using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Abstraction;
using BurgerApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Repositories.Implementation.StaticDbImplementation
{
    public class OrderRepository : IRepository<Order>
    {
        public void DeleteById(int id)
        {
            Order order = StaticDb.Orders.FirstOrDefault(o => o.Id == id);
            StaticDb.Orders.Remove(order);
        }

        public List<Order> GetAll()
        {
            return StaticDb.Orders;
        }

        public Order GetById(int id)
        {
            return StaticDb.Orders.FirstOrDefault(order => order.Id ==  id);

        }

        public int Insert(Order entity)
        {
            entity.Id = ++StaticDb.OrderId;
            return entity.Id;
        }

        public int Update(Order entity)
        {
            Order order = StaticDb.Orders.FirstOrDefault(order => order.Id == entity.Id);
            int index = StaticDb.Orders.IndexOf(order);
            StaticDb.Orders[index] = entity;
        }
    }
}

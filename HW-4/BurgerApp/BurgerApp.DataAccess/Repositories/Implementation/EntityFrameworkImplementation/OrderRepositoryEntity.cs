using BurgerApp.DataAccess.Data;
using BurgerApp.DataAccess.Repositories.Abstraction;
using BurgerApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.DataAccess.Repositories.Implementation.EntityFrameworkImplementation
{
    public class OrderRepositoryEntity : IRepository<Order>
    {
        private BurgerAppDbContext _burgerAppDbContext;

        public OrderRepositoryEntity(BurgerAppDbContext burgerAppDbContext)
        {
            _burgerAppDbContext = burgerAppDbContext;
        }
        public void DeleteById(int id)
        {
            Order orderDb = _burgerAppDbContext.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found!");
            }
            _burgerAppDbContext.Orders.Remove(orderDb);
            _burgerAppDbContext.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return _burgerAppDbContext
                   .Orders
                   .Include(x => x.BurgerOrders)
                   .ThenInclude(x => x.Burger)
                   .Include(x => x.User)
                   .ToList();
        }

        public Order GetById(int id)
        {
            return _burgerAppDbContext
                    .Orders
                    .Include(x => x.BurgerOrders)
                    .ThenInclude(x => x.Burger)
                    .Include(x => x.User)
                    .FirstOrDefault(x => x.Id == id)!;
        }

        public int Insert(Order entity)
        {
            _burgerAppDbContext.Orders.Add(entity);
            return _burgerAppDbContext.SaveChanges();   
        }

        public int Update(Order entity)
        {
            _burgerAppDbContext.Orders.Update(entity);
            return _burgerAppDbContext.SaveChanges();   
        }
    }
}

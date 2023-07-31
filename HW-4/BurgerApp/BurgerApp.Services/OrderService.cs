using BurgerApp.Services.Abstraction;
using BurgerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Services
{
    public class OrderService : IOrderService
    {
        public void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel)
        {
            throw new NotImplementedException();
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<OrderListViewModel> GetAll(int orderId)
        {
            throw new NotImplementedException();
        }

        public OrderDetailsViewModel GetOrderDetails(int orderId)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            throw new NotImplementedException();
        }
    }
}

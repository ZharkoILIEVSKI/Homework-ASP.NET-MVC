using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BurgerApp.ViewModels;

namespace BurgerApp.Services.Abstraction
{
    public interface IOrderService
    {
        List<OrderListViewModel> GetAll(); 
        OrderDetailsViewModel GetOrderDetails(int orderId);
        void CreateOrder(OrderViewModel orderViewModel);
        void DeleteOrder(int orderId);
        void UpdateOrder(OrderViewModel orderViewModel);
        void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel);
    }
}

using BurgerApp.Domain.Models;
using BurgerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BurgerApp.Mappers.Extensions
{
    public static class OrderMapper
    {
        public static OrderViewModel MapToOrderViewModel(this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                IsDelivered = order.IsDelivered,
            };
        }
        public static OrderDetailsViewModel MapToOrderDetailsViewModel(this Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                FullName = order.FullName,
                Location = order.OrderLocation,
                BurgerNames = order.BurgerOrders.Select(x => x.Burger.Name).ToList(),
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel ) 
        {
            return new Order
            {
                Id = orderViewModel.Id,
                FullName = orderViewModel.FullName,
                IsDelivered = orderViewModel.IsDelivered,
                OrderLocation = orderViewModel.Location,
                BurgerOrders = new List<BurgerOrder>(),
            };
        }

        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                Delivered = order.IsDelivered,
                UserFullName = $"{order.FullName.FullName}",
                BurgerNames = order.BurgerOrders.Select(po => po.Burger.Name).ToList()
            };
        }
}
}

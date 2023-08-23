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
                Location = order.Location,
                BurgerNames = order.Burgers.Select(x => x.Name).ToList(),
            };
        }

        public static Order MapToOrder(this OrderViewModel orderViewModel ) 
        {
            return new Order
            {
                Id = orderViewModel.Id,
                FullName = orderViewModel.FullName,
                IsDelivered = orderViewModel.IsDelivered,
                Location = orderViewModel.Location,
                Burgers = new List<Burger>(),
            };
        }

        public static OrderListViewModel MapToOrderListViewModel(this Order order)
        {
            return new OrderListViewModel
            {
                Id = order.Id,
                Delivered = order.IsDelivered,
                UserFullName = $"{order.FullName}",
                BurgerNames = order.Burgers.Select(x => x.Name).ToList()
            };
        }
}
}

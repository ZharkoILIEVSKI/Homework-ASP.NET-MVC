using BurgerApp.DataAccess.Repositories.Abstraction;
using BurgerApp.Domain.Models;
using BurgerApp.Mappers.Extensions;
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
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;
        private IBurgerRepository _burgerRepository;

        public OrderService(IRepository<Order> orderRepository,
                            IRepository<User> userRepository,
                            IBurgerRepository burgerRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _burgerRepository = burgerRepository;
        }

        public void AddBurgerToOrder(BurgerOrderViewModel burgerOrderViewModel)
        {
            var burgerDb = _burgerRepository.GetById(burgerOrderViewModel.Id);
            if (burgerDb == null)
            {
                throw new Exception($"Burger with id {burgerOrderViewModel.Id} was not found");
            }

            var orderDb = _orderRepository.GetById(burgerOrderViewModel.OrderId);
            if (orderDb == null)
            {
                throw new Exception($"Order with id {burgerOrderViewModel.OrderId} was not found.");
            }

            var burgerOrder = new BurgerOrder
            {
                Burger = burgerDb,
                BurgerId = burgerDb.Id,
                OrderId = orderDb.Id,
            };
            orderDb.BurgerOrders.Add(burgerOrder);
            _orderRepository.Update(orderDb);
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if (userDb == null)
            {
                throw new Exception($"User with id {orderViewModel.UserId} was not found");
            }
            Order order = orderViewModel.MapToOrder();
            order.FullName = userDb;
        }

        public void DeleteOrder(int orderId)
        {
            Order orderDb = _orderRepository.GetById(orderId);
            if(orderDb == null)
            {
                throw new Exception($"The order with id {orderId} was not found");
            }
            _orderRepository.DeleteById(orderId);
        }

        public List<OrderListViewModel> GetAll(int orderId)
        {
            List<Order> dbOrders = _orderRepository.GetAll();
            return dbOrders.Select(order => order.MapToOrderListViewModel()).ToList();
        }

        public OrderDetailsViewModel GetOrderDetails(int orderId)
        {
            Order orderDb = _orderRepository.GetById(orderId);
            if(orderDb == null)
            {
                throw new Exception($"The order with id {orderId} was not found");
            }

            return orderDb.MapToOrderDetailsViewModel();
        }

        public void UpdateOrder(OrderViewModel orderViewModel)
        {
            Order orderDb = _orderRepository.GetById(orderViewModel.Id);
            if (orderDb == null)
            {
                throw new Exception($"The order with id {orderViewModel.Id} was not found.");
            }

            User userDb = _userRepository.GetById(orderViewModel.UserId);
            if (userDb == null)
            {
                throw new Exception($"The user with id {orderViewModel.UserId} was not found.");
            }
            Order editOrder = orderViewModel.MapToOrder();
            editOrder.FullName = userDb;
            editOrder.Id = orderViewModel.Id;
            editOrder.BurgerOrders = orderDb.BurgerOrders;
            _orderRepository.Update(editOrder);
        }
    }
}

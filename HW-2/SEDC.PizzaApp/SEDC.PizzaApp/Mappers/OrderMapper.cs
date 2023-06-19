using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Mappers
{
    public static class OrderMapper
    {
        public static OrderViewModel ToOrderViewModel(Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
                FirstName = order.User.FirstName,
                LastName = order.User.LastName,
                PhoneNumber = order.User.PhoneNumber,
                UserAddress = order.User.Address,
            };
        }
    }
}

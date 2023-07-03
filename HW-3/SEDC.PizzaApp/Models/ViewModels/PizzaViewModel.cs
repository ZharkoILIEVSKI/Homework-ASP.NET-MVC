using SEDC.PizzaApp.Models.Enums;

namespace SEDC.PizzaApp.Models.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PizzaSize PizzaSize { get; set; }
        public bool IsOnPromotion { get; set; }
    }
}

//Create PizzaViewModel and refator pizza controller to use view models instead of domain models, including mappers :)


using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            List<PizzaViewModel> pizzaList = new List<PizzaViewModel>()
            {
                new PizzaViewModel
                {
                    Id = 1,
                    Name = StaticDb.Pizzas.First().Name,
                    Price = StaticDb.Pizzas.First().Price,
                    PizzaSize = StaticDb.Pizzas.First().PizzaSize
                },
                new PizzaViewModel
                {
                    Id = 2,
                    Name = StaticDb.Pizzas.Last().Name,
                    Price = StaticDb.Pizzas.Last().Price,
                    PizzaSize = StaticDb.Pizzas.Last().PizzaSize
                }
            };
            
            return View(pizzaList);
        }
        public IActionResult GetPizzas() 
        {
            var pizzas = StaticDb.Pizzas;
            return View(pizzas);
            
        }

        public IActionResult Details(int? id)
        {
            if (!(id == null))
            {
                return View();
            }
            else
            return new EmptyResult();
        }

        public IActionResult Details(bool IsOnPromotion)
        {
            if (IsOnPromotion)
            {
                return View();
            }
            if (!IsOnPromotion)
            {
                return new EmptyResult();
            }
        }

    }
}

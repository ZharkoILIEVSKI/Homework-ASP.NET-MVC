using Microsoft.AspNetCore.Mvc;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("ListOrders")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("Order/Details/{id?}")]
        public IActionResult Details(int? id)
        {
            if (id == 0)
            {
                return new EmptyResult();
            }
            else
            {
                return View();
            } 
        }

        [Route("Order/JsonData")]
        public IActionResult GetJson()
        {
            var order = new { id = 3, IsDelivered = false };
            return new JsonResult(order);
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}

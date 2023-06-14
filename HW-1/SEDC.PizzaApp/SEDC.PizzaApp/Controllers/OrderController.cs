using Microsoft.AspNetCore.Mvc;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        [Route("https://localhost:7252/ListOrders")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("https://localhost:7252/Order/Details{id?}")]
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

        [Route("https://localhost:7252/Order/JsonData")]
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

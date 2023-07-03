using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models;
using System.Diagnostics;

namespace SEDC.PizzaApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact() 
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        //Add a SeeUsers action in the Home controller.This action should return a view that shows all the full names of the users in the system.

        public IActionResult SeeUsers() 
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
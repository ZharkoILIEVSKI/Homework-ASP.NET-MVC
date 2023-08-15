using BurgerApp.Services.Abstraction;
using BurgerApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BurgerApp.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        // private IUserService _userService;
        private IBurgerService _burgerService;
        
        public OrderController(IOrderService orderService, 
                                //IUserService userService,
                                IBurgerService burgerService)
        {
            _orderService = orderService;
            _burgerService = burgerService;
            //_userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
           List<OrderListViewModel> orderListViewModels = _orderService.GetAll();
           return View(orderListViewModels);
        }

        [HttpGet]
        
        public IActionResult Details(int? id) 
        {
            if (id == null)
            {
                return View("Very Bad Request");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception ex)
            {
                return View("ExeceptionPage");
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            OrderViewModel orderViewModel = new OrderViewModel();
            //ViewBag.Users = _userService.GetUsers();
            return View(orderViewModel);
        }

        [HttpPost]
        public IActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.CreateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("ExeptionPage");
            }
        }

        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderViewModel model = _orderService.UpdateOrder(id.Value);
                //ViewBag.Users = _userService.GetUsersFromDropdown();

                return View(model);
            }
            catch(Exception ex)
            {
                return View("ResourceNotFound");
            }
        }

        [HttpPost]
        public IActionResult Edit(OrderViewModel orderViewModel)
        {
            try
            {
                _orderService.UpdateOrder(orderViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ResourceNotFound");
            }
        }

        [HttpGet]
        public IActionResult Delete(int? id) 
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderDetails(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception ex)
            {
                return View("ExceptionPage");
            }
        }

        [HttpPost]
        public IActionResult Delete(OrderDetailsViewModel orderDetailsViewModel)
        {
            try
            {
                _orderService.DeleteOrder(orderDetailsViewModel.Id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View("ExceptionPage");
            }

        }

        [HttpGet]
        public IActionResult AddBurger(int id)
        {
            BurgerOrderViewModel burgerOrderViewModel = new BurgerOrderViewModel();
            burgerOrderViewModel.OrderId = id;
            ViewBag.Burgers = _burgerService.GetBurgersFromDropDown();
            return View(burgerOrderViewModel);
        }


        [HttpGet]
        public IActionResult AddBurger(BurgerOrderViewModel burgerOrderViewModel ) 
        {
            try
            {
                _orderService.AddBurgerToOrder(burgerOrderViewModel);
                return RedirectToAction("Details", new {id = burgerOrderViewModel.OrderId});
            }
            catch (Exception ex)
            {
                return View("ExceptionPage");
            }
        }
    }
}


using Microsoft.AspNetCore.Mvc;

namespace Taxi.Web.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Index";
            
            return View();
        }
        
        [HttpGet("Login")]
        public IActionResult Login()
        {
            ViewBag.Title = "Login";
            
            return View();
        }

        [HttpGet("Drivers/{id}")]
        public IActionResult Drivers(string id)
        {
            ViewBag.Title = "Drivers";
            
            return View();
        }
        
        [HttpGet("Orders/{id}")]
        public IActionResult Orders(string id)
        {
            ViewBag.Title = "Orders";
            
            return View();
        }
        
        [HttpGet("Drivers/New/{id}")]
        public IActionResult NewDriver(string id)
        {
            ViewBag.Title = "New driver";
            
            return View();
        }
    }
}
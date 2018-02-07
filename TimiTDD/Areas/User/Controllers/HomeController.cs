using Microsoft.AspNetCore.Mvc;

namespace TimiTDD.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }
    }
}
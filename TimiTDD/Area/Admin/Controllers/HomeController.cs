using Microsoft.AspNetCore.Mvc;

namespace TimiTDD.Area.Admin.Controllers
{
    //Default index page
    //returns the view
    public class HomeController : AreaController
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        } 
    }
}
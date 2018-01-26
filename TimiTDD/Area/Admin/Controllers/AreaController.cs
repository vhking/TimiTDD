using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TimiTDD.Area.Admin.Controllers
{
    //Modifies Area and Role Authorization
    //inherits the base class for an MVC controller with view support
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AreaController : Controller
    {
        
    }
}
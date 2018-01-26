using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimiTDD.Models;

namespace TimiTDD.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private int wId;

        public HomeController(UserManager<ApplicationUser> usermanager)
        {          
            _userManager = usermanager;           
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Check if the user is logged in or not. Sends the user to its area based on role.
            var user = await GetCurrentUserAsync();
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {               
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("User"))
                {
                    return RedirectToAction("Index", "Work", new { area = "User" });
                }
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                return View();
            }
            else
            {
                return View();
            }
                      
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Helpers
        private async Task<ApplicationUser> GetCurrentUserAsync()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }       
        #endregion
    }
}

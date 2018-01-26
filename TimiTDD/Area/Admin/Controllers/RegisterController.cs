using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimiTDD.Data;
using TimiTDD.Models;
using TimiTDD.Models.AccountViewModel;

namespace TimiTDD.Area.Admin.Controllers
{
    /**
      Controller for registering users
    */
    class RegisterController : AreaController
    {
        private readonly UserManager<ApplicationUser> _userManager;       
        private readonly  RoleManager<ApplicationRole> _roleManager;
      
        public RegisterController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;          
        }

        //Gets all active users from db
        //Returns them to the view as a list
        [HttpGet]
        public IActionResult Index()
        {
            List<UserListViewModel> model = new List<UserListViewModel>();
            if (model != null)
            {
                model = _userManager.Users.Select(u => new UserListViewModel
                {
                    Id = u.Id,
                    UserId = u.UserId,
                    Name = u.Name,
                    UserName = u.UserName

                }).ToList();
                return View(model);
            }

            return View();


        }

        //Get all available roles
        //Returns them to the view as a list
        [HttpGet]
        public IActionResult Create()
        {
            RegisterViewModel model = new RegisterViewModel
            {
                Roles = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id
                }).ToList()
            };
            return View(model);
            
        }

        //Checks if the values in the form are valid
        //Checks if the creation is succssful
        //Checks if role id value is valid
        //Cechks if the creation of the user and role are successful        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {                  
                    UserId = model.UserId,
                    Name = model.Name,
                    UserName = model.UserName                   
                    
                };

                // cheack if the user is added to the database
                IdentityResult result = _userManager.CreateAsync(user, model.Password).Result;
                if (result.Succeeded)
                {
                    ApplicationRole applicationRole = await _roleManager.FindByIdAsync(model.RoleId);
                    if (applicationRole != null)
                    {
                        // check if the role is added to the database
                        IdentityResult roleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                        if (roleResult.Succeeded)
                        {
                            return RedirectToAction("Index");

                        }                       
                    }                   
                }               
            }
            return View(model);
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimiTDD.Models;
using TimiTDD.Models.AccountViewModels;

namespace TimiTDD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

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

        // Returns the Create form with available roles 
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

        //Create User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {                  
                    UserId = registerViewModel.UserId,
                    Name = registerViewModel.Name,
                    UserName = registerViewModel.UserName                   
                    
                };

                // cheack if the user is added to the database
                IdentityResult result = _userManager.CreateAsync(user, registerViewModel.Password).Result;
                if (result.Succeeded)
                {
                    ApplicationRole applicationRole = await _roleManager.FindByIdAsync(registerViewModel.RoleId);
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
            return View(registerViewModel);
        }

        //get user
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            EditUserViewModel model = new EditUserViewModel
            {
                Roles = _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Id
                }).ToList()
            };

            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    model.UserId = user.UserId;
                    model.Name = user.Name;
                    model.UserName = user.UserName;
                    model.Addr = user.Addr;
                    model.City = user.City;
                    model.ZIP = user.ZIP;
                    model.Title = user.Title;
                    model.RoleId = _roleManager.Roles.Single(r => r.Name == _userManager.GetRolesAsync(user).Result.Single()).Id;
                
                }
            }
            return View(model);
        }


        //Edit user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    user.Name = model.Name;
                    user.UserName = model.UserName;
                    user.Addr = model.Addr;
                    user.City = model.City;
                    user.ZIP = model.ZIP;
                    user.Title = model.Title;
                    string existingRole = _userManager.GetRolesAsync(user).Result.Single();
                    string existingRoleId = _roleManager.Roles.Single(r => r.Name == existingRole).Id;
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        if (existingRoleId != model.RoleId)
                        {
                            IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, existingRole);
                            if (roleResult.Succeeded)
                            {
                                ApplicationRole applicationRole = await _roleManager.FindByIdAsync(model.RoleId);
                                if (applicationRole != null)
                                {
                                    IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                                    if (newRoleResult.Succeeded)
                                    {
                                        return RedirectToAction("Index");
                                    }
                                }
                            }
                        }
                        return RedirectToAction("Index");
                    }                   
                }
            }
            return View(model);
        }

        //get user
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            string name = string.Empty;
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    name = applicationUser.Name;
                }
            }
            return View(name);
        }

        //delete user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id, IFormCollection form)
        {
            if (!String.IsNullOrEmpty(id))
            {
                ApplicationUser applicationUser = await _userManager.FindByIdAsync(id);
                if (applicationUser != null)
                {
                    IdentityResult result = await _userManager.DeleteAsync(applicationUser);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");

                    }
                }
            }
            return View();
        }

        #region Helpers
        private Task<ApplicationUser> GetCurrentUserAsync()
        {

            return _userManager.GetUserAsync(HttpContext.User);

        }
        private string GetCurrentUserId()
        {
            var currentUser = GetCurrentUserAsync();
            var userId = currentUser?.Id;

            return userId.ToString();

        }

        #endregion


    }
    
}
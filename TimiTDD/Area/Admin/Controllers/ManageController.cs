using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimiTDD.Models;
using TimiTDD.Models.AccountViewModel;

namespace TimiTDD.Area.Admin.Controllers
{
    class ManageController : AreaController
    {
        /**
            Controller for managing all the user accounts
         */
        private readonly UserManager<ApplicationUser> _userManager;      
        private readonly  RoleManager<ApplicationRole> _roleManager;        

        public ManageController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;          
        }
        
        //Get the user and the its role
        //Returns them to the view
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
                    model.ZIP = user.ZIP;
                    model.City = user.City;
                    model.Title = user.Title;
                    model.RoleId = _roleManager.Roles.Single(r => r.Name == _userManager.GetRolesAsync(user).Result.Single()).Id;
                
                }
            }
            return View(model);
        }


        //Edits the Users properties where there has been changes
        //Checks if the existing role id is equal to the choosen role.        
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
                    user.ZIP = model.ZIP;
                    user.City = model.City;
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

        //Get the user
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
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteUser(string id)
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
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimiTDD.Models;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Areas.User.Controllers
{
    class WorkController : Controller
    {
        private readonly IGenericRepository<WorkParticipation> _genericWorkRepository;
        private readonly IGenericRepository<Project> _genericProjectRepository;
        private readonly IGenericRepository<WorkCategory> _genericWorkCategoryRepository;
        private readonly IGenericRepository<Client> _genericContractorRepository;      
        private readonly UserManager<ApplicationUser> _userManager;
        
        // int wId;

        public WorkController(
            UserManager<ApplicationUser> usermanager,
            IGenericRepository<WorkParticipation> genericWorkRepository,
            IGenericRepository<Project> genericProjectRepository,
            IGenericRepository<WorkCategory> genericWorkCategoryRepository,
            IGenericRepository<Client> genericContractorRepository)
        {            
            _userManager = usermanager;
            _genericWorkRepository = genericWorkRepository;
            _genericProjectRepository = genericProjectRepository;
            _genericWorkCategoryRepository = genericWorkCategoryRepository;
            _genericContractorRepository = genericContractorRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
          
            var user = await GetCurrentUserAsync();
            var userId = user?.Id;
                     
            // Checks if the user are in a active session
            // Sends them to te session if they are 
            // Sends them to the manin page if they aren't
            if (_genericWorkRepository.GetAll.Where(u => u.UserId == userId && u.SessionState == true) != null)
            {
                // Gets the users latest active session
                var workId = _genericWorkRepository.GetAll.Where(u => u.UserId == userId && u.SessionState == true).Max(w => w.Id);
                var workParticipation = _genericWorkRepository.Get(workId);
                //Makes sure to pick a work session that have key fields as Null
                if (workId != 0 && workParticipation.ProjectId == null && workParticipation.DateTimeEnd == null)
                {
                    return RedirectToAction("CheckIn");
                }
            }
            else
            {
                return View();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(WorkParticipation workParticipation)
        {   

            //Starts a new work session
            if (Request.Form["BtnStart"] != String.IsNullOrEmpty(Request.Form["BtnStart"]))
            {
                workParticipation.SessionState = true;
                workParticipation.DateTimeStart = DateTime.Now;
                _genericWorkRepository.Add(workParticipation);
                return RedirectToAction("CheckIn");
            }
            else{
                return View();
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> CheckIn()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var userId = user?.Id;
            // gets the users latest session
            var workId = _genericWorkRepository.GetAll.Where(u => u.UserId == userId && u.SessionState == true).Max(wp => wp.Id);
            
            var workParticipation = _genericWorkRepository.Get(workId);

            if (workParticipation == null)
            {
                return NotFound();
            }

            return View(workParticipation);

        }

        [HttpGet]
        public IActionResult ProjectWork(int id)
        {
           
            // list project by id and name and puts it in a ViewBag
            ViewBag.ProjectId = new SelectList(_genericProjectRepository.GetAll, "PId", "Detail");
            // list workcategories by ide and name and puts it in a ViewBag
            ViewBag.WorkCategoryId = new SelectList(_genericWorkCategoryRepository.GetAll, "WCId", "WCDetail");
            // makes list of values an put them in a ViewBag
            ViewBag.WPBreak = new SelectList(
                new List<SelectListItem> {
                    new SelectListItem { Text = "Ingen pause", Value = "0" },
                 new SelectListItem { Text = "15 minutt -> 0,25", Value = "0,25" },
                 new SelectListItem { Text = "30 minutt -> 0,5", Value = "0,5" },
                 new SelectListItem { Text = "45 minutt -> 0,75", Value = "0,75" },
                 new SelectListItem { Text = "60 minutt -> 1,0", Value = "1,0" }
               }, "Value", "Text");
           
            WorkParticipation workParticipation = _genericWorkRepository.Get(id);

            if (workParticipation == null)
            {
                // returns error if not found
                return NotFound();
            }

            // returns data to view
            return View(workParticipation);

        }

        // posts the rest of the infromation about the work session in a project
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProjectWork(WorkParticipation workParticipation)
        {
            ViewBag.ProjectId = new SelectList(_genericProjectRepository.GetAll, "PId", "Detail", workParticipation.ProjectId);
            ViewBag.WorkCategoryId = new SelectList(_genericWorkCategoryRepository.GetAll, "WCId", "WCDetail", workParticipation.WorkCategoryId);

            try
            {
                if (ModelState.IsValid)
                {                   
                    // Ends the work session
                    workParticipation.SessionState = false;
                    _genericWorkRepository.Update(workParticipation);
                    return RedirectToAction("ProjectVerification");
                }
                else
                {
                    return View(workParticipation);
                }
            }
            catch 
            {
                return View(workParticipation);
            }
            
        }

        [HttpGet]
        public IActionResult HourWork(int id)
        {           
            // gets list of project and represent it with PId and PName
            ViewBag.ProjectId = new SelectList(_genericProjectRepository.GetAll, "PId", "Detail");
            // Gets list of contractor and represnt it with CId and CName
            ViewBag.ContracterId = new SelectList(_genericContractorRepository.GetAll, "CId", "CName");
            // makes list of values and put them in a ViewBag
            ViewBag.WPBreak = new SelectList(
               new List<SelectListItem> {
                      new SelectListItem { Text = "Ingen pause", Value = "0" },
                 new SelectListItem { Text = "15 minutt", Value = "0,25" },
                 new SelectListItem { Text = "30 minutt", Value = "0,5" },
                 new SelectListItem { Text = "45 minutt", Value = "0,75" },
                 new SelectListItem { Text = "60 minutt", Value = "1,0" }
              }, "Value", "Text");           
           
            WorkParticipation workParticipation = _genericWorkRepository.Get(id);

            if (workParticipation == null)
            {
                // returns error when not found
                return NotFound();
            }

            // returns data to view
            return View(workParticipation);

        }

        // POST: Employe/HourWork/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HourWork(WorkParticipation workParticipation)
        { 

            ViewBag.ProjectId = new SelectList(_genericProjectRepository.GetAll, "PId", "Detail", workParticipation.ProjectId);            
            ViewBag.ContracterId = new SelectList(_genericContractorRepository.GetAll, "CId", "CName", workParticipation.ClientId);

            try
            {
                if (ModelState.IsValid)
                {
                    workParticipation.SessionState = false;
                    _genericWorkRepository.Update(workParticipation);
                    return RedirectToAction("HourWorkVerification");
                }
                else
                {
                    return View(workParticipation);
                }
            }
            catch
            {
                return View(workParticipation);
            }
           
        }

        [HttpGet]
        public async Task<IActionResult> ProjectVerification()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var userId = user?.Id;

            var workId = _genericWorkRepository.GetAll.Where(u => u.UserId == userId).Max(w => w.Id);
            if (workId == 0)
            {
                return NotFound();
            }
            WorkParticipation workParticipation = _genericWorkRepository.Get(workId);

            if (workParticipation == null)
            {
                return NotFound();
            }

            return View(workParticipation);
        }

        [HttpGet]
        public async Task<IActionResult> HourWorkVerification()
        {
            ApplicationUser user = await GetCurrentUserAsync();
            var userId = user?.Id;

            var workId = _genericWorkRepository.GetAll.Where(u => u.UserId == userId).Max(w => w.Id);
            if (workId == 0)
            {
                return NotFound();
            }

            WorkParticipation workParticipation = _genericWorkRepository.Get(workId);

            if (workParticipation == null)
            {
                return NotFound();
            }


            return View(workParticipation);
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
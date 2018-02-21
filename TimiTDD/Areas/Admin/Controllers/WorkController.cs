using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TimiTDD.Models;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class WorkCotroller : Controller
    {
        private readonly IGenericRepository<WorkParticipation> _workRepository;
        
        // The ID for "Prosjektarbeid" in ActivityType
        private static int projectWork = 1;
        // The ID for "Timearbeid" in ActivityType
        private static int hourWork = 2;
        
        public WorkCotroller(IGenericRepository<WorkParticipation> workRepository)
        {
            _workRepository = workRepository;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var workDoneList = _workRepository.GetAll.Where(w=>w.ActivityTypeId == projectWork).Where(w=>w.ActivityTypeId == hourWork);

            return View(workDoneList.OrderByDescending(d=>d.DateTimeStart.Value.Year).OrderByDescending(d=>d.DateTimeStart.Value.Date));
        }

        public IActionResult WorkByYear()
        {
            var workYear = _workRepository.GetAll.Select(x=> new {x.DateTimeStart, x.Hours});
            return View(workYear.OrderByDescending(d=>d.DateTimeStart.Value.Year));
        }
    }
}
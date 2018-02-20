using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TimiTDD.Models;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Areas.Admin.Controllers
{
    public class WorkCotroller : Controller
    {
        private readonly IGenericRepository<WorkParticipation> _workRepository;
        
        private static int projectWork = 1;
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
    }
}
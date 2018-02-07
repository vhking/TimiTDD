using System.Collections.Generic;
using System.Linq;
using TimiTDD.Data;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Models.EFRepository
{
  
    class EFProjectRepository : IGenericRepository<Project>
    {
        private readonly ApplicationDbContext _context;

        public EFProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Project> GetAll => _context.Project;

        public void Add(Project obj)
        {
            _context.Project.Add(obj);
            _context.SaveChangesAsync();
        }

        public Project Delete(int id)
        {
            Project dbEntry = _context.Project.SingleOrDefault(m => m.ProjectId == id);
            if (dbEntry != null)
            {
                _context.Project.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public Project Get(int id)
        {            
            return _context.Project.SingleOrDefault(m=>m.ProjectId == id);
        }

        public void Update(Project obj)
        {
            if (obj.ProjectId != 0)
            {
                Project dbEntry = _context.Project
                    .FirstOrDefault(p => p.ProjectId == obj.ProjectId);
                if (dbEntry != null )
                {
                    dbEntry.ProjectId = obj.ProjectId;
                    dbEntry.ProjectName = obj.ProjectName;
                    dbEntry.StartDate = obj.StartDate;
                    dbEntry.EndDate = obj.EndDate;
                    dbEntry.EstimateMasonry = obj.EstimateMasonry;
                    dbEntry.EstimateTile = obj.EstimateTile;
                    dbEntry.EstimateStructural = obj.EstimateStructural;
                    dbEntry.EstimateExternal = obj.EstimateExternal;
                    dbEntry.EstimatePlating = obj.EstimatePlating;
                    dbEntry.EstimateStender = obj.EstimateStender;
                    dbEntry.EstimateFinalisingWork = obj.EstimateFinalisingWork;
                    dbEntry.EstimateGarage = obj.EstimateGarage;
                    dbEntry.EstimateAssembly = obj.EstimateAssembly;
                    dbEntry.EstimateOther = obj.EstimateOther;
                }
            }
            
            _context.SaveChanges();
        }
    }
}
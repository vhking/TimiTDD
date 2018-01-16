using System.Collections.Generic;
using System.Linq;
using TimiTDD.Data;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Models.EFRepository
{
    class EFProjectRepository : IGenericRepository<Project>
    {
        private readonly ApplicationDbContext _context;

        EFProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Project> GetAll => _context.Project;

        public void Add(Project project)
        {
            _context.Project.Add(project);
            _context.SaveChangesAsync();
        }

        public Project Delete(int id)
        {
            var dbEntry = _context.Project.FirstOrDefault(p=>p.ProjectId == id);
            if (dbEntry != null)
            {
                _context.Project.Remove(dbEntry);
                _context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public Project Get(int id)
        {
            return _context.Project.FirstOrDefault(p=>p.ProjectId == id);
        }

        public void Update(Project project)
        {
             if (project.ProjectId != 0)
            {
                Project dbEntry = _context.Project
                    .FirstOrDefault(p => p.ProjectId == project.ProjectId);
                if (dbEntry != null )
                {
                    dbEntry.ProjectId = project.ProjectId;
                    dbEntry.ProjectName = project.ProjectName;
                    dbEntry.StartDate = project.StartDate;
                    dbEntry.EndDate = project.EndDate;
                    dbEntry.EstimateMasonry = project.EstimateMasonry;
                    dbEntry.EstimateTile = project.EstimateTile;
                    dbEntry.EstimateStructural = project.EstimateStructural;
                    dbEntry.EstimateExternal = project.EstimateExternal;
                    dbEntry.EstimatePlating = project.EstimatePlating;
                    dbEntry.EstimateStender = project.EstimateStender;
                    dbEntry.EstimateFinalisingWork = project.EstimateFinalisingWork;
                    dbEntry.EstimateGarage = project.EstimateGarage;
                    dbEntry.EstimateAssembly = project.EstimateAssembly;
                    dbEntry.EstimateOther = project.EstimateOther;
                }
            }           
            _context.SaveChanges();
        }
    }
}
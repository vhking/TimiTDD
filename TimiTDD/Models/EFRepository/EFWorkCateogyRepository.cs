using System.Collections.Generic;
using TimiTDD.Data;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Models.EFRepository
{
    class EFWorkCategoryRepository : IGenericRepository<WorkCategory>
    {
        private readonly ApplicationDbContext _context;
        public EFWorkCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<WorkCategory> GetAll => _context.WorkCategory;

        public void Add(WorkCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public WorkCategory Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public WorkCategory Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(WorkCategory obj)
        {
            throw new System.NotImplementedException();
        }
    }

}
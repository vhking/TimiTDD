using System.Collections.Generic;
using TimiTDD.Data;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Models.EFRepository
{
    class EFAbsenceRepository : IGenericRepository<AbsenceCategory>
    {
        private readonly ApplicationDbContext _context;
        public EFAbsenceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<AbsenceCategory> GetAll => _context.AbsenceCategory; 

        public void Add(AbsenceCategory obj)
        {
            throw new System.NotImplementedException();
        }

        public AbsenceCategory Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public AbsenceCategory Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AbsenceCategory obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
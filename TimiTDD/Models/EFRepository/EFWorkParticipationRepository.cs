using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TimiTDD.Data;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Models.EFRepository
{
    class EFWorkParticipationRepository : IGenericRepository<WorkParticipation>
    {
        private readonly ApplicationDbContext _context;
        public EFWorkParticipationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<WorkParticipation> GetAll => _context.WorkParticipation;

        public void Add(WorkParticipation obj)
        {
            _context.WorkParticipation.Add(obj);
            _context.SaveChanges();
        
        }

        public WorkParticipation Delete(int id)
        {
            var dbEntry = _context.WorkParticipation.FirstOrDefault(m => m.Id == id);
            if (dbEntry != null)
            {
                _context.WorkParticipation.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public WorkParticipation Get(int id)
        {
            var dbEntry = _context.WorkParticipation.Include(c=>c.CId).Include(a=>a.ATId).Include(w=>w.WCId).FirstOrDefault(wp => wp.Id == id);

                return dbEntry;
        }

        public void Update(WorkParticipation obj)
        {
            if (obj.Id != 0)
            {

                WorkParticipation dbEntry = _context.WorkParticipation
                    .SingleOrDefault(p => p.Id == obj.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = obj.Id;
                    // dbEntry.DateTimeStart = obj.DateTimeStart;
                    // dbEntry.DateTimeEnd = obj.DateTimeEnd;
                    // dbEntry.Hours = obj.Hours;
                    dbEntry.WorkBreak = obj.WorkBreak;
                    dbEntry.Comment = obj.Comment;
                    dbEntry.Session = obj.Session;
                    dbEntry.ClientId = obj.ClientId;
                    dbEntry.ProjectId = obj.ProjectId;
                    dbEntry.UserId = obj.UserId;
                    dbEntry.WorkCategoryId = obj.WorkCategoryId;
                    dbEntry.ActivityTypeId = obj.ActivityTypeId;
                    

                }
            }

            _context.SaveChanges();
        }
    }
}
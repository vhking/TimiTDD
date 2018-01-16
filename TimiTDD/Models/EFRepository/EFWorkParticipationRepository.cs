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

        public void Add(WorkParticipation workParticipation)
        {
            _context.WorkParticipation.Add(workParticipation);
            _context.SaveChangesAsync();
        }

        public WorkParticipation Delete(int id)
        {
            var dbEntry = _context.WorkParticipation.SingleOrDefault(m => m.Id == id);
            if (dbEntry != null)
            {
                _context.WorkParticipation.Remove(dbEntry);
                _context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public WorkParticipation Get(int id)
        {
            return _context.WorkParticipation.SingleOrDefault(wp=>wp.Id == id);
        }

        public void Update(WorkParticipation workParticipation)
        {
           
            if (workParticipation.Id != 0)
            {

                WorkParticipation dbEntry = _context.WorkParticipation
                    .SingleOrDefault(p => p.Id == workParticipation.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = workParticipation.Id;
                    dbEntry.DateTimeStart = workParticipation.DateTimeStart;
                    dbEntry.DateTimeEnd = workParticipation.DateTimeEnd;
                    dbEntry.Hours = workParticipation.Hours;
                    dbEntry.Break = workParticipation.Break;
                    dbEntry.Comment = workParticipation.Comment;
                    dbEntry.SessionState = workParticipation.SessionState;
                    dbEntry.ClientId = workParticipation.ClientId;
                    dbEntry.ProjectId = workParticipation.ProjectId;
                    dbEntry.UserId = workParticipation.UserId;
                    dbEntry.WorkCategoryId = workParticipation.WorkCategoryId;
                    dbEntry.AbsenceId = workParticipation.AbsenceId;
                    dbEntry.ActivityTypeId = workParticipation.ActivityTypeId;
                }
            }

            _context.SaveChangesAsync();
        }
    }
}

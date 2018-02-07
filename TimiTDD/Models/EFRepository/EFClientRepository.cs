using System.Collections.Generic;
using System.Linq;
using TimiTDD.Data;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Models.EFRepository
{
    class EFCleintRepository : IGenericRepository<Client>
    {
        private readonly ApplicationDbContext _context;
        public EFCleintRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Client> GetAll => _context.Client;

        public void Add(Client obj)
        {
            _context.Client.Add(obj);
            _context.SaveChanges();
        }

        public Client Delete(int id)
        {
            
            Client dbEntry = _context.Client.SingleOrDefault(m => m.Id == id);
            if (dbEntry != null)
            {
                _context.Client.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }

        public Client Get(int id)
        {
            return _context.Client.SingleOrDefault(m=>m.Id == id);
        }

        public void Update(Client obj)
        {
            
            if (obj.Id != 0)
            {
                 Client dbEntry = _context.Client
                    .SingleOrDefault(p => p.Id == obj.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = obj.Id;
                    dbEntry.Name = obj.Name;
                    dbEntry.Email = obj.Email;
                    dbEntry.Addr = obj.Addr;
                    dbEntry.ZIP = obj.ZIP;
                    dbEntry.City = obj.City;
                    dbEntry.Org = obj.Org;
                   
                }
            }
            
            _context.SaveChanges();
        }
    }
}
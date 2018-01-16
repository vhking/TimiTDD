using System.Collections.Generic;
using System.Linq;
using TimiTDD.Data;
using TimiTDD.Models.IRepository;

namespace TimiTDD.Models.EFRepository
{
    class EFClientRepository : IGenericRepository<Client>
    {
        private readonly ApplicationDbContext _context;

        EFClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Client> GetAll => _context.Client;

        public void Add(Client arg)
        {
            _context.Client.Add(arg);
            _context.SaveChangesAsync();
        }

        public Client Delete(int id)
        {
            var dbEntry = _context.Client.SingleOrDefault(c=>c.Id == id);
            if (dbEntry!= null)
            {
                _context.Client.Remove(dbEntry);
                _context.SaveChangesAsync();
            }
            return dbEntry;
        }

        public Client Get(int id)
        {
            return _context.Client.SingleOrDefault(c=>c.Id == id);
        }

        public void Update(Client client)
        {
            if (client.Id != 0)
            {

                Client dbEntry = _context.Client
                    .SingleOrDefault(p => p.Id == client.Id);
                if (dbEntry != null)
                {
                    dbEntry.Id = client.Id;
                    dbEntry.Name = client.Name;
                    dbEntry.Email = client.Email;
                    dbEntry.Addr = client.Addr;
                    dbEntry.ZIP = client.ZIP;
                    dbEntry.City = client.City;
                    dbEntry.Org = client.Org;
                }
            }

            _context.SaveChangesAsync();
        }
    }
}
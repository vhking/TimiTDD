using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimiTDD.Models.IRepository
{
    interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll{ get; } 
        T Get(int id);
        void Add(T arg);
        void Update(T arg);
        T Delete(int id);
    }
}
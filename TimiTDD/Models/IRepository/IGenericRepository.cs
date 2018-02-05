using System.Collections.Generic;

namespace TimiTDD.Models.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll { get; }
        void Update(T obj);
        void Add(T obj);
        T Delete(int id);
        T Get(int id);
    }  
}
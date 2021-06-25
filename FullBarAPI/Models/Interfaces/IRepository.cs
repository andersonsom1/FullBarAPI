using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullBarAPI.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Add (T item);
        Task Remove(int id);
        Task Update (T item);
        Task<T> FindById (int id);
        Task<IEnumerable<T>> FindAll();
    }
}

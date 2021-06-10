using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T item);
        Task<T> FindById(int id);
        Task<IQueryable<T>> FindAll();
        Task Edit(int id, T item);
        Task Remove(int id);
        
    }
}

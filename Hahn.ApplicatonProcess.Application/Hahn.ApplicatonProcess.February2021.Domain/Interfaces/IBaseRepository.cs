using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        Task<TEntity> FindById(int id);
        Task<IQueryable<TEntity>> FindAll();
        Task Edit(int id, TEntity entity);
        Task Remove(int id);
        
    }
}

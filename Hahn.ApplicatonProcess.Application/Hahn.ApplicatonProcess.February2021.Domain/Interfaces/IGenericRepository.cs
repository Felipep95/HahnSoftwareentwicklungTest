using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity entity);
        Task<TEntity> FindById(int id);
        //Task Edit(int id);
        void Edit(TEntity entity);
        //Task Remove(int id);
        void Remove(TEntity entity);
    }
}

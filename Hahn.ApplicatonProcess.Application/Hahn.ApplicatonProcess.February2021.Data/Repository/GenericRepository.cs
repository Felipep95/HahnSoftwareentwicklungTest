using Hahn.ApplicatonProcess.February2021.Data.Context;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    //TODO: https://pradeeploganathan.com/architecture/repository-and-unit-of-work-pattern-asp-net-core-3-1/
    //Note: need to handle business logic here?
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Edit(TEntity entity)
        {
            _context.Update(entity);
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }
    }
}

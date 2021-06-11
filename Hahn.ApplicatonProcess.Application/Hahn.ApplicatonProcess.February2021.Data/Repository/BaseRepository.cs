using Hahn.ApplicatonProcess.February2021.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public async Task Edit(int id, TEntity entity)
        {
            var entityToEdit = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Update(entityToEdit);
        }

        public async Task<IQueryable<TEntity>> FindAll()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return (IQueryable<TEntity>)entities;
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var entityToRemove = await _context.Set<TEntity>().FindAsync(id);
            _context.Set<TEntity>().Remove(entityToRemove);
        }
    }
}

using Hahn.ApplicatonProcess.February2021.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.February2021.Domain.Interfaces
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext _context;
        //internal DbSet<TEntity> dbSet;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            //dbSet = context.Set<TEntity>();
        }

        public virtual TEntity GetByID(object id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _context.Set<TEntity>().Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Attach(entityToDelete);
            }
            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            _context.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}

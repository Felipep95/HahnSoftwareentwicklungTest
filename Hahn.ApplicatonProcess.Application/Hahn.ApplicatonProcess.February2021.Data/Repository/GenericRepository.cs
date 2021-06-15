//using Hahn.ApplicatonProcess.February2021.Data.Context;
//using System.Threading.Tasks;

//namespace Hahn.ApplicatonProcess.February2021.Data.Repository
//{
//    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
//    {
//        private readonly DatabaseContext _context;

//        public GenericRepository(DatabaseContext context)
//        {
//            _context = context;
//        }

//        public async Task Add(TEntity entity)
//        {
//            await _context.Set<TEntity>().AddAsync(entity);
//        }

//        public async Task<TEntity> FindById(int id)
//        {
//            return await _context.Set<TEntity>().FindAsync(id);
//        }

//        public void Edit(TEntity asset)
//        {
//            _context.Set<TEntity>().Update(asset);
//        }

//        public void Remove(TEntity asset)
//        {
//            _context.Set<TEntity>().Remove(asset);
//        }
//    }
//}

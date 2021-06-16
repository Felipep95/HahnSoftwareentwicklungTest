using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DatabaseContext _context;
        private AssetRepository _assetsRepository;
        
        public UnityOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public AssetRepository assetRepository
        {
            get
            {
                if (_assetsRepository == null)
                {
                    _assetsRepository = new AssetRepository(_context);
                }
                return _assetsRepository;
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}

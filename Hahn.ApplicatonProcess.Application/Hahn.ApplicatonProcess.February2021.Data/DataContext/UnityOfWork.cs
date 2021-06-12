using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DbContext _context;
        //private readonly IAssetRepository Assets;
        public IAssetRepository Assets { get; }

        //public UnityOfWork(IAssetRepository asset)
        //{
        //    Assets = asset;
        //}
        public UnityOfWork(DbContext context, IAssetRepository assetRepository)
        {
            _context = context;
            Assets = assetRepository;
        }

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context.Dispose();
        }
    }
}

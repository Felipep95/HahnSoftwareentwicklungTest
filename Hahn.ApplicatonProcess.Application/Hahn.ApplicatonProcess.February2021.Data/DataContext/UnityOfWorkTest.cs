using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System;

namespace Hahn.ApplicatonProcess.February2021.Data.DataContext
{
    public class UnityOfWorkTest
    {
        //private DatabaseContext _context = new DatabaseContext();
        private readonly DatabaseContext _context;
        private AssetRepository _assetRepository;
        //private GenericRepository<Asset> _assetRepository;

        public UnityOfWorkTest(DatabaseContext context)
        {
            _context = context;
        }

        public AssetRepository assetRepository
        {
            get
            {
                if (_assetRepository == null)
                {
                    _assetRepository = new AssetRepository(_context);
                }
                return _assetRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
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

    }
}

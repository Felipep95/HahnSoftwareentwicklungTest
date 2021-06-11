using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly DbContext _context;

        public UnityOfWork(DbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            //TODO: implements logic
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

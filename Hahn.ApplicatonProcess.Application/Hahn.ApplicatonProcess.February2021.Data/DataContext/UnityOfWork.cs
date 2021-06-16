using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Commit()
        {
            var success = (await _context.SaveChangesAsync()) > 0;
            return success;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}

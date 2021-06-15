using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DatabaseContext _context;
        
        public AssetRepository(DatabaseContext context)
        {
            _context = context;

            if (!_context.Assets.Any())
            {
                _context.Assets.Add(new Asset(1, "Test1", Department.HQ, "Brazil", "Brazil@hotmail.com", DateTime.UtcNow, true));
                _context.Assets.Add(new Asset(2, "Test2", Department.Store1, "Germany", "Germany@hotmail.com", DateTime.UtcNow, true));
                _context.Assets.Add(new Asset(3, "Test3", Department.Store2, "France", "France@hotmail.com", DateTime.UtcNow, false));
                _context.Assets.Add(new Asset(4, "Test4", Department.Store3, "Denmark", "Denmark@hotmail.com", DateTime.UtcNow, false));
                _context.Assets.Add(new Asset(5, "Test5", Department.MaintenanceStation, "Switzerland", "Switzerland@hotmail.com", DateTime.UtcNow, false));
                _context.SaveChanges(); 
            }
        }

        public async Task Add(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
        }

        public async Task<Asset> FindById(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public void Edit(Asset asset)
        {
            _context.Assets.Update(asset);
        }

        public void Remove(Asset asset)
        {
            _context.Assets.Remove(asset);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
﻿using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        
        public AssetRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
        }

        public async Task<Asset> FindByIdAsync(int id)
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
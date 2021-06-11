using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Interfaces;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceAsset : IServiceAsset
    {
        private readonly DataContext _context;
        private readonly AssetRepository _assetRepository;
        
        public ServiceAsset(DataContext context, AssetRepository assetRepository)
        {
            _context = context;
            _assetRepository = assetRepository;
        }

        public void Add(Asset asset)
        {
            _assetRepository.Add(asset);
        }

        public async Task Edit(int id, Asset asset)
        {
            await _assetRepository.Edit(id, asset);
        }

        public async Task<IQueryable<Asset>> FindAll()
        {
            return await _assetRepository.FindAll();
        }

        public async Task<Asset> FindById(int id)
        {
            return await _assetRepository.FindById(id);
        }

        public async Task Remove(int id)
        {
            await _assetRepository.Remove(id);
        }
    }
}

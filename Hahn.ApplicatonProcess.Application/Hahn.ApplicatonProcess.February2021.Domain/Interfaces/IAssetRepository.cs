using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public interface IAssetRepository : IDisposable
    {
        public Task Add(Asset asset);
        public Task<Asset> FindById(int id);
        public void Edit(Asset asset);
        public void Remove(Asset asset);
    }
}

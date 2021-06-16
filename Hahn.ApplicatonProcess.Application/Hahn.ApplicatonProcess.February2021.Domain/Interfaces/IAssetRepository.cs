using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public interface IAssetRepository
    {
        Task AddAsync(Asset asset);
        Task<Asset> FindByIdAsync(int id);
        void Edit(Asset asset);
        void Remove(Asset asset);
    }
}

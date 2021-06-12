using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Models;


namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        private readonly DataContext _context;
        public AssetRepository(DataContext context) : base(context)
        {

        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System;
using System.Net;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        private readonly DatabaseContext _context;
        
        public AssetRepository(DatabaseContext context) : base(context)
        {
            //TODO: why was get error when use UnityOfWork as parameter?
            _context = context;
            AddAsset(1, "Test",  Department.HQ, "Brazil", "Brazil@hotmail.com", new DateTime(), true);
            AddAsset(2, "Test2", Department.MaintenanceStation, "Germany", "Germany@hotmail.com", new DateTime(), true);
            AddAsset(3, "Test3", Department.Store1, "France", "France@hotmail.com", new DateTime(), true);
            AddAsset(4, "Test4", Department.Store2, "Denmark", "Denmark@hotmail.com", new DateTime(), true);
            AddAsset(5, "Test5", Department.Store3, "Switzerland", "Switzerland@hotmail.com", new DateTime(), true);

            //_context.SaveChanges(); //quando cria um novo asset, cria com o id em sequencia, porem no getById da erro de id duplicado(após o primeiro getById)
            //todo: id pulando de 6 em 6 quando não setado o id nos AddAsset
        }

        private void AddAsset(int id, string assetName, Department department,
                string countrOfDepartment, string emailAdressDepartment, DateTime purchaseDate, bool broken)
        {
            try
            {
                _context.Assets.Add(new Asset
                {
                    ID = id,
                    AssetName = assetName,
                    Department = department,
                    CountryOfDepartment = countrOfDepartment,
                    EMailAdressOfDepartment = emailAdressDepartment,
                    PurchaseDate = purchaseDate,
                    broken = broken
                });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
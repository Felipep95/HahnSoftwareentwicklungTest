using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System;
using System.Linq;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        private readonly DatabaseContext _context;

        public AssetRepository(DatabaseContext context) : base(context)
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

            //_context.Assets.Add(new Asset("Test1", Department.HQ, "Brazil", "Brazil@hotmail.com", new DateTime(), true));
            //_context.Assets.Add(new Asset("Test2", Department.Store1, "Germany", "Germany@hotmail.com", new DateTime(), true));
            //_context.Assets.Add(new Asset("Test3", Department.Store2, "France", "France@hotmail.com", new DateTime(), false));
            //_context.Assets.Add(new Asset("Test4", Department.Store3, "Denmark", "Denmark@hotmail.com", new DateTime(), false));
            //_context.Assets.Add(new Asset("Test5", Department.MaintenanceStation, "Switzerland", "Switzerland@hotmail.com", new DateTime(), false));

            //AddAsset(1, "Test",  Department.HQ, "Brazil", "Brazil@hotmail.com", new DateTime(), true);
            //AddAsset(2, "Test2", Department.MaintenanceStation, "Germany", "Germany@hotmail.com", new DateTime(), true);
            //AddAsset(3, "Test3", Department.Store1, "France", "France@hotmail.com", new DateTime(), true);
            //AddAsset(4, "Test4", Department.Store2, "Denmark", "Denmark@hotmail.com", new DateTime(), true);
            //AddAsset(5, "Test5", Department.Store3, "Switzerland", "Switzerland@hotmail.com", new DateTime(), true);

            //_context.SaveChanges(); //quando cria um novo asset, cria com o id em sequencia, porem no getById da erro de id duplicado(após o primeiro getById)
            //todo: id pulando de 6 em 6 quando não setado o id nos AddAsset
        }

        //private void AddAsset(int id, string assetName, Department department,
        //        string countrOfDepartment, string emailAdressDepartment, DateTime purchaseDate, bool broken)
        //{
        //    try
        //    {
        //        _context.Assets.Add(new Asset
        //        {
        //            ID = id,
        //            AssetName = assetName,
        //            Department = department,
        //            CountryOfDepartment = countrOfDepartment,
        //            EMailAdressOfDepartment = emailAdressDepartment,
        //            PurchaseDate = purchaseDate,
        //            broken = broken
        //        });
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
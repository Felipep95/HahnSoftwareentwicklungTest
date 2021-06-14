using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using System;
using System.Linq;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        //private readonly DatabaseContext _context;
        UnityOfWork _unityOfWork;

        //public AssetRepository(DatabaseContext context) : base(context)
        public AssetRepository(UnityOfWork unityOfWork) : base(unityOfWork)
        {
            _unityOfWork = unityOfWork;


            _unityOfWork.Assets.Add(new Asset(1, "Test1", Department.HQ, "Brazil", "Brazil@hotmail.com", DateTime.UtcNow, true));
            _unityOfWork.Assets.Add(new Asset(2, "Test2", Department.Store1, "Germany", "Germany@hotmail.com", DateTime.UtcNow, true));
            _unityOfWork.Assets.Add(new Asset(3, "Test3", Department.Store2, "France", "France@hotmail.com", DateTime.UtcNow, false));
            _unityOfWork.Assets.Add(new Asset(4, "Test4", Department.Store3, "Denmark", "Denmark@hotmail.com", DateTime.UtcNow, false));
            _unityOfWork.Assets.Add(new Asset(5, "Test5", Department.MaintenanceStation, "Switzerland", "Switzerland@hotmail.com", DateTime.UtcNow, false));
            _ = _unityOfWork.Commit();



            //_context = (DatabaseContext)unityOfWork;

            //if (!_context.Assets.Any())
            //{
            //    _context.Assets.Add(new Asset(1, "Test1", Department.HQ, "Brazil", "Brazil@hotmail.com", DateTime.UtcNow, true));
            //    _context.Assets.Add(new Asset(2, "Test2", Department.Store1, "Germany", "Germany@hotmail.com", DateTime.UtcNow, true));
            //    _context.Assets.Add(new Asset(3, "Test3", Department.Store2, "France", "France@hotmail.com", DateTime.UtcNow, false));
            //    _context.Assets.Add(new Asset(4, "Test4", Department.Store3, "Denmark", "Denmark@hotmail.com", DateTime.UtcNow, false));
            //    _context.Assets.Add(new Asset(5, "Test5", Department.MaintenanceStation, "Switzerland", "Switzerland@hotmail.com", DateTime.UtcNow, false));
            //    _context.SaveChanges();
            //}
        }

        //public void Dispose()
        //{
        //    _context?.Dispose();
        //}
    }
}
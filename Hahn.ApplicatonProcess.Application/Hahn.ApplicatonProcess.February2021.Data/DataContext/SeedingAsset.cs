//using Hahn.ApplicatonProcess.February2021.Domain.Enums;
//using Hahn.ApplicatonProcess.February2021.Domain.Models;
//using System;
//using System.Threading.Tasks;

//namespace Hahn.ApplicatonProcess.February2021.Data.DataContext
//{
//    public class SeedingAsset
//    {
//        private static async Task AddAssetData(UnityOfWork _unityOfWork)
//        {

//            var testAsset = new Asset();
//            {
//                testAsset.ID = 1;
//                testAsset.AssetName = "Test";
//                testAsset.Department = Department.HQ;
//                testAsset.CountryOfDepartment = "Brazil";
//                testAsset.EMailAdressOfDepartment = "Test@hotmail.com";
//                testAsset.PurchaseDate = new DateTime();
//                testAsset.broken = true;

//            };

//            var testAsset2 = new Asset();
//            {
//                testAsset2.ID = 2;
//                testAsset2.AssetName = "Test2";
//                testAsset2.Department = Department.Store1;
//                testAsset2.CountryOfDepartment = "Germany";
//                testAsset2.EMailAdressOfDepartment = "Test2@hotmail.com";
//                testAsset2.PurchaseDate = new DateTime();
//                testAsset2.broken = false;
//            };

//            await _unityOfWork.Assets.Add(testAsset);
//            await _unityOfWork.Assets.Add(testAsset2);
//            await _unityOfWork.Commit();
//        }
//    }
//}

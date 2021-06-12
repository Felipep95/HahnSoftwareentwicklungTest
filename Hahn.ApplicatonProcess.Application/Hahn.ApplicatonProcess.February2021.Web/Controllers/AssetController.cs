using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IUnityOfWork _unityOfWork;

        //UnityOfWork uow = new UnityOfWork();


        public AssetController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Asset>> GetById(int id)
        {
            //_unityOfWork.BeginTransaction();
            return await _unityOfWork.Assets.FindById(id);
            //return await uow.Assets.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> Post(Asset asset)
        {
            var newAsset = new Asset();

            newAsset.ID = asset.ID;
            newAsset.AssetName = asset.AssetName;
            newAsset.Department = asset.Department;
            newAsset.CountryOfDepartment = asset.CountryOfDepartment;
            newAsset.EMailAdressOfDepartment = asset.EMailAdressOfDepartment;
            newAsset.PurchaseDate = asset.PurchaseDate;
            newAsset.broken = asset.broken;

            await _unityOfWork.Assets.Add(newAsset);
            await _unityOfWork.Commit();
            //await uow.Assets.Add(newAsset);//null reference on asset
            //await uow.Commit();

            return Ok(newAsset);
        }

        
    }
}

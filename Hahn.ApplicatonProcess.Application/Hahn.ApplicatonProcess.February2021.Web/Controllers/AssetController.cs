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
        private readonly UnityOfWork _unityOfWork;
        
        public AssetController(UnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<Asset>> GetById(int id)
        {
            return await _unityOfWork.Assets.FindById(id);
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

            return Ok(newAsset);
        }

        
    }
}

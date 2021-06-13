using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        public async Task<ActionResult<Asset>> Post(Asset asset)
        {
            //var checkId = _unityOfWork.Assets.FindById(asset.ID);
            try
            {
                var newAsset = new Asset();//TODO: create dto

                newAsset.ID = asset.ID;
                newAsset.AssetName = asset.AssetName;
                newAsset.Department = asset.Department;
                newAsset.CountryOfDepartment = asset.CountryOfDepartment;
                newAsset.EMailAdressOfDepartment = asset.EMailAdressOfDepartment;
                newAsset.PurchaseDate = asset.PurchaseDate;
                newAsset.broken = asset.broken;

                await _unityOfWork.Assets.Add(newAsset);
                

                return Ok(newAsset);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetById(int id)
        {
            var asset = await _unityOfWork.Assets.FindById(id);

            var getAsset = new Asset();

            getAsset.ID = asset.ID;
            getAsset.AssetName = asset.AssetName;
            getAsset.Department = asset.Department;
            getAsset.CountryOfDepartment = asset.CountryOfDepartment;
            getAsset.EMailAdressOfDepartment = asset.EMailAdressOfDepartment;
            getAsset.PurchaseDate = asset.PurchaseDate;
            getAsset.broken = asset.broken;


            await _unityOfWork.Commit();
            return getAsset;
        }
    }
}

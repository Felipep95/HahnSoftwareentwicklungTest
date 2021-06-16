using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Data.DataContext;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly UnityOfWorkTest _unityOfWorkTest;

        public AssetController(UnityOfWorkTest unityOfWorkTest)
        {
            _unityOfWorkTest = unityOfWorkTest;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CREATEAssetDTO assetDTO)
        {
            var newAsset = new Asset();

            try
            {
                var createdAsset = new Asset();

                createdAsset.AssetName = assetDTO.AssetName;
                createdAsset.Department = assetDTO.Department;
                createdAsset.CountryOfDepartment = assetDTO.CountryOfDepartment;
                createdAsset.EmailAdressOfDepartment = assetDTO.EmailAdressOfDepartment;
                createdAsset.PurchaseDate = assetDTO.PurchaseDate;
                createdAsset.Broken = assetDTO.Broken;

                await _unityOfWorkTest.assetRepository.Add(createdAsset);
                _unityOfWorkTest.Commit();

                newAsset.Id = createdAsset.Id;
                newAsset.AssetName = createdAsset.AssetName;
                newAsset.Department = createdAsset.Department;
                newAsset.CountryOfDepartment = createdAsset.CountryOfDepartment;
                newAsset.EmailAdressOfDepartment = createdAsset.EmailAdressOfDepartment;
                newAsset.PurchaseDate = createdAsset.PurchaseDate;
                newAsset.Broken = createdAsset.Broken;

            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }

            return Created(new Uri(Request.GetEncodedUrl() + "/" + newAsset.Id), newAsset);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetById(int id)
        {
            var asset = await _unityOfWorkTest.assetRepository.FindById(id);
            return Ok(asset);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Asset>> Update(int id, CREATEAssetDTO assetDTO)
        {
            var getAsset = await _unityOfWorkTest.assetRepository.FindById(id);
            //var updatedAsset = Helper.SetValuesUpdate(getAsset);

            //TODO: create function to mapper assetDTO
            getAsset.AssetName = assetDTO.AssetName;
            getAsset.Department = assetDTO.Department;
            getAsset.CountryOfDepartment = assetDTO.CountryOfDepartment;
            getAsset.EmailAdressOfDepartment = assetDTO.EmailAdressOfDepartment;
            getAsset.PurchaseDate = assetDTO.PurchaseDate;
            getAsset.Broken = assetDTO.Broken;

            var editedAsset = new Asset();

            //TODO: create function to return asset
            //editedAsset.Id = getAsset.Id;
            //editedAsset.AssetName = getAsset.AssetName;
            //editedAsset.Department = getAsset.Department;
            //editedAsset.CountryOfDepartment = getAsset.CountryOfDepartment;
            //editedAsset.EmailAdressOfDepartment = getAsset.EmailAdressOfDepartment;
            //editedAsset.PurchaseDate = getAsset.PurchaseDate;
            //editedAsset.Broken = getAsset.Broken;

            _unityOfWorkTest.assetRepository.Edit(getAsset);
            _unityOfWorkTest.Commit();
            
            return Ok(getAsset);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var assetToDelete = await _unityOfWorkTest.assetRepository.FindById(id);
            _unityOfWorkTest.assetRepository.Remove(assetToDelete);
            _unityOfWorkTest.Commit();
            return Ok("Asset deleted successfully");
        }
    }
}

//#region Helper test

public class CREATEAssetDTO
{
    public string AssetName { get; set; }
    public Department Department { get; set; }
    public string CountryOfDepartment { get; set; }
    public string EmailAdressOfDepartment { get; set; }
    public DateTime PurchaseDate { get; set; }
    public bool Broken { get; set; }
}
public static class Helper
{
    public static Asset ConvertDtoToAsset(CREATEAssetDTO assetDTO)
    {
        var responseAsset = new Asset();

        responseAsset.AssetName = assetDTO.AssetName;
        responseAsset.Department = assetDTO.Department;
        responseAsset.CountryOfDepartment = assetDTO.CountryOfDepartment;
        responseAsset.EmailAdressOfDepartment = assetDTO.EmailAdressOfDepartment;
        responseAsset.PurchaseDate = assetDTO.PurchaseDate;
        responseAsset.Broken = assetDTO.Broken;

        return responseAsset;
    }

    public static Asset SetValuesUpdate(Asset asset)
    {
        var responseAsset = new Asset();

        responseAsset.AssetName = asset.AssetName;
        responseAsset.Department = asset.Department;
        responseAsset.CountryOfDepartment = asset.CountryOfDepartment;
        responseAsset.EmailAdressOfDepartment = asset.EmailAdressOfDepartment;
        responseAsset.PurchaseDate = asset.PurchaseDate;
        responseAsset.Broken = asset.Broken;

        return responseAsset;
    }
}
//#endregion



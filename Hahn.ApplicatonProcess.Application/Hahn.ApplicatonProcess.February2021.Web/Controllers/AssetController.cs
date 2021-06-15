using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly UnityOfWork _unityOfWork;
        //private readonly DatabaseContext _context;
        private readonly AssetRepository _assetRepository;

        public AssetController(UnityOfWork unityOfWork, AssetRepository assetRepository)
        {
            //_context = context;
            _assetRepository = assetRepository;
            _unityOfWork = unityOfWork;
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> Create(CREATEAssetDTO assetDTO)
        {
            var createdAsset = new Asset();

            try
            {
                Helper.ConvertDtoToAsset(assetDTO);
                await _assetRepository.Add(createdAsset);
                await _unityOfWork.Commit();
                //createdAsset.AssetName = asset.AssetName;
                //createdAsset.Department = asset.Department;
                //createdAsset.CountryOfDepartment = asset.CountryOfDepartment;
                //createdAsset.EmailAdressOfDepartment = asset.EmailAdressOfDepartment;
                //createdAsset.PurchaseDate = asset.PurchaseDate;
                //createdAsset.Broken = asset.Broken;
            }
            catch (Exception)
            {
                await _unityOfWork.Rollback();
            }
            
            return Created(new Uri(Request.GetEncodedUrl() + "/" + createdAsset.Id), createdAsset);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetById(int id)
        {
            var asset = await _assetRepository.FindById(id);
            return Ok(asset);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Asset>> Update(int id)
        {
            var getAsset = await _assetRepository.FindById(id);
            var updatedAsset = Helper.SetValuesUpdate(getAsset);
            await _unityOfWork.Commit();
            return Ok(updatedAsset);

            //assetToEdit.AssetName = getAsset.AssetName;
            //assetToEdit.Department = getAsset.Department;
            //assetToEdit.CountryOfDepartment = getAsset.CountryOfDepartment;
            //assetToEdit.EmailAdressOfDepartment = getAsset.EmailAdressOfDepartment;
            //assetToEdit.PurchaseDate = getAsset.PurchaseDate;
            //assetToEdit.Broken = getAsset.Broken;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var assetToDelete = await _assetRepository.FindById(id);
            _assetRepository.Remove(assetToDelete);
            await _unityOfWork.Commit();
            return Ok("Asset deleted successfully");
        }
    }
}


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



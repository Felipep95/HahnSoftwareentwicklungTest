using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Data.Context;
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
        private readonly DatabaseContext _context;
        
        public AssetController(UnityOfWork unityOfWork, DatabaseContext context)
        {
            _unityOfWork = unityOfWork;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Asset>> Create(Asset asset)
        {
            try
            {
                var newAsset = new Asset();//TODO: create dto

                newAsset.Id = asset.Id;
                newAsset.AssetName = asset.AssetName;
                newAsset.Department = asset.Department;
                newAsset.CountryOfDepartment = asset.CountryOfDepartment;
                newAsset.EmailAdressOfDepartment = asset.EmailAdressOfDepartment;
                newAsset.PurchaseDate = asset.PurchaseDate;
                newAsset.Broken = asset.Broken;

                await _unityOfWork.Assets.Add(newAsset);
                await _unityOfWork.Commit();

                return Created(new Uri(Request.GetEncodedUrl() + "/" + newAsset.Id), newAsset);
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
            return Ok(asset);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id)
        {
            var getAsset = await _unityOfWork.Assets.FindById(id);
            
            var assetToEdit = new Asset();
            
            assetToEdit.AssetName = getAsset.AssetName;
            assetToEdit.Department = getAsset.Department;
            assetToEdit.CountryOfDepartment = getAsset.CountryOfDepartment;
            assetToEdit.EmailAdressOfDepartment = getAsset.EmailAdressOfDepartment;
            assetToEdit.PurchaseDate = getAsset.PurchaseDate;
            assetToEdit.Broken = getAsset.Broken;

            _unityOfWork.Assets.Edit(assetToEdit);
            await _unityOfWork.Commit();

            return Ok(assetToEdit);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var assetToDelete = await _unityOfWork.Assets.FindById(id);
            _unityOfWork.Assets.Remove(assetToDelete);
            await _unityOfWork.Commit();
            return Ok("Asset deleted successfully");
        }

        [HttpGet]
        public async Task<ActionResult<Asset>> GetAll()
        {
            var assetList = await _context.Assets.ToListAsync();
            return Ok(assetList);
        }
    }
}

using Hahn.ApplicatonProcess.February2021.Domain.DTO;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Hahn.ApplicatonProcess.February2021.Domain.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/v1/asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _assetService;

        public AssetController(AssetService assetService)
        {
            _assetService = assetService;
        }

        /// <summary>
        ///  Create a new asset
        /// </summary>
        ///  <response code = "201">creates a new asset</response>
        ///  <response code = "400">unable to create the asset due to validation error</response>
        [HttpPost]
        public async Task<ActionResult> Create(CREATEAssetDTO assetDTO)
        {
            var newAsset = await _assetService.Create(assetDTO);
            return Created(new Uri(Request.GetEncodedUrl() + "/" + newAsset.Id), newAsset);
        }

        /// <summary>
        ///  Return the asset with the id specified as parameter
        /// </summary>
        ///  <response code = "200">success getting an asset by id</response>
        ///  <response code = "400">asset with specified id does not exist</response> 

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetById(int id)
        {
            var asset = await _assetService.FindById(id);

            if (asset == null)
                return NotFound($"Error: asset with id {id} not found");

            return asset;
        }

        /// <summary>
        ///  Get the asset by id specified as parameter and update the data
        /// </summary>
        ///  <response code = "200">success getting an asset by id</response>
        ///  <response code = "400">asset with specified id does not exist</response> 
        [HttpPut("{id}")]
        public async Task<ActionResult<Asset>> Update(int id, CREATEAssetDTO assetDTO)
        {
            var asset = await _assetService.FindById(id);

            if (asset == null)
                return NotFound($"Error: asset with id {id} not found");

            return await _assetService.Update(id, assetDTO);
        }

        /// <summary>
        ///  Get the asset by id specified as parameter and delete the data
        /// </summary>
        ///  <response code = "200">success getting an asset by id</response>
        ///  <response code = "400">asset with specified id does not exist</response> 
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var asset = await _assetService.FindById(id);

            if (asset == null)
                return NotFound($"Error: asset with id {id} not found");
            
            await _assetService.Delete(id);
            
            return Ok("Asset deleted successfully");
        }
    }
}

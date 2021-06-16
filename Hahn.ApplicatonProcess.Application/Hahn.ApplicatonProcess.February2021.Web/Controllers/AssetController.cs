using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Domain.DTO;
using Hahn.ApplicatonProcess.February2021.Domain.Mapper;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Hahn.ApplicatonProcess.February2021.Domain.Services;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/asset")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly AssetService _assetService;
        
        public AssetController(AssetService assetService)
        {
           _assetService = assetService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CREATEAssetDTO assetDTO)
        {
            var newAsset = await _assetService.Create(assetDTO);
            return Created(new Uri(Request.GetEncodedUrl() + "/" + newAsset.Id), newAsset);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Asset>> GetById(int id)
        {
            return await _assetService.FindById(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Asset>> Update(int id, CREATEAssetDTO assetDTO)
        {
            return await _assetService.Update(id, assetDTO);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _assetService.Delete(id);
            return Ok("Asset deleted successfully");
        }
    }
}

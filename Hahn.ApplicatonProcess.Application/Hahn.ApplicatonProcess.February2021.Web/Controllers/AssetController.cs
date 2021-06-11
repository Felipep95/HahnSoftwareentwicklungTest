using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Data.Repository;
using Hahn.ApplicatonProcess.February2021.Domain.Models;


namespace Hahn.ApplicatonProcess.February2021.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly UnityOfWork _unityOfWork;
        private readonly AssetRepository _assetRepository;

        public AssetController(UnityOfWork unityOfWork, AssetRepository assetRepository)
        {
            _unityOfWork = unityOfWork;
            _assetRepository = assetRepository;
        }

        public async Task<ActionResult<Asset>> GetAll()
        {
            return (Asset) await _assetRepository.FindAll();
        }

        public async Task<ActionResult<Asset>> GetById(int id)
        {
            return await _assetRepository.FindById(id);
        }
    }
}

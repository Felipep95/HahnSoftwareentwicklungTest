using System;
using System.Data;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.February2021.Data;
using Hahn.ApplicatonProcess.February2021.Domain.DTO;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Mapper;
using Hahn.ApplicatonProcess.February2021.Domain.Models;


namespace Hahn.ApplicatonProcess.February2021.Domain.Services
{
    public class AssetService
    {
        private UnityOfWork _unityOfWork;

        public AssetService(UnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<Asset> Create(CREATEAssetDTO assetDTO)
        {
            var newAsset = AssetMapping.ToEntity(assetDTO);

            try
            {
                await _unityOfWork.assetRepository.AddAsync(newAsset);
                await _unityOfWork.Commit();
            }
            catch (DataException)
            {
                throw new Exception();
            }

            return newAsset;
        }

        public async Task<Asset> FindById(int id)
        {
            return await _unityOfWork.assetRepository.FindByIdAsync(id);
        }

        public async Task<Asset> Update(int id, CREATEAssetDTO assetDTO)
        {
            var assetToEdit = await _unityOfWork.assetRepository.FindByIdAsync(id) ?? throw new Exception();

            assetToEdit.AssetName = assetDTO.AssetName;
            assetToEdit.Department = assetDTO.Department;
            assetToEdit.CountryOfDepartment = assetDTO.CountryOfDepartment;
            assetToEdit.EmailAdressOfDepartment = assetDTO.EmailAdressOfDepartment;
            assetToEdit.PurchaseDate = assetDTO.PurchaseDate;
            assetToEdit.Broken = assetDTO.Broken;

            _unityOfWork.assetRepository.Edit(assetToEdit);
            await _unityOfWork.Commit();

            return assetToEdit;
        }

        public async Task Delete(int id)
        {
            var assetTodelete = await _unityOfWork.assetRepository.FindByIdAsync(id);
            _ = assetTodelete ?? throw new Exception();
            _unityOfWork.assetRepository.Remove(assetTodelete);
            await _unityOfWork.Commit();
        }

        public string GetEnumValue(Department department)
        {
            var enumValue = department.ToString();
            return enumValue;
        }
    }
}



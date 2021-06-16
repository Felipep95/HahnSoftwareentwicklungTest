using Hahn.ApplicatonProcess.February2021.Domain.DTO;
using Hahn.ApplicatonProcess.February2021.Domain.Models;

namespace Hahn.ApplicatonProcess.February2021.Domain.Mapper
{
    public class AssetMapping
    {
        public static Asset ToEntity(CREATEAssetDTO assetDTO)
        {
            var asset = new Asset();

            asset.AssetName = assetDTO.AssetName;
            asset.Department = assetDTO.Department;
            asset.CountryOfDepartment = assetDTO.CountryOfDepartment;
            asset.EmailAdressOfDepartment = assetDTO.EmailAdressOfDepartment;
            asset.PurchaseDate = assetDTO.PurchaseDate;
            asset.Broken = assetDTO.Broken;

            return asset;
        }

        public static CREATEAssetDTO ToDto(Asset asset)
        {
            var assetDTO = new CREATEAssetDTO();

            assetDTO.AssetName = asset.AssetName;
            assetDTO.Department = asset.Department;
            assetDTO.CountryOfDepartment = asset.CountryOfDepartment;
            assetDTO.EmailAdressOfDepartment = asset.EmailAdressOfDepartment;
            assetDTO.PurchaseDate = asset.PurchaseDate;
            assetDTO.Broken = asset.Broken;

            return assetDTO;
        }
    }
}

using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using System;

namespace Hahn.ApplicatonProcess.February2021.Domain.DTO
{
    public class CREATEAssetDTO
    {
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EmailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }
    }
}

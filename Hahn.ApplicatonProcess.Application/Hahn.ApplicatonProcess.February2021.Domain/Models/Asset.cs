using System;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;

namespace Hahn.ApplicatonProcess.February2021.Domain.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EmailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool Broken { get; set; }


        public Asset()
        {

        }

        public Asset(int id, string assetName, Department department, string countrOfDepartment, string emailAdressDepartment, DateTime purchaseDate, bool broken)
        {
            Id = id;
            AssetName = assetName;
            Department = department;
            CountryOfDepartment = countrOfDepartment;
            EmailAdressOfDepartment = emailAdressDepartment;
            PurchaseDate = purchaseDate;
            Broken = broken;
        }
    }
}

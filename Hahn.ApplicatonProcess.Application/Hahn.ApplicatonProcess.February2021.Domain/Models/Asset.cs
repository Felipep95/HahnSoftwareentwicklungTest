using System;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;

namespace Hahn.ApplicatonProcess.February2021.Domain.Models
{
    public class Asset
    {
        public int ID { get; set; }
        public string AssetName { get; set; }
        public Department Department { get; set; }
        public string CountryOfDepartment { get; set; }
        public string EMailAdressOfDepartment { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool broken { get; set; }


        //public Asset()
        //{

        //}

        //public Asset(int id, string assetName, Department department, string countrOfDepartment, string emailAdressDepartment, DateTime purchaseDate, bool broken)
        //{
        //    ID = id;
        //    AssetName = assetName;
        //    Department = department;
        //    CountryOfDepartment = countrOfDepartment;
        //    EMailAdressOfDepartment = emailAdressDepartment;
        //    PurchaseDate = purchaseDate;
        //    broken = brokenn;
        //}
    }
}

using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace Hahn.ApplicatonProcess.February2021.Web.Services
{
    public class AssetResponseExample : IExamplesProvider<Asset>
    {
        Asset IExamplesProvider<Asset>.GetExamples()
        {
            return new Asset
            {
                Id = 1,
                AssetName = "Some Asset Name",
                Department = Department.HQ,
                CountryOfDepartment = "Germany",
                EmailAdressOfDepartment = "somevalidemail@email.com",
                PurchaseDate = DateTime.UtcNow,
                Broken = false
            };
        }
    }
}
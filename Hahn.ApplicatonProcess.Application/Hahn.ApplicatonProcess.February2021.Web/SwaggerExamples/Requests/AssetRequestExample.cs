using Hahn.ApplicatonProcess.February2021.Domain.DTO;
using Hahn.ApplicatonProcess.February2021.Domain.Enums;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace Hahn.ApplicatonProcess.February2021.Web.SwaggerExamples.Requests
{
    public class AssetRequestExample : IExamplesProvider<CREATEAssetDTO>
    {
        public CREATEAssetDTO GetExamples()
        {
            return new CREATEAssetDTO
            {
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
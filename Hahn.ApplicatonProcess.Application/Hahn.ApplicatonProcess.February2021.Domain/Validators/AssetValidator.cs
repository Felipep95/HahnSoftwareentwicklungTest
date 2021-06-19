using FluentValidation;
using Hahn.ApplicatonProcess.February2021.Domain.DTO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<CREATEAssetDTO>
    {
        HttpClient client = new HttpClient();
        
        public AssetValidator()
        {
            RuleFor(x => x.AssetName).NotNull().NotEmpty().MinimumLength(5).WithMessage("name need at least 5 Characters");
            RuleFor(x => x.Department).NotNull().NotEmpty().IsInEnum().WithMessage("department must be a valid enumvalue");
            RuleFor(x => x.PurchaseDate).NotNull().NotEmpty().GreaterThan(DateTime.Now.AddYears(-1)).WithMessage("purchase date must not be older then one year");
            RuleFor(x => x.EmailAdressOfDepartment).NotNull().NotEmpty().EmailAddress().WithMessage("email must be an valid email");
            RuleFor(x => x.Broken).NotNull().NotEmpty();

            RuleFor(x => x.CountryOfDepartment).NotNull().NotEmpty().MustAsync(
                async (CountryOfDepartment, cancellation) =>
                {
                    var uri = "https://restcountries.eu";
                    var parameterName = "/rest/v2/name/";
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await client.GetAsync($"{parameterName}{CountryOfDepartment}");

                    return response.IsSuccessStatusCode ? true : false;
                }
                ).WithMessage("invalid country name");
        }
    }
}

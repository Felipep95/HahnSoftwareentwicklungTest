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
    public class CreateAssetValidator : AbstractValidator<CREATEAssetDTO>
    {
        HttpClient client = new HttpClient();
        
        public CreateAssetValidator()
        {
            RuleFor(x => x.AssetName).MinimumLength(5).WithMessage("at least 5 Characters");
            RuleFor(x => x.Department).IsInEnum().WithMessage("must be a valid enumvalue");
            RuleFor(x => x.PurchaseDate).Must(ValidateDate).WithMessage("must not be older then one year");
            RuleFor(x => x.EmailAdressOfDepartment).EmailAddress().WithMessage("must be an valid email");
            RuleFor(x => x.Broken).NotNull();

            RuleFor(x => x.CountryOfDepartment).MustAsync(
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

        public bool ValidateDate(DateTime date) => date >= DateTime.Now.AddYears(-1) ? true : false;
    }
}

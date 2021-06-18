using FluentValidation;
using Hahn.ApplicatonProcess.February2021.Domain.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Domain.Validators
{
    public class CreateAssetValidator : AbstractValidator<CREATEAssetDTO>
    {
        

        public CreateAssetValidator()
        {
            RuleFor(x => x.AssetName).MinimumLength(5).WithMessage("at least 5 Characters");
            RuleFor(x => x.Department).IsInEnum().WithMessage("must be a valid enumvalue");
            //TODO: create RuleFor to validate CountryOfDepartament, note that need to get country list from this api https://restcountries.eu/rest/v2, and if exist country, then validate ok
            RuleFor(x => x.PurchaseDate).Must(ValidateDate).WithMessage("must not be older then one year");
            RuleFor(x => x.EmailAdressOfDepartment).EmailAddress().WithMessage("must be an valid email");
            RuleFor(x => x.Broken).NotNull();//TODO: review validate in doc... if provided should not be null
        }

        public bool ValidateDate(DateTime date) => date >= DateTime.Now.AddYears(-1) ? true : false;

        HttpClient httpClient = new HttpClient();

        public async Task GetCountryList(string country)
        {
            var countryList = new List<Stream>();

            try
            {
                string url = "https://restcountries.eu/rest/v2/all?fields=name;";
                var response = await httpClient.GetStreamAsync(url);
                countryList.Add(response);
            }
            catch (Exception)
            {
                throw;
            }

            HttpResponseMessage checkCountry = await httpClient.GetAsync(country);

        }

    }
}

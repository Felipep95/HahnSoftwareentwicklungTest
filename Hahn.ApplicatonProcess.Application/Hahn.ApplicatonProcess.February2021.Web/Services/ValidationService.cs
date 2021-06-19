using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Web.Services
{
    public class ValidationService
    {
        HttpClient client = new HttpClient();

        public async Task<bool> ValidateCountry(string name)
        {
            var uri = "https://restcountries.eu/rest/v2/name";

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync($"/{name}");

            return response.IsSuccessStatusCode ? true : false;
        }
    }
}

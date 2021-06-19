using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Hahn.ApplicatonProcess.February2021.Data.HttpDataAccess
{
    public class MyHttpContext
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

        public MyHttpContext()
        {

        }

        //HttpClient client = new HttpClient();

        //public async Task<bool> GetCountry(string name)
        //{
        //    var uri = "https://restcountries.eu/rest/v2/name";

        //    client.BaseAddress = new Uri(uri);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    var response = await client.GetAsync($"/{name}");

        //    return response.IsSuccessStatusCode ? true : false;

        //    var uri = "https://restcountries.eu/rest/v2/";
        //    var countryFilter = "all?fields=name";

        //    client.BaseAddress = new Uri(uri);
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var response = await client.GetAsync(countryFilter);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var countries = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<List<string>>(countries);
        //    }

        //    return new List<string>();
        //}
    }
}

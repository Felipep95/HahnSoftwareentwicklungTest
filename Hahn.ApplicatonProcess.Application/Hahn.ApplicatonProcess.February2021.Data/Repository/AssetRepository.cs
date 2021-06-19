using Hahn.ApplicatonProcess.February2021.Data.Context;
using Hahn.ApplicatonProcess.February2021.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.February2021.Data.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly DatabaseContext _context = new DatabaseContext();
        HttpClient client = new HttpClient();

        public AssetRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
        }

        public async Task<Asset> FindByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public void Edit(Asset asset)
        {
            _context.Assets.Update(asset);
        }

        public void Remove(Asset asset)
        {
            _context.Assets.Remove(asset);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<List<string>> GetCountryList()
        {
            var uri = "https://restcountries.eu/rest/v2/";
            var countryFilter = "all?fields=name";

            client.BaseAddress = new Uri(uri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync(countryFilter);

            if (response.IsSuccessStatusCode)
            {
                var countries = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<string>>(countries);
            }

            return new List<string>();
        }
    }
}
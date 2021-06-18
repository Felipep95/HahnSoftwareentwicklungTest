//using System;
//using System.IO;
//using System.Net.Http;
//using System.Threading.Tasks;


//namespace Hahn.ApplicatonProcess.February2021.Data.HttpDataAccess
//{
//    public class MyHttpContext
//    {
//        HttpClient httpClient = new HttpClient();

//        public async Task<Stream> GetCountryList()
//        {
//            Stream countryList;

//            try
//            {
//                string url = "https://restcountries.eu/rest/v2/all?fields=name;";
//                var response = await httpClient.GetStreamAsync(url);
//                countryList = response;
//            }
//            catch (Exception)
//            {
//                throw;
//            }

//            return countryList;
//        }
//    }
//}

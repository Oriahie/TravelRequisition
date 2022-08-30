using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRequisition.Core.Interface.Services;
using TravelRequisition.Core.Models;

namespace TravelRequisition.Infrastructure.Services
{
    public class CountryService : ICountryService
    {
        public async Task<CountryModel> GetByName(string name)
        {
            using HttpClient _httpClient = new HttpClient();
            var url = $"https://restcountries.com/v2/name/{name}";
            var result = await _httpClient.GetAsync(url);
            var res = await result.Content.ReadAsStringAsync();
            var resval = JsonConvert.DeserializeObject<List<CountryModel>>(res);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception($"{name.ToUpper()} Not Found");
            }
            return resval.First();
        }
    }
}

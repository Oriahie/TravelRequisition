using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRequisition.Core.Interface.Services;
using TravelRequisition.Core.Models;

namespace TravelRequisition.Infrastructure.Services
{
    public class WeatherService : IWeatherService
    {

        public async Task<WeatherModel> GetWeather(double lat, double lng)
        {
            using HttpClient _httpClient = new HttpClient();
            var url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lng}&appid=2a409c92893f00c305907041408c1e9f";
            var result = await _httpClient.GetAsync(url);
            var res = await result.Content.ReadAsStringAsync();
            var resval = JsonConvert.DeserializeObject<WeatherModel>(res);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception($"Location Not Found");
            }
            return resval;
        }
    }
}

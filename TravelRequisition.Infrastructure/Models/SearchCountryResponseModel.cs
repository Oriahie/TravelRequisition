using System;
using System.Collections.Generic;
using System.Text;
using TravelRequisition.Core.Models;

namespace TravelRequisition.Infrastructure.Models
{
    public class SearchCountryResponseModel
    {
        public CountryModel CountryInfo { get; set; }
        public WeatherModel WeatherInfo { get; set; }
    }
}

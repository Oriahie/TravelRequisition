using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRequisition.Core.Models
{
    public class CountryModel
    {
        public string name { get; set; }
        public string capital { get; set; }
        public string subregion { get; set; }
        public string region { get; set; }
        public int population { get; set; }
        public List<Currency> currencies { get; set; }
        public List<double> latlng { get; set; }
    }

    public class Currency
    {
        public string code { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }

}


using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelRequisition.Core.Models;

namespace TravelRequisition.Core.Interface.Services
{
    public interface ICountryService
    {
        Task<CountryModel> GetByName(string name);
    }
}

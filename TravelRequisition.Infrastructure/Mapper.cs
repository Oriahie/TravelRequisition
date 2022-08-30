using System;
using System.Collections.Generic;
using System.Text;
using TravelRequisition.Core.Entities;
using TravelRequisition.Core.Models;
using TravelRequisition.Core.Utilities;
using TravelRequisition.Infrastructure.Models;

namespace TravelRequisition.Infrastructure
{
    public static class Mapper
    {
        public static TravelRequest Map(this TravelRequestModel model)
        {
            if (model == null)
                return null;

            return new TravelRequest
            {
                ChargeCode = model.ChargeCode,
                Country = model.Country,
                Destination = model.Destination,
                Name = model.Name,
                ProposedDeparture = model.ProposedDeparture,
                SourceCountry = model.SourceCountry,
                SourceLocation = model.SourceLocation,
                RequisitionStatus  = RequisitionStatus.Submitted,
                TravelClass = model.TravelClass,
                TripType = model.TripType,
                RequestDate = DateTime.Now
            };
        }


        public static SearchCountryResponseModel Map(this WeatherModel model, CountryModel country)
        {
            if (model == null)
                return null;

            return new SearchCountryResponseModel
            {
                CountryInfo = country,
                WeatherInfo = model
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TravelRequisition.Core.Utilities;

namespace TravelRequisition.Infrastructure.Models
{
    public class TravelRequestModel
    {
        [Required]
        public string SourceLocation { get; set; }
        [Required]
        public string SourceCountry { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public DateTime ProposedDeparture { get; set; }
        [Required]
        public TravelClass TravelClass { get; set; }
        [Required]
        public TripType TripType { get; set; }
        [Required]
        public string ChargeCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

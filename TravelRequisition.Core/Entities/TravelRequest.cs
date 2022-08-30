using System;
using System.Collections.Generic;
using System.Text;
using TravelRequisition.Core.Utilities;

namespace TravelRequisition.Core.Entities
{
    public class TravelRequest
    {
        public long Id { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
        public string SourceLocation { get; set; }
        public string SourceCountry { get; set; }
        public string Destination { get; set; }
        public string Country { get; set; }
        public DateTime ProposedDeparture { get; set; }
        public TravelClass TravelClass { get; set; }
        public TripType TripType { get; set; }
        public string ChargeCode { get; set; }
        public string Name { get; set; }
        public RequisitionStatus RequisitionStatus { get; set; }
        public long RequisitionNumber { get; set; }

    }
}

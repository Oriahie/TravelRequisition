using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRequisition.Core.Utilities
{
    public enum TravelClass
    {
        Economy, 
        Business, 
        First_Class
    }

    public enum TripType
    {
        One_Way,
        Round_Trip
    }

    public enum RequisitionStatus
    {
        Submitted, 
        Approved, 
        Booked, 
        Canceled
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models.ViewModels
{
    public class EventVenueDropDownViewModel
    {
        public int EventVenueId { get; set; }
        public IEnumerable<EventVenue> EventVenues { get; set; }
    }
}
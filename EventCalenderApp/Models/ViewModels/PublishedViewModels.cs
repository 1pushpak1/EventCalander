using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models.ViewModels
{
    public class PublishedViewModels
    {
        public int EventId { get; set; }
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }
        public int? EventTypeId { get; set; }
        [Display(Name = "Event Type")]
        public string EventTypeName { get; set; }
        public int? EventVenueId { get; set; }
        [Display(Name = "Event Venue")]
        public string EventVenueName { get; set; }
        [Display(Name = "Start Time")]
        public DateTime EventStartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime EventEndTime { get; set; }
        [Display(Name = "Booking Time")]
        public DateTime EventMaxBookingTime { get; set; }

    }
}
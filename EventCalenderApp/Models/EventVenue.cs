using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models
{
    public class EventVenue
    {
        [Key]
        public int EventVenueId { get; set; }
        public string EventVenueName { get; set; }
    }
}
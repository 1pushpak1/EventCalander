using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models
{
    public class EventDetail
    {
        [Key]
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventStarTime { get; set; }
        public DateTime EventEndTime { get; set; }
        public DateTime EventMaxBookingTime { get; set; }
        [ForeignKey("EventType")]
        public int? EventTypeId { get; set; }
        public EventType EventType { get; set; }
        [ForeignKey("EventVenue")]
        public int? EventVenueId { get; set; }
        public EventVenue EventVenue { get; set; }
        public bool IsPublished { get; set; }
        public bool IsDeleted { get; set; }
    }
}
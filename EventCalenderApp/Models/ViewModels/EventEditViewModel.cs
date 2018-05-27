using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EventCalenderApp.Models.ViewModels;

namespace EventCalenderApp.Models.ViewModels
{
    public class EventEditViewModel
    {
        public int EventId { get; set; }
        [Required]
        [MaxLength(1000)]
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime EventStarTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EventEndTime { get; set; }

        [Required]
        [Display(Name = "Booking Time")]
        public DateTime EventMaxBookingTime { get; set; }
        
        public int? EventTypeId { get; set; }
        
        public int? EventVenueId { get; set; }

        [Display(Name = "Event Type")]
        public EventTypeDropDownViewModel EventTypeDropDownVm { get; set; }

        [Display(Name = "Event Venue")]
        public EventVenueDropDownViewModel EventVenueDropDownVm { get; set; }
        [Display(Name = "Publish")]
        public bool IsPublished { get; set; }

        public bool IsDeleted { get; set; }

    }
}
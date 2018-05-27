using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EventCalenderApp.Models.ViewModels
{
    public class EventDeleteViewModel
    {
        [Required]
        public int EventId { get; set; }

        [Display(Name = "Type")]
        public string EventTypeName { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string EventTitle { get; set; }

        [Display(Name = "Venue")]
        public string EventVenueName { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime? EventStartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime? EventEndTime { get; set; }

        [Required]
        [Display(Name = "Max Booking Time")]
        public DateTime? EventMaxBookingTime { get; set; }

        public Boolean IsPublished { get; set; }

        [Display(Name = "Is Published")]
        public string IsPublishedText => IsPublished ? "Yes" : "No";

        public bool IsDeleted { get; set; }

    }
}